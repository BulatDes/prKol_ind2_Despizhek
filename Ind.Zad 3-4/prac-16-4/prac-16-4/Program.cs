using System;
using System.Collections;



namespace prac_16_4
{
    internal class Program
    {
        static Hashtable katalog = new Hashtable();
        static void Main(string[] args)
        {
            bool end = false;
            while (end==false)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Выберите действие");
                    Console.WriteLine("1.Добавить диск\n" +
                        "2.Добавить песню\n" +
                        "3.Удалить диск\n" +
                        "4.Удалить песню\n" +
                        "5.Просмотреть весь каталог\n" +
                        "6.Просмотреть содержимое диска\n" +
                        "7.Найти песню по всему катологу\n" +
                        "8.Завершить работу с программой\n");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":AddDisc();break;
                        case "2": AddSong(); break;
                        case "3": DeleteDisc(); break;
                        case "4": DeleteSong(); break;
                        case "5": KatalogView(); break;
                        case "6": DiscSongView(); break;
                        case "7": SearchSongInKatalog(); break;
                        case "8": end = true; break;
                        default:
                            {
                                Console.WriteLine("Неправильный ввод");
                                Console.ReadKey();
                                break;
                            }
                    }
                }
                catch
                {
                    Console.WriteLine("error");
                }
            }
        }

        public static void AddDisc()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Введите имя диска");
                string name = Console.ReadLine();
                if (katalog.ContainsKey(name))
                {
                    Console.WriteLine("Диск с таким именем уже существует");
                    Console.ReadKey();
                }
                else
                {
                    katalog[name] = new ArrayList();
                    Console.WriteLine("Диск добавлен");
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("Произошла ошибка");
                Console.ReadKey();
            }
        }

        public static void AddSong()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Введите имя диска в который вы хотите добавить песню");
                string diskname=Console.ReadLine();
                if (katalog.ContainsKey(diskname))
                {
                    ArrayList songs = (ArrayList)katalog[diskname];
                    Console.WriteLine("Введите имя песни");
                    string songname = Console.ReadLine();
                    if (songs.Contains(songname))
                    {
                        Console.WriteLine("Такая песня уже есть");
                        Console.ReadKey();
                    }
                    else
                    {
                        songs.Add(songname);
                        Console.WriteLine("Песня сохранена");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Такой диск не существует");
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("Unknown error");
                Console.ReadKey();
            }
        }

        public static void DeleteDisc()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Введите имя диска которого вы хотите удалить");
                string discname = Console.ReadLine();
                if (katalog.ContainsKey(discname))
                {
                    katalog.Remove(discname);
                    Console.WriteLine($"Диск '{discname}' удален");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Диск с таким именем не найден");
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("Unknown error");
                Console.ReadKey();
            }
        }

        public static void DeleteSong()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Введите имя диска в котором вы хотите удалить песню");
                string diskname = Console.ReadLine();
                if (katalog.ContainsKey(diskname))
                {
                    ArrayList songs = (ArrayList)katalog[diskname];
                    Console.WriteLine("Введите имя песни");
                    string songname = Console.ReadLine();
                    if (songs.Contains(songname))
                    {
                        songs.Remove(songname);
                        Console.WriteLine("Песня удалена");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"Песня с именем {songname} не найдена");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Такой диск не существует");
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("Unknown error");
                Console.ReadKey();
            }
        }

        public static void KatalogView()
        {
            try
            {
                Console.Clear();
                if(katalog.Count == 0)
                {
                    Console.WriteLine("Пока что в каталоге ничего нет");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Каталог:");
                    foreach( var h in katalog.Keys)
                    {
                        Console.WriteLine($"{h}");
                    }
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("unknown error");
                Console.ReadKey();
            }
        }

        public static void DiscSongView()
        {
            try
            {
                Console.Clear();
                if (katalog.Count == 0)
                {
                    Console.WriteLine("Пока что в каталоге ничего нет");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Введите название диска который хотите промотреть");
                    string diskname = Console.ReadLine();
                    if (katalog.ContainsKey(diskname))
                    {
                        ArrayList songs = (ArrayList)katalog[diskname];
                        Console.WriteLine($"Диск {diskname}:");
                        foreach (var h in songs)
                        {
                            Console.WriteLine($"{h}");
                        }
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Диск не найден");
                        Console.ReadKey();
                    }
                }
            }
            catch
            {
                Console.WriteLine("unknown error");
                Console.ReadKey();
            }

        }

        public static void SearchSongInKatalog()
        {
            try
            {
                Console.Clear();
                if (katalog.Count == 0)
                {
                    Console.WriteLine("Пока что в каталоге ничего нет");
                    Console.ReadKey();
                }
                else
                {
                    bool flag = false;
                    Console.WriteLine("Введите название песни который вы хотите найти");
                    string songname = Console.ReadLine();
                    ICollection value = katalog.Values;
                    foreach (ArrayList songs in value)
                    {
                        foreach (string h in songs)
                        {
                            if(h == songname)
                            {
                                flag = true;
                                Console.WriteLine($"{h}");
                            }
                        }
                    }
                    Console.ReadKey();
                    if (flag == false)
                    {
                        Console.WriteLine("Такая песня не найдена"); Console.ReadKey();
                    }
                }
            }
            catch
            {
                Console.WriteLine("unknown error");
                Console.ReadKey();
            }
        }
    }
}
