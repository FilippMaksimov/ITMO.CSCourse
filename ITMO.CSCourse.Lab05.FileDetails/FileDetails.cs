using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMO.CSCourse.Lab05.FileDetails
{
    public class FileDetails
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            FileStream stream = new FileStream(fileName, FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            int size = (int)stream.Length;
            char[] contents = new char[size];
            for (int i = 0; i < size; i++)
            {
                contents[i] = (char)reader.Read();
            }
            //foreach (char ch in contents)
            //{
            //    Console.Write(ch);
            //}
            reader.Close();

            //Console.WriteLine(args.Length);
            //foreach (string arg in args)
            //{
            //    Console.WriteLine(arg);
            //}
            Summarize(contents); //Вызов метода!!!
        }
        static void Summarize(char[] contents)
        {
            int vowels = 0;
            int consonants = 0;
            int lines = 0;
            foreach (char current in contents)
            {
                if (Char.IsLetter(current))
                {
                    if ("EYUIOAeyuioa".IndexOf(current) != -1)
                    {
                        vowels++;
                    }
                    else
                    {
                        consonants++;
                    }
                }
                else if (current == '\n')
                {
                    lines++;
                }
            }
            Console.WriteLine("Total number of characters is: {0}", contents.Length);
            Console.WriteLine("Total number of vowels is: {0}", vowels);
            Console.WriteLine("Total number of consonants is: {0}", consonants);
            Console.WriteLine("Total number of lines is: {0}", lines);
        }
    }
}