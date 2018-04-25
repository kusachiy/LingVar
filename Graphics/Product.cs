using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    class Product
    {
        public int Kalor { get; set; }
        public int Edok { get; set; }
        public int Time { get; set; }        

        public Product(int kalor,int edok,int time)
        {
            Kalor = kalor;
            Edok = edok;
            Time = time;
        }
        
    }
}
