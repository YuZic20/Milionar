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
    /// Interakční logika pro Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        List<Button> LOfButtons = new List<Button>();
        int LastButtonPr = 0;
        int LastButtonPrCo = 1;
        SolidColorBrush DefalutBackColor = Brushes.DarkCyan;
        SolidColorBrush DefalutActiveColor = Brushes.Orange;
        public Game()
        {
            
            InitializeComponent();
            LOfButtons.Add(Button1);
            LOfButtons.Add(Button2);
            LOfButtons.Add(Button3);
            LOfButtons.Add(Button4);
            LOfButtons[0].Background = DefalutBackColor;
            LOfButtons[1].Background = DefalutBackColor;
            LOfButtons[2].Background = DefalutBackColor;
            LOfButtons[3].Background = DefalutBackColor;
        }
        


        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            ColorChangeAndStart(1);
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ColorChangeAndStart(2);
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            ColorChangeAndStart(3);
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            ColorChangeAndStart(4);
        }
        private void ColorChangeAndStart (int number)
        {
            if (LastButtonPr == number)
            {
                LOfButtons[number-1].Background = DefalutBackColor;
                LastButtonPrCo = 1;
                //do stuff
                LastButtonPr = 0;
            }
            else
            {
                LOfButtons[number - 1].Background = DefalutActiveColor;
                LOfButtons[LastButtonPrCo - 1].Background = DefalutBackColor;
                LastButtonPr = number;
                LastButtonPrCo = number;
            }
        }
        //https://opentdb.com/
    }
}
