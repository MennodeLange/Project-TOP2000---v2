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

// Import using
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

// Own using
using BusinessLayer;
using DataLayer;

namespace Top2000
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        public string openclosed = "Closed";

        public MainWindow()
        {
            InitializeComponent();
        }
        
        public void MenuH_Click(object sender, RoutedEventArgs e)
        {
            if (openclosed == "Closed")
            {
                MenuCon.Height = 190;
                openclosed = "Open";
            }
            else
            {
                MenuCon.Height = 30;
                openclosed = "Closed";
            }
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
            TBSearch.Text = "";
        }
        /// <summary>
        /// Functie die word aangeroepen waneer de search textbox niet langer gefocussed is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LostFocusE(object sender, RoutedEventArgs e)
        {
            TBSearch.Text = "Search...";
        }
        
        public void GetTop10Search()
        {
            int SearchLength = TBSearch.Text.Length;
            string SearchInput = TBSearch.Text;
            int above = 0;
            string SelectedJaartal = CBJaar.SelectedValue.ToString();
            //Top10.DataContext = objDataSet;
            //Top10.DataContext = ds.Tables[0].DefaultView;

            Lijst objBusinessLayer = new Lijst();
            objBusinessLayer.LijstLengte = SearchLength;
            objBusinessLayer.SearchInput = SearchInput;
            objBusinessLayer.Above = above;
            objBusinessLayer.SelectedJaartal = SelectedJaartal;
            Top10.DataContext = objBusinessLayer.DataSetTop10;
        }

        public void GetTop10()
        {
           
        }
    }  
}
