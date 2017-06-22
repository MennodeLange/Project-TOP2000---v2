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
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.Connection = Connectie;
            objSqlCommand.CommandText = "GetTop10Search";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.Add("@jaartal", SqlDbType.Int, 50).Value = lijst.SelectedJaartal;
            objSqlCommand.Parameters.Add("@above", SqlDbType.Int, 50).Value = lijst.Above;
            objSqlCommand.Parameters.Add("@input", SqlDbType.VarChar, 100).Value = lijst.SearchInput;
            CONad.SelectCommand = objSqlCommand;
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
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.Connection = Connectie;
            objSqlCommand.CommandText = "GetTop10";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.Add("@jaartal", SqlDbType.Int, 50).Value = lijst.SelectedJaartal;
            objSqlCommand.Parameters.Add("@above", SqlDbType.Int, 50).Value = lijst.Above;
            CONad.SelectCommand = objSqlCommand;
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
                SqlCommand objSqlCommand = new SqlCommand();
                objSqlCommand.CommandText = "GetJaren";
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Connection = Connectie;

                using (SqlDataAdapter adapter = new SqlDataAdapter(objSqlCommand))
                {
                    // DataTable dt = new DataTable();
                    adapter.Fill(objLijst.DataTable);

                    ///voor elk jaar word er een item toegevoegd aan de combobox die per jaar met 1 word verhoogd
                    for (int i = 0; i < objLijst.DataTable.Rows.Count; i++)
                    {
                        objLijst.SelectedJaartal = objLijst.DataTable.Rows[i][0].ToString();
                    }
                }
                Connectie.Close();
            }
        }


        public void ArtiestToevoegen()
        {
            Artiest artiest = new Artiest();

            Connectie.Open();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "AddArtiest";
            objSqlCommand.Parameters.AddWithValue("@naam", artiest.Naam);
            objSqlCommand.Parameters.AddWithValue("@url", artiest.Url);
            objSqlCommand.Parameters.AddWithValue("@biografie", artiest.Bio);
            objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objSqlCommand.Connection = Connectie;
            objSqlCommand.ExecuteNonQuery();
            Connectie.Close();
        }

        public void ArtiestVerwijderen()
        {

            Connectie.Open();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "RemoveArtiestZonderLied";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = Connectie;
            objSqlCommand.ExecuteNonQuery();
            Connectie.Close();
        }

        /// <summary>
        /// Loaded van ComboBox jaren.
        /// </summary>
        /// <returns></returns>
        public SqlCommand Loaded()
        {
            Connectie.Open();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "GetArtiestenZonderLied";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = Connectie;

            return objSqlCommand;
        }

        public SqlCommand LoadedArtiest()
        {
            Connectie.Open();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "GetAllArtiesten";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = Connectie;

            return objSqlCommand;
        }

        /// <summary>
        /// Before MyFunction() Changed to FillComboboxWithYears()
        /// </summary>
        public DataTable FillComboboxWithYears()
        {
            Connectie.Close();
            Connectie.Open();
            DataTable DatableFilled = new DataTable();
            Lijst objLijst = new Lijst(DatableFilled);
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "GetJaren";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = Connectie;


            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(objSqlCommand))
                {

                    adapter.Fill(objLijst.DataTable);

                    // String x is het eerste jaar van de top2000
                    string x = objSqlCommand.ExecuteScalar().ToString();
                    // Voor elk jaar dat de top2000 bestaat word ii met 1 verhoogd

                    // Voor elk jaar word er een item toegevoegd aan de combobox die per jaar met 1 word verhoogd
                    return objLijst.DataTable;
                }
            }

        }

        public DataTable FillComboboxWithArtiesten()
        {
            Connectie.Close();
            Connectie.Open();
            DataTable DatableFilled = new DataTable();
            Lijst objLijst = new Lijst(DatableFilled);
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "GetAllArtiesten";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = Connectie;


            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(objSqlCommand))
                {

                    adapter.Fill(objLijst.DataTable);

                    // String x is het eerste jaar van de top2000
                    string x = objSqlCommand.ExecuteScalar().ToString();
                    // Voor elk jaar dat de top2000 bestaat word ii met 1 verhoogd

                    // Voor elk jaar word er een item toegevoegd aan de combobox die per jaar met 1 word verhoogd
                    return objLijst.DataTable;
                }
            }

        }


        public void ArtiestBewerken(Artiest artiest)
        {
           
            Connectie.Open();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "UpdateArtiest";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = Connectie;
            objSqlCommand.Parameters.AddWithValue("@artiest", artiest.SelectedArtiest);


            // end stored procedure

            if (artiest.ArtiestLenght == 0)
            {
                objSqlCommand.Parameters.AddWithValue("@naam", artiest.SelectedArtiest);
            }
            if (artiest.ArtiestLenght != 0)
            {
                objSqlCommand.Parameters.AddWithValue("@naam", artiest.Naam);
            }
            if (artiest.UrlLenght == 0)
            {
                objSqlCommand.Parameters.AddWithValue("@url", DBNull.Value);
            }
            if (artiest.UrlLenght != 0)
            {
                objSqlCommand.Parameters.AddWithValue("@url", artiest.Url);
            }
            if (artiest.BioLenght == 0)
            {
                objSqlCommand.Parameters.AddWithValue("@biografie", DBNull.Value);
            }
            if (artiest.BioLenght != 0)
            {
                objSqlCommand.Parameters.AddWithValue("@biografie", artiest.Bio);

                {
                    objSqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
