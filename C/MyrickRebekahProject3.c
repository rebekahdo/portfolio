/*
 * Rebekah Myrick 10/6/21
 */
#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <time.h>

#include "prog3.h"

/***********************************************
*                                             **
*   MATRIX FUNCTIONS                          **
*                                             **
*   NOTE:  parameter n ALWAYS expresses the   **
*     dimensions of the square matrix in      **
*     question.                               **
*                                             **
***********************************************/
char ** alloc_square_mtx(int n) 
{
    char** square_char_matrix = (char**) malloc(n*sizeof (char*));
    for (int i = 0; i < n; ++i) 
    {
        *(square_char_matrix+i) = (char*) malloc(n*sizeof (char));
    }
    return square_char_matrix; // placeholder

}

/*
 * Free the memory
 */
void free_square_mtx(char **m, int n) 
{
    for (int i = 0; i < n; ++i) 
    {
        free(m[i]);
    }
    free(m);
}

/*
 * Populate the matrix with random lowercase alphabets
 */
void pop_mtx_alpha(char **m, int n)
{
    int lower_case_character_val = (int)'a';
    int upper_case_character_val = (int)'z';
    srand(time(0));
    for (int i = 0; i < n; ++i) 
    {
        for (int j = 0; j < n; ++j) 
        {
            char random_val = (char)((rand() % (upper_case_character_val -
                    lower_case_character_val + 1))+lower_case_character_val);
            m[i][j] = random_val;
        }
    }
}


/*
 * Displaying the matrix
 */
void display_mtx(char **m, int n){
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j) {
            printf("%c ", m[i][j]);
        }
        printf("\n");
    }
}

/*
 * Swaps the rows of the matrix
 */
void swap_rows(char **m, int n, int r1, int r2)
{
    if ((r1 >= 0 && r1 < n) && (r2 >= 0 && r2 < n) && (r1 != r2)) 
    {
        for (int i = 0; i < n; ++i) 
        {
            char temp = m[r1][i];
            m[r1][i] = m[r2][i];
            m[r2][i] = temp;
        }
    }
}

/*
 * Swaps the columns of the matrix
 */
void swap_cols(char **m, int n, int c1, int c2){
    if ((c1 >= 0 && c1 < n) && (c2 >= 0 && c2 < n) && (c1 != c2)) 
    {
        for (int i = 0; i < n; ++i) 
        {
            char temp = m[i][c1];
            m[i][c1] = m[i][c2];
            m[i][c2] = temp;
        }
    }
}

/*
 * Rotates the matrix 90 deg towards right
 */
void rotate_right(char **m, int n)
{
    for (int i = 0; i < n / 2; ++i) 
    {
        for (int j = i; j < n - i - 1; ++j) 
        {
            char temp = m[i][j];
            m[i][j] = m[n-1-j][i];
            m[n-1-j][i] = m[n-1-i][n-1-j];
            m[n-1-i][n-1-j] = m[j][n-1-i];
            m[j][n-1-i] = temp;
        }
    }
}


void floating_boulders(char **m, int n, int nb)
{
    // checking the boulders count
    nb = nb < 0 ? 0 : nb;
    nb = nb > n*n ? n*n : nb;
    char initial_fillchar, required_fillchar;
    // if number of boulders are more than half of the total spaces
    if (nb > (n*n) / 2) 
    {
        // set fill char to boulders
        initial_fillchar = '#';
        required_fillchar = '.';
        nb = n*n - nb;
    } 
    else 
    {
        initial_fillchar = '.';
        required_fillchar = '#';
    }
    // populating the entire matrix with the initial fill char
    for (int i = 0; i < n; ++i) 
    {
        for (int j = 0; j < n; ++j) 
        {
            m[i][j] = initial_fillchar;
        }
    }
    srand(time(0));
    while (nb > 0) 
    {
        int random_row = (rand() % n);
        int random_col = (rand() % n);
        if (m[random_row][random_col] == initial_fillchar) 
        {
            m[random_row][random_col] = required_fillchar;
            nb--;
        }
    }
}

/*
 * Pulls all the non-air objects towards the ground
 */
