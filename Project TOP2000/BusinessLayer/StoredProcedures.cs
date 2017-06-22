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

        public StoredProcedures()
        {

        }

        public DataView GetTop10Search(Lijst lijst)
        {
            DataSet DatasetFilled = new DataSet();
            Lijst objLijst = new Lijst(DatasetFilled);

            objLijst.Val = objLijst.LijstLengte;
            SqlDataAdapter CONad = new SqlDataAdapter();
            SqlCommand objSqlCommand = new SqlCommand("GetTop10Search", Connectie);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.AddWithValue("@jaartal", lijst.SelectedJaartal);
            objSqlCommand.Parameters.AddWithValue("@above", lijst.Above);
            objSqlCommand.Parameters.AddWithValue("@input", lijst.SearchInput);
            CONad.SelectCommand = objSqlCommand;
            CONad.Fill(DatasetFilled);
            objLijst.DataViewTop10 = DatasetFilled.Tables[0].DefaultView;
            Connectie.Close();

            return objLijst.DataViewTop10;
        }

        public DataView GetTop10(Lijst lijst)
        {
            DataSet DatasetFilled = new DataSet();
            Lijst objLijst = new Lijst(DatasetFilled);

            lijst.Val = lijst.LijstLengte;
            SqlDataAdapter CONad = new SqlDataAdapter();
            SqlCommand objSqlCommand = new SqlCommand("GetTop10", Connectie);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.AddWithValue("@jaartal", lijst.SelectedJaartal);
            objSqlCommand.Parameters.AddWithValue("@above", lijst.Above);
            CONad.SelectCommand = objSqlCommand;
            CONad.Fill(DatasetFilled);
            objLijst.DataViewTop10 = DatasetFilled.Tables[0].DefaultView;
            Connectie.Close();

            return objLijst.DataViewTop10;
        }

       


        public void ArtiestToevoegen(Artiest artiest)
        {
            Connectie.Open();
            SqlCommand objSqlCommand = new SqlCommand("AddArtiest", Connectie);
            objSqlCommand.Parameters.AddWithValue("@naam", artiest.Naam);
            objSqlCommand.Parameters.AddWithValue("@url", artiest.Url);
            objSqlCommand.Parameters.AddWithValue("@biografie", artiest.Bio);
            objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objSqlCommand.ExecuteNonQuery();
            Connectie.Close();
        }

        public void ArtiestVerwijderen(Artiest artiest)
        {
            Connectie.Open();

            SqlCommand objSqlCommand = new SqlCommand("RemoveArtiestZonderLied", Connectie);
            objSqlCommand.Parameters.AddWithValue("@naam", artiest.Naam);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.ExecuteNonQuery();
            Connectie.Close();
        }

        /// <summary>
        /// Loaded van ComboBox jaren.
        /// </summary>
        /// <returns></returns>
        public DataTable GetArtiestenZonderLied()
        {


            Connectie.Close();
            Connectie.Open();
            DataTable DatableFilled = new DataTable();
            Lijst objLijst = new Lijst(DatableFilled);
            SqlCommand objSqlCommand = new SqlCommand("GetArtiestZonderLied", Connectie);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            using (SqlDataAdapter adapter = new SqlDataAdapter(objSqlCommand))
            {
                adapter.Fill(objLijst.DataTable);

                // Voor elk jaar word er een item toegevoegd aan de combobox die per jaar met 1 word verhoogd
                return objLijst.DataTable;
            }
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
            SqlCommand objSqlCommand = new SqlCommand("GetJaren", Connectie);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            using (SqlDataAdapter adapter = new SqlDataAdapter(objSqlCommand))
            {
                adapter.Fill(objLijst.DataTable);

                // Voor elk jaar word er een item toegevoegd aan de combobox die per jaar met 1 word verhoogd
                return objLijst.DataTable;
            }
        }

        public SqlCommand GetAllArtiesten()
        {
            Connectie.Close();
            Connectie.Open();
            DataTable DatableFilled = new DataTable();
            Lijst objLijst = new Lijst(DatableFilled);
            SqlCommand objSqlCommand = new SqlCommand("GetAllArtiesten", Connectie);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            using (SqlDataAdapter adapter = new SqlDataAdapter(objSqlCommand))
            {
                adapter.Fill(objLijst.DataTable);

                // Voor elk jaar word er een item toegevoegd aan de combobox die per jaar met 1 word verhoogd
                return objSqlCommand;
            }
        }

        public void ArtiestAanpassen(Artiest artiest)
        {
            Connectie.Open();
            SqlCommand objSqlcommand = new SqlCommand("UpdateArtiest", Connectie);
            objSqlcommand.CommandType = CommandType.StoredProcedure;
            objSqlcommand.Parameters.AddWithValue("@artiest", artiest.SelectedArtiest);

            if (artiest.ArtiestLenght == 0)
            {
                objSqlcommand.Parameters.AddWithValue("@naam", artiest.SelectedArtiest);
            }
            if (artiest.ArtiestLenght != 0)
            {
                objSqlcommand.Parameters.AddWithValue("@naam", artiest.Naam);
            }
            if (artiest.UrlLenght == 0)
            {
                objSqlcommand.Parameters.AddWithValue("@url", DBNull.Value);
            }
            if (artiest.UrlLenght != 0)
            {
                objSqlcommand.Parameters.AddWithValue("@url", artiest.Url);
            }
            if (artiest.BioLenght == 0)
            {
                objSqlcommand.Parameters.AddWithValue("@biografie", DBNull.Value);
            }
            if (artiest.BioLenght != 0)
            {
                objSqlcommand.Parameters.AddWithValue("@biografie", artiest.Bio);
            }
            objSqlcommand.ExecuteNonQuery();
        }
        }
    }
