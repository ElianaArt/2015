using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySortTest
{

    #region Программа переворачивания строки
    //class Program
    //{
    //    
    //    static void Main(string[] args)
    //    {
    //        string massString = "12345";
    //        char[] unSortMass = massString.ToCharArray();
    //        sortMass = unSortMass.Reverse();

    //        Console.WriteLine(new string(sortMass.ToArray()));
    //        Console.ReadLine();
    //    }

    //    static IEnumerable<char> sortMass { get; set; }
    //}
    #endregion

    #region Программа проверки строки на наличие числа текущее + 1 LinkedList
    //class Program
    //{

    //    static void Main(string[] args)
    //    {
    //        LinkedList<uint> mass = new LinkedList<uint>();

    //        mass.AddFirst(5);
    //        mass.AddFirst(3);
    //        mass.AddFirst(1);
    //        mass.AddFirst(40);
    //        mass.AddFirst(2);

    //        uint min = mass.First.Value;
           
    //        Stopwatch sw = new Stopwatch();
    //        sw.Start();
    //        try
    //        {
    //            for (LinkedListNode<uint> i = mass.First; i != null; i = i.Next)
    //            {
    //                if (i.Value < min) min = i.Value;
    //            }
    //            for (int i = 0; i < mass.Count; i++)
    //            {
    //                if (mass.Contains(min + Convert.ToUInt32(i)))
    //                    Console.Write("T ");
    //                else
    //                {
    //                    Console.WriteLine("F ");
    //                    return;
    //                }
    //            }
    //        }
    //       finally
    //        {
    //            Console.WriteLine();
    //            Console.WriteLine(sw.Elapsed);
    //            sw.Stop();
    //            Console.ReadLine();
    //        }
         
    //        Console.ReadLine();
    //    }

       
    //}
    #endregion

    #region Программа проверки строки на наличие числа текущее + 1 List ( БЫСТРЕЕ!! 1 000 000 эл ) 0.120400 мс
    //class Program
    //{

    //    static void Main(string[] args)
    //    {
    //        List<uint> mass = new List<uint>();
    //        int count = 1000000;
    //        Random rnd = new Random();
    //        for (int i = 0; i < count; i++)
    //        {
    //            mass.Add(Convert.ToUInt32(rnd.Next(100)));
    //        }

    //        uint min = mass[0];

    //        Stopwatch sw = new Stopwatch();
    //        sw.Start();
    //        try
    //        {
    //            for (int i = 0; i < mass.Count; i++)
    //            {
    //                if (mass[i] < min) min = mass[i];
    //            }
    //            for (int i = 0; i < mass.Count; i++)
    //            {
    //                if (mass.Contains(min + Convert.ToUInt32(i)))
    //                    Console.Write("T ");
    //                else
    //                {
    //                    Console.WriteLine("F ");
    //                    return;
    //                }
    //            }
    //        }
    //        finally
    //        {
    //            Console.WriteLine();
    //            Console.WriteLine(sw.Elapsed);
    //            sw.Stop();
    //            Console.ReadLine();
    //        }

    //        Console.ReadLine();
    //    }


    //}
    #endregion

    #region Программа проверки строки на наличие числа текущее + 1 List (с сортировкой медленнее, с пузырьковой вообще хана) 0.2 c
    //class Program
    //{

    //    static void Main(string[] args)
    //    {

    //        List<uint> mass = new List<uint>();
    //        int count = 1000000;
    //        Random rnd = new Random();
    //        for (int i = 0; i < count; i++)
    //        {
    //            mass.Add(Convert.ToUInt32(rnd.Next(100)));
    //        }

    //        Stopwatch sw = new Stopwatch();
    //        sw.Start();
    //        try
    //        {
    //            mass.Sort();

    //            uint min = mass[0];

    //            for (int i = 0; i < mass.Count; i++)
    //            {
    //                if (mass.Contains(min + Convert.ToUInt32(i)))
    //                    Console.Write("T ");
    //                else
    //                {
    //                    Console.WriteLine("F ");
    //                    return;
    //                }
    //            }
    //        }
    //        finally
    //        {
    //            Console.WriteLine();
    //            Console.WriteLine(sw.Elapsed);
    //            sw.Stop();
    //            Console.ReadLine();
    //        }

    //        Console.ReadLine();
    //    }


    //}
    #endregion

    #region Программа проверки строки на наличие числа текущее + 1  0.00329
    //class Program
    //{

    //    static void Main(string[] args)
    //    {

    //        List<uint> mass = new List<uint>();

    //        int count = 1000000;
    //        Random rnd = new Random();
    //        for (int i = 0; i < count; i++)
    //        {
    //            mass.Add(Convert.ToUInt32(rnd.Next(100)));
    //        }

           

    //        Stopwatch sw = new Stopwatch();
    //        sw.Start();
    //        try
    //        {
    //            foreach (uint VARIABLE in mass)
    //            {

                
    //                if(!(mass.Contains(VARIABLE+1) && mass.Contains(VARIABLE - 1)))
    //                {
    //                    Console.WriteLine("F ");
    //                    return;
    //                }
                  
    //            }

    //        }
             
    //        finally
    //        {
    //            Console.WriteLine();
    //            Console.WriteLine(sw.Elapsed);
    //            sw.Stop();
    //            Console.ReadLine();
    //        }

    //        Console.ReadLine();
    //    }


    //}
    #endregion


    #region j = ?
    //class Program
    //{

    //    static void Main(string[] args)
    //    {

    //        int j = 0;
    //        for (int i = 0; i < 10; i++)
    //        {
    //            j = j++;
    //        }
    //        Console.WriteLine(" j = "+ j);
    //        Console.ReadLine();
    //    }


    //}
    #endregion



}

