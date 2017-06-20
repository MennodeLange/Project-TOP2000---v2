using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using BusinessLayer;
using DataLayer;

namespace Top2000
{
    /// <summary>
    /// Interaction logic for Artiest_Bewerken.xaml
    /// </summary>
    public partial class Artiest_Bewerken : Window
    { 
       

        private void BTNAanpassen_Click(object sender, RoutedEventArgs e)
        {
            string ArtiestUrl = TBArtiestUrl.Text;
            int UrlLengte = TBArtiestUrl.Text.Length;
            int BioLengte = TBArtiestBiografie.Text.Length;
            string BioText = TBArtiestBiografie.Text;
            string ArtiestNaam = TBArtiestNaam.Text;

            Artiest artiest = new Artiest();
            artiest.Bio = BioText;
            artiest.Naam = ArtiestNaam;
            artiest.Url = ArtiestUrl;


        }

        private void BTNTerug_Click(object sender, RoutedEventArgs e)
        {  
        

    
        }
    }
}
