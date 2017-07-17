using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMiner
{
    public class Sentence
    {
        public List<Word> Words { get; set; }

        public Sentence() { Words = new List<Word>(); }
    }
}
