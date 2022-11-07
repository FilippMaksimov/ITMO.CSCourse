using ITMO.CSCourse.Lab07.Utils;
using System;

public class Test
{
    public static void Main()
    {
        string message;

        Console.WriteLine("Enter the string to reverse: ");
        message = Console.ReadLine();

        Utils.Reverse(ref message);
        Console.WriteLine(message);
    }
}