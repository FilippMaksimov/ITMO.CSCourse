using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Divider
{
    internal class DivideIt
    {
        public static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Введите первое целое число");
                string temp = Console.ReadLine();
                int i = Int32.Parse(temp);

                Console.WriteLine("Введите второе целое число");
                temp = Console.ReadLine();
                int j = Int32.Parse(temp);

                int k = i / j;
                Console.WriteLine("Результом деления {0} на {1} является {2} ", i, j, k);
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception was thrown, {0}", e);
            }
        }
    }
}


