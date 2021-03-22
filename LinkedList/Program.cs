using LinkedList.Model;
using System;
namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var circularList = new CircularList<int>();

            circularList.Add(2);
            circularList.Add(6);
            circularList.Add(9);
            circularList.Add(5);
            circularList.Add(3);

            foreach(var item in circularList)
                Console.WriteLine(item);
            Console.WriteLine();

            circularList.Delete(9);
            circularList.Delete(3);
            circularList.Delete(2);
            foreach (var item in circularList)
                Console.WriteLine(item);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
