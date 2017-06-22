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

namespace Top2000
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        Lijst lijst = new Lijst();
        Artiest objartiest = new Artiest();
        

        public string openclosed = "Closed";

        public int val = 0;


        public MainWindow()
        {
            InitializeComponent();
            Loaded();
            TBSearch.TextChanged += new TextChangedEventHandler(TextChanged);
            val = TBSearch.Text.Length;
            lijst.Above = 0;
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

        
        public void Loaded()
        {
            VulComboBox();
            CBJaar.SelectedIndex = 0;
            Top10.Background = Brushes.White;
        }
        private void CBJaar_changed(object sender, System.EventArgs e)
        {
            lijst.Above = 0;
            GetTop10();
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
            StoredProcedures ProcedureArtiestBewerken = new StoredProcedures();
            ProcedureArtiestBewerken.ArtiestBewerken(objartiest);
            Artiest_Bewerken objArtiestBewerken = new Artiest_Bewerken();
            objArtiestBewerken.Show();
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
            lijst.Above = 0;
            GetTop10();
        }

        public void BtnVorige_Click(object sender, RoutedEventArgs e)
        {
            if (lijst.Above > 0)
            {
                lijst.Above -= 10;
            }
            GetTop10();
        }

        public void BtnVolgende_Click(object sender, RoutedEventArgs e)
        {

            if (lijst.Above < 1990){
                lijst.Above += 10;
            }
            GetTop10();
        }

        public void BtnLaatste_Click(object sender, RoutedEventArgs e)
        {
            lijst.Above = 1990;
            GetTop10();
        }

        private void TextChanged(object Sender, TextChangedEventArgs e)
        {
             

            lijst.Above  = 0;
            if (TBSearch.Text.Length >= 3 && !(TBSearch.Text == "Search"))
            {
                GetTop10Search();
            }

            if (val != 0 && TBSearch.Text.Length < val)
            {
                GetTop10Search();
            }

            if (TBSearch.Text.Length == 0 && !(TBSearch.Text == "Search") || TBSearch.Text == "Search...")
            {
                GetTop10();
            }
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
        
        /// <summary>
        /// Get top 10 Search
        /// </summary>
        public void GetTop10Search()
        {
            // Variabelen
            int SearchLength = TBSearch.Text.Length;
            string SearchInput = TBSearch.Text;
            //int above = 0;
            string SelectedJaartal = CBJaar.SelectedValue.ToString();
            

            // Variabelen op sturen naaar de businesslayer
            Lijst objBusinessLayer = new Lijst();
            objBusinessLayer.LijstLengte = SearchLength;
            objBusinessLayer.SearchInput = SearchInput;
            objBusinessLayer.Above = lijst.Above;
            objBusinessLayer.SelectedJaartal = SelectedJaartal;

            // Top10 vullen
            //objBusinessLayer.DataViewTop10 = Top10.DataContext;
            Top10.DataContext = objBusinessLayer.DataViewTop10;

            StoredProcedures ProcedureGetTop10Search = new StoredProcedures();
            ProcedureGetTop10Search.GetTop10Search(objBusinessLayer);

            Top10.DataContext = ProcedureGetTop10Search.GetTop10Search(objBusinessLayer);
        }

        /// <summary>
        /// Get top 10
        /// </summary>
        public void GetTop10()
        {

            Lijst objBusinessLayer = new Lijst();
            // Variabelen
            //int SearchLength = TBSearch.Text.Length;
            //string SearchInput = TBSearch.Text;
           // int above = 0;


            string Jaartal = CBJaar.SelectedValue.ToString();
            objBusinessLayer.SelectedJaartal = Jaartal;

            // Variabelen op sturen naar de businesslayer
            objBusinessLayer.Above = lijst.Above;

            // Top10 vullen
            //objBusinessLayer.DataViewTop10 = Top10.DataContext;
            
            //^ dit moet geen null zijn als je er doorheen bent gelopen.

            StoredProcedures ProcedureGetTop10 = new StoredProcedures();
            ProcedureGetTop10.GetTop10(objBusinessLayer);

            Top10.DataContext = ProcedureGetTop10.GetTop10(objBusinessLayer);
        }

        /// <summary>
        /// Before MyFunction() changed to VulComboBox()
        /// </summary>
        public void VulComboBox()
        {
            StoredProcedures ProcedureVulBox = new StoredProcedures();
            ProcedureVulBox.FillComboboxWithYears();
            //for (int i = 0; i < dt.Rows.Count; i++)
            for (int i = 0; i < ProcedureVulBox.FillComboboxWithYears().Rows.Count; i++)
            {
                CBJaar.Items.Add(ProcedureVulBox.FillComboboxWithYears().Rows[i][0].ToString());
                //CBJaar.Items.Add(dt.Rows[i][0].ToString())
            }
        }
    }  
}