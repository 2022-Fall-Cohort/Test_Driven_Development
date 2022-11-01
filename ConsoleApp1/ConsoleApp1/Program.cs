using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Fruit lemon = new Fruit(false, "Lemon", 80);

            Console.WriteLine($"Before Spoiled {lemon.IsRotten}");

            lemon.Spoiled();

            Console.WriteLine($"After Spoiled {lemon.IsRotten}");

            int[] iarray = { 1, 2, 3 };
            Console.WriteLine($"iarray.Length is {iarray.Length}");


        }
    }
}