using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;


namespace BusinessLayer
{
   public class StoredProcedures
    {
        private int val;

        public int Val
        {
            get { return val; }
            set { val = value; }
        }

        public StoredProcedures()
        {

        }
        public StoredProcedures(int _val)
        {
            this.val = _val;
        }

        public void GetTop10Search()
        {
            Lijst objLijst = new Lijst();

            SqlConnection Connectie = new SqlConnection(ConfigurationManager.ConnectionStrings["Top2000ConnectionString"].ConnectionString);
            SqlDataAdapter CONad = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connectie;
            cmd.CommandText = "GetTop10Search";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@jaartal", SqlDbType.Int, 50).Value = objLijst.SelectedJaartal;
            cmd.Parameters.Add("@above", SqlDbType.Int, 50).Value = objLijst.Above;
            cmd.Parameters.Add("@input", SqlDbType.VarChar, 100).Value = objLijst.SearchInput;
            CONad.SelectCommand = cmd;
            CONad.Fill(objLijst.DataSetTop10);
            Connectie.Close();
        }

        public void GetTop10()
        {
            Lijst objLijst = new Lijst();

            SqlConnection Connectie = new SqlConnection(ConfigurationManager.ConnectionStrings["Top2000ConnectionString"].ConnectionString);
            SqlDataAdapter CONad = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connectie;
            cmd.CommandText = "GetTop10";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@jaartal", SqlDbType.Int, 50).Value = objLijst.SelectedJaartal;
            cmd.Parameters.Add("@above", SqlDbType.Int, 50).Value = objLijst.Above;
            CONad.SelectCommand = cmd;
            CONad.Fill(objLijst.DataSetTop10);
            Connectie.Close();
        }

        public void GetJaren()
        {
            SqlConnection Connectie = new SqlConnection(ConfigurationManager.ConnectionStrings["Top2000ConnectionString"].ConnectionString);
            Lijst objLijst = new Lijst();

            //try
            //{
            using (Connectie)
            {
                Connectie.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetJaren";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connectie;

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    // DataTable dt = new DataTable();
                    adapter.Fill(objLijst.DataTable);

                    ///voor elk jaar word er een item toegevoegd aan de combobox die per jaar met 1 word verhoogd
                    for (int i = 0; i < objLijst.DataTable.Rows.Count; i++)
                    {
                        objLijst.SelectedJaartal = objLijst.DataTable.Rows[i][0].ToString();
                    }
                }
            }
        }


        public void ArtiestToevoegen()
        {
            Artiest artiest = new Artiest();
            SqlConnection Connectie = new SqlConnection(ConfigurationManager.ConnectionStrings["Top2000ConnectionString"].ConnectionString);

            Connectie.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "AddArtiest";
            cmd.Parameters.AddWithValue("@naam", artiest.Naam);
            cmd.Parameters.AddWithValue("@url", artiest.Url);
            cmd.Parameters.AddWithValue("@biografie", artiest.Bio);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = Connectie;
            cmd.ExecuteNonQuery();
            Connectie.Close();
        }

        public void ArtiestVerwijderen()
        {
            SqlConnection Connectie = new SqlConnection(ConfigurationManager.ConnectionStrings["Top2000ConnectionString"].ConnectionString);

            Connectie.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "RemoveArtiestZonderLied";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = Connectie;
            cmd.ExecuteNonQuery();
            Connectie.Close();
        }
    }
}
