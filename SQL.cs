using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;


namespace PRAKTIKA_PI20A
{
    public class SQL
    {

        MySqlConnection connection = new MySqlConnection("datasource = localhost;port=3306;username=root;password=");
        MySqlCommand command;
        public SQL()
        {

        }

        public void Prideti_Vartotoja(int role, string username, string password, string vardas, string pavarde)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO praktika_pi20a.vartotojas (Roles_numeris, Naudotojo_vardas, Slaptazodis, Vardas, Pavarde) VALUES ('" + role + "', '" + username + "', '" + password + "', '" + vardas + "', '" + pavarde + "')", connection);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public bool VartotojoEgzistavimas(string username, string password)
        {
            bool Result = false;

            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM praktika_pi20a.vartotojas WHERE Naudotojo_vardas=@Naudotojo_vardas AND Slaptazodis=@Slaptazodis", connection);
            command.Parameters.AddWithValue("@Naudotojo_vardas", username);
            command.Parameters.AddWithValue("@Slaptazodis", password);
            command.ExecuteNonQuery();
            MySqlDataReader da = command.ExecuteReader();

            while (da.Read())
            {
                Result = da.HasRows;
            }
            connection.Close();
            return Result;
        }
        public bool StudentoEgzistavimas(string vardas, string pavarde)
        {
            bool Result = false;

            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM praktika_pi20a.vartotojas WHERE Vardas=@Vardas AND Pavarde=@Pavarde AND Roles_numeris='3'", connection);
            command.Parameters.AddWithValue("@Vardas", vardas);
            command.Parameters.AddWithValue("@Pavarde", pavarde);
            command.ExecuteNonQuery();
            MySqlDataReader da = command.ExecuteReader();

            while (da.Read())
            {
                Result = da.HasRows;
            }
            connection.Close();
            return Result;
        }

        public int VartotojoRole(string username, string password)
        {
            int Result = 0;

            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM praktika_pi20a.vartotojas WHERE Naudotojo_vardas=@Naudotojo_vardas AND Slaptazodis=@Slaptazodis", connection);
            command.Parameters.AddWithValue("@Naudotojo_vardas", username);
            command.Parameters.AddWithValue("@Slaptazodis", password);
            command.ExecuteNonQuery();

            MySqlDataReader da = command.ExecuteReader();
            while (da.Read())
            {

                Result = da.GetInt32(2);

            }
            connection.Close();

            return Result;
        }
        public int VartotojoNumeris(string username, string password)
        {
            int Result = 0;
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM praktika_pi20a.vartotojas WHERE Naudotojo_vardas=@Naudotojo_vardas AND Slaptazodis=@Slaptazodis", connection);
            command.Parameters.AddWithValue("@Naudotojo_vardas", username);
            command.Parameters.AddWithValue("@Slaptazodis", password);
            command.ExecuteNonQuery();

            MySqlDataReader da = command.ExecuteReader();
            while (da.Read())
            {
                Result = da.GetInt32(0);
            }
            connection.Close();
            return Result;
        }
        public int StudentoGrupe(string username, string password)
        {
            int Result = -1;
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM praktika_pi20a.vartotojas WHERE Naudotojo_vardas=@Naudotojo_vardas AND Slaptazodis=@Slaptazodis", connection);
            command.Parameters.AddWithValue("@Naudotojo_vardas", username);
            command.Parameters.AddWithValue("@Slaptazodis", password);
            command.ExecuteNonQuery();

            MySqlDataReader da = command.ExecuteReader();
            while (da.Read())
            {
                Result = da.GetInt32(1);
            }
            connection.Close();
            return Result;
        }

