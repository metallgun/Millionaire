using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента пустой страницы см. по адресу http://go.microsoft.com/fwlink/?LinkID=390556

namespace Milionaire
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class NewgamePage : Page
    {
        List<Button> answerButtons = new List<Button>();
        List<Question> easyQuestions, mediumQuestions, hardQuestions;

        public NewgamePage()
        {
            this.InitializeComponent();

            answerButtons.Add(answerButton1);
            answerButtons.Add(answerButton2);
            answerButtons.Add(answerButton3);
            answerButtons.Add(answerButton4);

            foreach (Button b in answerButtons)
            {
                b.Background = new SolidColorBrush(Windows.UI.Colors.Orange);
                b.Background.Opacity = 0;
                b.Visibility = Visibility.Visible;
                b.Click += (sender, e) =>
                    {
                        foreach (Button but in answerButtons)
                        {
                            //but.Background = new SolidColorBrush(Windows.UI.Colors.Black);
                            but.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                            but.Background.Opacity = 0;
                            //but.FontStyle = Windows.UI.Text.FontStyle.Normal;
                        }

                        //b.Background = new SolidColorBrush(Windows.UI.Colors.Orange);
                        b.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
                        b.Background.Opacity = 1;
                        //b.FontStyle = Windows.UI.Text.FontStyle.Italic;
                    };
            };
            //Легкие

        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //var pc = (Player)e.Parameter;
            //nameText.Text = "Имя - "+pc.Name;
            //scoreText.Text = "Очки - "+pc.Score.ToString();
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            string correctAnswer = "";   //для проверки пока не добавлен вопрос
            Brush orange = new SolidColorBrush(Windows.UI.Colors.Orange);
            foreach (Button b in answerButtons)
            {
                if (b.Background.Opacity == 1)
                {
                    if (b.Content.ToString() == correctAnswer)
                    {
                        b.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    }
                    else
                    {
                        b.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                        foreach (Button b1 in answerButtons)
                        {
                            if (b1.Content.ToString() == correctAnswer)
                            {
                                b1.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                            }
                        }
                    }
                }
            }
        }

        private void _5050Button_Click(object sender, RoutedEventArgs e)
        {
            string correctAnswer = "";  //для проверки пока не добавлен вопрос
            int count = 0;
            while (count < 2)
            {
                int rnd = new Random().Next(3);
                if (answerButtons[rnd].Content.ToString() != correctAnswer && answerButtons[rnd].IsEnabled)
                {
                    answerButtons[rnd].Visibility = Visibility.Collapsed;
                    count++;
                }
            }
        }
    }
}

