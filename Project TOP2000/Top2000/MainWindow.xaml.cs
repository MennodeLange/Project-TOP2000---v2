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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

using BusinessLayer;
using DataLayer;
namespace Top2000
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
     
        public MainWindow()
        {
            InitializeComponent();
        }

        
        public void MenuH_Click(object sender, RoutedEventArgs e)
        {
        }

   

        private void CBJaar_changed(object sender, System.EventArgs e)
        {
          

        }

        private void Artiest_Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            Artiest_Toevoegen Toevoegen = new Artiest_Toevoegen();
            Toevoegen.Show();
            this.Close();
        }

        private void Artiest_Verwijderen_Click(object sender, RoutedEventArgs e)
        {
            Artiest_Verwijderen Verwijderen = new Artiest_Verwijderen();
            Verwijderen.Show();
            this.Close();
        }

        private void Artiest_Bewerken_Click(object sender, RoutedEventArgs e)
        {
            Artiest_Bewerken Bewerken = new Artiest_Bewerken();
            Bewerken.Show();
            this.Close();
        }  

        private void Jaar_Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            Jaar_Toevoegen toevoegen = new Jaar_Toevoegen();
            toevoegen.Show();
            this.Close();
        }

        public void BtnEerste_Click(object sender, RoutedEventArgs e)
        {
        
        }

        public void BtnVorige_Click(object sender, RoutedEventArgs e)
        {
         
        }

        public void BtnVolgende_Click(object sender, RoutedEventArgs e)
        {
           
        }

        public void BtnLaatste_Click(object sender, RoutedEventArgs e)
        {
           
        }


        private void TextChanged(object Sender, TextChangedEventArgs e)
        {
          
        }

        /// <summary>
        /// Functie die word aangeroepen waneer de search textbox gefocussed is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GotFocusE(object sender, RoutedEventArgs e)
        {
           
        }
        /// <summary>
        /// Functie die word aangeroepen waneer de search textbox niet langer gefocussed is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LostFocusE(object sender, RoutedEventArgs e)
        {
            
        
        }



        public void GetTop10Search()
        {
           
        }

        public void GetTop10()
        {
           
         
        }

      
    }  
}