void gravity(char **m, int n)
{
    for (int i = n-1; i >= 0; --i) 
    {
        for (int j = 0; j < n; ++j) 
        {
            // if the current block is an air
            if (m[i][j] == '.') 
            {
                // till the blocks on the above rows for the current col
                // are air, move up
                // basically searching for floating boulders
                for (int k = i-1; k >= 0; --k) 
                {
                    // if the current block is not an air
                    // then swap the original air block with this
                    // block
                    if (m[k][j] != '.') 
                    {
                        char temp = m[i][j];
                        m[i][j] = m[k][j];
                        m[k][j] = temp;
                        break;
                    }
                }
            }
        }
    }
}

void mountains(char **m, int n)
{
    srand(time(0));
    int total_boulders = (rand() % (n*n+1));
    floating_boulders(m, n, total_boulders);
    gravity(m, n);
}



void sink(char **m, int n)
{
    for (int i = n-1; i > 0; --i) 
    {
        // swapping bottom row with the top row, this means that
        // at the end of the iteration, the bottom most row will
        // be at the top
        swap_rows(m, n, i, i-1);
    }
    for (int i = 0; i < n; ++i) 
    {
        // first row now becomes the air
        m[0][i] = '.';
    }
}








/***********************************************
*                                             **
*   STRING FUNCTIONS                          **
*                                             **
***********************************************/


void str_trim(char *s) 
{
    // getting the length of the string first
    int size = 0;
    for (int i = 0; s[i] != 0; ++i) 
    {
        size += 1;
    }
    // now processing the index from where the first character appears
    int startIdx = 0, endIdx = size;
    for (int i = 0; s[i] != '\0'; ++i) 
    {
        if (isspace(s[i])) 
        {
            startIdx++;
        } 
        else 
        {
            break;
        }
    }
    // getting the endIdx
    for (int i = size; i >= 0; --i) 
    {
        if (isspace(s[i])) 
        {
            --endIdx;
        } 
        else 
        {
            break;
        }
    }
    // now creating the trimmed string
    if (endIdx > startIdx) 
    {
        char* trimmedString = (char*) malloc((endIdx - startIdx + 1)*sizeof(char ));
        int k, i;
        for (i = startIdx, k = 0; i <= endIdx; ++i, ++k) 
        {
            trimmedString[k] = s[i];
        }
        trimmedString[k] = '\0';
        for (int j = 0; j < k; ++j) 
        {
            s[j] = trimmedString[j];
        }
        s[k] = '\0';
    }
}


int str_search(char *s, char *pattern) 
{
    int curr_idx;
    short found = 0;
    int found_idx = -1;
    for (int i = 0; s[i] != '\0'; ++i) 
    {
        // start searching for the pattern from this current index
        curr_idx = i;
        found = 1;
        int j;
        for (j = 0; pattern[j] != '\0' && s[i] != '\0'; ++j, ++i) 
        {
            // if characters do not match then break
            // set found = 0
            if (s[i] != pattern[j]) 
            {
                found = 0;
                break;
            }
        }
        // if found is 0, then match was not found
        // set i to be the curr_idx
        if (found == 0) 
        {
            i = curr_idx;
        } 
        else 
        {
            // this is for testing the case when the length
            // of the substring is more than the length of the string
            if (pattern[j] == '\0') 
            {
                found_idx = curr_idx;
                break;
            }

        }
    }
    return found_idx;  // just a placeholder to make gcc happy for now

}





#ifndef _LIB  // DO NOT REMOVE THIS LINE!!!
// IT DOESN"T CHANGE HOW YOUR PROGRAM
// WORKS, BUT IT GIVES US A WAY TO CALL
// YOUR FUNCTIONS FROM OUR CODE FOR
// TESTING

/**
* Write a test driver in main below to exercise and
*   your function implementations.
*
* Think carefully about your test cases!
*/
int main()
{



    // test driver
    char** random_mat = alloc_square_mtx(4);
    // displaying the floating boulders
    floating_boulders(random_mat, 4, 7);
    // displaying the matrix
    display_mtx(random_mat, 4);
    // now using gravity to bring all the blocks down
    gravity(random_mat, 4);
    printf("\n");
    display_mtx(random_mat, 4);
    // freeing up the memory
    free_square_mtx(random_mat, 4);


    // checking for trimming the string
    char newString[16] = "       a   b   ";
    printf("\n%s", newString);
    str_trim(newString);
    printf("\n%s", newString);

    // checking for finding out the string search
    char source_string[20] = "abracadabra";
    char pattern[20] = "dab";

    printf("\n%d\n", str_search(source_string, pattern));



}


#endif        // DO NOT REMOVE THIS LINE!!!