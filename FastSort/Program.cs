using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int>();
            Random rnd = new Random();
            myList.Add(rnd.Next(100));
            myList.Add(rnd.Next(100));
            myList.Add(rnd.Next(100));
            myList.Add(rnd.Next(100));
            myList.Add(rnd.Next(100));
            myList.Add(rnd.Next(100));
            myList.Add(rnd.Next(100));
            myList.Add(rnd.Next(100));
            myList.Add(rnd.Next(100));
            myList.Add(rnd.Next(100));
            myList.Add(rnd.Next(100));


            for (int i = 0; i < myList.Count; i++)
            {
                if (i == FastSort.index)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("'" + myList[i] + "' ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.Write("'" + myList[i] + "' "); 
            }
               
            
            Console.WriteLine();


            myList = myList.FSort();

            for (int i = 0; i < myList.Count; i++)
            {
                if (i == FastSort.index)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("'" + myList[i] + "' ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.Write("'" + myList[i] + "' ");
            }

            Console.ReadLine();
        }
    }

    
    public static class FastSort
    {
        public static  int index = 7;

        public static List<int> FSort(this List<int> list)
        {
            //Random rnd = new Random();
            //int index = rnd.Next(list.Count-1);

            //Console.WriteLine("index = " + index);

            for (int i = 0; i < index; i++)
            {
                if (list[i] > list[index])
                {
                    Swap(list, i, index);
                    index = i;
                    Console.WriteLine("index = " + index);
                }
            }

            for (int i = 0; i < index; i++)
            {
                for (int j = i + 1; j < index - 1; j++)
                {
                    if (list[i] > list[j])
                    {
                        Swap(list, i, j);
                    }
                    if (list[i] > list[index])
                    {
                        Swap(list, i, index);
                        index = i;
                        Console.WriteLine("index = " + index);
                    }
                }
            }

            return list; 
        }


        public static int FindNext(int index, List<int> list)
        {
            if (list.Count - 1  > index)
            {
                for (int i = index+1; i < list.Count; i++)
                {
                    if(list[i])
                }
            }
            return 0; 
        }

        public static List<int>  Swap(List<int> list, int a, int b)
        {
            int temp = list[a];
            list[a] = list[b];
            list[b] = temp;
            return list;
        }

    }
}
