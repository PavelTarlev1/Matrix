using System;
using System.Linq;

namespace Scrooge_McDuck
{
    class Scrooge_McDuck
    {


        static void Main(string[] args)
        {
            int[] firstNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int N = firstNumbers[0];
            int M = firstNumbers[1];

            int[,] matrix = new int[N + 2, M + 2];
            //  -----------> 
            // |           x N       
            // |
            // \  z M

            //вписване тип 
            //
            // 0 0 0 0 0 0
            // 0 3 3 3 3 0
            // 0 3 ж 3 3 0
            // 0 3 3 3 3 0 
            // 0 0 0 0 0 0

            for (int z = 1; z <= N; z++)
            {
                int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int x = 1; x <= M; x++)
                {
                    matrix[z, x] = arr[x - 1];
                }
            }

            //определяне кординатитена 0-лата в матрицата с вкючена рамка от 0-ли.


            int cordZ = 0;
            int cordX = 0;

            for (int z = 1; z <= N; z++)
            {
                for (int x = 1; x <= M; x++)
                {
                    if (matrix[z, x] == 0)
                    {
                        cordZ = z;
                        cordX = x;
                        break;
                    }
                }
            }

            int coins = 0;
            while (true)
            {
                //кординати
                int Left = matrix[cordZ, cordX - 1];
                int Right = matrix[cordZ, cordX + 1];
                int Down = matrix[cordZ + 1, cordX];
                int Up = matrix[cordZ - 1, cordX];

                if (Left == 0 && Right == 0 && Up == 0 && Down == 0)
                {
                    break;
                }
                else
                {
                    int nextPosition = Math.Max(Up, Math.Max(Down, Math.Max(Left, Right)));


                    if (nextPosition == Left)
                    {
                        cordX--;
                    }
                    else if (nextPosition == Right)
                    {
                        cordX++;
                    }
                    else if (nextPosition == Up)
                    {
                        cordZ--;
                    }
                    else if (nextPosition == Down)
                    {
                        cordZ++;
                    }
                    matrix[cordZ, cordX]--;
                    coins++;
                }
            }
            Console.WriteLine(coins);
        }
    }
}


}