        public void PaskirtiStudentuiGrupe(int id, int nr)
        {
            connection.Open();
            command = new MySqlCommand("UPDATE praktika_pi20a.vartotojas SET Grupes_numeris = '" + id + "' WHERE ID = '" + nr + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void PridetiDalyka(string destomasDalykas, int destytojoNR, int id)
        {

            connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO praktika_pi20a.dalykas (Dalyko_pavadinimas, Destytojo_numeris, Grupes_numeris) VALUES('" + destomasDalykas + "', '" + destytojoNR + "', '" + id + "')", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void PridetiGrupe(string grupesPavadinimas)
        {

            connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO praktika_pi20a.studentu_grupes (Grupes_pavadinimas) VALUES('" + grupesPavadinimas + "')", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void IstrintiGrupe(int id)
        {

            connection.Open();
            MySqlCommand command = new MySqlCommand("DELETE FROM praktika_pi20a.studentu_grupes WHERE Grupes_numeris = '" + id + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public bool GrupesEgzistavimas(string grupesPavadinimas)
        {
            bool Result = false;
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM praktika_pi20a.studentu_grupes WHERE Grupes_Pavadinimas=@Grupes_Pavadinimas", connection);
            command.Parameters.AddWithValue("@Grupes_Pavadinimas", grupesPavadinimas);
            command.ExecuteNonQuery();
            MySqlDataReader da = command.ExecuteReader();

            while (da.Read())
            {
                Result = da.HasRows;
            }
            connection.Close();
            return Result;
        }
        public bool DalykoEgzistavimas(string pavadinimas)
        {
            bool Result = false;
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM praktika_pi20a.dalykas WHERE Dalyko_pavadinimas='" + pavadinimas + "'", connection);
            command.ExecuteNonQuery();
            MySqlDataReader da = command.ExecuteReader();

            while (da.Read())
            {
                Result = da.HasRows;
            }
            connection.Close();
            return Result;
        }
        public bool DestytojoEgzistavimas(string vardas, string pavarde)
        {
            bool Result = false;
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM praktika_pi20a.vartotojas WHERE Vardas='" + vardas + "' AND Pavarde='" + pavarde + "'", connection);
            command.ExecuteNonQuery();
            MySqlDataReader da = command.ExecuteReader();

            while (da.Read())
            {
                Result = da.HasRows;
            }
            connection.Close();
            return Result;
        }
        public List<StudentoGrupe> Rodyti_Studentu_Grupe()
        {
            List<StudentoGrupe> Result = new List<StudentoGrupe>();

            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT Grupes_numeris, Grupes_pavadinimas FROM praktika_pi20a.studentu_grupes", connection);
            command.ExecuteNonQuery();
            MySqlDataReader da = command.ExecuteReader();

            while (da.Read())
            {
                StudentoGrupe grupe = new StudentoGrupe();

                grupe.numerio_Nustatymas(da.GetInt32(0));
                grupe.vardo_Nustatymas(da.GetString(1));

                Result.Add(grupe);
            }
            connection.Close();
            return Result;
        }

        public List<Studentai> Rodyti_Studenta()
        {

            List<Studentai> Result = new List<Studentai>();
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM praktika_pi20a.vartotojas", connection);
            command.ExecuteNonQuery();
            MySqlDataReader da = command.ExecuteReader();
            while (da.Read())
            {
                if (da.GetInt32(2) == 3)
                {
                    Studentai studentai = new Studentai();

                    studentai.nustatytiNumeri(da.GetInt32(0));
                    studentai.nustatytiVarda(da.GetString(5));
                    studentai.nustatytiPavarde(da.GetString(6));

                    Result.Add(studentai);
                }

            }
            connection.Close();
            return Result;
        }
        public void VartotojoTrinimas(int id)
        {
            connection.Open();
            command = new MySqlCommand("DELETE FROM praktika_pi20a.vartotojas WHERE ID = '" + id + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DalykoTrinimas(int id)
        {
            connection.Open();
            command = new MySqlCommand("DELETE FROM praktika_pi20a.dalykas WHERE Dalyko_numeris = '" + id + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }


        public List<StudijuDalykas> Rodyti_Dalyka()
        {
            List<StudijuDalykas> Result = new List<StudijuDalykas>();

            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT Dalyko_numeris, Dalyko_pavadinimas FROM praktika_pi20a.dalykas", connection);
            command.ExecuteNonQuery();
            MySqlDataReader da = command.ExecuteReader();
            while (da.Read())
            {

                StudijuDalykas dalykas = new StudijuDalykas();

                dalykas.numerioNustatymas(da.GetInt32(0));
                
                dalykas.vardoNustatymas(da.GetString(1));


                Result.Add(dalykas);

            }
            connection.Close();
            return Result;
        }

        public List<Vartotojai> Rodyti_Destytoja()
        {
            List<Vartotojai> Result = new List<Vartotojai>();

            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM praktika_pi20a.vartotojas", connection);
            command.ExecuteNonQuery();
            MySqlDataReader da = command.ExecuteReader();
            while (da.Read())
            {
                if (da.GetInt32(2) == 2)
                {
                    Vartotojai destytojuInfo = new Vartotojai();

                    destytojuInfo.nustatytiNumeri(da.GetInt32(0));
                    destytojuInfo.nustatytiVarda(da.GetString(5));
                    destytojuInfo.nustatytiPavarde(da.GetString(6));

                    Result.Add(destytojuInfo);
                }

            }
            connection.Close();
            return Result;
        }

        public List<Studentai> Grupes_Studentas(int grupesNR)
        {

            List<Studentai> Result = new List<Studentai>();
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM praktika_pi20a.vartotojas WHERE Grupes_numeris = '" + grupesNR + "'", connection);
            command.ExecuteNonQuery();
            MySqlDataReader da = command.ExecuteReader();
            while (da.Read())
            {
                if (da.GetInt32(2) == 3)
                {
                    Studentai studentas = new Studentai();

                    studentas.nustatytiNumeri(da.GetInt32(0));
                    studentas.nustatytiVarda(da.GetString(5));
                    studentas.nustatytiPavarde(da.GetString(6));

                    Result.Add(studentas);
                }

            }
            connection.Close();
            return Result;
        }

        public List<StudijuDalykas> Dalyko_Rodymas(int grupesNR, int destytojoNR)
        {
            List<StudijuDalykas> Result = new List<StudijuDalykas>();

            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM praktika_pi20a.dalykas WHERE Grupes_numeris = '" + grupesNR + "' AND Destytojo_numeris = '" + destytojoNR + "'", connection);
            command.ExecuteNonQuery();
            MySqlDataReader da = command.ExecuteReader();
            while (da.Read())
            {
                StudijuDalykas dalykas = new StudijuDalykas();

                dalykas.numerioNustatymas(da.GetInt32(0));
                dalykas.vardoNustatymas(da.GetString(1));
                dalykas.destytojoNustatymas(da.GetInt32(2));
                dalykas.grupesNustatymas(da.GetInt32(3));



                Result.Add(dalykas);


            }
            connection.Close();
            return Result;
        }

        public List<StudijuDalykas> Grupes_Dalykas(int grupesNR)
        {
            List<StudijuDalykas> Result = new List<StudijuDalykas>();

            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM praktika_pi20a.dalykas WHERE Grupes_numeris = '" + grupesNR + "'", connection);
            command.ExecuteNonQuery();
            MySqlDataReader da = command.ExecuteReader();
            while (da.Read())
            {
                StudijuDalykas dalykas = new StudijuDalykas();

                dalykas.numerioNustatymas(da.GetInt32(0));
                dalykas.vardoNustatymas(da.GetString(1));
                dalykas.destytojoNustatymas(da.GetInt32(2));
                dalykas.grupesNustatymas(da.GetInt32(3));

                Result.Add(dalykas);


            }
            connection.Close();
            return Result;
        }
 
 
        public void PazymioIrasymas(int id, int pazymys, int destytojoNR, int dalykoNR)
        {

            connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO praktika_pi20a.pazymiai (Studento_numeris, Destytojo_numeris, Pazymys, Dalyko_numeris) VALUES('" + id + "', '" + pazymys + "', '" + destytojoNR + "', '" + dalykoNR + "' )", connection);
            command.ExecuteNonQuery();
            connection.Close();

        }
        public bool PazymioEgzistavimas(int id, int destytojoNR, int pazymys, int dalykoNR)
        {
            bool Result = false;
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM praktika_pi20a.pazymiai WHERE Studento_numeris = '" + id + "' AND Destytojo_numeris = '" + destytojoNR + "' AND Pazymys ='" + pazymys + "' AND Dalyko_numeris = '" + dalykoNR + "'", connection);
            command.ExecuteNonQuery();
            MySqlDataReader da = command.ExecuteReader();

            while (da.Read())
            {
                Result = da.HasRows;
            }
            connection.Close();
            return Result;
        }

        public int PazymioGavimas(int id, int pavadinimas)
        {
            int Result = -1;

            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM praktika_pi20a.pazymiai WHERE Studento_numeris = '" + id + "' AND Dalyko_numeris = '" + pavadinimas + "' ", connection);
            command.ExecuteNonQuery();
            MySqlDataReader da = command.ExecuteReader();
            while (da.Read())
            {
                Result = da.GetInt32(3);
            }
            connection.Close();
            return Result;
        }
    }
}
