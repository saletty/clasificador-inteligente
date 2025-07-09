using System.Collections.Generic;

namespace ClasificadorComents.Models
{
    public class FaqProcess
    {
        public string Title { get; set; }
        public string Intro { get; set; }
        public List<ProcessStep> Steps { get; set; }
    }
}

