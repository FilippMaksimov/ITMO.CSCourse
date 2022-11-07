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
                Console.WriteLine("Please enter the yaer");
                string line = Console.ReadLine();
                int yearNum = int.Parse(line);
                bool isLeapYear = (yearNum % 4 == 0) && (yearNum % 100 != 0 || yearNum % 400 == 0); // Условие високосного года 
                if (isLeapYear)
                {
                    Console.WriteLine("This is a Leap Year");
                }
                else
                {
                    Console.WriteLine("This is not a Leap Year");
                }

                int maxDayNum = isLeapYear ? 366 : 365; //Если год високосный, макс значение 366, а если нет - 365!

                Console.WriteLine("Please enter a day number:");
                line = Console.ReadLine();
                int dayNum = int.Parse(line);

                if (dayNum < 1 || dayNum > maxDayNum)
                {
                    throw new ArgumentOutOfRangeException("Day out of the range");
                }
                int monthNum = 0;

                if (isLeapYear) // Для високосного года
                {
                    foreach (int daysInMonth in DaysInMonthsLeap)
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
                }
                else
                {
                    foreach (int daysInMonth in DaysInMonths) // для невисокосного года 
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
        static System.Collections.ICollection DaysInMonthsLeap = new int[12] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; // Новоя коллекция!
        static System.Collections.ICollection DaysInMonths = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    }
}
