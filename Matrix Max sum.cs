using System;
using System.Linq;

namespace Matrix_Max_Sum
{
    class Matrix_max_sum
    {
        static void printMatrix(int[,] matrix)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int z = 0; z < matrix.GetLength(1); z++)
                {
                    Console.Write(" {0, 4}", matrix[x, z]);

                }
                Console.WriteLine();
            }
        }





        static void Main(string[] args)
        {
            int A = int.Parse(Console.ReadLine());
            int[] B = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[,] matrix = new int[A, B.Length];
            for (int i = 0; i < B.Length; i++)
            {
                matrix[0, i] = B[i];
            }
            for (int z = 1; z < A; z++)
            {
                int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int x = 0; x < B.Length; x++)
                {
                    matrix[z, x] = arr[x];
                }
            }
            int[] direction = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();


            int finalsum = int.MinValue;
            for (int i = 0; i < direction.Length; i += 2)
            {

                int x = (direction[i]);
                int z = (direction[i + 1]);
                int sum = 0;

                if (x > 0 && z > 0)

                {
                    x -= 1;
                    z -= 1;
                    for (int c = 0; c <= z; c++)
                    {
                        sum += matrix[x, c];
                    }
                    for (int r = 0; r <= x - 1; r++)
                    {
                        sum += matrix[r, z];
                    }
                }
                if (x < 0 && z < 0)
                {
                    x = Math.Abs(x) - 1;
                    z = Math.Abs(z) - 1;

                    for (int c = matrix.GetLength(1) - 1; c >= z; c--)
                    {
                        sum += matrix[x, c];
                    }
                    for (int r = matrix.GetLength(0) - 1; r > x; r--)
                    {
                        sum += matrix[r, z];
                    }
                }
                if (x > 0 && z < 0)
                {
                    z = Math.Abs(z) - 1;
                    x -= 1;

                    for (int c = 0; c <= z; c++)
                    {
                        sum += matrix[x, c];
                    }
                    for (int r = x + 1; r < matrix.GetLength(0); r++)
                    {
                        sum += matrix[r, z];
                    }
                }
                if (x < 0 && z > 0)
                {
                    x = Math.Abs(x) - 1;
                    z -= 1;
                    for (int c = matrix.GetLength(1) - 1; c >= z; c--)
                    {
                        sum += matrix[x, c];
                    }
                    for (int r = 0; r < x; r++)
                    {
                        sum += matrix[r, z];
                    }
                }
                if (sum > finalsum)
                {
                    finalsum = sum;
                }

            }
            Console.WriteLine(finalsum);
        }
    }
}
