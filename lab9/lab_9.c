#include<stdio.h>
#include<string.h>
#include<conio.h>
#include<ctype.h>
#include <windows.h>
#include<math.h>

struct proces{
	int size;
	char name[100];
	int time; 
};
int main()
{
	SetConsoleCP (1251); 
	SetConsoleOutputCP (1251);
	int v_razdela;
	int kol_razd, k = 0, i, kol=0, time = 1, del_proc, j=0, m, r = 1;
	puts("Введиет количество разделв памяти: ");
	scanf("%d", &kol_razd);
	puts("Введиет объем раздела памяти: ");
	scanf("%d", &v_razdela);
	struct proces proc_kol[1000];
	while(k != 3)
	{
			printf("Полный объем памяти: %d\n", kol_razd*v_razdela);
			printf("Количество разделов: %d\n", kol_razd);
			puts("Инофрмация о процессах");
			for(i = 0; i < kol_razd; i++)
			{
				if(proc_kol[i].size > 0 && kol <= kol_razd)
					printf("Процесс: %s\tОбъем памяти: %d\n", proc_kol[i].name, proc_kol[i].size);
				if(kol > kol_razd)
				{
					j = kol-kol_razd;
					m = j;
					for(m; m < kol_razd+r; m++)
					{
						if(proc_kol[m].size != -1)
							printf("Процесс: %s\tОбъем памяти: %d\n", proc_kol[m].name, proc_kol[m].size);
					}
					r += 1;
					break;				
				}		
			}
			printf("\n");
			puts("Выгруженные процессы");
			if(j != 0)
			{
				for(i = 0; i < j; i++)
				{
					if(proc_kol[i].size > 0)
						printf("Процесс: %s\tОбъем памяти: %d\n", proc_kol[i].name, proc_kol[i].size);		
				}
			}
			printf("\n");
			puts("Меню");
			puts("1. Добавить процесс");
			puts("2. Свопинг");
			puts("3. Завершить работу");
			puts("Ваш выбор: ");
			scanf("%d", &k);
			system("cls");
			switch(k)
			{
				case 1:
					puts("Введите имя процессора: ");
					scanf("%s", &proc_kol[kol].name);
					puts("Введите объем памяти требуемой данному процессору: ");
					scanf("%d", &proc_kol[kol].size);
					if(proc_kol[kol].size > v_razdela)
					{
						proc_kol[kol].size = 0;
						puts("Объем памяти указан не верно");
						break;
				    }
				    else
					{
				    	proc_kol[kol].time = kol + time;
						kol += 1;
						time += 1;
						break;
				    }
				case 2:
					proc_kol[kol].size = -1;
					kol += 1;
					break;
				case 3:
					break;
				default:
					puts("Пункт меню выбран не верно");
					break;
			}
	}
	fflush(stdin);
	getchar();
	return 0;
}
