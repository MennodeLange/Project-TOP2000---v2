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
    public class Artiest
    {
        private string bio;

        public string Bio
        {
            get { return bio; }
            set { bio = value; }
        }
        private string naam;

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        //private string geboorteDatum;

        //public string GeboorteDatum
        //{
        //    get { return geboorteDatum; }
        //    set { geboorteDatum = value; }
        //}

       
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public Artiest()
        {

        }

        public Artiest(string _naam, string _bio, string _Url)
        {
            this.naam = _naam; 
            this.bio = _bio;
            this.Url = _Url;

        }
        public void Aanpassen()
        {

        }

    }
}
