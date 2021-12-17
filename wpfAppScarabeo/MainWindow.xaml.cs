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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfAppScarabeo
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Server s = new Server("1", 1);
            s.start();
        }

        private void bttConnect_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client(txtIp.Text, int.Parse(txtPort.Text), txtNickname.Text);
            client.requestConnection();
        }
    }
}
