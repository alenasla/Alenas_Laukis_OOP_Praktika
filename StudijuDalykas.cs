using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAKTIKA_PI20A
{
    public class StudijuDalykas
    {
        public int nr, destytojas, grupe;
        public string vardas;

        public int NumerioGavimas()
        {
            return nr;
        }

        public int DestytojoGavimas()
        {
            return destytojas;
        }

        public int GrupesGavimas()
        {
            return grupe;
        }

        public string VardoGavimas()
        {
            return vardas;
        }

        public void numerioNustatymas(int numeris)
        {
            nr = numeris;
        }

        public void destytojoNustatymas(int Destytojas)
        {
            destytojas = Destytojas;
        }

        public void grupesNustatymas(int Grupe)
        {
            grupe = Grupe;
        }

        public void vardoNustatymas(string Vardas)
        {
            vardas = Vardas;
        }
    }
}
