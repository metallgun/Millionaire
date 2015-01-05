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

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=391641

namespace Milionaire
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<Question> easyQuestions, mediumQuestions, hardQuestions;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            //Легкие
            easyQuestions.Add(new Question { QuestionName = "Что растёт в огороде?", RightAnswer = "Лук", WrongAnswer1 = "Пистолет", WrongAnswer2 = "Пулемёт", WrongAnswer3 = "Ракета СС-20" });
            easyQuestions.Add(new Question { QuestionName = "Как называют микроавтобусы, совершающие поездки по определённым маршрутам?", RightAnswer = "Маршрутка", WrongAnswer1 = "Рейсовка", WrongAnswer2 = "Путёвка", WrongAnswer3 = "Курсовка" });
            easyQuestions.Add(new Question { QuestionName = "О чём писал Грибоедов, отмечая, что он «нам сладок и приятен» ?", RightAnswer = "Дым Отечества", WrongAnswer1 = "Дух купечества", WrongAnswer2 = "Дар пророчества", WrongAnswer3 = "Пыл девичества" });
            easyQuestions.Add(new Question { QuestionName = "Какого персонажа нет в известной считалке «На золотом крыльце сидели» ?", RightAnswer = "Кузнеца", WrongAnswer1 = "Сапожника", WrongAnswer2 = "Короля", WrongAnswer3 = "Портного" });
            easyQuestions.Add(new Question { QuestionName = "Какой специалист занимается изучением неопознанных летающих объектов?", RightAnswer = "Уфолог", WrongAnswer1 = "Кинолог", WrongAnswer2 = "Сексопатолог", WrongAnswer3 = "Психиатр" });
            //easyQuestions.Add(new Question { QuestionName = "", RightAnswer = "", WrongAnswer1 = "", WrongAnswer2 = "", WrongAnswer3 = "" });
            //easyQuestions.Add(new Question { QuestionName = "", RightAnswer = "", WrongAnswer1 = "", WrongAnswer2 = "", WrongAnswer3 = "" });
            //easyQuestions.Add(new Question { QuestionName = "", RightAnswer = "", WrongAnswer1 = "", WrongAnswer2 = "", WrongAnswer3 = "" });
            //easyQuestions.Add(new Question { QuestionName = "", RightAnswer = "", WrongAnswer1 = "", WrongAnswer2 = "", WrongAnswer3 = "" });
            //easyQuestions.Add(new Question { QuestionName = "", RightAnswer = "", WrongAnswer1 = "", WrongAnswer2 = "", WrongAnswer3 = "" });

            //Средние
            mediumQuestions.Add(new Question { QuestionName = "Как называется разновидность воды, в которой атом водорода замещён его изотопом дейтерием?", RightAnswer = "Тяжёлая", WrongAnswer1 = "Лёгкая", WrongAnswer2 = "Средняя", WrongAnswer3 = "Невесомая" });
            mediumQuestions.Add(new Question { QuestionName = "Что такое десница?", RightAnswer = "Рука", WrongAnswer1 = "Бровь", WrongAnswer2 = "Глаз", WrongAnswer3 = "Шея" });
            mediumQuestions.Add(new Question { QuestionName = "В какое море впадает река Урал?", RightAnswer = "Каспийское", WrongAnswer1 = "Азовское", WrongAnswer2 = "Чёрное", WrongAnswer3 = "Средиземное" });
            mediumQuestions.Add(new Question { QuestionName = "На что кладут руку члены английского общества лысых во время присяги?", RightAnswer = "Бильярдный шар", WrongAnswer1 = "Баскетбольный мяч", WrongAnswer2 = "Апельсин", WrongAnswer3 = "Кокосовый орех" });
            mediumQuestions.Add(new Question { QuestionName = "Как назывался каменный монолит, на котором установлен памятник Петру I в Санкт-Петербурге?", RightAnswer = "Гром-камень", WrongAnswer1 = "Дом-камень", WrongAnswer2 = "Гора-камень", WrongAnswer3 = "Разрыв-камень" });
            //mediumQuestions.Add(new Question { QuestionName = "", RightAnswer = "", WrongAnswer1 = "", WrongAnswer2 = "", WrongAnswer3 = "" });
            //mediumQuestions.Add(new Question { QuestionName = "", RightAnswer = "", WrongAnswer1 = "", WrongAnswer2 = "", WrongAnswer3 = "" });
            //mediumQuestions.Add(new Question { QuestionName = "", RightAnswer = "", WrongAnswer1 = "", WrongAnswer2 = "", WrongAnswer3 = "" });
            //mediumQuestions.Add(new Question { QuestionName = "", RightAnswer = "", WrongAnswer1 = "", WrongAnswer2 = "", WrongAnswer3 = "" });
            //mediumQuestions.Add(new Question { QuestionName = "", RightAnswer = "", WrongAnswer1 = "", WrongAnswer2 = "", WrongAnswer3 = "" });

            //Сложные
            hardQuestions.Add(new Question { QuestionName = "Как Пётр Ильич Чайковский назвал свою серенаду для скрипки с оркестром си-бемоль минор?", RightAnswer = "Меланхолическая", WrongAnswer1 = "Флегматическая", WrongAnswer2 = "Холерическая", WrongAnswer3 = "Сангвиническая" });
            hardQuestions.Add(new Question { QuestionName = "Какого ордена не было у первого советского космонавта Юрия Гагарина?", RightAnswer = "«Орден двойного дракона» (Китай)", WrongAnswer1 = "«Ожерелье Нила» (Египет)", WrongAnswer2 = "«Крест Грюнвальда» (Польша)", WrongAnswer3 = "«Плайя Хирон» (Куба)" });
            hardQuestions.Add(new Question { QuestionName = "Какое животное имеет второе название — кугуар?", RightAnswer = "Пума", WrongAnswer1 = "Оцелот", WrongAnswer2 = "Леопард", WrongAnswer3 = "Пантера" });
            hardQuestions.Add(new Question { QuestionName = "Что в России 19 века делали в дортуаре?", RightAnswer = "Спали", WrongAnswer1 = "Ели", WrongAnswer2 = "Ездили верхом", WrongAnswer3 = "Купались" });
            hardQuestions.Add(new Question { QuestionName = "Какой химический элемент назван в честь злого подземного гнома?", RightAnswer = "Кобальт", WrongAnswer1 = "Гафний", WrongAnswer2 = "Бериллий", WrongAnswer3 = "Теллур" });
            //hardQuestions.Add(new Question { QuestionName = "", RightAnswer = "", WrongAnswer1 = "", WrongAnswer2 = "", WrongAnswer3 = "" });
            //hardQuestions.Add(new Question { QuestionName = "", RightAnswer = "", WrongAnswer1 = "", WrongAnswer2 = "", WrongAnswer3 = "" });
            //hardQuestions.Add(new Question { QuestionName = "", RightAnswer = "", WrongAnswer1 = "", WrongAnswer2 = "", WrongAnswer3 = "" });
            //hardQuestions.Add(new Question { QuestionName = "", RightAnswer = "", WrongAnswer1 = "", WrongAnswer2 = "", WrongAnswer3 = "" });
            //hardQuestions.Add(new Question { QuestionName = "", RightAnswer = "", WrongAnswer1 = "", WrongAnswer2 = "", WrongAnswer3 = "" });
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Подготовьте здесь страницу для отображения.

            // TODO: Если приложение содержит несколько страниц, обеспечьте
            // обработку нажатия аппаратной кнопки "Назад", выполнив регистрацию на
            // событие Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Если вы используете NavigationHelper, предоставляемый некоторыми шаблонами,
            // данное событие обрабатывается для вас.
        }


        private void buttonNewGame_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewPlayerPage));
        }
    }
}
