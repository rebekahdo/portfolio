/*  Rebekah Myrick          */
/*  CS 211                  */
/*  09/05/2021              */

#include <stdio.h>
#include <stdlib.h>


void arrayCopy(int fromArray[], int toArray[], int n);
void myFavorateSort(int arr[], int n);
int linSearch(int arr[], int n, int target, int* numComparisons);
int binSearch(int arr[], int n, int target, int* numComparisons);

int main(void)
{
    // allocate
    int *arr = NULL, *copyArr = NULL;

    int n = 0, id, comp;
    const int c = -999;
    int val;

    // prompt user to enter values
    printf("Enter in a list of numbers followed by the terminal value of %d:\n",c);
    scanf("%d", &val);

    // loop until user enter -999
    while(val != c)
    {
        n++;
        int *temp = malloc(sizeof(int)*(n));

        for(int i = 0;i < n -1; i++)
            temp[i] = arr[i];
        free(arr);
        arr = temp;
        arr[n-1] = val;
        scanf("%d", &val);
    }

    // update size using malloc
    copyArr = malloc(sizeof(int)*n);

    // copy array
    arrayCopy(arr, copyArr, n);
    myFavorateSort(copyArr, n);

    // read the integer to search
    printf("Enter a number value to search or %d to end: ",c);
    scanf("%d",&val);
    // loop until user enter -999
    while(val != c)
    {
        id = linSearch(arr, n, val, &comp);
        if(id == -1)
            printf("%d not found in array using linear search. ",val);
        else
            printf("%d found at index %d in the array using linear search. ",val, id);
            printf("Comparisons: %d\n",comp);

        id = binSearch(copyArr, n, val, &comp);

        if(id == -1)
            printf("%d not found in array using binary search. ",val);
        else
            printf("%d found at index %d in the array using binary search. ",val, id);
            printf("Comparisons: %d\n",comp);
            printf("\n");

        printf("Enter an number value to search or %d to end: ",c);
        scanf("%d",&val);
    }

    free(arr);
    free(copyArr);

    return 0;
}

//method to copy array
void arrayCopy(int fromArray[], int toArray[], int n)
{
    for(int i = 0; i < n; i++)
    {
        toArray[i] = fromArray[i];
    }
}

//method to sort array
void myFavorateSort(int arr[], int n)
{
    for(int i = 0; i < n -1; i++)
    {
        for(int j = 0; j < n -1 - i; j++)
        {
            if(arr[j] > arr[ j + 1])
            {
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
}

//method to search
int linSearch(int arr[], int n, int target, int* comp)
{
    *comp = 0;

    // loop to search
    for(int i = 0; i < n; i++)
    {
        (*comp)++;
        if(arr[i] == target)
            return i;
    }
return -1;
}

//method to search
int binSearch(int arr[], int n, int target, int* comp)
{
    *comp = 0;

    int low = 0, high = n -1;

    while(low <= high)
    {
        (*comp)++;
        int mid = (low + high) / 2;
        if(arr[mid] == target)
            return mid;
        else if(arr[mid] > target)
            high = mid - 1;
        else
            low = mid + 1;
    }

    return -1;
}
