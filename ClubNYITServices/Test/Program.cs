using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMiner;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IList<string> skills = new List<string>();
            skills.Add("Java");
            skills.Add("CSharp");
            skills.Add("sql");
            skills.Add(".Net");
            skills.Add("Oracle");

            IList<ClubClass> clubs = new List<ClubClass>();
            ClubClass c1 = new ClubClass
            {
                ClubID = 1,
                ClubName = "Virtual Oracle User Group",
                ClubDescription = "Do you not live near a Java User Group? Would you like to hear what other Java User Groups talk about? Do you love JUG sessions but yearn for more of them? The vJUG is virtual, so if you live on the planet Earth you can join. Actually even if you don't you can still join! Our aim is to get the greatest minds and speakers of the Java industry giving talks and presentations for this community, in the form of webinars and JUG session streaming from JUG f2f meetups. If you're a Java enthusiast and you want to learn more about Java and surrounding technologies, join and see what we have to offer!"

            };
            ClubClass c4 = new ClubClass
            {
                ClubID = 4,
                ClubName = "Virtual Oracle User Group",
                ClubDescription = "Do you not live near a Java User Group? Would you like to hear what other Java User Groups talk about? Do you love JUG sessions but yearn for more of them? The vJUG is virtual, so if you live on the planet Earth you can join. Actually even if you don't you can still join! Our aim is to get the greatest minds and speakers of the industry giving talks and presentations for this community, in the form of webinars and JUG session streaming from JUG f2f meetups. If you're a Java enthusiast and you want to learn more about Java and surrounding technologies, join and see what we have to offer!"

            };

            ClubClass c2 = new ClubClass
            {
                ClubID = 2,
                ClubName = ".Net Coders",
                ClubDescription = "NET Coders is a group of free studies located in São Paulo and is currently one of the largest and most active groups world.The main focus of the group is to promote networking and disseminate knowledge in software , platforms , technologies and programming languages ​​. despite our influence be Microsoft ( .NET Framework ) , we addressed several other issues such as Mean , Javascript, Angle, JQuery, Tizen , Phonegap , Xamarin , Web Standards , Android , iOS , Java, Python, Redis , Architecture and Best Practices"

            };

            ClubClass c3 = new ClubClass
            {
                ClubID = 3,
                ClubName = "London SQL Server User Group",
                ClubDescription = "UK SQL Server User Group based in the London area aimed at enthusiasts looking to learn more about all things SQL Server related.Networklearn,ask a question,meet other folk,get fed - these are all things that happen at user group events.These events are a really great opportunity to socialise in an informal learning experience.We are PASS Affialiated Chapter we have a website  the events listed Being a Member of PASS which is FREE and offers a number of benefits, including online videos of previous events including Summits & 24HOP as well as the PASS Virutal chapters which provide regular online events covering a large range of topics"

            };

            clubs.Add(c1);
            clubs.Add(c2);
            clubs.Add(c3);
            clubs.Add(c4);

            IList<KeywordWeightage> keywordWeightage = new List<KeywordWeightage>();
            KeywordWeightage kw = null;
            IList<Title> title = null;
            IList<Title> desc = null;
            foreach (var c in clubs)
            {
                kw = new KeywordWeightage();
                kw.DescKeyword = new HashSet<string>();
                kw.TitleKeyword = new HashSet<string>();
                kw.AllKeyword = new HashSet<string>();
                kw.DescWeightedAverage = 0.0;
                kw.TitleWeightedAverage = 0.0;
                kw.TotalWeightedAverage = 0.0;
                title = KeywordMiner.Extract(c.ClubName).ToList<Title>();
                 desc = KeywordMiner.Extract(c.ClubDescription).ToList<Title>();
                foreach (var item in title)
                {
                    kw.TitleKeyword.Add(item.Text);
                    kw.AllKeyword.Add(item.Text);
                }
                kw.TitleKeywordCount = kw.TitleKeyword.Count();
                foreach (var item in desc)
                {
                    kw.DescKeyword.Add(item.Text);
                    kw.AllKeyword.Add(item.Text);
                }
                kw.DescKeywordCount = kw.DescKeyword.Count();
                kw.ClubID = c.ClubID;
                keywordWeightage.Add(kw);
            }

            SkillsPreprocessor spp = new SkillsPreprocessor();
            SkillWeightage sw= spp.WeighSkills(skills);
            IList<KeywordWeightage> keywordWeightageP = new List<KeywordWeightage>();
            KeywordWeightage kwP = null;
            foreach (var item in keywordWeightage)
            {
                kwP = spp.WeighKeywords(item, sw);
                
                keywordWeightageP.Add(kwP);
            }

            keywordWeightageP = spp.OrderClubs(keywordWeightageP);

            foreach (var item in keywordWeightageP)
            {
                Console.WriteLine("ClubID");
                Console.WriteLine(item.ClubID);
                Console.WriteLine(item.TitleKeywordCount);
                Console.WriteLine(item.TitleWeightedAverage);
                //foreach (var item1 in item.TitleKeyword)
                //{
                //    Console.WriteLine(item1);

                //}
                Console.WriteLine(item.DescKeywordCount);
                Console.WriteLine(item.DescWeightedAverage);
                //foreach (var item2 in item.DescKeyword)
                //{
                //    Console.WriteLine(item2);

                //}
                Console.WriteLine(item.TotalWeightedAverage);
                //foreach (var item3 in item.AllKeyword)
                //{
                //    Console.WriteLine(item3);

                //}

            }
                Console.ReadLine();
        }
    }
}
