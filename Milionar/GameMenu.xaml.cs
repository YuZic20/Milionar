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

namespace Milionar
{
    /// <summary>
    /// Interakční logika pro GameMenu.xaml
    /// </summary>
    public partial class GameMenu : Page
    {
        public GameMenu()
        {
            InitializeComponent();
        }
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            //((MainWindow)Application.Current.MainWindow).MainFrame.Source = new Uri ("Game.xaml");
            //MainWindow.MainFrame.Navigate(new Uri(url, UriKind.Relative));
            ((MainWindow)Application.Current.MainWindow).MainFrame.Source = (new Uri("Game.xaml", UriKind.Relative));
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
