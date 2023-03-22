#include <stdio.h>
#include <stdlib.h>

int main (int argc, char** argv)
{

  int arr1[10];
  int arr2[10];
  int arr3[10];
  int i;
  int max = 1000;
  for (i = 0 ; i < max ; i++)
  {
    arr1[i] = i;
  }

  for (i = 0 ; i < 10 ; i++)
    {
     arr1[i] = 100 + i;
     arr3[i] = 300 + i;
    }

  for (i = 0 ; i < 15 ; i++)
    {
     arr2[i] = 200 + i;
    }

  printf ("arr1: ");
  for (i = 0 ; i < 10 ; i++)
    printf ("%d, ", arr1[i]);
  printf ("\n");

  printf ("arr2: ");
  for (i = 0 ; i < 10 ; i++)
    printf ("%d, ", arr2[i]);
  printf ("\n");

  printf ("arr3: ");
  for (i = 0 ; i < 10 ; i++)
    printf ("%d, ", arr3[i]);
  printf ("\n");

  return 0;
}
