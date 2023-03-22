#include <stdio.h>
#include <stdlib.h>

int main (int argc, char** argv)
{
 /* QUESTION 10 */
 /* code from Programming Project 1 description to "grow the array" */
 /* - modified so the variable names match the above code           */
 /* - this code will double the size of the current array           */

 /* set temp to refer to the location in memory of the original array */
 int *temp;
 temp = arr1;         /* REAL LINE OF CODE FOR QUESTION 10 */

 /* allocate new space for the larger array */
 arr1 = (int *) malloc ( size1 * 2 * sizeof(int) );

 /* copy the existing values from the original array to the larger array */
 for ( i = 0 ; i < size1 ; i++)
   arr1[i] = temp[i];

 /* return the allocated memory from the original array back to the OS */
 free (temp);

 /* update the size1 variable to properly reflect the current size of the array */
 size1 = size1 * 2;


 /* Now that the array has "grown" add some more values */
 /* add some new values into the array */
 for (i = originalSize ; i < size1 ; i++)
  {
   arr1[i] = 1000 + i;
  }

 /* print out the values just stored into the array 10 per line */
 printf ("\nThe current values in the array:\n");
 for (i = 0 ; i < size1; i++)
  {
   printf ("%7d", arr1[i]);
   if ((i+1)%10 == 0)
     printf ("\n");
  }
 printf ("\n");


 return 1;
}
