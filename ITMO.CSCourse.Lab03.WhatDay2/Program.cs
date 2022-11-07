using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMO.CSCourse.Lab03.WhatDay2
{
    enum MonthName
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        Novebmer,
        December
    }

    internal class WhatDay
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter a day number between 1 and 365:");
                string line = Console.ReadLine();
                int dayNum = int.Parse(line);

                if (dayNum < 1 || dayNum > 365)
                {
                    throw new ArgumentOutOfRangeException("Day out of the range");
                }
                int monthNum = 0;
                foreach (int daysInMonth in DaysInMonths)
                {
                    if (dayNum <= daysInMonth)
                    {
                        break;
                    }
                    else
                    {
                        dayNum -= daysInMonth;
                        monthNum++;
                    }
                }
                MonthName temp = (MonthName)monthNum;
                string MonthName = temp.ToString();
                Console.WriteLine("{0}, {1}", dayNum, MonthName);
            }
            catch (Exception caught)
            {
                Console.WriteLine(caught);
            }
        }
        static System.Collections.ICollection DaysInMonths = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    }
}
