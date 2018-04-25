using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Graphics
{
   
    public struct Interval
    {
        public int LeftBorder { get; set; }
        public int RightBorder { get; set; }
    }

    public enum Additions
    {
        VERY,NOT_VERY
    }

    public class LingVar
    {
        public string Name { get; set; }
        public Interval Interval { get; set; }
        public List<Term> Terms { get; set; }
        public Func<int, string> ActiveTerm => ((n) =>
        {
            Term aTerm = null;
            double maximum = -100;
            foreach (var term in Terms)
            {
                if (term.Function(n) > maximum)
                {
                    maximum = term.Function(n);
                    aTerm = term;
                }
            }
            return aTerm?.Name;
        });
        public Func<int, double> ActiveTermCoeff => ((n) =>
        {
            Term aTerm = null;
            double maximum = -100;
            foreach (var term in Terms)
            {
                if (term.Function(n) > maximum)
                {
                    maximum = term.Function(n);
                    aTerm = term;
                }
            }
            return maximum;
        });
        public LingVar()
        {
            Terms = new List<Term>();
           
            
        }
    }
}
