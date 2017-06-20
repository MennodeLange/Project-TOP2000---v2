using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class Song
    {
        private string songNaam;

        public string SongNaam
        {
            get { return songNaam; }
            set { songNaam = value; }
        }

        private int positie;

        public int Positie
        {
            get { return positie; }
            set { positie = value; }
        }

        private Artiest artiest;

        public Artiest Artiest
        {
            get { return artiest; }
            set { artiest = value; }
        }

        public Song()
        {

        }
        public Song(string _songNaam, int _positie, Artiest _artiest)
        {
            this.songNaam = _songNaam;
            this.positie = _positie;
            this.artiest = _artiest;
        }
        
    }
}
