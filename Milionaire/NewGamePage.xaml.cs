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
        Question currentQuestion;

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
                        foreach (Button but in answerButtons)
                        {
                            but.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                            but.Background.Opacity = 0;
                        }

                        b.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
                        b.Background.Opacity = 1;
                    };
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
                        Task.Delay(3000);
                        //Обновление
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

        //Заполнение полей
        private void FillFeilds(int difficulty)
        {
            foreach (Button b in answerButtons) b.Content = null;
            currentQuestion = new Question();
            var query = questionList.Where(e => e.Difficulty == difficulty);
            currentQuestion = query.ToList()[(new Random()).Next(query.ToList().Count - 1)];
            questionList.Remove(currentQuestion);
            questionText.Text = currentQuestion.QuestionName;
            List<string> wrong = new List<string>();
            wrong.Add(currentQuestion.WrongAnswer1);
            wrong.Add(currentQuestion.WrongAnswer2);
            wrong.Add(currentQuestion.WrongAnswer3);
            answerButtons[(new Random()).Next(3)].Content = currentQuestion.RightAnswer;
            foreach (Button b in answerButtons)
            {
                if (b.Content==null)
                {
                    b.Content = wrong[(new Random()).Next(wrong.Count - 1)];
                    wrong.Remove(b.Content.ToString());
                }
            }
        }
    }
}

