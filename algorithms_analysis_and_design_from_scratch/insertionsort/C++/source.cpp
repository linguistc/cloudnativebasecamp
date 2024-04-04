#include <iostream>;
using namespace std;

void insertionSort(int arr[], int n)
{
	int i = 1, j, key;			// 1
	for (; i < n; ++i)					// n
	{
		j = i - 1;						// n
		key = arr[i];					// n
		while (j >= 0)					// n*n
		{
			if (key < arr[j])			// n*n
				arr[j + 1] = arr[j];	// n*n
			else break;
			--j;						// n*n
		}
		arr[j + 1] = key;				// n
	}
}

/*
		f(n) = 4n^2 + 4n + 1
		f(n) = O(n^2) as n -> infinity

				O(n^2)
*/

void readArr(int arr[], int n)
{
	for (int i = 0; i < n; ++i)
	{
		cout << "Element " << i + 1 << ": ";
		cin >> arr[i];
	}
}
void printArr(int arr[], int n)
{
	cout << "[";
	for (int i = 0; i < n; ++i)
	{
		cout << arr[i];
		if (i != n - 1) cout << ", ";
	}
	cout << "]\n";
}


int main()
{
	int n;
	cout << "How many Elements to sort? ";
	cin >> n;
	int* arr = new int[n];
	readArr(arr, n);
	insertionSort(arr, n);
	printArr(arr, n);


	return 0;
}
