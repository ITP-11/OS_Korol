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
	puts("������� ���������� ������� ������: ");
	scanf("%d", &kol_razd);
	puts("������� ����� ������� ������: ");
	scanf("%d", &v_razdela);
	struct proces proc_kol[1000];
	while(k != 3)
	{
			printf("������ ����� ������: %d\n", kol_razd*v_razdela);
			printf("���������� ��������: %d\n", kol_razd);
			puts("���������� � ���������");
			for(i = 0; i < kol_razd; i++)
			{
				if(proc_kol[i].size > 0 && kol <= kol_razd)
					printf("�������: %s\t����� ������: %d\n", proc_kol[i].name, proc_kol[i].size);
				if(kol > kol_razd)
				{
					j = kol-kol_razd;
					m = j;
					for(m; m < kol_razd+r; m++)
					{
						if(proc_kol[m].size != -1)
							printf("�������: %s\t����� ������: %d\n", proc_kol[m].name, proc_kol[m].size);
					}
					r += 1;
					break;				
				}		
			}
			printf("\n");
			puts("����������� ��������");
			if(j != 0)
			{
				for(i = 0; i < j; i++)
				{
					if(proc_kol[i].size > 0)
						printf("�������: %s\t����� ������: %d\n", proc_kol[i].name, proc_kol[i].size);		
				}
			}
			printf("\n");
			puts("����");
			puts("1. �������� �������");
			puts("2. �������");
			puts("3. ��������� ������");
			puts("��� �����: ");
			scanf("%d", &k);
			system("cls");
			switch(k)
			{
				case 1:
					puts("������� ��� ����������: ");
					scanf("%s", &proc_kol[kol].name);
					puts("������� ����� ������ ��������� ������� ����������: ");
					scanf("%d", &proc_kol[kol].size);
					if(proc_kol[kol].size > v_razdela)
					{
						proc_kol[kol].size = 0;
						puts("����� ������ ������ �� �����");
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
					puts("����� ���� ������ �� �����");
					break;
			}
	}
	fflush(stdin);
	getchar();
	return 0;
}
