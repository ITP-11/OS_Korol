#include<stdio.h>
#include<string.h>
#include<conio.h>
#include<ctype.h>
#include <windows.h>
#include<math.h>

int main()
{
	SetConsoleCP (1251); 
	SetConsoleOutputCP (1251);
	int pm, kol, k = 0, del = 0, j = 0, flag = -1, v = 0, proc, f, pust = 0, i;
	int obem;
	int ind, ch = 0, h;
	puts("������� ���������� ���������: ");
	scanf("%d", &proc);
	puts("������� ����� ������: ");
	scanf("%d", &pm);
	puts("������� ����� �������: ");
	scanf("%d", &kol);
	obem = pm/kol;
	float A[proc][kol], B[2][100];
	int C[proc];
	while(k != 4)
	{
		printf("����� ����� ������: %d\n", pm*proc);
		printf("����� ������ �� ������ �������: %d\n", pm);
		printf("����� ����� �������: %d\n", kol*proc);
		printf("����� ������� ��� ������� ��������: %d\n", kol);
		printf("����� ��������� �������: %d\n", pust);
		printf("������ ��������: %d\n", obem);
		puts("------------------------------------------------");
		puts("����:");
		puts("1. �������� �������� � ������");
		puts("2. ������� ��������");
		puts("3. ������� ������� �������");
		puts("4. �����");
		scanf("%d", &k);
		system("cls");
		switch(k)
		{
			case 1:
				puts("������� ����� ��������: ");
				scanf("%f", &B[0][j]);
				puts("������� ���������� ��������� ������: ");
				scanf("%f", &B[1][j]);
				j++;
				break;
			case 2:
				puts("1. ������� �� ������ �������� ��������");
				puts("2. ������� ��� �������� ��������� ��������");
				int p;
				scanf("%d", &p);
				if(p == 1)
				{
					puts("������� ��������: ");
					scanf("%d", &ind);
					puts("������� �������: ");
					scanf("%d", &del);
					A[del][ind] = 0;
				}
				else if(p == 2)
				{
					puts("������� �������: ");
					scanf("%d", &del);
					for(i = 0; i < kol; i++)
						A[del][i] = 0;
					C[del] = 0;
				}
				break;
			case 3:
				ch = 0;
				while(ch < proc)
				{
					for(h = 0; h < j; h++)
					{
						if(ch == B[0][h])
						{
							flag = h;
							break;
						}
					}
					for(f = 0; f < kol; f++)
					{
						if(A[ch][f] == 0 && flag >= 0)
						{
							A[ch][f] = B[1][flag];
							B[1][flag] = -1;
							B[0][flag] = -1;
							v = 1;
							break;
						}
					}
					for(f = 0; f < kol; f++)
					{
						if(v == 0 && flag >= 0)
						{
							A[ch][C[ch]] = B[1][flag];
							B[1][flag] = -1;
							B[0][flag] = -1;
							C[ch]++;
							if(C[ch] == kol)
								C[ch] = 0;
							break;
						}
					}
					flag = -1;
					ch++;
					v = 0;
			    }
				printf("������� �������\n\n");
				for(f = 0; f < kol; f++)
				{
					printf("%5d", f);
					for(i = 0; i < proc; i++)
						printf("%5.0f", A[i][f]);
					printf("\n");
				}
				pust = 0;
				for(i = 0; i < proc; i++)
				{
					for(f = 0; f < kol; f++)
					{
						if(A[i][f] == 0)
							pust++;
					}	
				}
				break;
			case 4:
				break;
			default:
				break;
		}		
	}
	fflush(stdin);
	getchar();
	return 0;
}
