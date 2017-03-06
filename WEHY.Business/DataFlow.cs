using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEHY.Business
{
    public class Lookup
    {
        public int ID { get; set; }
        public string Title { get; set; }
    }
   
    public class DataFlow
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public double Value { get; set; }
    }
}
