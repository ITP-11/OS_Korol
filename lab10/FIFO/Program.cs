using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba10
{
    class Program
    {
        static void Main(string[] args)
        {
            int pm, kol, k = 0, del = 0, j = 0, flag = -1, v = 0, proc, f, pust = 0;
            double obem;
            int ind, ch = 0;
            Console.WriteLine("Введите количество процессов:");
            proc = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите объем памяти:");
            pm = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите число страниц:");
            kol = Convert.ToInt32(Console.ReadLine());
            obem = pm / kol;
            Console.WriteLine();
            double[,] A = new double[proc,kol];
            double[,] B = new double[2,100];
            int[] C = new int[proc];
            while (k != 4)
            {
                Console.WriteLine("Общий объем памяти:{0}", pm*proc);
                Console.WriteLine("Объем памяти на каждый процесс:{0}",pm);
                Console.WriteLine("Общее число страниц:{0}",kol*proc);
                Console.WriteLine("Число страниц для каждого процесса:{0}",kol);
                Console.WriteLine("Число свободных страниц во всех стрннах:{0}",pust);
                Console.WriteLine("Размер страници:{0}",obem);
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить страницу в память");
                Console.WriteLine("2. Удалить страницу");
                Console.WriteLine("3. Вывести таблицу страниц");
                Console.WriteLine("4. Выход");
                try
                {
                    k = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    k = 3;
                }
                switch (k)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите номер процесса:");
                            B[0, j] = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите количество требуемой памяти:");
                            B[1, j] = Convert.ToDouble(Console.ReadLine());
                            j++;
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("1.Удалить из памяти заданную страницу");
                            Console.WriteLine("2.Удалить все страницы заданного процесса");
                            int p = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                if (p == 1)
                                {
                                    Console.WriteLine("Введите страницу:");
                                    ind = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Введите процесс:");
                                    del = Convert.ToInt32(Console.ReadLine());
                                    A[del, ind] = 0;
                                }
                                else if (p == 2)
                                {
                                    Console.WriteLine("Введите процесс:");
                                    del = Convert.ToInt32(Console.ReadLine());
                                    for(int i = 0;i< kol; i++)
                                    {
                                        A[del,i] = 0;
                                    }
                                    C[del] = 0;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.Write("Нет такой страници");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            ch = 0;
                            while (ch < proc)
                            {
                                for(int h=0;h< j; h++)
                                {
                                    if (ch == B[0, h])
                                    {
                                        flag = h;
                                        break;
                                    }
                                }
                                for(f=0;f< kol; f++)
                                {
                                    if (A[ch, f] == 0 && flag >= 0)
                                    {
                                        A[ch, f] = B[1, flag];
                                        B[1, flag] = -1;
                                        B[0, flag] = -1;
                                        v = 1;
                                        break;
                                    }
                                }
                                for (f = 0; f < kol; f++)
                                {
                                    if (flag >= 0 && v == 0)
                                    {
                                        A[ch, C[ch]] = B[1, flag];
                                        B[1, flag] = -1;
                                        B[0, flag] = -1;
                                        C[ch]++;
                                        if (C[ch] == kol)
                                        {
                                            C[ch] = 0;
                                        }
                                        break;
                                    }
                                }
                                flag = -1;
                                ch++;
                                v = 0;
                            }
                            Console.WriteLine("Таблица страниц");
                            for (f = 0; f < kol; f++)
                            {
                                Console.Write("{0,5}", f);
                                for (int i = 0; i < proc; i++)
                                {
                                    Console.Write("{0,5}",A[i, f]);
                                }
                                Console.WriteLine();
                            }
                            pust = 0;
                            for (int i = 0; i < proc; i++)
                            {
                                for (f = 0; f < kol; f++)
                                {
                                    if (A[i, f] == 0) pust++;
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                }
            }
        }
    }
}