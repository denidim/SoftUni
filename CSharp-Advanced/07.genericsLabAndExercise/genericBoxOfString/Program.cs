﻿using System;

namespace genericBoxOfString
{
    public class Box<T>
    {
        public T Value{ get; set; }
        public Box(T str)
        {
            Value = str;
        }


        public override string ToString()
        {
            return $"{Value.GetType()}: {Value}";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var box = new Box<string>(Console.ReadLine());
                Console.WriteLine(box);
            }
        }
    }
}
