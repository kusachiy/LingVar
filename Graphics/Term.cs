using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Graphics
{
 

    public class Term
    {
        public string Name { get; set; }
        public Func<int,double> Function { get; set; }
        public Additions Addition { get; set; }
        public Brush LineColor { get; set; }

        public Term(string name,Brush color, Func<int,double> func)
        {
            Name = name;
            Function = func;
            LineColor = color;
        }
    }
}
