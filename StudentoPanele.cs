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
    public partial class StudentoPanele : Form
    {
        SQL sql = new SQL();
        
        List<StudijuDalykas> Subject_List;

        int Studento_Grupe = -1;
        int StudentoNumeris = -1;

        public string studentoVardas;
        public string studentoPavarde;

        public StudentoPanele(int grupe, int numeris)
        {
            InitializeComponent();

            Studento_Grupe = grupe;
            StudentoNumeris = numeris;
        }

        private void StudentoPanele_Load(object sender, EventArgs e)
        {
            StudentoVardas.Text = studentoVardas;
            StudentoPavarde.Text = studentoPavarde;
            listView1.Items.Clear();

            Subject_List = sql.Grupes_Dalykas(Studento_Grupe);

            for (int i = 0; i < Subject_List.Count; i++)
            {
                int Pazymys = sql.PazymioGavimas(StudentoNumeris, Subject_List[i].NumerioGavimas());
                string DalykoPavadinimas = Subject_List[i].VardoGavimas();

                if (Pazymys == -1)
                {
                    ListViewItem LVI = new ListViewItem(new[] {DalykoPavadinimas});
                    listView1.Items.Add(LVI);
                }
                else
                {
                    ListViewItem LVI = new ListViewItem(new[] {DalykoPavadinimas, Pazymys.ToString()});
                    listView1.Items.Add(LVI);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prisijungimas prisijungti = new Prisijungimas();
            prisijungti.Show();
            this.Hide();
        }
    }
}
