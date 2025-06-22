namespace ClasificadorComents.Utils
{
    public static class CosineSimilarity
    {
        public static double Calcular(List<float> a, List<float> b)
        {
            if (a.Count != b.Count)
                throw new ArgumentException("Los vectores deben tener la misma dimensión.");

            float dotProduct = 0f;
            float normA = 0f;
            float normB = 0f;

            for (int i = 0; i < a.Count; i++)
            {
                dotProduct += a[i] * b[i];
                normA += a[i] * a[i];
                normB += b[i] * b[i];
            }

            return dotProduct / (Math.Sqrt(normA) * Math.Sqrt(normB));
        }
    }
}
