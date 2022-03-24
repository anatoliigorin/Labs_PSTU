#include <iostream>
#include <ctime>
#include <conio.h>
using namespace std;

class Dot
{
private:
	int posX;
	int posY;
public:
	
	void GetRandPos(int sizeX, int sizeY)
	{
		srand(time(0));
		this->posX = rand() % (sizeX);
		this->posY = rand() % (sizeY);
	}
	bool CheckPos(int tryX, int tryY)
	{
		if ((this->posX == tryX) && (this->posY == tryY))
			return true;
		else return false;
	}
	int GetPosX()
	{
		return this->posX;
	}
	int GetPosY()
	{
		return this->posY;
	}
};

void PrintDesk(Dot dot, int sizeX, int sizeY, int tryX, int tryY)
{
	for (int i = sizeY; i >= 0; i--)
	{
		if ((i == tryY) && (i == dot.GetPosY()))
		{
			if (tryX < dot.GetPosX())
			{
				for (int j = 0; j < tryX; j++)
					cout << "|  ";
				cout << "| o";
				for (int j = tryX + 1; j < dot.GetPosX(); j++)
					cout << "|  ";
				cout << "| X";
				for (int j = dot.GetPosX() + 1; j <= sizeX; j++)
					cout << "|  ";
				cout << "|" << endl;
			}
			else if (tryX > dot.GetPosX())
			{
				for (int j = 0; j < dot.GetPosX(); j++)
					cout << "|  ";
				cout << "| X";
				for (int j = dot.GetPosX() + 1; j < tryX; j++)
					cout << "|  ";
				cout << "| o";
				for (int j = tryX + 1; j <= sizeX; j++)
					cout << "|  ";
				cout << "|" << endl;
			}
		}
		else if (i == tryY)
		{
			for (int j = 0; j < tryX; j++)
				cout << "|  ";
			cout << "| o";
			for (int j = tryX + 1; j <= sizeX; j++)
				cout << "|  ";
			cout << "|" << endl;
		}
		else if (i == dot.GetPosY())
		{
			for (int j = 0; j < dot.GetPosX(); j++)
				cout << "|  ";
			cout << "| X";
			for (int j = dot.GetPosX() + 1; j <= sizeX; j++)
				cout << "|  ";
			cout << "|" << endl;
		}
		else
		{
			for (int j = 0; j <= sizeX; j++)
				cout << "|  ";
			cout << "|" << endl;
		}

	}
}


int main()
{
	setlocale(LC_ALL, "ru");

	Dot dot;
	int sizeX, sizeY;
	cout << "Игра Найди точку. Введите размер поля: ";
	cin >> sizeX >> sizeY;
	sizeX--;
	sizeY--;
	dot.GetRandPos(sizeX, sizeY);
	system("cls");
	for (int i = 0; i < sizeY; i++)
	{
		for (int j = 0; j <= sizeX; j++)
			cout << "|  ";
		cout << "|" << endl;
	}
	cout << "| o";
	for (int j = 1; j <= sizeX; j++)
		cout << "|  ";
	cout << "|" << endl;

	int tryX = 0, tryY = 0, score = 0;
	char turn;
	bool f = false;
	while (f == false)
	{
		cout << "Координаты(служебное): " << dot.GetPosX() << " " << dot.GetPosY() << endl;
		cout << "Ваш счет: " << score << endl;
		int getch(void);
		turn = getch();
		if (turn == 'w') tryY++;
		else if (turn == 'a') tryX--;
		else if (turn == 's') tryY--;
		else if (turn == 'd') tryX++;
		else cout << "Некорректный символ! ";
		while ((tryX > sizeX) || (tryY > sizeY) || (tryX < 0) || (tryY<0))
		{
			system("cls"); 
			cout << "Нельзя выходить с поля! Проигрыш!" << endl << "Куда идем(wasd)? " << endl;
			tryX = 0;
			tryY = 0;
			score = 0;
			PrintDesk(dot, sizeX, sizeY, tryX, tryY);
			turn = getch();
			if (turn == 'w') tryY++;
			else if (turn == 'a') tryX--;
			else if (turn == 's') tryY--;
			else if (turn == 'd') tryX++;
		}
		if (dot.CheckPos(tryX, tryY) == true)
		{
			dot.GetRandPos(sizeX, sizeY);
			score++;
		}
		system("cls");
		PrintDesk(dot, sizeX, sizeY, tryX, tryY);
	}
	return 0;
}
