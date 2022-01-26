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
    public partial class DestytojoPanele : Form
    {
        SQL sql = new SQL();

        List<StudentoGrupe> Grupiu_Sarasas;
        List<Studentai> Studentu_Sarasas;
        List<StudijuDalykas> Dalyku_Sarasas;

        int destytojoNumeris = 0;
        public string destytojoVardas;
        public string destytojoPavarde;



        public DestytojoPanele(int destytojoNR)
        {
            InitializeComponent();
            destytojoNumeris = destytojoNR;

        }

        private void DestytojoPanele_Load(object sender, EventArgs e)
        {
            DestytojoVardas.Text = destytojoVardas;
            DestytojoPavarde.Text = destytojoPavarde;
            StudentuGrupes.Items.Clear();

            Grupiu_Sarasas = sql.Rodyti_Studentu_Grupe();

            for (int i = 0; i < Grupiu_Sarasas.Count; i++)
                StudentuGrupes.Items.Add(Grupiu_Sarasas[i].vardo_Gavimas());
        }

        private void StudentuGrupes_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudentuSarasas.Items.Clear();

            Studentu_Sarasas = sql.Grupes_Studentas(Grupiu_Sarasas[StudentuGrupes.SelectedIndex].numerio_Gavimas());

            for (int i = 0; i < Studentu_Sarasas.Count; i++)
            {
                StudentuSarasas.Items.Add(Studentu_Sarasas[i].gautiVarda() + " " + Studentu_Sarasas[i].gautiPavarde());
            }


            DestomasDalykas.Items.Clear();
            Dalyku_Sarasas = sql.Dalyko_Rodymas(Grupiu_Sarasas[StudentuGrupes.SelectedIndex].numerio_Gavimas(), destytojoNumeris);
            for (int i = 0; i < Dalyku_Sarasas.Count; i++)
            {
                DestomasDalykas.Items.Add(Dalyku_Sarasas[i].VardoGavimas());
            }
            
            

        }
        private void IssaugojimoMygtukas_Click(object sender, EventArgs e)
        {
            try
            {

                int studentoNR = Studentu_Sarasas[StudentuSarasas.SelectedIndex].gautiNumeri();
                int pazymys = Convert.ToInt32(Text_Mark.Text);
                int dalykoNR = Dalyku_Sarasas[DestomasDalykas.SelectedIndex].NumerioGavimas();

                if (int.TryParse(Text_Mark.Text, out int value))
                {
                    if (Convert.ToInt32(Text_Mark.Text) < 1 || Convert.ToInt32(Text_Mark.Text) > 10 )
                        MessageBox.Show("Įvedamas pažymys turi būti 1-10 tarpe");
                    else
                    {
                      
                        sql.PazymioIrasymas(studentoNR, destytojoNumeris, pazymys, dalykoNR);
                        MessageBox.Show("Pažymys sėkmingai įvestas.");

                    }
                }
                else
                    MessageBox.Show("Klaida: norint įrašyti pažymį galite naudoti tik skaičius.");
            }
            catch(Exception exc)
            {
                MessageBox.Show("Negalima priskirti pažymio, jeigu nedėstote šiam studentui." + exc.ToString());
            }

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Prisijungimas prisijungti = new Prisijungimas();
            prisijungti.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void StudentuSarasas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
