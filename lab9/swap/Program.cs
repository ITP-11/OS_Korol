using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class D
    {
        public static int V, V_sv, n, k_a = 0, k_success = 0;
        public static Process[] proc;
        public static Process[] sw = new Process[20];
        public static void Create()
        {
            int t;
            Console.Write("\nВведите количество разделов памяти: ");
            n = Convert.ToInt32(Console.ReadLine());
            proc = new Process[n];
            Console.Write("Введите объём раздела памяти: ");
            t = Convert.ToInt32(Console.ReadLine());
            V = n * t;
            for (int i = 0; i < n; i++)
                proc[i] = new Process(t);
            V_sv = V;
            for (int i = 0; i < sw.Length; i++)
                sw[i] = new Process(t);
        }
        public static int Swap()
        {
            Console.Clear();
            int min = V;
            int r = -1;
            for (int i = 0; i < proc.Length; i++)
            {
                if (proc[i].Mem_p != 0 && proc[i].Mem_p < min) { min = proc[i].Mem_p; r = i; }
            }
            if (r != -1)
            {
                int g = 0, ff = 0;
                while (g < sw.Length && ff == 0)
                {
                    if (sw[g].Name_p == null)
                    {
                        sw[g].Name_p = proc[r].Name_p;
                        sw[g].Mem_p = proc[r].Mem_p;
                        sw[g].data = proc[r].data;
                        ff = 1;
                    }
                    g++;
                }
                proc[r].Mem_p = 0;
                proc[r].Name_p = null;
                proc[r].data = null;
                V_sv += proc[r].V0;
                Console.WriteLine("Процесс, занимающий наименьший объём памяти выгружен");
            }
            else { Console.WriteLine("Процессов не обнаружено"); Console.ReadKey(); }
            return r;
        }
        public static void add()
        {
            Console.Clear();
            string name;
            int vv;
            Console.Write("\nВведите имя процесcа: ");
            name = Console.ReadLine();
            Console.Write("\nВведите объём памяти требуемой данному процессу(Кб): ");
            vv = Int32.Parse(Console.ReadLine());
            k_a++;
            if (vv > V) Console.WriteLine("Ошибка: объём всей памяти меньше объёма памяти требуемой процессу");
            else
            {
                if (vv <= proc[0].V0)
                {
                    int f = 0, i = 0;
                    while (i < proc.Length && f == 0)
                    {
                        if (proc[i].Name_p == null)
                        {

                            proc[i].Name_p = name;
                            proc[i].Mem_p = vv;
                            k_success++; f++;
                            proc[i].data = new string[vv];
                            V_sv = V_sv - proc[i].V0;
                        }

                        i++;
                    }

                    if (f == 0)
                    {
                        int r = Swap();
                        proc[r].Name_p = name;
                        proc[r].Mem_p = vv;
                        k_success++;
                        proc[r].data = new string[vv];
                        V_sv = V_sv - proc[r].V0;

                    }
                }
                else { Console.WriteLine("Ошибка: объём раздела меньше объёма требуемой памяти"); Console.ReadKey(); }
            }

        }
        public static void Vyvod()
        {
            Console.WriteLine("\nИнформация о процессах\n");
            int f = 0;
            for (int i = 0; i < proc.Length; i++)
            {

                if (proc[i].Mem_p != 0)
                { Console.WriteLine("Процесс: {0,-9}Объём памяти(Кб): {1,-5}  Номер блока памяти: {2} ", proc[i].Name_p, proc[i].Mem_p, i + 1); f++; }

            }
            if (f == 0) Console.WriteLine("Нет процессов.");

        }
        public static void SW()
        {
            Console.WriteLine("\nВыгруженные процессы\n");
            int f = 0;
            for (int i = 0; i < sw.Length; i++)
            {
                if (sw[i].Mem_p != 0)
                { Console.WriteLine("Процесс: {0,-9}Объём памяти(Кб): {1,-5} ", sw[i].Name_p, sw[i].Mem_p); f++; }
            }
            if (f == 0) Console.WriteLine("Нет процессов.");

        }
        public static void MaxR()
        {
            int temp;
            int max = -1;
            for (int i = 0; i < proc.Length; i++)
            {
                temp = proc[i].V0 - proc[i].Mem_p;
                if (temp > max) max = temp;
            }
            if (max != -1) Console.WriteLine("Размер наибольшего свободного блока: " + max + " Кб");
        }
        public static void KolPercent()
        {
            if (k_a != 0)
            {
                float k = 100 * (float)k_success / k_a;
                Console.WriteLine("Количество удовлетворённых запросов: {0,-4:f1}%", k);
            }
        }
    }
    class Process
    {
        int mem_p, V_razd;
        string name_p;
        public Process(int V_r) { V_razd = V_r; }
        public string[] data;
        public int V0
        {
            get { return V_razd; }
            set { V_razd = value; }
        }
        public int Mem_p
        {
            get { return mem_p; }
            set { mem_p = value; }
        }
        public string Name_p
        {
            get { return name_p; }
            set { name_p = value; }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int k = 12;
            D.Create();
            do
            {
                Console.Clear();
                Console.WriteLine("Полный объём памяти: " + D.V + " Кб");
                Console.WriteLine("Количество разделов: " + D.n);
                Console.WriteLine("Объём свободной памяти: " + D.V_sv + " Кб");
                Console.WriteLine("Количество запросов на выделение памяти: " + D.k_a);
                D.KolPercent();
                D.MaxR();
                D.Vyvod();
                D.SW();
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить процесс");
                Console.WriteLine("2. Свопинг");
                Console.WriteLine("3. Завершить работу программы");
                k = Convert.ToInt32(Console.ReadLine());
                switch (k)
                {
                    case 1: D.add(); break;
                    case 2: D.Swap(); break;
                    case 3: Console.Clear(); Console.WriteLine("Выход..."); break;
                    default: break;
                }
            }
            while (k != 3);
            Console.ReadKey();
        }
    }
}
