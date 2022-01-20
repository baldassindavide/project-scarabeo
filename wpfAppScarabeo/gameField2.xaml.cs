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
        DatiCondivisi d;

        string bufferLettera;
        List<Button> ListBufferButton;

        Button[] arrayButtonsLettere;
        List<Button> listButtonsPressed;
        string parola; // vincolo: creare la parola in linea
        public gameField2()
        {
            InitializeComponent();
            m = new Manager();
            trd = new Thread(new ThreadStart(m.managerActions));
            d = new DatiCondivisi();
            trd.IsBackground = true;
            trd.Start();


            arrayButtonsLettere = new Button[] { bl1, bl2, bl3, bl4, bl5, bl6, bl7, bl8 }; // imposto array dei bottoni lettera
            listButtonsPressed = new List<Button>(); // max 8 elementi dato che ci sono 8 lettere disponibili
            ListBufferButton = new List<Button>(); // bottoni delle 8 lettere premuti

            foreach (Button b in arrayButtonsLettere)
            {
                b.Content = estraiLettera();
            }

        }

        public string estraiLettera()
        {
            
            Random r = new Random(DateTime.Now.Millisecond);
            Lettera randomLetter = d.getListLettereSacchetto()[r.Next(d.getListLettereSacchetto().Count - 1)]; // valore massimo = lunghezza lista
            d.removeLetteraFromSacchetto(randomLetter);
            return randomLetter.toString();

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
                    foreach (Button b in listButtonsPressed)
                    {
                        b.Background = Brushes.Green;
                    }
                    trovato = true;
                }
            }
            parola = "";

            if (!trovato)
                MessageBox.Show("non trovato :(");

            resetField(!trovato,false); // resetta solo gli 8 tasti personali
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button source = sender as Button;
            if (bufferLettera != "")
            {
                source.Content = bufferLettera;
                listButtonsPressed.Add(source);

                parola += bufferLettera; // formo la parola
            }

           

            bufferLettera = ""; // svuoto il buffer
        }
        private void ButtonLetter_Click(object sender, RoutedEventArgs e)
        {
            Button source = sender as Button;
            if (!source.Content.ToString().Equals(""))
            {
                bufferLettera = source.Content.ToString();
                source.Visibility = Visibility.Hidden;
                ListBufferButton.Add(source);
            }
        }

        private void bReset_Click(object sender, RoutedEventArgs e)
        {
            foreach(Button b in arrayButtonsLettere)
            {
                d.getListLettereSacchetto().Add(new Lettera(b.Content.ToString(),1));
            }
            resetField(true, true);
            
        }

        private void resetField(bool all, bool reset) // se all è false, resetta solo le 8 lettere personali
        {
            if (all)
            {
                foreach (Button b in listButtonsPressed)
                {
                    b.Content = "";
                    foreach (Button button in arrayButtonsLettere)
                        button.Visibility = Visibility.Visible;
                }
            }

            if (reset)
                foreach (Button b in arrayButtonsLettere)
                    b.Content = estraiLettera();

            foreach (Button b in arrayButtonsLettere)
            {
                b.Visibility = Visibility.Visible;
                if(!all)
                for (int i = 0; i < ListBufferButton.Count; i++)
                    if (b == ListBufferButton[i])
                        b.Content = estraiLettera();
            }


            listButtonsPressed.Clear(); // pulisco la lista
            ListBufferButton.Clear();
            parola = "";
        }

        private void btnResa_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Sei sicuro di arrenderti?", "Resa", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                this.Close();
        }
    }
}
