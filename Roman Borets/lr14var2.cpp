#include <iostream>
#include <clocale>
#include <conio.h>

using namespace std;

struct Node 
{
	int key;
	Node *left;
	Node *right;
	Node *parent;
};

void push(Node **t, int val)
{
	if ((*t) == NULL)
	{
		(*t) = new Node;
		(*t)->key = val;
		(*t)->left = (*t)->right = NULL;
		return;
	}
	if (val > (*t)->key)
	{
		push(&(*t)->right, val);
	}
	else
	{
		push(&(*t)->left, val);
	}
}
//void print(Node *t,int u)
void print(Node *t)\\
{
	if (t != 0)
	{
		std::cout << t->key << "  ";

		print(t->left);
		print(t->right);
	}
}



int main()
{
	setlocale(LC_ALL, "Russian");
	Node *t = NULL;
	int val,n,s;
	cout << "������� ������ ������ -";
	cin >> val; cout << endl;
	push(&t, val);
	cout << "������� ���������� ��������� " << endl;
	cin >> n;
	for (int i = 0; i < n; i++)
	{
		cout << "������� �����" << endl << "->";
			cin >> s;
		push(&t, s);
	}
	cout << "���� ������" << endl;
	print(t);
	cout << endl<<"������� ����� �������..."<<endl;
	_getch();
	return 0;
}

