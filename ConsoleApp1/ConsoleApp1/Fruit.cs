using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Fruit
    {
        public bool IsRotten { get; set; }
        public string? Name { get; set; }
        public int Calories { get; set; }

        public Fruit(bool isRotten, string fruitName, int calories)
        {
            IsRotten = isRotten;
            Name = fruitName;
            Calories = calories;
        }

        public void Spoiled()
        {
            IsRotten = true;
        }
    }
}
