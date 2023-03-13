using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Xml.Linq;

namespace Lab1_2_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task2();
        }

        static void Task1() 
        {
            List<int> sequence = new List<int>() { 5, -4, 6, -7, 8, -9, 10, 11, };
            var positiveNum = sequence.Where(n => n >= 0).ToList();

            Console.Write("Отриманий масив: ");
            for (int i = 0; i < positiveNum.Count; i++)
            {
                Console.Write($"{positiveNum[i]},");
            }
        }

        static void Task2()
        {
            Console.WriteLine("Введiть число, з яким порiвнюватимуться ключi словника");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>()
            {
                { 1, "a" },
                { 2, "b" },
                { 3, "c" },
                { 4, "d" }
            };

            Dictionary<int, string> newDictionary = new Dictionary<int, string>();

            Console.Write("Отриманий словник: ");
            foreach (var item in keyValuePairs.Where(i => choice <= i.Key))
            {
                Console.Write($" {item.Key} {item.Value} ");
                newDictionary.Add(item.Key, item.Value);
            }

            Console.WriteLine("\t");

            string json = JsonSerializer.Serialize(newDictionary);
            string path = @"text.txt";
            File.AppendAllText(path, json);

            Console.WriteLine($"Отриманий словник у форматi JSON {json}");
        }
        static void Task3LinkedList()
        {
            LinkedList<int> ints = new LinkedList<int>(Enumerable.Range(1, 10));

            while (ints.Count != 1)
            {
                List<LinkedListNode<int>> nodes = new List<LinkedListNode<int>>();

                bool flag = false;

                var node = ints.Last;

                while (node.Previous != null)
                {
                    if (flag)
                    {
                        nodes.Add(node);
                        node = node.Previous;
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
                }

                for (int i = 0; i < nodes.Count; i++)
                {
                    ints.Remove(nodes[i]);
                }
            }

            Console.Write("Отримане число: ");
            foreach (var item in ints)
            {
                Console.WriteLine(item);
            }

        }
        static void Task3List()
        {
            List<int> ints = new List<int>(Enumerable.Range(1, 10));
            while (ints.Count != 1)
            {
                ints = ints.Where((value, index) => index % 2 == 0).ToList();
            }

            Console.Write("Отримане число: ");
            foreach (var item in ints)
            {
                Console.WriteLine(item);
            }
        }
    }
}

