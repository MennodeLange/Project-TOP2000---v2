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
using BusinessLayer;


using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace Top2000
{
    /// <summary>
    /// Interaction logic for Artiest_Toevoegen.xaml
    /// </summary>
    public partial class Artiest_Toevoegen : Window
    {
        Artiest objArtiest = new Artiest();
        public Artiest_Toevoegen()
        {

            InitializeComponent();
        }

        private void BTNTerug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void BTNAanpassen_Click(object sender, RoutedEventArgs e)
        {
          
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Wilt u deze artiest toevoegen?", "Zeker weten?", System.Windows.MessageBoxButton.YesNo);

            if (TBArtiestNaam.Text.Length == 0 || TBArtiestUrl.Text.Length == 0 || TBArtiestBiografie.Text.Length == 0)
            {
                MessageBox.Show("Vul eerst alle velden in");
            }
            else
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {

                    objArtiest.Naam = TBArtiestNaam.Text;
                    objArtiest.Url = TBArtiestUrl.Text;
                    objArtiest.Bio = TBArtiestBiografie.Text;
                    //hier moet de stored procedure methode uitgevoerd worden
                    StoredProcedures Procedures = new StoredProcedures();
                    Procedures.ArtiestToevoegen(objArtiest);

                    MessageBox.Show("Artiest Toegevoegd!");
                    TBArtiestNaam.Text = "";
                    TBArtiestUrl.Text = "";
                    TBArtiestBiografie.Text = "";
                }

                if (messageBoxResult == MessageBoxResult.No)
                {
                    MessageBox.Show("Artiest niet Toegevoegd!");

                }
            }
        }
    }
}
