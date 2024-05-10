using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;


namespace DAL
{

    public class AccessDB
    {
        private static DataTable nomProv = new DataTable();

        private static DataTable nomVehicule = new DataTable();
        public static DataTable ConnecterBD()
        {
            LoadNomProv();
            LoadNomVehicule();


            // Connexion locale sur WampServer
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=bdesva;UID=root;PASSWORD=;");

            // Connexion distante avec CPanel
            //MySqlConnection conn = new MySqlConnection("SERVER=cpanel.techinfo-cstj.ca;DATABASE=haloulou_gestionparticipants;UID=haloulou_gp_user;PASSWORD=AQWE23SEF;");

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT Annee, CodePr, CodeCarb, CodeGen, NbreImmats FROM nouvimmat", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                adp.Fill(ds, "immat");

                var dt = ds.Tables["immat"];

                return dt;
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }


        }

        private static void LoadNomVehicule()
        {
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=bdesva;UID=root;PASSWORD=;");
            try
            {

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM vehicule:", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                adp.Fill(ds, "vehichule");

                var dt = ds.Tables["vehichule"];
                nomVehicule = dt;


            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return;
            }
            finally
            {
                conn.Close();
            }

        }

        private static void LoadNomProv()
        {
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=bdesva;UID=root;PASSWORD=;");


            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM province ;", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds, "province");

                var dt = ds.Tables["province"];
                nomProv = dt;


            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return;
        }
            finally
            {
                conn.Close();
            }
}

        public static string GetVehiculeName(string codeGen)
        {

            for (int i = 0; i < nomVehicule.Rows.Count; i++)
            {
                if (codeGen == nomVehicule.Rows[i]["CodeGenre"].ToString())
                {
                    return nomVehicule.Rows[i]["GenreVehicule"].ToString();
                }
            }
            return null;
        }

        public static string GetProvinceName(string codePr)
        {
            for (int i = 0; i < nomProv.Rows.Count; i++)
            {
                if (codePr == nomProv.Rows[i]["CodeProvince"].ToString())
                {
                    return nomProv.Rows[i]["NomProvince"].ToString();
                }
            }
            return null;

        }

        public static double GetVehiculeCount(string codePr, int year)
        {
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=bdesva;UID=root;PASSWORD=;");

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT Annee, CodePr, CodeCarb, CodeGen, NbreImmats FROM nouvimmat WHERE Annee=@year AND CodePr=@codePr", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                adp.Fill(ds, "immat");

                var dt = ds.Tables["immat"];

                if (dt == null)
                {
                    throw new Exception();
                }
                double total = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    total += (double)dt.Rows[i]["NbreImmats"];
                }
                return total;
            }





            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                conn.Close();
            }

        }

        public static double GetSepcificVehiculeCount(string codePr, int year, string codeCarb)
        {

            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=bdesva;UID=root;PASSWORD=;");

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT Annee, CodePr, CodeCarb, CodeGen, NbreImmats FROM nouvimmat WHERE Annee=@year AND CodePr=@codePr AND CodeCarb=@codeCarb", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                adp.Fill(ds, "immat");

                var dt = ds.Tables["immat"];

                if (dt == null)
                {
                    throw new Exception();
                }
                double total = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    total += (double)dt.Rows[i]["NbreImmats"];
                }
                return total;
            }





            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }


    }

}


