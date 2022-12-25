using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DiskrMath1
{
    internal class Program
    {
        static Set U = new Set("U");
        static void Main(string[] args)
        {
            Console.WriteLine("Задайте универсальное множество U:");
            Console.WriteLine("1. Вручную");
            Console.WriteLine("2. Случайно");
            Console.WriteLine("3. Заполнить от 0 до 100");
            int i1 = Convert.ToInt32(Console.ReadLine());
            U.isU = true;
            switch (i1)
            {
                case 1:
                    {
                        SetManually(U);
                        break;
                    }
                case 2: 
                    {
                        SetRandom(U);
                        break;
                    }
                case 3:
                    {
                        Random rand = new Random();
                        for (int i = 0; i < 101; i++)
                        {
                            U.AddToList(i);
                        }
                        break;
                    }
            }

            List<Set> sets= new List<Set>();
            sets.Add(U);
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Распечатать множество");
            Console.WriteLine("2. Распечатать все множества");
            Console.WriteLine("3. Добавить множество");
            Console.WriteLine("4. Удалить множество");
            Console.WriteLine("5. Выполнить операции над множествами");
            Console.WriteLine("6. Выйти из программы");
            int i2 = Convert.ToInt32(Console.ReadLine());
            do
            {
                
                switch (i2) 
                {
                    case 1:
                        {
                            Console.WriteLine("Введите название множества: ");
                            string name = Console.ReadLine();
                            Print(name, sets);
                            break;
                        }
                    case 2:
                        {
                            PrintAll(sets);
                            break;
                        }
                    case 3:
                        {
                            AddSet(sets);
                            break;
                        }
                    case 4:
                        {
                            DelSet(sets);
                            break;
                        }
                    case 5:
                        {
                            Operations(sets);
                            break;
                        }
                }
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Распечатать множество");
                Console.WriteLine("2. Распечатать все множества");
                Console.WriteLine("3. Добавить множество");
                Console.WriteLine("4. Удалить множество");
                Console.WriteLine("5. Выполнить операции над множествами");
                Console.WriteLine("6. Выйти из программы");
                i2 = Convert.ToInt32(Console.ReadLine());
            } while(i2 != 6);
        }
        static public void SetManually(Set set)
        {
            if (set.isU)
            {
                Console.WriteLine($"Введите количество элементов во множестве {set.GetName()}:");
                int N = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine($"Введите {i + 1} элемент:");
                    int toAdd = Convert.ToInt32(Console.ReadLine());
                    set.AddToList(toAdd);
                }
                Console.WriteLine($"Множество {set.GetName()} сформировано!");
            }
            else
            {
                Console.WriteLine($"Введите количество элементов во множестве {set.GetName()}:");
                int N = Convert.ToInt32(Console.ReadLine());
                if (N > U.GetLength())
                {
                    Console.WriteLine($"Количество элементов больше чем в универсальном множестве!");
                }
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine($"Введите {i + 1} элемент:");
                    int toAdd = Convert.ToInt32(Console.ReadLine());
                    bool isDo = false;
                    for (int j = 0; j < U.GetLength(); j++)
                    {
                        if (U[j] == toAdd)
                        {
                            isDo = true;
                        }
                    }
                    if (!isDo)
                    {
                        Console.WriteLine("Такого числа нет в универсальном множестве");
                        i--;
                    }
                    else
                    {
                        set.AddToList(toAdd);
                    }
                }
                Console.WriteLine($"Множество {set.GetName()} сформировано!");
            }
        }
        static public void SetRandom(Set set)
        {
            if (set.isU)
            {
                Random rand = new Random();
                Console.WriteLine($"Введите количество элементов во множестве {set.GetName()}:");
                int N = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < N; i++)
                {
                    set.AddToList(rand.Next(100));
                }
                Console.WriteLine($"Множество {set.GetName()} сформировано!");

            }
            else
            {
                Random rand = new Random();
                Console.WriteLine($"Введите количество элементов во множестве {set.GetName()}:");
                int N = Convert.ToInt32(Console.ReadLine());
                if (N > U.GetLength())
                {
                    Console.WriteLine($"Количество элементов больше чем в универсальном множестве!");
                }
                for (int i = 0; i < N; i++)
                {
                    bool isDo = false;
                    int toAdd = rand.Next(100);
                    for (int j = 0; j < U.GetLength(); j++)
                    {
                        if (U[j] == toAdd)
                        {
                            isDo = true;
                        }
                    }
                    if (!isDo)
                    {
                        i--;
                    }
                    else
                    {
                        set.AddToList(toAdd);
                    }
                }
            Console.WriteLine($"Множество {set.GetName()} сформировано!");
        }
        }
        static public void Print(string name, List<Set> sets)
        {
            if (name == "U")
            {
                sets[0].Print();
                return;
            }
            for (int i = 0; i < sets.Count; i++) 
            {
                if (name == sets[i].GetName()) 
                {
                    sets[i].Print();
                    return;
                }
            }
            Console.WriteLine($"Не найдено множество с таким названием.");
            return;
        }
        static public void PrintAll(List<Set> sets)
        {
            for (int i = 0; i < sets.Count; i++)
            {
                sets[i].Print();
            }
        }
        static public void AddSet(List<Set> sets)
        {
            Console.WriteLine($"Введите название множества:");
            string name = Console.ReadLine();
            for (int j = 0; j < sets.Count; j++)
            {
                if (name == sets[j].GetName())
                {
                    Console.WriteLine($"Множество с таким именем уже существует");
                    return;
                }
            }
            Set temp = new Set(name);
            Console.WriteLine($"Как заполнить множество?");
            Console.WriteLine($"1. Вручную");
            Console.WriteLine($"2. Случайными числами");
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    {
                        SetManually(temp);
                        break;
                    }
                case 2:
                    {
                        SetRandom(temp);
                        break;
                    }
            }
            sets.Add(temp);
        }
        static public void DelSet(List<Set> sets) 
        {
            Console.WriteLine($"Введите название множества, которое надо удалить:");
            string name = Console.ReadLine();
            for (int i = 0; i < sets.Count; i++)
            {
                if (name == sets[i].GetName())
                {
                    sets.Remove(sets[i]);
                    Console.WriteLine($"Множество успешно удалено!");
                    return;
                }
            }
            Console.WriteLine($"Такое множество не найдено");
        }
        public static void Operations(List<Set> sets)
        {
            Console.WriteLine($"Выберите операцию:");
            Console.WriteLine($"1. Объединение");
            Console.WriteLine($"2. Пересечение");
            Console.WriteLine($"3. Разность");
            Console.WriteLine($"4. Суммирующая разность");
            Console.WriteLine($"5. Проверка вхождения одного множества в другое");
            Console.WriteLine($"6. Проверка вхождения числа в множество");
            Console.WriteLine($"7. Назад");
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    {
                        Console.WriteLine($"Введите название первого множества:");
                        string name1 = Console.ReadLine();
                        bool isDo = false;
                        Set temp1 = new Set("temp1");
                        for (int j = 0; j < sets.Count; j++)
                        {
                            if (name1 == sets[j].GetName())
                            {
                                isDo = true;
                                temp1 = sets[j];
                                break;
                            }
                        }
                        if (!isDo)
                        {
                            Console.WriteLine($"Такое множество не найдено");
                            break;
                        }
                        

                        Console.WriteLine($"Введите название второго множества:");
                        string name2 = Console.ReadLine();
                        isDo = false;
                        Set temp2 = new Set("temp2");
                        for (int j = 0; j < sets.Count; j++)
                        {
                            if (name2 == sets[j].GetName())
                            {
                                isDo = true;
                                temp2 = sets[j];
                                break;
                            }
                        }
                        if (!isDo)
                        {
                            Console.WriteLine($"Такое множество не найдено");
                            break;
                        }

                        Console.WriteLine($"Введите название нового множества:");
                        string name0 = Console.ReadLine();
                        isDo = true;
                        for (int j = 0; j < sets.Count; j++)
                        {
                            if (name0 == sets[j].GetName())
                            {
                                Console.WriteLine($"Множество с таким именем уже существует");
                                isDo = false;
                                break;
                            }
                        }
                        if (isDo)
                        {
                            Console.WriteLine($"Множество создано!");
                            Set temp = new Set(name0);
                            temp.Uni(temp1, temp2);
                            sets.Add(temp);
                        }
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine($"Введите название первого множества:");
                        string name1 = Console.ReadLine();
                        bool isDo = false;
                        Set temp1 = new Set("temp1");
                        for (int j = 0; j < sets.Count; j++)
                        {
                            if (name1 == sets[j].GetName())
                            {
                                isDo = true;
                                temp1 = sets[j];
                                break;
                            }
                        }
                        if (!isDo)
                        {
                            Console.WriteLine($"Такое множество не найдено");
                            break;
                        }


                        Console.WriteLine($"Введите название второго множества:");
                        string name2 = Console.ReadLine();
                        isDo = false;
                        Set temp2 = new Set("temp2");
                        for (int j = 0; j < sets.Count; j++)
                        {
                            if (name2 == sets[j].GetName())
                            {
                                isDo = true;
                                temp2 = sets[j];
                                break;
                            }
                        }
                        if (!isDo)
                        {
                            Console.WriteLine($"Такое множество не найдено");
                            break;
                        }

                        Console.WriteLine($"Введите название нового множества:");
                        string name0 = Console.ReadLine();
                        isDo = true;
                        for (int j = 0; j < sets.Count; j++)
                        {
                            if (name0 == sets[j].GetName())
                            {
                                Console.WriteLine($"Множество с таким именем уже существует");
                                isDo = false;
                                break;
                            }
                        }
                        if (isDo)
                        {
                            Console.WriteLine($"Множество создано!");
                            Set temp = new Set(name0);
                            temp.Inter(temp1, temp2);
                            sets.Add(temp);
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine($"Введите название первого множества:");
                        string name1 = Console.ReadLine();
                        bool isDo = false;
                        Set temp1 = new Set("temp1");
                        for (int j = 0; j < sets.Count; j++)
                        {
                            if (name1 == sets[j].GetName())
                            {
                                isDo = true;
                                temp1 = sets[j];
                                break;
                            }
                        }
                        if (!isDo)
                        {
                            Console.WriteLine($"Такое множество не найдено");
                            break;
                        }


                        Console.WriteLine($"Введите название второго множества:");
                        string name2 = Console.ReadLine();
                        isDo = false;
                        Set temp2 = new Set("temp2");
                        for (int j = 0; j < sets.Count; j++)
                        {
                            if (name2 == sets[j].GetName())
                            {
                                isDo = true;
                                temp2 = sets[j];
                                break;
                            }
                        }
                        if (!isDo)
                        {
                            Console.WriteLine($"Такое множество не найдено");
                            break;
                        }

                        Console.WriteLine($"Введите название нового множества:");
                        string name0 = Console.ReadLine();
                        isDo = true;
                        for (int j = 0; j < sets.Count; j++)
                        {
                            if (name0 == sets[j].GetName())
                            {
                                Console.WriteLine($"Множество с таким именем уже существует");
                                isDo = false;
                                break;
                            }
                        }
                        if (isDo)
                        {
                            Console.WriteLine($"Множество создано!");
                            Set temp = new Set(name0);
                            temp.Diff(temp1, temp2);
                            sets.Add(temp);
                        }
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine($"Введите название первого множества:");
                        string name1 = Console.ReadLine();
                        bool isDo = false;
                        Set temp1 = new Set("temp1");
                        for (int j = 0; j < sets.Count; j++)
                        {
                            if (name1 == sets[j].GetName())
                            {
                                isDo = true;
                                temp1 = sets[j];
                                break;
                            }
                        }
                        if (!isDo)
                        {
                            Console.WriteLine($"Такое множество не найдено");
                            break;
                        }


                        Console.WriteLine($"Введите название второго множества:");
                        string name2 = Console.ReadLine();
                        isDo = false;
                        Set temp2 = new Set("temp2");
                        for (int j = 0; j < sets.Count; j++)
                        {
                            if (name2 == sets[j].GetName())
                            {
                                isDo = true;
                                temp2 = sets[j];
                                break;
                            }
                        }
                        if (!isDo)
                        {
                            Console.WriteLine($"Такое множество не найдено");
                            break;
                        }

                        Console.WriteLine($"Введите название нового множества:");
                        string name0 = Console.ReadLine();
                        isDo = true;
                        for (int j = 0; j < sets.Count; j++)
                        {
                            if (name0 == sets[j].GetName())
                            {
                                Console.WriteLine($"Множество с таким именем уже существует");
                                isDo = false;
                                break;
                            }
                        }
                        if (isDo)
                        {
                            Console.WriteLine($"Множество создано!");
                            Set temp = new Set(name0);
                            temp.SumDiff(temp1, temp2);
                            sets.Add(temp);
                        }
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine($"Введите название первого множества:");
                        string name1 = Console.ReadLine();
                        bool isDo = false;
                        Set temp1 = new Set("temp1");
                        for (int j = 0; j < sets.Count; j++)
                        {
                            if (name1 == sets[j].GetName())
                            {
                                isDo = true;
                                temp1 = sets[j];
                                break;
                            }
                        }
                        if (!isDo)
                        {
                            Console.WriteLine($"Такое множество не найдено");
                            break;
                        }


                        Console.WriteLine($"Введите название второго множества:");
                        string name2 = Console.ReadLine();
                        isDo = false;
                        Set temp2 = new Set("temp2");
                        for (int j = 0; j < sets.Count; j++)
                        {
                            if (name2 == sets[j].GetName())
                            {
                                isDo = true;
                                temp2 = sets[j];
                                break;
                            }
                        }
                        if (!isDo)
                        {
                            Console.WriteLine($"Такое множество не найдено");
                            break;
                        }

                        if (temp2.isIncluded(temp1))
                        {
                            Console.WriteLine("Второе множество входит в первое");
                        }
                        else
                        {
                            Console.WriteLine("Второе множество не входит в первое");
                        }
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine($"Введите название множества:");
                        string name1 = Console.ReadLine();
                        bool isDo = false;
                        Set temp1 = new Set("temp1");
                        for (int j = 0; j < sets.Count; j++)
                        {
                            if (name1 == sets[j].GetName())
                            {
                                isDo = true;
                                temp1 = sets[j];
                                break;
                            }
                        }
                        if (!isDo)
                        {
                            Console.WriteLine($"Такое множество не найдено");
                            break;
                        }
                        Console.WriteLine($"Введите число для проверки:");
                        int X = Convert.ToInt32(Console.ReadLine());
                        if (temp1.isIncluded(X))
                        {
                            Console.WriteLine($"Число входит в множество");
                        }
                        else
                        {
                            Console.WriteLine($"Число не входит в множество");
                        }

                        break;
                    }
                case 7:
                    {
                        break;
                    }
            }
        }
    }
}
