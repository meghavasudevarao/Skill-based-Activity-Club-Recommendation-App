using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMiner
{
    public class Paragraph
    {
        public List<Sentence> Sentences { get; set; }

        public Paragraph() { Sentences = new List<Sentence>(); }
    }
}
