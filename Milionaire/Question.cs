using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionaire
{
    public class Question
    {
        public int Difficulty { get; set; }
        public string QuestionName { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }
        public string RightAnswer { get; set; }

        private void PopulateQuestionList(List<Question> _QuestionList)
        {
            _QuestionList.Add(new Question { QuestionName = "Что растёт в огороде?", RightAnswer = "Лук", WrongAnswer1 = "Пистолет", WrongAnswer2 = "Пулемёт", WrongAnswer3 = "Ракета СС-20", Difficulty = 1});
            _QuestionList.Add(new Question { QuestionName = "Как порой называют деспотичную женщину?", RightAnswer = "Жандарм в юбке", WrongAnswer1 = "Майор в декольте", WrongAnswer2 = "Ефрейтор в платье", WrongAnswer3 = "Сержант в бигуди", Difficulty = 1 });
            _QuestionList.Add(new Question { QuestionName = "Как заканчивается русская пословица: \"Была бы изба...\"?", RightAnswer = "будут и тараканы", WrongAnswer1 = "сделаем евроремонт", WrongAnswer2 = "завершим приватизацию", WrongAnswer3 = "найдем злую собаку", Difficulty = 1 });
            _QuestionList.Add(new Question { QuestionName = "Что нужно для детской игры в классики?", RightAnswer = "Клетки на асфальте", WrongAnswer1 = "Боксерский ринг", WrongAnswer2 = "Партитура", WrongAnswer3 = "Ракетка", Difficulty = 1 });
            _QuestionList.Add(new Question { QuestionName = "Что группа ЛЮБЭ требовала от Америки, призывая ее не валять дурака?", RightAnswer = "Отдать Аляску", WrongAnswer1 = "Забыть о гамбургерах", WrongAnswer2 = "Освободить индейцев", WrongAnswer3 = "Закрыть Голливуд", Difficulty = 1 });
            _QuestionList.Add(new Question { QuestionName = "Какая фраза чаще всего звучит на аукционе?", RightAnswer = "Кто больше?", WrongAnswer1 = "Кто сильнее?", WrongAnswer2 = "Кто хитрее?", WrongAnswer3 = "Продано", Difficulty = 1 });
            _QuestionList.Add(new Question { QuestionName = "Сколько суток составляют високосный год?", RightAnswer = "366", WrongAnswer1 = "365", WrongAnswer2 = "364", WrongAnswer3 = "356", Difficulty = 1});
            _QuestionList.Add(new Question { QuestionName = "Что Вячеслав Добрынин умолял не сыпать ему на рану в одной из песен", RightAnswer = "Соль", WrongAnswer1 = "Перец", WrongAnswer2 = "Сахар", WrongAnswer3 = "Стрептоцид", Difficulty = 1 });
            _QuestionList.Add(new Question { QuestionName = "Что царь Гордий завязал так, что Александру Македонскому пришлось взяться за меч?", RightAnswer = "Узел", WrongAnswer1 = "Шнурки", WrongAnswer2 = "Бант", WrongAnswer3 = "Беседа", Difficulty = 1 });
            _QuestionList.Add(new Question { QuestionName = "В каком из этих фильмов главное действующее лицо В.И.Ленин", RightAnswer = "Человек с ружьем", WrongAnswer1 = "Человек-невидимка", WrongAnswer2 = "Человек-амфибия", WrongAnswer3 = "По кличке зверь", Difficulty = 1 });
            _QuestionList.Add(new Question { QuestionName = "О чём писал Грибоедов, отмечая, что он «нам сладок и приятен» ?", RightAnswer = "Дым Отечества", WrongAnswer1 = "Дух купечества", WrongAnswer2 = "Дар пророчества", WrongAnswer3 = "Пыл девичества", Difficulty = 1 });
            _QuestionList.Add(new Question { QuestionName = "Какого персонажа нет в известной считалке «На золотом крыльце сидели» ?", RightAnswer = "Кузнеца", WrongAnswer1 = "Сапожника", WrongAnswer2 = "Короля", WrongAnswer3 = "Портного", Difficulty = 1 });
            _QuestionList.Add(new Question { QuestionName = "Какой специалист занимается изучением неопознанных летающих объектов?", RightAnswer = "Уфолог", WrongAnswer1 = "Кинолог", WrongAnswer2 = "Сексопатолог", WrongAnswer3 = "Психиатр", Difficulty = 1 });
            _QuestionList.Add(new Question { QuestionName = "Как называется разновидность воды, в которой атом водорода замещён его изотопом дейтерием?", RightAnswer = "Тяжёлая", WrongAnswer1 = "Лёгкая", WrongAnswer2 = "Средняя", WrongAnswer3 = "Невесомая", Difficulty = 2 });
            _QuestionList.Add(new Question { QuestionName = "Какой из этих алкогольных напитков не употребляют в горячем виде?", RightAnswer = "Крюшон", WrongAnswer1 = "Грог", WrongAnswer2 = "Пунш", WrongAnswer3 = "Глинтвейн", Difficulty = 2 });
            _QuestionList.Add(new Question { QuestionName = "Из какого материала изготавливается керамическая посуда?", RightAnswer = "Глина", WrongAnswer1 = "Стекло", WrongAnswer2 = "Гипс", WrongAnswer3 = "Керамика", Difficulty = 2 });
            _QuestionList.Add(new Question { QuestionName = "Устройством какого из этих инструментов не предусмотрены меха для нагнетания воздуха?", RightAnswer = "Волторна", WrongAnswer1 = "Орган", WrongAnswer2 = "Волынка", WrongAnswer3 = "Шарманка", Difficulty = 2 });
            _QuestionList.Add(new Question { QuestionName = "Как называется южноамериканский аналог степи?", RightAnswer = "Пампасы", WrongAnswer1 = "Прерии", WrongAnswer2 = "Тундра", WrongAnswer3 = "Саванна", Difficulty = 2 });
            _QuestionList.Add(new Question { QuestionName = "Какой дворец является резиденцией президента РФ в Санкт-Питербурге?", RightAnswer = "Константиновский", WrongAnswer1 = "Зимний", WrongAnswer2 = "Михайловский", WrongAnswer3 = "Таврический", Difficulty = 2 });
            _QuestionList.Add(new Question { QuestionName = "Что такое десница?", RightAnswer = "Рука", WrongAnswer1 = "Бровь", WrongAnswer2 = "Глаз", WrongAnswer3 = "Шея", Difficulty = 2 });
            _QuestionList.Add(new Question { QuestionName = "В какое море впадает река Урал?", RightAnswer = "Каспийское", WrongAnswer1 = "Азовское", WrongAnswer2 = "Чёрное", WrongAnswer3 = "Средиземное", Difficulty = 2 });
            _QuestionList.Add(new Question { QuestionName = "На что кладут руку члены английского общества лысых во время присяги?", RightAnswer = "Бильярдный шар", WrongAnswer1 = "Баскетбольный мяч", WrongAnswer2 = "Апельсин", WrongAnswer3 = "Кокосовый орех", Difficulty = 2 });
            _QuestionList.Add(new Question { QuestionName = "Как назывался каменный монолит, на котором установлен памятник Петру I в Санкт-Петербурге?", RightAnswer = "Гром-камень", WrongAnswer1 = "Дом-камень", WrongAnswer2 = "Гора-камень", WrongAnswer3 = "Разрыв-камень", Difficulty = 2 });
            _QuestionList.Add(new Question { QuestionName = "Как Пётр Ильич Чайковский назвал свою серенаду для скрипки с оркестром си-бемоль минор?", RightAnswer = "Меланхолическая", WrongAnswer1 = "Флегматическая", WrongAnswer2 = "Холерическая", WrongAnswer3 = "Сангвиническая", Difficulty = 3});
            _QuestionList.Add(new Question { QuestionName = "Какое сравнение не использовал Пушкин, противопоставляя Онегина и Ленского?", RightAnswer = "Земля и небо", WrongAnswer1 = "Волна и камень", WrongAnswer2 = "Стихи и проза", WrongAnswer3 = "Лед и пламень", Difficulty = 3 });
            _QuestionList.Add(new Question { QuestionName = "От какой империи Россия унаследовала двуглавого орла на гербе?", RightAnswer = "Византийская", WrongAnswer1 = "Римская", WrongAnswer2 = "Османская", WrongAnswer3 = "Китайская", Difficulty = 3 });
            _QuestionList.Add(new Question { QuestionName = "Команда какой страны стала победительницей первого чемпионата мира по футболу?", RightAnswer = "Уругвай", WrongAnswer1 = "Ямайка", WrongAnswer2 = "Бразилия", WrongAnswer3 = "Аргентина", Difficulty = 3 });
            _QuestionList.Add(new Question { QuestionName = "Кого из этих писателей англичане считают прародителем разведслужбы Великобритании?", RightAnswer = "Даниель Дефо", WrongAnswer1 = "Джонатан Свифт", WrongAnswer2 = "Генри Филдинг", WrongAnswer3 = "Чарльз Диккенс", Difficulty = 3 });
            _QuestionList.Add(new Question { QuestionName = "Какое животное имеет второе название — кугуар?", RightAnswer = "Пума", WrongAnswer1 = "Оцелот", WrongAnswer2 = "Леопард", WrongAnswer3 = "Пантера", Difficulty = 3 });
            _QuestionList.Add(new Question { QuestionName = "Что в России 19 века делали в дортуаре?", RightAnswer = "Спали", WrongAnswer1 = "Ели", WrongAnswer2 = "Ездили верхом", WrongAnswer3 = "Купались", Difficulty = 3 });
            _QuestionList.Add(new Question { QuestionName = "Какой химический элемент назван в честь злого подземного гнома?", RightAnswer = "Кобальт", WrongAnswer1 = "Гафний", WrongAnswer2 = "Бериллий", WrongAnswer3 = "Теллур", Difficulty = 3 });
            _QuestionList.Add(new Question { QuestionName = "Кто из этих философоф в 1864 году написал музыку на стихи А.С.Пушкина \"Заклинание\" и \"Зимний вечер\"", RightAnswer = "Ницше", WrongAnswer1 = "Гегель", WrongAnswer2 = "Шопенгауэр", WrongAnswer3 = "Юнг", Difficulty = 4 });
            _QuestionList.Add(new Question { QuestionName = "В каком городе в 1932 году был проведён первый международный кинофестиваль?", RightAnswer = "Венеция", WrongAnswer1 = "Канны", WrongAnswer2 = "Париж", WrongAnswer3 = "Берлин", Difficulty = 4 });
            _QuestionList.Add(new Question { QuestionName = "Сколько раз в сутки подзаводят куранты на Спасской башни Кремля?", RightAnswer = "2", WrongAnswer1 = "1", WrongAnswer2 = "3", WrongAnswer3 = "4", Difficulty = 4 });
            _QuestionList.Add(new Question { QuestionName = "Кто первым получил Нобелевскую премию по литературе?", RightAnswer = "Поэт", WrongAnswer1 = "Романист", WrongAnswer2 = "Драматург", WrongAnswer3 = "Эссеист", Difficulty = 4 });
            _QuestionList.Add(new Question { QuestionName = "Как назвали первую кимберлитовую трубку, открытую Ларисой Попугаевой 21 августа 1954 года?", RightAnswer = "Зарница", WrongAnswer1 = "Удачная", WrongAnswer2 = "Мир", WrongAnswer3 = "Советская", Difficulty = 4 });
        }
    }
}
