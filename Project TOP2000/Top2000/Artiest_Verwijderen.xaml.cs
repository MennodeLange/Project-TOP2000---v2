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
    /// Interaction logic for Artiest_Verwijderen.xaml
    /// </summary>
    public partial class Artiest_Verwijderen : Window
    {

        public Artiest_Verwijderen()
        {
            InitializeComponent();
          
        }

        private void BTNVerwijderen_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BTNTerug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        
    }
}
