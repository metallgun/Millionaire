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
using Windows.Storage;
using System.Threading.Tasks;

// Документацию по шаблону элемента пустой страницы см. по адресу http://go.microsoft.com/fwlink/?LinkID=390556

namespace Milionaire
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class FinishGamePage : Page
    {
        public FinishGamePage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Container.Quest = 0;
            int prize = Container.Score;
            if (prize < 1000000) finalPhraseText.Text = "К сожалению, Вы не выиграли миллион.\nПопробуйте еще раз.";
            else finalPhraseText.Text = "Поздравляем!\nВы стали миллионером!";
            scoreText.Text += " " + prize;
        }

        private async Task WriteScoreToFile(int score)
        {
            //создаем массив очков
            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes((score.ToString()).ToCharArray());

            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;

            //создаем папку
            var playerFolder = await local.CreateFolderAsync("playerFolder", CreationCollisionOption.OpenIfExists);
            //создаем файл
            string filename = Container.Name + "File.txt";
            var file = await playerFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

            //пишем очки
            using (var s = await file.OpenStreamForWriteAsync())
            {
                s.Write(fileBytes, 0, fileBytes.Length);
            }
        }

        private void recordsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RecordPage));
        }

        private void endButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}