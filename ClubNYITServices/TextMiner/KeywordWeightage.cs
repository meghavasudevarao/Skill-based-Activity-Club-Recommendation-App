using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMiner
{
    public class KeywordWeightage
    {
        public double TitleWeightedAverage { get; set; }
        public int TitleKeywordCount { get; set; }
        public double DescWeightedAverage { get; set; }
        public int DescKeywordCount { get; set; }
        public HashSet<string> TitleKeyword { get; set; }
        public HashSet<string> DescKeyword { get; set; }
        public HashSet<string> AllKeyword { get; set; }
        public double TotalWeightedAverage { get; set; }
        public double TotalWeight { get; set; }
        public long ClubID { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var property in this.GetType().GetProperties())
            {
                sb.Append(property.GetValue(this, null));
            }

            return sb.ToString();
        }
    }
}
