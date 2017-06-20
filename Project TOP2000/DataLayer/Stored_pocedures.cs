using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

using BusinessLayer;

namespace DataLayer
{
     public class Stored_pocedures 
    {
        private int val;

        public int Val
        {
            get { return val; }
            set { val = value; }
        }

        public Stored_pocedures(int _val)
        {
            this.val = _val;
        }

        public void GetTop10Search(string _val)
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
    }
}