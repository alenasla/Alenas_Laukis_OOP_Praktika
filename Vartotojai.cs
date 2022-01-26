using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAKTIKA_PI20A
{
    public class Vartotojai
    {
        public int numeris;
        public string vardas, pavarde;
        public int gautiNumeri()
        {
            return numeris;
        }

        public void nustatytiNumeri(int Numeris)
        {
            numeris = Numeris;
        }

        public string gautiVarda()
        {
            return vardas;
        }

        public string gautiPavarde()
        {
            return pavarde;
        }

        public void nustatytiVarda(string Vardas)
        {
            vardas = Vardas;
        }

        public void nustatytiPavarde(string Pavarde)
        {
            pavarde = Pavarde;
        }
    }
}
