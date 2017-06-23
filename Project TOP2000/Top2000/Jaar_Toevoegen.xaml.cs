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
using Microsoft.Win32;

namespace Top2000
{
   
    /// <summary>
    /// Interaction logic for Jaar_Toevoegen.xaml
    /// </summary>
    public partial class Jaar_Toevoegen : Window
    {
        Artiest objArtiest = new Artiest();
        public List<string> Positie = new List<string>();
        public List<string> Songid = new List<string>();
        public List<string> Jaar = new List<string>();
        public Jaar_Toevoegen()
        {
            InitializeComponent();
        }

        private void BTNUploaden_Click(object sender, RoutedEventArgs e)
        {

            //System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Wilt u dit jaar toevoegen?", "Zeker weten?", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {

                try
                {
                    for (int i = 0; i < Positie.Count; i++)
                    {
                        objArtiest.Posities = Convert.ToInt32(Positie[i]);
                        objArtiest.Songids = Convert.ToInt32(Songid[i]);
                        objArtiest.Jaars = Convert.ToInt32(Jaar[i]);

                        StoredProcedures Jaartoevoegen = new StoredProcedures();
                        Jaartoevoegen.JaarToevoegen(objArtiest);

                 
                    }
                   
                }
                catch
                {
                    MessageBox.Show("het gokezen bestand is niet geldig (kijk help)");
                }

                MessageBox.Show("Jaar Toegevoegd!!");
            }
            if (messageBoxResult == MessageBoxResult.No)
            {
                MessageBox.Show("Jaar niet Toegevoegd!!");
            }
        }

        private void BTNTerug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void BTNHelp_Click(object sender, RoutedEventArgs e)
        {
            Help newhelp = new Help();
            newhelp.Show();
        }
        
        /// <summary>
        /// word = string geseperate bij komma
        /// line = hele regel 
        /// lines is alle regels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFileUploaden_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Title = "Open Tekst bestand";
            Dialog.Filter = "TXT files|*.txt";
            Dialog.InitialDirectory = @"C:\";



            ///als hij het explorer scherm kan openen
            if (Dialog.ShowDialog() == true)
            {
                ///lines heeft nu alle regels uit het gekozen bestand
                        List<string[]> Lines = File.ReadLines(Dialog.FileName).Select(line => line.Split(',')).ToList();

                        int counter = 0;

                ///voor elk woord in de regel
                foreach (var line in Lines)
                {

                    ///message is nu de string die het woord bevat

                    if (counter == 0)
                    {
                        var message = string.Join(Environment.NewLine, line[0]);

                        Positie.Add(message);
                        counter = 1;
                    }
                
                    if (counter == 1)
                    {
                        var message = string.Join(Environment.NewLine, line[1]);

                        Songid.Add(message);
                        counter = 2;
                    }
                    if (counter == 2)
                    {
                        var message = string.Join(Environment.NewLine, line[2]);

                        Jaar.Add(message);
                        counter = 0;

                    }

                }

            }
        }
    }
}