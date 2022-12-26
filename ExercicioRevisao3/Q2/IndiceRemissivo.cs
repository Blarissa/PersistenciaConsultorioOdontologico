using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    internal class IndiceRemissivo
    {
        public string PathTXT { get; private set; }
        public string PathIgnore { get; private set; }

        public IndiceRemissivo(string pathTXT, string pathIgnore)
        {
            PathIgnore= pathIgnore;
            PathTXT= pathTXT;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
