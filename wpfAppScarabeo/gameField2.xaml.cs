using System;
using System.Collections.Generic;
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
        public gameField2()
        {
            InitializeComponent();
            m = new Manager();
            trd = new Thread(new ThreadStart(Manager.managerActions));
            trd.IsBackground = true;
            trd.Start();

        }

        private void btnInvia_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("bottone");
        }
    }
}
