using FuzzySharp;            // instalar NuGet FuzzySharp
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Text;
using ClasificadorComents.Data;
using ClasificadorComents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;

namespace ClasificadorComents.Services
{
    public class FaqProcessService
    {
        private readonly MLContext _mlContext;
        private readonly ITransformer _transformer;
        private readonly List<FaqProcess> _processes;
        private readonly List<float[]> _vectors;

        public FaqProcessService()
        {
            _mlContext = new MLContext();
            _processes = FaqProcessRepository.GetAll();

            // Prepara TF-IDF (igual que antes)
            var embedData = _processes
                .Select(p => new DocToEmbed
                {
                    Text = string.Join(" ",
                        p.Title, p.Intro,
                        string.Join(" ", p.Steps.Select(s => s.Text)))
                })
                .ToList();

            var dv = _mlContext.Data.LoadFromEnumerable(embedData);
            var pipeline = _mlContext.Transforms.Text
                .NormalizeText("NormalizedText", nameof(DocToEmbed.Text))
                .Append(_mlContext.Transforms.Text.FeaturizeText(
                    outputColumnName: "Features",
                    inputColumnName: "NormalizedText"));

            _transformer = pipeline.Fit(dv);
            _vectors = _transformer
                .Transform(dv)
                .GetColumn<float[]>("Features")
                .ToList();
        }

        private class DocToEmbed { public string Text { get; set; } }

        private static float Cosine(float[] a, float[] b)
        {
            float dot = 0, magA = 0, magB = 0;
            for (int i = 0; i < a.Length; i++)
            {
                dot += a[i] * b[i];
                magA += a[i] * a[i];
                magB += b[i] * b[i];
            }
            return dot / (float)(Math.Sqrt(magA) * Math.Sqrt(magB) + 1e-6);
        }


public FaqProcess BuscarProceso(string pregunta,
                               int umbralFuzzy = 60,
                               float umbralTfIdf = 0.5f)
    {
        // 1) Normalizar: minúsculas, sin tildes, sin signos
        static string Normalize(string text)
        {
            var formD = text.Normalize(NormalizationForm.FormD);
            var sb = new System.Text.StringBuilder();
            foreach (var ch in formD)
            {
                var cat = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (cat != UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);
            }
            return sb.ToString()
                     .ToLowerInvariant()
                     .Replace("¿", "")
                     .Replace("?", "")
                     .Trim();
        }

        var cleanPregunta = Normalize(pregunta);

        // 2) Capa fuzzy con WeightedRatio
        int bestFzScore = 0;
        FaqProcess bestFz = null;
        foreach (var proc in _processes)
        {
            var titleNorm = Normalize(proc.Title);
            int score = Fuzz.WeightedRatio(titleNorm, cleanPregunta);
            Console.WriteLine($"[Fuzzy] {score}% vs '{proc.Title}'");
            if (score > bestFzScore)
            {
                bestFzScore = score;
                bestFz = proc;
            }
        }

        if (bestFzScore >= umbralFuzzy)
        {
            Console.WriteLine($"→ Acepto por Fuzzy {bestFzScore}%: '{bestFz.Title}'");
            return bestFz;
        }

        // 3) Fallback TF-

        // --- 3) Fallback TF-IDF ---
        // transforma la pregunta
        var singleDv = _mlContext.Data.LoadFromEnumerable(
                                new[] { new DocToEmbed { Text = pregunta } });
            var trUser = _transformer.Transform(singleDv);
            var userVector = trUser.GetColumn<float[]>("Features").First();

            // calcula similitud coseno contra todos
            float bestTfScore = float.MinValue;
            int bestTfIdx = -1;
            for (int i = 0; i < _vectors.Count; i++)
            {
                var s = Cosine(userVector, _vectors[i]);
                Console.WriteLine($"[TF-IDF]{s:F4} vs '{_processes[i].Title}'");
                if (s > bestTfScore)
                {
                    bestTfScore = s;
                    bestTfIdx = i;
                }
            }
            Console.WriteLine($"→ Mejor TF-IDF: '{_processes[bestTfIdx].Title}' {bestTfScore:F4}");

            return (bestTfIdx >= 0 && bestTfScore >= umbralTfIdf)
                ? _processes[bestTfIdx]
                : null;
        }
    }
}
