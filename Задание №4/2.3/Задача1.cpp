#include <iostream>			//���������� ���������� ��� ����������� �����-������ ����������
#include <clocale>			//���������� ���������� ��� ����������� �������� ����� �� �������
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian"); //���������� ������� ����

	float i, j;

	cout << "������ ��������� �������� ��� ����� ����� �����\n\n";
	cout << "������� ������ �����: ";
	cin >> i;
	cout << "������� ������ �����: ";
	cin >> j;
	cout << "����������� ��������� ����� " << i << " �� ����� " << j << " ��������: " << i * j;

	return 0; //���������� �������� ������� main
}