using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    public class FuzzyCarModel
    {        

        static FuzzyCarModel()
        {

        }
        public Term PowerPS { get; set; }
        public Term Kilometer { get; set; }
        public Term Age { get; set; }
        public Term Price { get; set; }
    }
}
