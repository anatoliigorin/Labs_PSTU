#include <iostream>			//���������� ���������� ��� ����������� �����-������ ����������
#include <clocale>			//���������� ��������� ��� ����������� ������� ����� �� �������
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian"); //���������� ������� ����

	const float fut = 7.481; //���������, ������������ ���������� �������� � ����� ���������� ���� 
	float i;

	cout << "������� ����� ��������: ";
	cin >> i;
	cout << "���������� ���������� ����� � " << i << " �������� ����� " << i / fut;

	return 0; //���������� �������� ������� main
}