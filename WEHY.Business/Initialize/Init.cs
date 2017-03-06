using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WEHY.Business.Initialize
{
    public class Init
    {
        public Init() {
            RootDirectory.Directory = Directory.GetCurrentDirectory();
        }
    }
}
