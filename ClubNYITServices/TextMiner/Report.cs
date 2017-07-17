using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMiner
{
    public class Report
    {
        
		public string Content { get; set; }
        public int WordCount { get; set; }
        public IEnumerable<Keyword> Keywords { get; set; }
        public List<Paragraph> Paragraphs { get; set; }
        public IEnumerable<Title> Titles { get; set; }
    }

}
