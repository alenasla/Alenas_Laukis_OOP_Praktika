using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAKTIKA_PI20A
{
     public class Studentai:Vartotojai
    {
        public int grupe;

        public int Grupe()
        {
            return grupe;
        }

        public void NustatytiGrupe(int grupesNumeris)
        {
            grupe = grupesNumeris;
        }
    }
}
