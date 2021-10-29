#include <time.h>
#include <iostream>
#include <clocale>
using namespace std;

int Random(int min, int max)
{
	srand(time(NULL));
	int num = min + rand() % (max - min + 1);
	return num;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	
	int R = Random(0, 100);
	int X;

	cout << "Вводите числа от 1 до 100\nУ вас есть 7 попыток\n";
	for (int i = 1; i < 8; i++)
	{
		cout << i << "-я попытка\n";
		cin >> X;
		if (R > X)
		{
			cout << "Нужное число больше, чем " << X << "!\n";
		}
		else
		{
			if (R < X)
			{
				cout << "Нужное число меньше, чем " << X << "!\n";
			}
			else
			{
				cout << "Поздравляем! Вы угадали число!";
				return 0;
			}
		}
	}

	cout << "Не угадали :(\n\n";
	cout << "Число = " << R;
	return 0;
}