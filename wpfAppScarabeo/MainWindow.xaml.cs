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

namespace wpfAppScarabeo
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int X;
        private int Y;
        public MainWindow()
        {
            InitializeComponent();
            Label label = new Label();
            label.Width = 100;
            label.Height = 30;

            this.Content = label;

            this.Loaded += delegate
            {
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Elapsed += delegate
                {
                    this.Dispatcher.Invoke(new Action(delegate
                    {
                        Mouse.Capture(this);
                        Point pointToWindow = Mouse.GetPosition(this);
                        Point pointToScreen = PointToScreen(pointToWindow);
                        label.Content = pointToScreen.ToString();
                        Mouse.Capture(null);
                    }));
                };
                timer.Interval = 1;
                timer.Start();
            };
        }

        
    }
}
