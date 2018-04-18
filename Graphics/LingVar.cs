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

        public LingVar()
        {
            Terms = new List<Term>();
           
            
        }
    }
}
