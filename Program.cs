using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqu_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramCore programCore = new();
            programCore.StartWorkingWithPrisoners();
        }
    }

    class ProgramCore
    {
        private int _quantityPerpetratos = 30;
        private List<Perpetrator> _perpetrators = new List<Perpetrator>();

        public ProgramCore()
        {
            GenerateBase();
        }

        internal void StartWorkingWithPrisoners()
        {
            Console.Clear();
            Console.WriteLine("База данных перед амнистией");
            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();

            foreach (Perpetrator perpetrator in _perpetrators)
            {
                ShowPerpetrator(perpetrator);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Для амнистии за антиправительственные выступления нажмите Enter");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();

            ShowPolitical();
            ShowCriminals();
            ShowAmnestied();

            Console.ReadLine();
        }

        private void ShowPolitical()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Амнистия");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Perpetrator perpetrator in _perpetrators)
            {
                if (perpetrator.Status == "Антиправительственное")
                {
                    perpetrator.SetStatusAmnesty();
                }
            }
        }

        private void ShowCriminals()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Список уголовников");
            Console.ForegroundColor = ConsoleColor.White;

            var perpetrators = from Perpetrator in _perpetrators
                               where Perpetrator.Status == "Уголовное"
                               select Perpetrator;

            foreach (Perpetrator perpetrator in perpetrators)
            {
                ShowPerpetrator(perpetrator);
            }
        }

        private void ShowAmnestied()
        {
            var amnesty = from Perpetrator in _perpetrators
                          where Perpetrator.Status == "Амнистирован"
                          select Perpetrator;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Список амнистипрованных");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Perpetrator perpetrator in amnesty)
            {
                ShowPerpetrator(perpetrator);
            }
        }

        private void ShowPerpetrator(Perpetrator perpetrator)
        {
            Console.WriteLine($" {perpetrator.FullName }  | Преступление - {perpetrator.Status}");
        }
       
        private void GenerateBase()
        {
            bool continueGeneration = true;

            while (continueGeneration)
            {
                Perpetrator perpetrator = new Perpetrator();

                if (CheckFullNameMatching(perpetrator) == false)
                {
                    _perpetrators.Add(perpetrator);
                }
                if (_perpetrators.Count == _quantityPerpetratos)
                {
                    continueGeneration = false;
                }
            }
        }

        private bool CheckFullNameMatching(Perpetrator perpetrator)
        {
            bool isMatching = false;

            foreach (Perpetrator perpetratorTemp in _perpetrators)
            {
                if (perpetrator.FullName == perpetratorTemp.FullName)
                {
                    isMatching = true;
                }
            }
            return isMatching;
        }
    }

    class Perpetrator
    {
        private string[] _perpetratorFullNameBase = { "Нестер Евгения Ильинична", "Самиров Леонид Егорович"
                , "Рязанцев Андрей Александрович", "Фунтов Юрий Геннадьевич", "Ивойлова Ксения Марселевна"
                , "Шестунов Алексей Романович", "Ефанов Николай Алексеевич", "Петухина Алена Никитовна", "Качковский Вадим Васильевич"
                , "Тунеева Маргарита Вадимовна", "Точилкина Анжелика Григорьевна", "Батраков Никита Павлович", "Вязмитинова Галина Яновна"
                , "Индейкина Оксана Романовна", "Колосюк Руслан Янович", "Четков Михаил Ильич", "Хорошилова Надежда Кирилловна"
                , "Кадулин Павел Тимурович", "Якименко Вероника Рамилевна", "Валиулин Дмитрий Данилович", "Тельпугова Евгения Артемовна"
                , "Биушкина Татьяна Олеговна", "Славутинский Николай Игоревич", "Давыдов Александр Петрович", "Туаева Вероника Максимовна"
                , "Мутовкина Ирина Васильевна", "Тактаров Эдуард Ринатович", "Златовратский Борис Павлович", "Недодаева Полина Аркадьевна"
                , "Спиридонов Роман Борисович", "Лоринова Людмила Тимуровна", "Ряхин Марат Русланович", "Юльева Екатерина Ивановна"
                , "Шуйгин Олег Максимович", "Проклов Глеб Валентинович", "Майданов Тимофей Алексеевич", "Славянинов Артур Маратович"
                , "Таюпова Оксана Робертовна", "Коноплич Маргарита Андреевна", "Дратцева Римма Денисовна", "Гречановская Тамара Федоровна"
                , "Петрищева Ирина Никитовна", "Шейхаметова Раиса Артуровна", "Сумцова Анжелика Геннадьевна", "Есиповская Татьяна Робертовна"
                , "Свиногузова Кристина Ильдаровна", "Галанина Лидия Альбертовна", "Ледяева Жанна Константиновна", "Дудник Егор Радикович"
                , "Гаянов Григорий Алексеевич" };
        private string[] _status = { "Уголовное", "Антиправительственное" };

        internal string FullName { get; private set; }
        internal string Status { get; private set; }

        public Perpetrator()
        {
            GenerateFullName();
            GenerateStatus();
        }

        internal void SetStatusAmnesty()
        {
            Status = "Амнистирован";
        }

        internal string[] GetStatusBase()
        {
            string[] nationalityBase = new string[_status.Length];

            for (int i = 0; i < _status.Length; i++)
            {
                nationalityBase[i] = _status[i];
            }
            return nationalityBase;
        }

        private void GenerateFullName()
        {
            Random random = new Random();
            int minimumRandom = 0;
            int maximumRandom = _perpetratorFullNameBase.Length;

            FullName = _perpetratorFullNameBase[random.Next(minimumRandom, maximumRandom)];
        }

        private void GenerateStatus()
        {
            Random random = new Random();
            int minimumRandom = 0;
            int maximumRandom = _status.Length;
            Status = _status[random.Next(minimumRandom, maximumRandom)];
        }
    }
}
