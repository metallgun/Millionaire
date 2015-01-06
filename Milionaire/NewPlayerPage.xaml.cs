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
using Windows.UI.Popups;

// Документацию по шаблону элемента пустой страницы см. по адресу http://go.microsoft.com/fwlink/?LinkID=390556

namespace Milionaire
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class NewPlayerPage : Page
    {
        public NewPlayerPage()
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

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(MainPage));
            Frame.GoBack();
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            bool checkdata = true;
            if (playerNameTextbox.Text == null || playerNameTextbox.Text == "")
            {
                ShowMessagebox();
                checkdata = false;
            }

            var pc = new Player()
            {
                Name = playerNameTextbox.Text,
                Score = 0
            };

            if (checkdata == true) 
                Frame.Navigate(typeof(NewgamePage), pc);
        }

        private async void ShowMessagebox()
        {
            MessageDialog msg = new MessageDialog("Введите имя игрока"); //по хорошему нужно ex.message Но я хз как это сделать лол
            await msg.ShowAsync();
        }
    }
}
