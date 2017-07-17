using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMiner
{
    public class SkillsPreprocessor
    {
       
        public SkillWeightage WeighSkills(IList<string> skill)
        {
            #region Skills and corresponding weights
            var skillWeightage = new SkillWeightage();
            skillWeightage.skills = new Dictionary<string,double>();
            int skillcount = skill.Count();
            double weight = 0.0;
            double minWeight = 100.0 / skillcount;
            weight = 100.0;
            foreach (var s in skill)
            {
                skillWeightage.skills.Add(s,weight);
                weight = weight - minWeight;
            }
            Dictionary<string, double> myDictionary = new Dictionary<string,double>(skillWeightage.skills, StringComparer.OrdinalIgnoreCase);
            skillWeightage.skills.Clear();
            skillWeightage.skills = myDictionary;
            return skillWeightage;

            #endregion
        }


        public KeywordWeightage WeighKeywords(KeywordWeightage keywordWeightage, SkillWeightage skillWeightage)
        {
            #region WeightedAvg of Title KeyWords
            IList<string> strTitle = skillWeightage.skills.Keys.ToList().Intersect(keywordWeightage.TitleKeyword, StringComparer.OrdinalIgnoreCase).ToList<string>();
            keywordWeightage.TitleKeywordCount = strTitle.Count();
            foreach (var s in strTitle)
            {
                keywordWeightage.TitleWeightedAverage = keywordWeightage.TitleWeightedAverage + (skillWeightage.skills[s]);
                Console.WriteLine(s);
            }
            keywordWeightage.TitleWeightedAverage = keywordWeightage.TitleWeightedAverage / keywordWeightage.TitleKeywordCount;
            if (keywordWeightage.TitleKeywordCount ==0)
                keywordWeightage.TitleWeightedAverage = 0.0;
            #endregion

                #region WeightedAvg of Description KeyWords
            IList<string> strDesc = skillWeightage.skills.Keys.ToList().Intersect(keywordWeightage.DescKeyword, StringComparer.OrdinalIgnoreCase).ToList<string>();
            keywordWeightage.DescKeywordCount = strDesc.Count();
            foreach (var s in strDesc)
            {
                keywordWeightage.DescWeightedAverage = keywordWeightage.DescWeightedAverage + (skillWeightage.skills[s]);
                Console.WriteLine(s);
            }
            keywordWeightage.DescWeightedAverage = keywordWeightage.DescWeightedAverage / keywordWeightage.DescKeywordCount;
            if (keywordWeightage.DescKeywordCount == 0)
                keywordWeightage.DescWeightedAverage = 0.0;
            #endregion

            #region Total Weighted Average
            keywordWeightage.TotalWeightedAverage = (keywordWeightage.DescWeightedAverage + keywordWeightage.TitleWeightedAverage) / 2;
            #endregion
            keywordWeightage.TotalWeight = keywordWeightage.TitleWeightedAverage + keywordWeightage.DescWeightedAverage + keywordWeightage.TotalWeightedAverage;
            return keywordWeightage;
        }

        public IList<KeywordWeightage> OrderClubs(IList<KeywordWeightage> keywordWeightage)
        {
            //.ThenByDescending(m => m.TitleWeightedAverage).ThenByDescending(m => m.DescWeightedAverage).ToList<KeywordWeightage>()
            return keywordWeightage.AsQueryable().OrderByDescending(m => m.TotalWeight).ThenByDescending(m => m.DescWeightedAverage).ThenByDescending(m => m.TitleWeightedAverage).ThenByDescending(m => m.TotalWeightedAverage).ToList< KeywordWeightage>();

        }

    }
}
