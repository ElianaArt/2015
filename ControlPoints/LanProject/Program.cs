using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //int counter = 0;
            //List<Byte> myList = new List<Byte>() { 0, 0, 0, 1, 1, 0 };
            //List<Byte> _List;

            //var a = myList.Select((b) => b).Where((c) =>
            //{
            //    counter++;
            //    return c == 1;
            //});



            //if (a.First(b => b == 1) == a.Last(b => b == 1))
            //{
            //    Console.WriteLine();
            //}
            //Console.WriteLine("counter = {0}", counter);
            //Console.ReadLine();

            Console.WriteLine(null == null);

            Console.WriteLine((new bool[0]).Count());

            //------------------------------------------------

            //int i = 0;
            //i += i + SomeFunc(ref i, out i);

            //Console.WriteLine(i);
            Console.ReadLine();

        }
        public static int SomeFunc(ref int i, out int b)
        {
            return b = ++i;
        }
    }
}
