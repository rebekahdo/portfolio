#include <stdio.h>
#include <stdlib.h>

int main (int argc, char** argv)
{
  int* arr1;
  int size1 = 100;
  arr1 = (int *) malloc (sizeof(int) * size1);

  int max = 101l;
  int i;
  for (i = 0 ; i < max ; i++)
  {
    arr1[i] = i;
  }
  return 1;
}
