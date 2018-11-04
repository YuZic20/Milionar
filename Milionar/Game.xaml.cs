using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using QuickType;

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
        List<Trivia> HardQ = new List<Trivia>();
        List<Trivia> Qestions = new List<Trivia>();
        List<Trivia> MediumQ = new List<Trivia>();
        Random rnd = new Random();
        private int GoodA = 0;
        private int Round = 0;
        private int ButtonPlace = 0;
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
            LoadTrivia();
            GamePlay();
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


        private void GamePlay()
        {
            GoodA = rnd.Next(0, 4);

            
            Qestion.Text = BaseToString(Qestions[Round].question);

            LOfButtons[GoodA].Content = BaseToString(Qestions[Round].correct_answer);
            for (int i = 0; i <4; i++)
            {
                if(i == GoodA)
                {
                    i++;
                }
                if (i == 4)
                {
                    break;
                }
                LOfButtons[i].Content = BaseToString(Qestions[Round].incorrect_answers.GetValue(ButtonPlace).ToString());
                ButtonPlace++;
            }
        }


        private string BaseToString (string encodedText)
        {
            var encodedTextBytes = Convert.FromBase64String(encodedText);

            string plainText = Encoding.UTF8.GetString(encodedTextBytes);

            return plainText;
        }

        private void LoadTrivia()
        {

            using (WebClient wc = new WebClient())
            {
                var Easy = wc.DownloadString("https://opentdb.com/api.php?amount=5&difficulty=easy&type=multiple&encode=base64");

                for (int i = 0; i < 5; i++)
                {
                    Trivia Qestion = new Trivia(Easy, i);
                    Qestions.Add(Qestion);
                }
            }
            using (WebClient wc = new WebClient())
            {
                var Medium = wc.DownloadString("https://opentdb.com/api.php?amount=5&difficulty=medium&type=multiple");

                for (int i = 0; i < 5; i++)
                {
                    Trivia Qestion = new Trivia(Medium, i);
                    Qestions.Add(Qestion);
                }
            }

            using (WebClient wc = new WebClient())
            {
                
                var Hard = wc.DownloadString("https://opentdb.com/api.php?amount=5&difficulty=hard&type=multiple");

                for (int i =0; i < 5; i++)
                {
                    Trivia Qestion = new Trivia(Hard, i);
                    Qestions.Add(Qestion);
                }
               

            }

        }
        //https://opentdb.com/
    }
}
