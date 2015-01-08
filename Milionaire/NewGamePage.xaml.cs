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
using Windows.UI.Xaml.Shapes;
using System.Threading.Tasks;
using System.Threading;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;

// Документацию по шаблону элемента пустой страницы см. по адресу http://go.microsoft.com/fwlink/?LinkID=390556

namespace Milionaire
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class NewgamePage : Page
    {
        List<Button> answerButtons = new List<Button>();
        List<Rectangle> rectList = new List<Rectangle>();
        List<Question> questionList;
        int currentDifficulty;
        Player player;
        bool checkring = false;
        int numberofquestions;
        string correctAnswer;

        public NewgamePage()
        {
            

            this.InitializeComponent();

            phoneDialog.Visibility = Visibility.Collapsed;

            questionList = new List<Question>();
            Question.PopulateQuestionList(questionList);
            answerButtons.Add(answerButton1);
            answerButtons.Add(answerButton2);
            answerButtons.Add(answerButton3);
            answerButtons.Add(answerButton4);
            rectList.Add(aud1);
            rectList.Add(aud2);
            rectList.Add(aud3);
            rectList.Add(aud4);

            foreach (Button b in answerButtons)
            {
                b.Background = new SolidColorBrush(Windows.UI.Colors.Orange);
                b.Background.Opacity = 0;
                b.Visibility = Visibility.Visible;

                b.Click += (sender, e) =>
                {
                    foreach (var a in rectList)
                    {
                        a.Visibility = Visibility.Collapsed;
                    }
                    b.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
                    b.Background.Opacity = 1;
                    //Проверка правильности НЕ РАБОТАЕТ!!!
                    if (b.Background.Opacity == 1)
                    {
                        //Правильный ответ
                        if (b.Content.ToString() == correctAnswer)
                        {
                            Color(b);
                            //b.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                            //Sleep(3000);
                            AddingScore();
                            FillFeilds(1);
                            if (checkring) phoneDialog.Visibility = Visibility.Collapsed;
                        }
                        //Неправильный ответ
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
                            //await WriteScoreToFile(Container.Score);
                            //Container.Name = player.Name;
                            Frame.Navigate(typeof(FinishGamePage));
                        }
                    }
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
            player = (Player)e.Parameter;
            nameText.Text = player.Name;
            scoreText.Text = player.Score.ToString();
            if (!Container._5050)
            {
                _5050button.Visibility = Visibility.Collapsed;
                _5050button1.Visibility = Visibility.Collapsed;
                _5050XImage.Visibility = Visibility.Visible;
            }
            if (!Container.Ring)
            {
                ringbutton.Visibility = Visibility.Collapsed;
                ringButton.Visibility = Visibility.Collapsed;
                ringbuttonX.Visibility = Visibility.Visible;
            }
            if (!Container.Aud)
            {
                audbutton.Visibility = Visibility.Collapsed;
                audButton.Visibility = Visibility.Collapsed;
                audXImage.Visibility = Visibility.Visible;
            }
        }

        private async void Color(Button button)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    //button.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                });
            //Sleep(3000);
        }

        //Заполнение полей

        // 5 easy 5 medium 4 hard 1 million
        private void FillFeilds(int difficulty)
        {
            if (numberofquestions == 0) numberofquestions = Container.Quest;
            if (numberofquestions >= 0 && numberofquestions <= 4) difficulty = 1;
            if (numberofquestions >= 5 && numberofquestions <= 9) difficulty = 2;
            if (numberofquestions >= 10 && numberofquestions <= 13) difficulty = 3;
            if (numberofquestions == 14)
            {
                difficulty = 4;
                ringbutton.Visibility = Visibility.Collapsed;
                ringbuttonX.Visibility = Visibility.Visible;
                ringButton.Visibility = Visibility.Collapsed;
                _5050button.Visibility = Visibility.Collapsed;
                _5050button1.Visibility = Visibility.Collapsed;
                _5050XImage.Visibility = Visibility.Visible;
                audbutton.Visibility = Visibility.Collapsed;
                audButton.Visibility = Visibility.Collapsed;
                audXImage.Visibility = Visibility.Visible;
            }

            foreach (Button b in answerButtons)
            {
                b.IsEnabled = true;
                b.Visibility = Visibility.Visible;
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
            currentDifficulty = currentQuestion.Difficulty;
            numberofquestions += 1;
        }

        private void AddingScore()
        {
            if (player.Score == 0)
                player.Score = 100;
            else if (player.Score >= 100 && player.Score < 300)
                player.Score += 100;
            else if (player.Score == 300)
                player.Score = 500;
            else if ((player.Score >= 500 && player.Score < 64000) || (player.Score >= 125000 && player.Score < 1000000))
                player.Score = player.Score * 2;
            else player.Score = 125000;
            scoreText.Text = player.Score.ToString();
            if (player.Score == 1000 || player.Score == 32000)
            {
                Container.Score = player.Score;
                Container.Quest = numberofquestions;
                Frame.Navigate(typeof(ProgressPage), player.Score);
            }
            if (player.Score == 1000000)
            {
                Container.Score = player.Score;
                Container.Quest = numberofquestions;
                Frame.Navigate(typeof(FinishGamePage));
            }
        }

        private async Task WriteScoreToFile(int score)
        {
            //создаем массив очков
            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes((score.ToString()).ToCharArray());

            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;

            //создаем папку
            var playerFolder = await local.CreateFolderAsync("playerFolder", CreationCollisionOption.OpenIfExists);
            //создаем файл
            string filename = player.Name + "File.txt";
            var file = await playerFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

            //пишем очки
            using (var s = await file.OpenStreamForWriteAsync())
            {
                s.Write(fileBytes, 0, fileBytes.Length);
            }
        }

        private void Sleep(int ms)
        {
            DateTime now = DateTime.Now;
            DateTime endOfSleep = now.AddMilliseconds(ms);
            while (DateTime.Now < endOfSleep) { }
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
                    rectList[rnd].Visibility = Visibility.Collapsed;
                    count++;
                }
            }
            _5050button1.IsEnabled = false;
            _5050button.Visibility = Visibility.Collapsed;
            _5050XImage.Visibility = Visibility.Visible;
            Container._5050 = false;
        }

        /// <summary>
        /// Подсказка Звонок другу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ringButton_Click(object sender, RoutedEventArgs e)
        {
            phoneDialog.Visibility = Visibility.Visible;
            Sleep(1000);
            string[] answers = new string[4];
            int count = 0;
            for (int i = 0; i < answerButtons.Count; i++)
            {
                if (answerButtons[i].IsEnabled) 
                {
                    count++;
                    answers[i] = answerButtons[i].Content.ToString();
                }
            }
            if (currentDifficulty != 3)
            {
                //phoneDialog.Text = "Друг думает...";
                //Sleep(2000);
                if (currentDifficulty == 1)
                {
                    phoneDialog.Text = "Я уверен, что верный ответ: " + correctAnswer;
                }
                else 
                {
                    string answ;
                    int rd = new Random().Next(100);
                    if (rd < 60)
                        answ = correctAnswer;
                    else
                    {
                        answ = answers[(new Random()).Next(count)];
                    }
                    phoneDialog.Text = "Скорее всего, верный ответ: " + answ;
                }
            }
            else 
            {
                int rd = new Random().Next(100);
                if (rd < 80)
                {
                    phoneDialog.Text = "Не уверен. Наверное, ответ: " + answers[(new Random()).Next(count)];
                }
                else phoneDialog.Text = "Друг не поднимает трубку";
            }
            ringButton.IsEnabled = false;
            ringbutton.Visibility = Visibility.Collapsed;
            ringbuttonX.Visibility = Visibility.Visible;
            checkring = true;
            Container.Ring = false;
        }

        /// <summary>
        /// Подсказка зала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void audButton_Click(object sender, RoutedEventArgs e)
        {
            int rightPerc, i, count = 0,j1=0,before;
            foreach (Button b in answerButtons)
            {
                if (b.IsEnabled) count++;
            }
            int[] wrongPerc = new int[count - 1];
            if (count == 2)
            {
                rightPerc = (new Random()).Next(40, 70);
                before = rightPerc;
                wrongPerc[0] = 100 - before;
            }
            else
            {
            if (currentDifficulty == 1) rightPerc = (new Random()).Next(60, 90);
            else if (currentDifficulty == 2) rightPerc = (new Random()).Next(30, 70);
            else rightPerc = (new Random()).Next(10, 50);
            for (i = 0; i < wrongPerc.Count() - 1; i++)
            {
                    before = rightPerc;
                for (int j = 0; j < i; j++) before += wrongPerc[j];
                    wrongPerc[i] = (new Random()).Next((100 - before));
            } 
            int before1 = rightPerc;
                for (int j = 0; j < wrongPerc.Count() - 1; j++) before1 += wrongPerc[j];
                wrongPerc[i] = 100 - before1;
            }

            for (int i2 = 0; i2 < answerButtons.Count; i2++ )
            {
                rectList[i2].Visibility = Visibility.Visible;
                if (!answerButtons[i2].IsEnabled)
                    rectList[i2].Visibility = Visibility.Collapsed;
            }

            if (count == 2)
            {
                for (int i2 = 0; i2 < answerButtons.Count; i2++)
                    if (answerButtons[i2].IsEnabled)
                        if (answerButtons[i2].Content.ToString() == correctAnswer)
                            rectList[i2].Width = (rectList[i2].Width * rightPerc) / 100;
                        else rectList[i2].Width = (rectList[i2].Width * wrongPerc[0]) / 100;

            }
            else
            {
                for (int i1 = 0; i1 < answerButtons.Count; i1++)
            {
                if (answerButtons[i1].Content.ToString() == correctAnswer)
                        rectList[i1].Width = (rectList[i1].Width * rightPerc) / 100;
                else
                {
                        rectList[i1].Width = (rectList[i1].Width * wrongPerc[j1]) / 100;
                    j1++;
                }
            }
            }
            audbutton.Visibility = Visibility.Collapsed;
            audXImage.Visibility = Visibility.Visible;
            audButton.IsEnabled = false;
            Container.Aud = false;
        }

        /// <summary>
        /// Забрать деньги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moneyButton_Click(object sender, RoutedEventArgs e)
        {
            Container.Score = player.Score;
            Frame.Navigate(typeof(FinishGamePage));
        }
    }
}

