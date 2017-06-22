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

namespace Top2000
{
    /// <summary>
    /// Interaction logic for Artiest_Bewerken.xaml
    /// </summary>
    public partial class Artiest_Bewerken : Window
    {
        public SqlConnection Connectie = new SqlConnection(ConfigurationManager.ConnectionStrings["TOP2000ConnectionString"].ConnectionString);
        Artiest objArtiest = new Artiest();

        public Artiest_Bewerken()
        {
            InitializeComponent();
            VulCBMetArtiesten();
        }

        private void BTNAanpassen_Click(object sender, RoutedEventArgs e)
        {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Wilt u de gegevens echt aanpassen?", "Zeker weten?", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (Connectie)
                        {
                            objArtiest.Naam = TBArtiestNaam.Text;
                            objArtiest.Url = TBArtiestUrl.Text;
                            objArtiest.Bio = TBArtiestBiografie.Text;
                            objArtiest.ArtiestLenght = TBArtiestNaam.Text.Length;
                            objArtiest.UrlLenght = TBArtiestUrl.Text.Length;
                            objArtiest.BioLenght = TBArtiestBiografie.Text.Length;
                            objArtiest.SelectedArtiest = CBArtiestNaam.SelectedValue.ToString();

                            StoredProcedures UpdateArtiest = new StoredProcedures();

                            UpdateArtiest.ArtiestAanpassen(objArtiest);

                            MessageBox.Show("Artiest is succesvol geupdate!");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Artiest kon niet worden bijgewerkt");
                    }
                    CBArtiestNaam.SelectedItem = 0;
                    TBArtiestNaam.Text = null;
                    TBArtiestUrl.Text = null;
                    TBArtiestBiografie.Text = null;
                }
                if (messageBoxResult == MessageBoxResult.No)
                {
                    MessageBox.Show("Niet bijgewerkt!");
                
                }
        }


        private void BTNTerug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        /// <summary>
        /// Inplaats van Loaded -> Vul artiestbox
        /// </summary>
        public void VulCBMetArtiesten()
        {
            try
            {
                StoredProcedures ProcedureVulBoxArtiest = new StoredProcedures();
                ProcedureVulBoxArtiest.GetAllArtiesten();
                //oude loop for (int i = 0; i < dt.Rows.Count; i++)

                using (SqlDataAdapter adapter = new SqlDataAdapter(ProcedureVulBoxArtiest.GetAllArtiesten()))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CBArtiestNaam.Items.Add(dt.Rows[i][0].ToString());
                        i++;
                    }

                }
            }
            catch
            {
                MessageBox.Show("kan de gegevens niet ophalen");
            }
            CBArtiestNaam.SelectedIndex = 0;
        }
    }
}