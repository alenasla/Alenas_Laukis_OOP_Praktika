using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Web;


namespace PRAKTIKA_PI20A
{
    public partial class Prisijungimas : Form
    {
        SQL sql = new SQL();

        public Prisijungimas()
        {
            InitializeComponent();
        }

        private void Prisijungimas_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sql.VartotojoEgzistavimas(Username1.Text, Password.Text))
                {
                    int vartotojoNumeris = sql.VartotojoNumeris(Username1.Text, Password.Text);

                    if (sql.VartotojoRole(Username1.Text, Password.Text) == 1)
                    {
                       AdminValdymoCentras admin = new AdminValdymoCentras();
                       admin.Show();
                    }

                    if (sql.VartotojoRole(Username1.Text, Password.Text) == 2)
                    {
                        DestytojoPanele destytojas = new DestytojoPanele(vartotojoNumeris);
                        destytojas.destytojoVardas = Username1.Text;
                        destytojas.destytojoPavarde = Password.Text;
                        destytojas.Show();
                         
                    }
                    if (sql.VartotojoRole(Username1.Text, Password.Text) == 3)
                    {
                        int grupesNumeris = sql.StudentoGrupe(Username1.Text, Password.Text);

                        StudentoPanele studentas = new StudentoPanele(grupesNumeris, vartotojoNumeris);
                        studentas.studentoVardas = Username1.Text;
                        studentas.studentoPavarde = Password.Text;
                        studentas.Show();
                    }



                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Toks vartotojas neegzistuoja.");
                }
            }
            
            catch(Exception exc)
            {
                MessageBox.Show("ERROR: " + exc.Message);
            }
            Console.ReadLine();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Username1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
    }

}
