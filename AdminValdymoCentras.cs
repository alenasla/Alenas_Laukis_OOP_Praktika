using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRAKTIKA_PI20A
{
    public partial class AdminValdymoCentras : Form
    {
        SQL sql = new SQL();
        List<StudentoGrupe> Grupiu_Sarasas;
        List<Studentai> Studentu_Sarasas;
        List<StudijuDalykas> Dalyku_Sarasas;
        List<Vartotojai> Destytoju_Sarasas;
        public AdminValdymoCentras()
        {
            InitializeComponent();
        }

        private void AdminValdymoCentras_Load(object sender, EventArgs e)
        {

            try
            {
                StudentaiUpdate();
                GrupesUpdate();
                DalykasUpdate();
                DestytojasUpdate();
            }
            catch (Exception exc)
            {
                MessageBox.Show("ERROR: " + exc.Message);
            }
            Console.ReadLine();

        }

        private void StudentoPridejimas_Click(object sender, EventArgs e)
        {
            try
            {

                if (String.IsNullOrEmpty(StudentoVardas.Text) || String.IsNullOrEmpty(StudentoPavarde.Text))
                {
                    MessageBox.Show("Neteisingai įvesti duomenys - patikrinkite ar nepalikote tarpų ir tuščių eilučių.");
                }
                else
                {
                    string vardas = StudentoVardas.Text;
                    string pavarde = StudentoPavarde.Text;

                    if (sql.StudentoEgzistavimas(vardas, pavarde))
                    {
                        MessageBox.Show("Įvestas studentas jau yra pridėtas !");
                        return;
                    }
                    else
                    {
                        StudentoTrinimas.Items.Clear();
                        sql.Prideti_Vartotoja(3, vardas, pavarde, vardas, pavarde);
                        MessageBox.Show("Sėkmingai pridėjote studentą.");
                        StudentaiUpdate();
                    }
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Nepavyko pridėti studento: " + exc.ToString());
            }
        }
        private void GrupesPridejimas_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (sql.GrupesEgzistavimas(PridetiStudentuGrupe.Text))
                {
                    MessageBox.Show("Įvesta grupė jau yra sukurta !");
                    return;
                }
                else
                {
                    GrupesTrinimas.Items.Clear();
                    sql.PridetiGrupe(PridetiStudentuGrupe.Text);
                    MessageBox.Show("Studentų grupė sėkmingai sukurta !");
                    GrupesUpdate();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Nepavyko sukurti grupės: " + exc.ToString());
            }
            
        }

        private void TrintiGrupe_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Ar tikrai norite ištrinti pasirinktą studentų grupę?"), "Patvirtinimas", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sql.IstrintiGrupe(Grupiu_Sarasas[GrupesTrinimas.SelectedIndex].numerio_Gavimas());
                MessageBox.Show("Grupė sėkmingai ištrinta");

            }

            GrupesUpdate();

        }

        private void GrupesUpdate()
        {
            
            GrupesTrinimas.Items.Clear();
            GrupiuSarasas.Items.Clear();
            GrupesPasirinkimas.Items.Clear();


            Grupiu_Sarasas = sql.Rodyti_Studentu_Grupe();

            for (int i = 0; i < Grupiu_Sarasas.Count; i++)
                GrupesTrinimas.Items.Add(Grupiu_Sarasas[i].vardo_Gavimas());

            for (int i = 0; i < Grupiu_Sarasas.Count; i++)
                GrupiuSarasas.Items.Add(Grupiu_Sarasas[i].vardo_Gavimas());

            for (int i = 0; i < Grupiu_Sarasas.Count; i++)
                GrupesPasirinkimas.Items.Add(Grupiu_Sarasas[i].vardo_Gavimas());

        }

        private void TrintiStudenta_Click(object sender, EventArgs e)
        {


            if(MessageBox.Show(string.Format("Ar tikrai norite ištrinti pasirinktą studentą?"), "Patvirtinimas", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sql.VartotojoTrinimas(Studentu_Sarasas[StudentoTrinimas.SelectedIndex].gautiNumeri());
                MessageBox.Show("Studentas sėkmingai ištrintas");
                
            }

            StudentaiUpdate();
            
        }
        private void StudentaiUpdate()
        {
            
            StudentoTrinimas.Items.Clear();
            StudentuSarasas.Items.Clear();

            Studentu_Sarasas = sql.Rodyti_Studenta();

            for (int i = 0; i < Studentu_Sarasas.Count; i++)
                StudentoTrinimas.Items.Add(Studentu_Sarasas[i].gautiVarda() + " " + Studentu_Sarasas[i].gautiPavarde());

            for (int i = 0; i < Studentu_Sarasas.Count; i++)
                StudentuSarasas.Items.Add(Studentu_Sarasas[i].gautiVarda() + " " + Studentu_Sarasas[i].gautiPavarde());


        }
        private void DestytojoPridejimas_Click(object sender, EventArgs e)
        {
            try
            {


                if (String.IsNullOrWhiteSpace(DestytojoVardas.Text) || String.IsNullOrWhiteSpace(DestytojoPavarde.Text))
                {
                    MessageBox.Show("Neteisingai įvesti duomenys - patikrinkite ar nepalikote tarpų ar tuščių eilučių.");
                }
                else
                {
                    string vardas = DestytojoVardas.Text;
                    string pavarde = DestytojoPavarde.Text;

                    if (sql.DestytojoEgzistavimas(vardas, pavarde))
                    {
                        MessageBox.Show("Įvestas dėstytojas jau yra pridėtas !");
                        return;
                    }
                    else
                    {
                        DestytojoTrinimas.Items.Clear();
                        sql.Prideti_Vartotoja(2, vardas, pavarde, vardas, pavarde);
                        MessageBox.Show("Dėstytojas sėkmingai pridėtas !");
                        DestytojasUpdate();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nepavyko įterpti dėstytojo: " + ex.ToString());
            }
        }
        private void TrintiDestytoja_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Ar tikrai norite ištrinti pasirinktą dėstytoją?"), "Patvirtinimas", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sql.VartotojoTrinimas(Destytoju_Sarasas[DestytojoTrinimas.SelectedIndex].gautiNumeri());
                MessageBox.Show("Pasirinktas dėstytojas sėkmingai ištrintas.");
            }

            DestytojasUpdate();
            
        }

        private void DestytojasUpdate()
        {
            
            DestytojoTrinimas.Items.Clear();
            DestytojoPasirinkimas.Items.Clear();

            Destytoju_Sarasas = sql.Rodyti_Destytoja();

            for (int i = 0; i < Destytoju_Sarasas.Count; i++)
                DestytojoTrinimas.Items.Add(Destytoju_Sarasas[i].gautiVarda() + " " + Destytoju_Sarasas[i].gautiPavarde());

            for (int i = 0; i < Destytoju_Sarasas.Count; i++)
                DestytojoPasirinkimas.Items.Add(Destytoju_Sarasas[i].gautiVarda() + " " + Destytoju_Sarasas[i].gautiPavarde());
            
        }
        private void DalykoPriskyrimas_Click(object sender, EventArgs e)
        {
            try
            {
                if (sql.DalykoEgzistavimas(DalykoPavadinimas.Text))
                {
                    MessageBox.Show("Pasirinktas dalykas jau yra sukurtas ir priskirtas dėstytojui ir grupei !");
                    return;
                }
                else
                {
                    DalykoTrinimas.Items.Clear();
                    sql.PridetiDalyka(DalykoPavadinimas.Text, Destytoju_Sarasas[DestytojoPasirinkimas.SelectedIndex].gautiNumeri(), Grupiu_Sarasas[GrupesPasirinkimas.SelectedIndex].numerio_Gavimas());
                    MessageBox.Show("Dėstomas dalykas sėkmingai priskirtas dėstytojui ir grupei !");
                    DalykasUpdate();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Nepavyko sukurti ir priskirti dėstomo dalyko: " + exc.ToString());
            }

        }
        private void TrintiDalyka_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Ar tikrai norite ištrinti pasirinkto dalyko priskyrimą?"), "Patvirtinimas", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sql.DalykoTrinimas(Dalyku_Sarasas[DalykoTrinimas.SelectedIndex].NumerioGavimas());
                MessageBox.Show("Pasirinktas priskirtas dėstomas dalykas sėkmingai ištrintas.");
            }
            DalykasUpdate();
            
        }

        private void DalykasUpdate()
        {
            
            DalykoTrinimas.Items.Clear();


            Dalyku_Sarasas = sql.Rodyti_Dalyka();

            for (int i = 0; i < Dalyku_Sarasas.Count; i++)
                DalykoTrinimas.Items.Add(Dalyku_Sarasas[i].VardoGavimas());
        }

        private void GrupesPriskyrimas_Click(object sender, EventArgs e)
        {
            sql.PaskirtiStudentuiGrupe(Grupiu_Sarasas[GrupiuSarasas.SelectedIndex].numerio_Gavimas(), Studentu_Sarasas[StudentuSarasas.SelectedIndex].gautiNumeri());
            MessageBox.Show("Sėkmingai priskyrėte studentą grupei.");
            DalykasUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prisijungimas login = new Prisijungimas();
            login.Show();
            this.Hide();
        }

        private void DestytojoPasirinkimas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StudentuGrupe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void StudentuSarasas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void GrupesTrinimas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}
