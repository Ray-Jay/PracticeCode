using System;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int[,] spiral = new int[size, size];
        int totalElements = size * size;
        int rowBegin = 0;
        int rowEnd = size - 1;
        int columnBegin = 0;
        int columnEnd = size - 1;
        int number = 1;
        
        // print the perimeter elements of the square then make the square smaller each iteration
        // by moving start and end bounds
        while (number <= totalElements)
        {
            // left to right on a row
            for (int i = columnBegin; i <= columnEnd; i++) 
            {
                spiral[rowBegin, i] = number++;
            }
            rowBegin++;

            // down a column
            for (int i = rowBegin; i <= rowEnd; i++)
            {
                spiral[i, columnEnd] = number++;
            }
            columnEnd--;

            // right to left on a row
            for (int i = columnEnd; i >= columnBegin; i--)
            {
                spiral[rowEnd, i] = number++;
            }
            rowEnd--;

            // up a column
            for (int i = rowEnd; i >= rowBegin; i--)
            {
                spiral[i, columnBegin] = number++;
            }
            columnBegin++; 
        }
        return spiral;
    }
}
