using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ITMO.CSCourse.Lab05.MatrixMultiply
{
    internal class MatrixMultiply
    {
        static void Main()
        {
            int[,] a = new int[2, 2];
            int[,] b = new int[2, 2];
            Input(a, b);
            int[,] result = Multiply(a, b); //Объявление массива result с происвоением вызова метода Multiply!
            Output(result); //Вызов метода Output в методе Main!   
        }
        static void Input(int[,] dst1, int[,] dst2)
        {
            for (int r = 0; r < 2; r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    Console.Write("Enter the value for [{0},{1}] of first matrix: ", r, c);
                    string s1 = Console.ReadLine();
                    Console.WriteLine(s1);
                    dst1[r, c] = int.Parse(s1);
                }
            }
            Console.WriteLine();
            for (int r = 0; r < 2; r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    Console.Write("Enter the value for [{0},{1}] of second matrix: ", r, c);
                    string s2 = Console.ReadLine();
                    Console.WriteLine(s2);
                    dst2[r, c] = int.Parse(s2);
                }
            }
            Console.WriteLine();
        }
        static int[,] Multiply(int[,] a, int[,] b)
        {
            int[,] result = new int[2, 2]; //Задание параметров массива result
            for (int r = 0; r < 2; r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    result[r, c] += a[r, 0] * b[0, c] + a[r, 1] * b[1, c];
                }
            }
            return result;
        }
        static void Output(int[,] result)
        {
            for (int r = 0; r < result.GetLength(0); r++)
            {
                for (int c = 0; c < result.GetLength(1); c++)
                {
                    Console.WriteLine("{0} ", result[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}

