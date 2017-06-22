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
    /// Interaction logic for Artiest_Verwijderen.xaml
    /// </summary>
    public partial class Artiest_Verwijderen : Window
    {
        Artiest objArtiest = new Artiest();
        public SqlConnection Connectie = new SqlConnection(ConfigurationManager.ConnectionStrings["Top2000ConnectionString"].ConnectionString);
        public Artiest_Verwijderen()
        {
            InitializeComponent();
            SchermGeladen();
        }

        private void BTNVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Wilt u deze artiest echt verwijderen?", "Zeker weten?", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {

                try
                    {
                        objArtiest.Naam = CBVerwijderArtiest.SelectedValue.ToString();

                        StoredProcedures procedure = new StoredProcedures();
                        procedure.ArtiestVerwijderen(objArtiest);
                        CBVerwijderArtiest.Items.RemoveAt
                        (CBVerwijderArtiest.Items.IndexOf(CBVerwijderArtiest.SelectedItem));

                        if (CBVerwijderArtiest.Items.Count == 0)
                        {
                            MessageBox.Show("Geen Artiesten om te verwijderen. \r\n U kunt alleen artiesten verijwderen wanneer ze geen liedjes hebben");
                        }

                    }
                catch
                {
                    MessageBox.Show(" U heeft geen artiest gekozen om te verwijderen");
                }

            }
            if (messageBoxResult == MessageBoxResult.No)
            {
                MessageBox.Show("Artiest niet verwijderd!");

            }
        }

        private void BTNTerug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        
        public void SchermGeladen()
        {
            try
            {
                StoredProcedures VulComboboxArtiestZonderLied = new StoredProcedures();
                VulComboboxArtiestZonderLied.GetArtiestenZonderLied();

                for (int i = 0; i < VulComboboxArtiestZonderLied.GetArtiestenZonderLied().Rows.Count; i++)
                {
                    CBVerwijderArtiest.Items.Add(VulComboboxArtiestZonderLied.GetArtiestenZonderLied().Rows[i][0].ToString());
                }

            }
            catch
            {
                MessageBox.Show("kan de gegevens niet ophalen");
            }

          
            //    using (Connectie)
            //    {

            //        Connectie.Open();
            //        SqlCommand cmd = new SqlCommand("GetArtiestenZonderLied", Connectie);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        {
            //            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            //            {
            //                DataTable dt = new DataTable();
            //                adapter.Fill(dt);
            //                string x = cmd.ExecuteReader().ToString();


            //                for (int i = 0; i < dt.Rows.Count; i++)
            //                {
            //                    CBVerwijderArtiest.Items.Add(dt.Rows[i][0].ToString());
            //                    i++;
            //                }

            //            }
            //        }
            //    }
            //}
            
        }
    }
}