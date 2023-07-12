namespace CS_Basic.Task_2
{
    public delegate void dlgSortFamilies(ConsoleKey key);
    public class SortException : Exception
    {
        public SortException(string message) : base(message) { }
    }
    public class Sort_by_key
    {
        public event dlgSortFamilies eventSortFamilies;

        public void Sort()
        {
            Console.Write("Укажите вид сортировки: 1 - по возрастанию, 2 - по убыванию (или Escape для выхода): ");
            ConsoleKeyInfo ki = Console.ReadKey();
            if (ki.Key == ConsoleKey.Escape)
                return;
            Console.WriteLine();

            do
            {
                try
                {
                    switch (ki.Key)
                    {
                        case ConsoleKey.D1:
                            eventSortFamilies?.Invoke(ConsoleKey.D1);
                            break;
                        case ConsoleKey.D2:
                            eventSortFamilies?.Invoke(ConsoleKey.D2);
                            break;
                        case ConsoleKey.D0:
                        case ConsoleKey.D3:
                        case ConsoleKey.D4:
                        case ConsoleKey.D5:
                        case ConsoleKey.D6:
                        case ConsoleKey.D7:
                        case ConsoleKey.D8:
                        case ConsoleKey.D9:
                            throw new SortException($"Вызываемый клавишей {ki.KeyChar} тип сортировки не реализован!");
                            break;
                        default:
                            throw new SortException("Код сортировки должен быть цифрой!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.Write("Укажите вид сортировки: 1 - по возрастанию, 2 - по убыванию: ");
                ki = Console.ReadKey();
                Console.WriteLine();
            }
            while (ki.Key != ConsoleKey.Escape);
        }

    }

    internal class Program
    {
        static string[] families = { "Иванов", "Петров", "Сидоров", "Иванец", "Скоробогатов" };
        static void Main(string[] args)
        {
            foreach (string family in families)
            {
                Console.WriteLine(family);
            }
            Console.WriteLine("--------");

            //SortException exception = new SortException("Код сортировки должен быть цифрой!");

            Sort_by_key sort_by_key = new Sort_by_key();
            sort_by_key.eventSortFamilies += SortFamilies;

            sort_by_key.Sort();

            //SortFamiliesAsc(ref families);

            //foreach(string family in families)
            //{
            //    Console.WriteLine(family);
            //}
            //Console.WriteLine("--------");

            //SortFamiliesDesc(ref families);

            //foreach (string family in families)
            //{
            //    Console.WriteLine(family);
            //}

            //Console.ReadKey();
        }
        static void SortFamilies(ConsoleKey k)
        {
            switch (k)
            {
                case ConsoleKey.D1:
                    SortFamiliesAsc();
                    break;
                case ConsoleKey.D2:
                    SortFamiliesDesc();
                    break;
                default:
                    Console.WriteLine($"Клавиша {k.ToString()} не обрабатывается!");
                    break;
            }
        }
        static void SortFamiliesAsc()
        {
            string _family = families[0];
            for (int k = 0; k < families.Length; k++)
                for (int i = k + 1; i < families.Length; i++)
                    if (string.Compare(families[i], families[k]) < 0)
                    {
                        _family = families[k];
                        families[k] = families[i];
                        families[i] = _family;
                    }

            foreach (string family in families)
            {
                Console.WriteLine(family);
            }
            Console.WriteLine("--------");
        }
        static void SortFamiliesDesc()
        {
            string _family = families[0];
            for (int k = 0; k < families.Length; k++)
                for (int i = k + 1; i < families.Length; i++)
                    if (string.Compare(families[i], families[k]) > 0)
                    {
                        _family = families[k];
                        families[k] = families[i];
                        families[i] = _family;
                    }

            foreach (string family in families)
            {
                Console.WriteLine(family);
            }
            Console.WriteLine("--------");
        }
    }
}