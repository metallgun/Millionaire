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

        public NewgamePage()
        {
            this.InitializeComponent();

            answerButtons.Add(answerButton1);
            answerButtons.Add(answerButton2);
            answerButtons.Add(answerButton3);
            answerButtons.Add(answerButton4);

            foreach (Button b in answerButtons)
            {
                b.Click += (sender, e) =>
                    {
                        foreach (Button but in answerButtons)
                        {
                            but.Background = new SolidColorBrush(Windows.UI.Colors.Black);
                            but.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                        }

                        b.Background = new SolidColorBrush(Windows.UI.Colors.Orange);
                        b.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
                    };
            }
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

        //private void answerButton1_Click(object sender, RoutedEventArgs e)
        //{
        //    foreach (Button b in answerButtons)
        //    {
        //        b.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
        //        b.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
        //    }

        //    answerButton1.Background = new SolidColorBrush(Windows.UI.Colors.Yellow);
        //    answerButton1.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
        //}

        //public void ChooseButton(Button b)
        //{
        //    foreach (Button but in answerButtons)
        //    {
        //        but.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
        //        but.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
        //    }

        //    b.Background = new SolidColorBrush(Windows.UI.Colors.Orange);
        //    b.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
        //}
    }
}

