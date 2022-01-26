using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAKTIKA_PI20A
{
   public class StudentoGrupe
    {
        public int Nr;
        public string vardas;

        public int numerio_Gavimas()
        {
            return Nr;
        }

        public string vardo_Gavimas()
        {
            return vardas;
        }
        public void numerio_Nustatymas(int nr)
        {
            Nr = nr;
        }

        public void vardo_Nustatymas (string Vardas)
        {
            vardas = Vardas;
        }
    }
}
