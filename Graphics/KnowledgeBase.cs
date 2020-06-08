using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    public class Rule
    {
        public Term PowerPS { get; set; }
        public Term Kilometer { get; set; }
        public Term Age { get; set; }
        public Term Price { get; set; }

        public int Reliability { get; set; }
    }

    public static class KnowledgeBase
    {
        public static List<Rule> Rules { get; set; }

        static KnowledgeBase()
        {
            Rules = new List<Rule>();
        }

        public static void AddOrConfirmRule(Term powersPS, Term kilometer, Term Age, Term Price)
        {
            var r = Rules.FirstOrDefault(s => s.PowerPS == powersPS && s.Kilometer == kilometer && s.Age == Age && s.Price == Price);
            if (r is null)
                Rules.Add(new Rule { PowerPS = powersPS, Kilometer = kilometer, Age = Age, Price = Price, Reliability = 1 });
            else
                r.Reliability++;
        }

        public static Term ForecastPrice(Term powerPS, Term kilometer, Term Age)
        {
            var rules = Rules.Where(r => r.Age == Age && r.Kilometer == kilometer && r.PowerPS == powerPS).ToArray();
            var topRule = rules.OrderBy(r=>r.Reliability).Last();
            return topRule.Price;
        }
    }
}
