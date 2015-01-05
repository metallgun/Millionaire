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
using System.Threading.Tasks;
using System.Threading;

// Документацию по шаблону элемента пустой страницы см. по адресу http://go.microsoft.com/fwlink/?LinkID=390556

namespace Milionaire
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class NewgamePage : Page
    {
        List<Button> answerButtons = new List<Button>();
        List<Question> questionList;
        string correctAnswer;

        public NewgamePage()
        {
            this.InitializeComponent();
            questionList = new List<Question>();
            Question.PopulateQuestionList(questionList);
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
                    b.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
                    b.Background.Opacity = 1;
                };
                //При изменении (сразу после клика) происходит обраобтка - проверка на правильность
            }
            FillFeilds(1);
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var pc = (Player)e.Parameter;
            nameText.Text = pc.Name;
            scoreText.Text = pc.Score.ToString();
        }

        //Заполнение полей
        private void FillFeilds(int difficulty)
        {
            foreach (Button b in answerButtons)
            {
                b.Content = null;
                b.Background.Opacity = 0;
                b.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
            }
            Question currentQuestion = new Question();
            var query = questionList.Where(e => e.Difficulty == difficulty);
            currentQuestion = query.ToList()[(new Random()).Next(query.ToList().Count)];
            questionList.Remove(currentQuestion);
            questionText.Text = currentQuestion.QuestionName;
            List<string> wrong = new List<string>();
            wrong.Add(currentQuestion.WrongAnswer1);
            wrong.Add(currentQuestion.WrongAnswer2);
            wrong.Add(currentQuestion.WrongAnswer3);
            answerButtons[(new Random()).Next(answerButtons.Count)].Content = currentQuestion.RightAnswer;
            foreach (Button b in answerButtons)
            {
                if (b.Content==null)
                {
                    b.Content = wrong[(new Random()).Next(wrong.Count)];
                    wrong.Remove(b.Content.ToString());
                }
            }
            correctAnswer = currentQuestion.RightAnswer;
        }

        private void _5050button1_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            while (count < 2)
            {
                int rnd = new Random().Next(answerButtons.Count);
                if (answerButtons[rnd].Content.ToString() != correctAnswer && answerButtons[rnd].IsEnabled)
                {
                    answerButtons[rnd].Visibility = Visibility.Collapsed;
                    answerButtons[rnd].IsEnabled = false;
                    count++;
                }
            }
        }

        private void Clicks()
        {
            foreach (Button b in answerButtons)
            {
                b.Background = new SolidColorBrush(Windows.UI.Colors.Orange);
                b.Background.Opacity = 0;
                b.Visibility = Visibility.Visible;
                b.Click += (sender, e) =>
                {
                    //b.ClickMode = ClickMode.Press;
                    //foreach (Button but in answerButtons)
                    //{
                    //    but.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                    //    but.Background.Opacity = 0;
                    //}
                    b.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
                    b.Background.Opacity = 1;
                    
                    //if (b.Background.Opacity == 1)
                    //{
                    //    if (b.Content.ToString() == correctAnswer)
                    //    {
                    //        b.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                            
                    //        Sleep(5000);
                    //        FillFeilds(1);
                    //    }
                    //    else
                    //    {
                    //        b.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    //        foreach (Button b1 in answerButtons)
                    //        {
                    //            if (b1.Content.ToString() == correctAnswer)
                    //            {
                    //                b1.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    //            }
                    //        }
                    //    }
                    //}
                };
            }
        }



        private void Sleep(int ms)
        {
            DateTime now = DateTime.Now;
            DateTime endOfSleep = now.AddMilliseconds(ms);
            while (DateTime.Now < endOfSleep) { }
        }
    }
}

