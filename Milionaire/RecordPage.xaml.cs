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
using Windows.Storage;
using System.Collections;
using System.Text.RegularExpressions;

// Документацию по шаблону элемента пустой страницы см. по адресу http://go.microsoft.com/fwlink/?LinkID=390556

namespace Milionaire
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class RecordPage : Page
    {
        List<int> scoreList = new List<int>();
        List<Player> recordsList = new List<Player>();

        public RecordPage()
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

        private async Task ReadFile()
        {
            // Get the local folder.
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;

            
            if (local != null)
            {
                // Get the DataFolder folder.
                var dataFolder = await local.GetFolderAsync("playerFolder");

                IReadOnlyList<StorageFile> filelist;
                
                filelist = await dataFolder.GetFilesAsync();
                
                foreach (StorageFile sf in filelist)
                {
                    string path = sf.Path;
                    string filename = sf.Name;

                    string[] value;
                    value = Regex.Split(filename, "File.txt");

                    var f = await dataFolder.OpenStreamForReadAsync(filename);

                    using (StreamReader streamReader = new StreamReader(f))
                    {
                        int record = int.Parse(streamReader.ReadToEnd());
                        Player newplayer = new Player
                        {
                            Name = value[0],
                            Score = record
                        };
                        recordsList.Add(newplayer);
                        //scoreList.Add(record);
                    }
                }

                var query = from h in recordsList
                            orderby h.Score descending
                            select h;
                List<TextBlock> textblocklist = new List<TextBlock>();
                textblocklist.Add(FirstText);
                textblocklist.Add(SecondText);
                textblocklist.Add(ThirdText);
                textblocklist.Add(ForthText);
                textblocklist.Add(FifthText);

                for (int i = 0; i<5; i++)
                {
                    textblocklist[i].Text = query.ToList()[i].Name + " - " + query.ToList()[i].Score.ToString();
                    //textblocklist[i].Text = query.ToList()[i].Score.ToString();
                }

                //// Get the file.
                //var file = await dataFolder.OpenStreamForReadAsync("playerFile.txt");

                //// Read the data.
                //using (StreamReader streamReader = new StreamReader(file))
                //{
                //    this.FirstText.Text= streamReader.ReadToEnd();
                //}

            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            await ReadFile();
        }
    }
}
