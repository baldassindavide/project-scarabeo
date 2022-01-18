using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpfAppScarabeo
{
    /// <summary>
    /// Logica di interazione per gameField2.xaml
    /// </summary>
    public partial class gameField2 : Window
    {
        Manager m;
        Thread trd;

        string bufferLettera;

        Button[] arrayButtonsLettere;
        List<Button> listButtonsPressed;
        List<string> parolaFormata; // vincolo: creare la parola in linea
        string parola;
        public gameField2()
        {
            InitializeComponent();
            m = new Manager();
            trd = new Thread(new ThreadStart(m.managerActions));
            trd.IsBackground = true;
            trd.Start();


            arrayButtonsLettere = new Button[] { bl1, bl2, bl3, bl4, bl5, bl6, bl7, bl8 }; // imposto array dei bottoni lettera
            listButtonsPressed = new List<Button>(); // max 8 elementi dato che ci sono 8 lettere disponibili
            parolaFormata = new List<string>();
        }
        private void btnInvia_Click(object sender, RoutedEventArgs e)
        {
            StreamReader file = new StreamReader("parole.txt");
            string line = "";
            bool trovato = false;
             // cerco la parola
            while ((line = file.ReadLine()) != null && trovato == false)
            {
                if (line.Equals(parola.ToLower()))
                {
                    MessageBox.Show("TORVAOSDOASODAe");
                    trovato = true;
                }
            }
            parola = "";

            if (!trovato) 
                MessageBox.Show("non trovato :(");

            bReset_Click(null,null); // 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button source = sender as Button;
            if(bufferLettera != "")
            {
                source.Content = bufferLettera;
                listButtonsPressed.Add(source);
                parolaFormata.Add(bufferLettera); // formo la parola

                parola += bufferLettera;
            }

            bufferLettera = ""; // svuoto il buffer
        }
        private void ButtonLetter_Click(object sender, RoutedEventArgs e)
        {
            Button source = sender as Button;
            if(!source.Content.ToString().Equals(""))
            {
                bufferLettera = source.Content.ToString();
                source.Visibility = Visibility.Hidden;
                
            }  
        }

        private void bReset_Click(object sender, RoutedEventArgs e)
        {
            foreach(Button b in arrayButtonsLettere)
            {
                b.Visibility = Visibility.Visible;
            }

            foreach(Button b in listButtonsPressed)
            {
                b.Content = "";
            }

            listButtonsPressed.Clear(); // pulisco la lista
            parolaFormata.Clear();
            parola = "";
        }
    }
}
