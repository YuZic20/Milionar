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
        int LastButtonPr = -1;
        int LastButtonPrCo = 1;
        int ButtonPress = -1;
        SolidColorBrush DefalutBackColor = Brushes.MidnightBlue;
        SolidColorBrush DefalutActiveColor = Brushes.Indigo;
        List<Trivia> HardQ = new List<Trivia>();
        List<Trivia> Qestions = new List<Trivia>();
        List<Trivia> MediumQ = new List<Trivia>();
        Random rnd = new Random();
        private int GoodA = 0;
        private int Round = 0;
        private int ButtonPlace = 0;
        private string Prize = "100$";
        private bool lost = false;
        private bool Won = false;
        private bool HelpHalfUsed = false;
        private bool HelpCrowdUsed = false;

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
            GameEchoData();
        }

        private void HelpCrow_Click(object sender, RoutedEventArgs e)
        {
            if(HelpCrowdUsed) { return; }
            int NumOfHidden = rnd.Next(0, 71);
            int secondA = 0;
            int thirdA = 0;

            while (true)
            {
                secondA = rnd.Next(0, 4);
                if (secondA != GoodA) { break; }
            }
            while (true)
            {
                thirdA = rnd.Next(0, 4);
                if (thirdA != GoodA|| thirdA != secondA) { break; }
            }

            if (NumOfHidden <= 10)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == GoodA ) { i++; }
                    if (i >= 4) { break; }
                    LOfButtons[i].Content = "";


                }
            }else if (NumOfHidden <= 30)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == GoodA || i == secondA) { i++; }
                    if (i == GoodA || i == secondA) { i++; }
                    if (i >= 4) { break; }
                    LOfButtons[i].Content = "";


                }
            }
            else if (NumOfHidden <= 70)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == GoodA || i == secondA || i == thirdA) { i++; }
                    if (i == GoodA || i == secondA || i == thirdA) { i++; }
                    if (i == GoodA || i == secondA || i == thirdA) { i++; }
                    if (i >= 4) { break; }
                    LOfButtons[i].Content = "";


                }
            }
            HelpCrowdUsed = true;
        }

        private void HelpHalf_Click(object sender, RoutedEventArgs e)
        {
            if (HelpHalfUsed) { return; }
            int secondA = 0;
            while (true)
            {
                secondA= rnd.Next(0, 4);
                if (secondA != GoodA) { break; }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i == GoodA || i == secondA) { i++; }
                if (i == GoodA || i == secondA) { i++; }
                if (i >= 4) { break; }
                LOfButtons[i].Content = "";
                

            }
            HelpHalfUsed = true;
        }


        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (lost) { Qestion.Text = "you lost"; return; }
            if (Won) { Qestion.Text = "you Won"; return; }
            ButtonPress = 1;
            ColorChangeAndStart(1);
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (lost) { Qestion.Text = "you lost"; return; }
            if (Won) { Qestion.Text = "you Won"; return; }
            ButtonPress = 2;
            ColorChangeAndStart(2);
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (lost) { Qestion.Text = "you lost"; return; }
            if (Won) { Qestion.Text = "you Won"; return; }
            ButtonPress = 3;
            ColorChangeAndStart(3);
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (lost) { Qestion.Text = "you lost"; return; }
            if (Won) { Qestion.Text = "you Won"; return; }
            ButtonPress = 4;
            ColorChangeAndStart(4);
        }
        private void ColorChangeAndStart (int number)
        {
            if (LastButtonPr == number)
            {
                LOfButtons[number - 1].Background = DefalutBackColor;
                LastButtonPrCo = 1;
                //do stuff
                
                GamePlay();
                GameEchoData();
                ButtonPress = -1;
                //color stuff
                LastButtonPr = -1;
                LastButtonPr = -1;
            }
            else
            {
                LOfButtons[number - 1].Background = DefalutActiveColor;
                if (LastButtonPr != -1) { LOfButtons[LastButtonPrCo - 1].Background = DefalutBackColor; }
                
                LastButtonPr = number;
                LastButtonPrCo = number;
            }
        }

        private void GamePlay()
        {
            
            if(ButtonPress == -1) { return; }
            if (ButtonPress == GoodA + 1)
            {
                
                Round++;
                if (Round == 14) { Won = true; }
                AddPrize();
            }
            else
            {
                lost = true;
            }
        }
        private void GameEchoData()
        {
            GoodA = rnd.Next(0, 4);
            PrizeUi.Content = Prize;
            Progress.Value = Round + 1;
            Qestion.Text = BaseToString(Qestions[Round].question);

            //LOfButtons[GoodA].Background = DefalutActiveColor; //debug 

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
            ButtonPlace = 0;
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
                var Medium = wc.DownloadString("https://opentdb.com/api.php?amount=5&difficulty=medium&type=multiple&encode=base64");

                for (int i = 0; i < 5; i++)
                {
                    Trivia Qestion = new Trivia(Medium, i);
                    Qestions.Add(Qestion);
                }
            }

            using (WebClient wc = new WebClient())
            {
                
                var Hard = wc.DownloadString("https://opentdb.com/api.php?amount=5&difficulty=hard&type=multiple&encode=base64");

                for (int i =0; i < 5; i++)
                {
                    Trivia Qestion = new Trivia(Hard, i);
                    Qestions.Add(Qestion);
                }
               

            }

        }

        private void AddPrize()
        {
            if (Round == 0)
            {
                Prize = "100$";
            }
            else if (Round == 1)
            {
                Prize = "200$";
            }
            else if (Round == 2)
            {
                Prize = "300$";
            }
            else if (Round == 3)
            {
                Prize = "500$";
            }
            else if (Round == 4)
            {
                Prize = "1,000$";
            }
            else if (Round == 5)
            {
                Prize = "2,000$";
            }
            else if (Round == 6)
            {
                Prize = "4,000$";
            }
            else if (Round == 7)
            {
                Prize = "8,000$";
            }
            else if (Round == 8)
            {
                Prize = "16,000$";
            }
            else if (Round == 9)
            {
                Prize = "32,000$";
            }
            else if (Round == 10)
            {
                Prize = "64,000$";
            }
            else if (Round == 11)
            {
                Prize = "125,000$";
            }
            else if (Round == 12)
            {
                Prize = "250,000$";
            }
            else if (Round == 13)
            {
                Prize = "500,000$";
            }
            else if (Round == 14)
            {
                Prize = "1,000,000$";
            }
            
        }

        


        //https://opentdb.com/
    }
}
