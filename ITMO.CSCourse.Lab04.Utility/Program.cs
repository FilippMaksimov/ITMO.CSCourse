using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ITMO.CSCourse.Lab04.Utility
{
    public class Test
    {
        public static void Main()
        {
            int x;
            int y;
            int greater;
            int f;
            bool ok;

            Console.WriteLine("Enter first number:");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            y = int.Parse(Console.ReadLine());

            greater = Utils.Greater(x, y);

            Console.WriteLine("The greater number is " + greater);

            Console.WriteLine("Before swap: " + x + "," + y);
            Utils.Swap(ref x, ref y);
            Console.WriteLine("After swap: " + x + "," + y);

            Console.WriteLine("Number for factorial:");
            x = int.Parse(Console.ReadLine());
            ok = Utils.Factorial(x, out f);
            if (ok)
                Console.WriteLine("Factorial of (" + x + ") = " + f);
            else
                Console.WriteLine("Cannot compute this factorial");

        }
    }
    internal class Utils
    {
        public static int Greater(int a, int b)
        {
            if (a > b)
                return a;
            else
                return b;
        }
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public static bool Factorial(int n, out int result)
        {
            int k;
            int f;
            bool ok = true;
            if (n < 0) ok = false;

            try
            {
                checked
                {
                    f = 1;
                    for (k = 2; k <= n; k++)
                    {
                        f = f * k;
                    }
                }
            }
            catch (OverflowException)
            {
                f = 0;
                ok = false;
            }
            result = f;
            return ok;
        }
    }
}
