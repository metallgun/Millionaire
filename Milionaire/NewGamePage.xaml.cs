﻿using System;
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
using Windows.UI.Xaml.Media.Imaging;

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
        int currentDifficulty;
        Player player;
        int numberofQuetions;

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

            foreach (Button b in answerButtons)
            {
                b.Background = new SolidColorBrush(Windows.UI.Colors.Orange);
                b.Background.Opacity = 0;
                b.Visibility = Visibility.Visible;

                b.Click += (sender, e) =>
                {
                    b.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
                    b.Background.Opacity = 1;
                    //Проверка правильности НЕ РАБОТАЕТ!!!
                    if (b.Background.Opacity == 1)
                    {
                        //Правильный ответ
                        if (b.Content.ToString() == correctAnswer)
                        {
                            b.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                            Sleep(3000);
                            FillFeilds(1);
                            AddingScore();
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
        }

        //Заполнение полей

        // 5 easy 5 medium 4 hard 1 million
        private void FillFeilds(int difficulty)
        {
            if (numberofquestions >= 0 && numberofquestions <= 4) difficulty = 1;
            if (numberofquestions >= 5 && numberofquestions<=9) difficulty = 2;
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
            //if (player.Score == 1000 || player.Score == 32000 || player.Score == 1000000)
            //    Frame.Navigate(typeof(ProgressPage), player.Score);

        }

        //private void Clicks()
        //{
        //    foreach (Button b in answerButtons)
        //    {
        //        b.Background = new SolidColorBrush(Windows.UI.Colors.Orange);
        //        b.Background.Opacity = 0;
        //        b.Visibility = Visibility.Visible;
        //        b.Click += (sender, e) =>
        //        {
        //            //b.ClickMode = ClickMode.Press;
        //            //foreach (Button but in answerButtons)
        //            //{
        //            //    but.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
        //            //    but.Background.Opacity = 0;
        //            //}
        //            b.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
        //            b.Background.Opacity = 1;
                    
        //            //if (b.Background.Opacity == 1)
        //            //{
        //            //    if (b.Content.ToString() == correctAnswer)
        //            //    {
        //            //        b.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                            
        //            //        Sleep(5000);
        //            //        FillFeilds(1);
        //            //    }
        //            //    else
        //            //    {
        //            //        b.Background = new SolidColorBrush(Windows.UI.Colors.Red);
        //            //        foreach (Button b1 in answerButtons)
        //            //        {
        //            //            if (b1.Content.ToString() == correctAnswer)
        //            //            {
        //            //                b1.Background = new SolidColorBrush(Windows.UI.Colors.Green);
        //            //            }
        //            //        }
        //            //    }
        //            //}
        //        };
        //    }
        //}

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
                    count++;
                }
            }
            _5050button1.IsEnabled = false;
            _5050button.Visibility = Visibility.Collapsed;
            _5050XImage.Visibility = Visibility.Visible;
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
                phoneDialog.Text = "Друг думает...";
                Sleep(2000);
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
        }

        /// <summary>
        /// Подсказка зала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void audButton_Click(object sender, RoutedEventArgs e)
        {
            int rightPerc, i, count = 0;
            foreach (Button b in answerButtons)
            {
                if (b.IsEnabled) count++;
            }
            int[] wrongPerc = new int[count-1];
            if (currentDifficulty == 1) rightPerc = (new Random()).Next(60,90);
            else if (currentDifficulty == 2) rightPerc = (new Random()).Next(30,70);
            else rightPerc = (new Random()).Next(10,50);
            for (i = 0; i < wrongPerc.Count() - 1; i++)
            {
                int before = rightPerc;
                for (int j = 0; j < i; j++) before += wrongPerc[j];
                    wrongPerc[i] = (new Random()).Next((100 - before));
            }
            int before1 = rightPerc;
                for (int j = 0; j < wrongPerc.Count() - 1; j++) before1 += wrongPerc[j];
                wrongPerc[i] = 100 - before1;
        }

        private void moneyButton_Click(object sender, RoutedEventArgs e)
        {
            //Забрать деньги
        }
    }
}

