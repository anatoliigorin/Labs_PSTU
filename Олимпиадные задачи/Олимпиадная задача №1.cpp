#include <iostream>
#include <clocale>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	int X;
	cout << "Введите трехзначное число с неповторяющимися цифрами:\n";
	cin >> X;

	while ((X < 100) || (X > 999))
	{
		cout << "Число введено некорректно. Попробуйте еще раз : \n";
		cin >> X;
	}

	int a,b,c;
	a = X % 10;
	X = X / 10;
	b = X % 10;
	c = X / 10;

	while ((a == b) || (a == c) || (b == c))
	{
		cout << "Цифры не должны повторяться! Введите число еще раз: ";
		cin >> X;
		a = X % 10;
		X = X / 10;
		b = X % 10;
		c = X / 10;
	}

	cout << "Все возможные последовательности чисел:\n";
	
	int t;
	cout << a << b << c << "\t";
	
	t = c; c = b; b = t;
	cout << a << b << c << "\t";
	
	t = a; a = b; b = t;
	cout << a << b << c << "\t";
	
	t = a; a = c; c = t;
	cout << a << b << c << "\t";
	
	t = c; c = b; b = t;
	cout << a << b << c << "\t";
	
	t = a; a = b; b = t;
	cout << a << b << c << "\t";

	cout << "\n\nНаибольшее из этих чисел: ";

	if ((a > b) && (a > c))
	{
		cout << a;
		if (b > c)
		{
			cout << b << c;
		}
		else
		{
			cout << c << b;
		}
	}
	else
	{
		if ((b > a) && (b > c))
		{
			cout << b;
			if (a > c)
			{
				cout << a << c;
			}
			else
			{
				cout << c << a;
			}
		}
		else
		{
			if ((c > b) && (c > a))
			{
				cout << c;
				if (b > a)
				{
					cout << b << a;
				}
				else
				{
					cout << a << b;
				}
			}
		}

	}
	return 0;
}