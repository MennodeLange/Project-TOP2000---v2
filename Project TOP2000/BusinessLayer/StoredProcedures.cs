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
        public SqlConnection Connectie = new SqlConnection(ConfigurationManager.ConnectionStrings["Top2000ConnectionString"].ConnectionString);

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

        public DataView GetTop10Search(Lijst lijst)
        {
            SqlConnection Connectie = new SqlConnection(ConfigurationManager.ConnectionStrings["Top2000ConnectionString"].ConnectionString);
            DataSet DatasetFilled = new DataSet();
            Lijst objLijst = new Lijst(DatasetFilled);

            
            objLijst.Val = objLijst.LijstLengte;
            SqlDataAdapter CONad = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connectie;
            cmd.CommandText = "GetTop10Search";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@jaartal", SqlDbType.Int, 50).Value = lijst.SelectedJaartal;
            cmd.Parameters.Add("@above", SqlDbType.Int, 50).Value = lijst.Above;
            cmd.Parameters.Add("@input", SqlDbType.VarChar, 100).Value = lijst.SearchInput;
            CONad.SelectCommand = cmd;
            CONad.Fill(DatasetFilled);
            //DataSet DS = New DataSet();
            objLijst.DataViewTop10 = DatasetFilled.Tables[0].DefaultView;
            Connectie.Close();

            return objLijst.DataViewTop10;
        }

        public DataView GetTop10(Lijst lijst)
        {
            SqlConnection Connectie = new SqlConnection(ConfigurationManager.ConnectionStrings["Top2000ConnectionString"].ConnectionString);
            DataSet DatasetFilled = new DataSet();
            Lijst objLijst = new Lijst(DatasetFilled);

            //Lijst objLijst = new Lijst(DatasetFilled);

            lijst.Val = lijst.LijstLengte;
            SqlDataAdapter CONad = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connectie;
            cmd.CommandText = "GetTop10";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@jaartal", SqlDbType.Int, 50).Value = lijst.SelectedJaartal;
            cmd.Parameters.Add("@above", SqlDbType.Int, 50).Value = lijst.Above;
            CONad.SelectCommand = cmd;
            CONad.Fill(DatasetFilled);
            //DataSet DS = New DataSet();
            objLijst.DataViewTop10 = DatasetFilled.Tables[0].DefaultView;
            Connectie.Close();

            return objLijst.DataViewTop10;
        }

        public void GetJaren()
        {
            Lijst objLijst = new Lijst();

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

            Connectie.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "RemoveArtiestZonderLied";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = Connectie;
            cmd.ExecuteNonQuery();
            Connectie.Close();
        }

        public SqlCommand Loaded()
        {

            Connectie.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetArtiestenZonderLied";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = Connectie;

            return cmd;
        }

        /// <summary>
        /// Before MyFunction() Changed to FillComboboxWithYears()
        /// </summary>
        public DataTable FillComboboxWithYears()
        {
// NOTITIE: CLOSE MOET WEG!!!!!
            Connectie.Close();
            Connectie.Open();
            DataTable DatableFilled = new DataTable();
            Lijst objLijst = new Lijst(DatableFilled);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetJaren";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = Connectie;
           

            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    
                    adapter.Fill(objLijst.DataTable);

                    // String x is het eerste jaar van de top2000
                    string x = cmd.ExecuteScalar().ToString();
                    // Voor elk jaar dat de top2000 bestaat word ii met 1 verhoogd

                    // Voor elk jaar word er een item toegevoegd aan de combobox die per jaar met 1 word verhoogd
                    return objLijst.DataTable;
                }
            }
            
        }
    }
}
