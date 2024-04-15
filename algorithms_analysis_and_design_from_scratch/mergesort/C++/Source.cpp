#include <iostream>
using namespace std;

void merge(int array[], int start, int midPoint, int end)
{
	int left_lenght = midPoint - start + 1;
	int right_lenght = end - midPoint;

	int* left_array = new int[left_lenght];
	int* right_array = new int[right_lenght];

	int i, j, k;

	for (i = 0; i < left_lenght; ++i)
		left_array[i] = array[start + i];

	for (i = 0; i < right_lenght; ++i)
		right_array[i] = array[midPoint + 1 + i];

	i = 0, j = 0, k = start;

	while (i < left_lenght && j < right_lenght)
	{
		if (left_array[i] < right_array[j])
		{
			array[k] = left_array[i];
			++i;
		}
		else {
			array[k] = right_array[j];
			++j;
		}
		++k;
	}

	while (i < left_lenght)
	{
		array[k] = left_array[i];
		++i, ++k;
	}
	while (j < right_lenght)
	{
		array[k] = right_array[j];
		++j, ++k;
	}

	delete left_array, right_array;

}

void mergeSort(int array[], int start, int end)
{
	if (end <= start) return;
	int midPoint = (end + start) / 2;

	mergeSort(array, start, midPoint);
	mergeSort(array, midPoint + 1, end);
	merge(array, start, midPoint, end);
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
	int arr [] { 1, 4, 2, 29, 10, 7 };
	int n = sizeof(arr)/sizeof(arr[0]);
	mergeSort(arr, 0, n - 1);
	printArr(arr, n);


	return 0;
}