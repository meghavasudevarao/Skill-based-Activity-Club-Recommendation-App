using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextMiner
{
    public static class KeywordMiner
    {
        public static IEnumerable<Title> Extract(string content)
        {
            Dictionary<string, int> titles = new Dictionary<string, int>();
            MatchCollection mc = regtitle.Matches(content);
            foreach (Match m in mc)
            {
                if (!titles.ContainsKey(m.Value)) titles.Add(m.Value, 0);
                titles[m.Value]++;
            }
            
            MatchCollection mp = Captitle1.Matches(content);
            foreach (Match m in mp)
            {
                if (!titles.ContainsKey(m.Value)) titles.Add(m.Value, 0);
                titles[m.Value]++;
            }

            MatchCollection mk = Captitle2.Matches(content);
            foreach (Match m in mk)
            {
                if (!titles.ContainsKey(m.Value)) titles.Add(m.Value, 0);
                titles[m.Value]++;
            }
            MatchCollection msp = Sptitle.Matches(content);
            foreach (Match m in msp)
            {
                if (!titles.ContainsKey(m.Value)) titles.Add(m.Value, 0);
                titles[m.Value]++;
            }

            IEnumerable<Title> list = from n in titles select new Title { Text = n.Key, Count = n.Value };
            return list;
        }

        private static Regex regtitle = new Regex(@"(?<=(\s|^))"
                                                             + @"[A-Z\.0-9][A-Za-z0-9]*?[\.\-]*[A-Za-z0-9]+?"
                                                             + @"((\s[a-z]{1,3}){0,2}\s[A-Z\.0-9][A-Za-z0-9]*?[\.\-]*[A-Za-z0-9]+?){1,4}"
                                                             + @"(?=(\.|\?|!|\s|$))", (RegexOptions.Compiled | RegexOptions.Multiline));
        //PascalCase    "
        private static Regex Captitle1 = new Regex(@"(\b[^\Wa-z0-9_][^\WA-Z0-9_]*\b)", (RegexOptions.Compiled | RegexOptions.Multiline));

        private static Regex Captitle2 = new Regex(@"(\b[^\Wa-z0-9_]+\b)", (RegexOptions.Compiled | RegexOptions.Multiline));

        private static Regex Sptitle = new Regex(@"(^\.\w+)", (RegexOptions.Compiled | RegexOptions.Multiline));

    }
}
