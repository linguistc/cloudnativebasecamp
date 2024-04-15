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
	int arr[] = {1, 4, 2, 29, 10, 7};
	int n = sizeof(arr) / sizeof(arr[1]);
	insertionSort(arr, n);
	printArr(arr, n);
	return 0;
}
