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
        string playerName;
        int prevScore;

        public FinishGamePage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            Container.Quest = 0;
            playerName = Container.Name;
            int prize = Container.Score;
            await GetPrevRecord();
            if (prize >= prevScore)
            {
                await WriteScoreToFile(playerName, prize);
            }
            if (prize < 1000000) finalPhraseText.Text = "К сожалению, Вы не выиграли миллион.\nПопробуйте еще раз.";
            else finalPhraseText.Text = "Поздравляем!\nВы стали миллионером!";
            scoreText.Text += " " + prize;
        }

        private async Task GetPrevRecord()
        {
            try
            {
                // Get the local folder.
                StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;

                if (local != null)
                {
                    // Get the DataFolder folder.
                    var dataFolder = await local.GetFolderAsync("playerFolder");

                    // Get the file.
                    string filename = playerName + "File.txt";
                    var file = await dataFolder.OpenStreamForReadAsync(filename);

                    // Read the data.
                    using (StreamReader streamReader = new StreamReader(file))
                    {
                        prevScore = int.Parse(streamReader.ReadToEnd());
                    }
                }
            }
            catch
            {
                prevScore = 0;
            }
        }
        
        

        private async Task WriteScoreToFile(string name, int score)
        {
            //создаем массив очков
            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes((score.ToString()).ToCharArray());

            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;

            //создаем папку
            var playerFolder = await local.CreateFolderAsync("playerFolder", CreationCollisionOption.OpenIfExists);
            //создаем файл
            string filename = name + "File.txt";
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

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            var pc = new Player()
            {
                Name = playerName,
                Score = 0
            };

            Container._5050 = true;
            Container.Aud = true;
            Container.Ring = true;
            Container.Score = 0;
            Container.Quest = 0;

            Frame.Navigate(typeof(NewgamePage), pc);
        }
    }
}