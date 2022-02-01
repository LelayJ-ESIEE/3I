#include <stdio.h>
#include <stdlib.h>

// a)

typedef struct matrix {
  int rows;
  int cols;
  double* data;
} Matrix;

// b)

Matrix* allocateMatrix(int rows, int cols) {
    if (rows <= 0 || cols <= 0) return NULL;

    // allocate a matrix structure
    Matrix* m = (Matrix*) malloc(sizeof(Matrix));

    // set dimensions
    m->rows = rows;
    m->cols = cols;

    // allocate a double array of length rows * cols
    m->data = (double *) malloc(rows*cols*sizeof(double));
    
    // set all data to 0 #JIC
    for (int i = 0; i < rows*cols; i++)
        m->data[i] = 0.0;

    return m;
}

// c)

int freeMatrix(Matrix* m) {
    if (!m) return -1;
    // free m's data
    for (int i = 0; i < m->rows*m->cols; i++)
        m->data[i] = 0.0;
    free(m->data);
    // free m
    m->rows = 0;
    m->cols = 0;
    free(m);
    return 0;
}

// d)
#define ELEM(m, row, col) \
    m->data[(row-1) * m->cols + (col-1)]

int setElement(Matrix* m, int row, int col, double val) 
{
    if (!m) return -1;
    if (row <= 0 || row > m->rows ||
        col <= 0 || col > m->cols)
        return -2;

    ELEM(m, row, col) = val;
    return 0;
}

int getElement(Matrix* m, int row, int col) {
    if (!m) return -1;
    if (row <= 0 || row > m->rows ||
        col <= 0 || col > m->cols)
        return -2;

    return ELEM(m, row, col);
}

// e)

double sumMatrixElements(Matrix* m) {
    if (!m) return -1;
    double sum = 0;
    for (int i = 0; i < m->rows; i++)
    {
        for(int j = 0; j<m->cols; j++)
            sum += getElement(m, i, j);
    }
    return sum;
}

// f)

Matrix* matrixMultiplication(Matrix* m1, Matrix* m2) {
    if (!m1 || !m2) return -1;
    if (!(m1->rows == m2->cols)) return -2;

    Matrix* prod = allocateMatrix(m1->rows, m2->cols);
    for(int i = 0; i < m1->rows; i++) {

    }
}