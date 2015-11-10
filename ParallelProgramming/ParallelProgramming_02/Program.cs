using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming_02
{
    //class Program
    //{
    //    static BigInteger Factorial(long n)
    //    {
    //        BigInteger res = 1;
    //        do
    //        {
    //            res = res * n;
    //        } while (--n > 0);
    //        return res;
    //    }
    //    static void Main()
    //    {
    //        BigInteger res1 = 0, res2 = 0, res3 = 0;
    //        long n1 = 1000, n2 = 5, n3 = 4;
    //        Thread t1 = new Thread(() =>
    //        {
    //            res1 = Factorial(n1);
    //        });
    //        Thread t2 = new Thread(() => { res2 = Factorial(n2); });
    //        Thread t3 = new Thread(() => { res3 = Factorial(n3); });
    //        // Запускаем потоки
    //        t1.Start();
    //        t2.Start();
    //        t3.Start();
    //        // Ожидаем завершения потоков
    //        t1.Join();
    //        t2.Join();
    //        t3.Join();
    //        Console.WriteLine("Factorial of {0} equals {1}", n1, res1);
    //        Console.WriteLine("Factorial of {0} equals {1}", n2, res2);
    //        Console.WriteLine("Factorial of {0} equals {1}", n3, res3);
    //    }
    //}

    //---------------------------------------------------------------------------------------

    //class Program
    //{
    //    static double res;
    //    static void ThreadWork(object state)
    //    {
    //        string sTitle = ((object[])state)[0] as string;
    //        double d = (double)(((object[])state)[1]);
    //        Console.WriteLine(sTitle);
    //        res = d;
    //    }
    //    static void Main()
    //    {
    //        Thread thr1 = new Thread(ThreadWork);
    //        thr1.Start(new object[] { "Thread #1", 3.14 });
    //        thr1.Join();
    //        Console.WriteLine("Result: {0}", res);
    //    }
    //}

    //---------------------------------------------------------------------------------------

    //class Program
    //{
    //    static void Main()
    //    {
    //        for (int i = 0; i < 10; i++)
    //        {
    //            Thread t = new Thread(() =>
    //            Console.Write("ABCDEFGHIJK"[i]));
    //            t.Start();
    //        }
    //        Console.WriteLine();
    //        Console.ReadLine();
    //    }
    //}

    //---------------------------------------------------------------------------------------

    //class Program
    //{
    //    private static void Main()
    //    {
    //        for (int i = 0; i < 11; i++)
    //        {
    //            int i_copy = i;
    //            Thread t = new Thread(delegate ()
    //            {
    //                Console.Write("ABCDEFGHIJK"[i_copy]);
    //                Thread.Yield();
    //            });
    //            t.Start();
    //        }
    //        //Console.WriteLine();
    //        Console.ReadLine();
    //    }
    //}

    //---------------------------------------------------------------------------------------

    //class Program
    //{
    //    private static void SomeFunc()
    //    {

    //    }

    //    private static void Main()
    //    {
    //        Thread[] arThr = new Thread[10];
    //        for (int i = 0; i < arThr.Length; i++)
    //        {
    //            arThr[i] = new Thread(SomeFunc);
    //            arThr[i].Name = i.ToString();
    //            arThr[i].Start();
    //        }
    //        for (int i = 0; i < arThr.Length; i++)
    //        {
    //            if (arThr[i].IsAlive == true)
    //            {
    //                // Выводим информацию о потоках
    //                Console.WriteLine("Thread Id: {0}, name: {1}, IsAlive: {2}",
    //                    arThr[i].ManagedThreadId,
    //                    arThr[i].Name,
    //                    arThr[i].IsAlive);
    //            }
    //        }   
    //       Console.WriteLine();
    //       Console.ReadLine();
    //  }
    //}

    //---------------------------------------------------------------------------------------

    //internal class ThreadInfo
    //{
    //    private static void Main()
    //    {
    //        Thread t = Thread.CurrentThread;
    //        t.Name ="MAIN THREAD";
    //        foreach (PropertyInfo p in t.GetType().GetProperties())
    //        {
    //            Console.WriteLine("{0}, {1}",p.Name,p.GetValue(t, null));
    //        }
    //    }
    //}

    //---------------------------------------------------------------------------------------

    //class PriorityTesting
    //{
    //    static long[] counts;
    //    static bool finish;
    //    static void ThreadFunc(object iThread)
    //    {
    //        while (true)
    //        {
    //            if (finish)
    //                break;
    //            counts[(int)iThread]++;
    //        }
    //    }
    //    static void Main()
    //    {
    //        counts = new long[5];
    //        Thread[] t = new Thread[5];
    //        for (int i = 0; i < t.Length; i++)
    //        {
    //            t[i] = new Thread(ThreadFunc);
    //            t[i].Priority = (ThreadPriority)i;
    //        }
    //        // Запускаем потоки
    //        for (int i = 0; i < t.Length; i++)
    //            t[i].Start(i);
    //        // Даём потокам возможность поработать 10 c
    //        Thread.Sleep(10000);
    //        // Сигнал о завершении
    //        finish = true;
    //        // Ожидаем завершения всех потоков
    //        for (int i = 0; i < t.Length; i++)
    //            t[i].Join();
    //        // Вывод результатов
    //        for (int i = 0; i < t.Length; i++)
    //            Console.WriteLine("Thread with priority {0}, Counts: {1}", (ThreadPriority)i, counts[i]);
    //    }
    //}

    //---------------------------------------------------------------------------------------

    //    class PriorityTesting
    //{
    //    static long[] counts;
    //    static bool finish;
    //    static void ThreadFunc(object iThread)
    //    {
    //        while(true)
    //        {
    //            if(finish)
    //            break;
    //            counts[(int)iThread]++;
    //            Thread.Sleep(0);
    //        }
    //    }
    //    static void Main()
    //    {
            
    //        int cratnost = 2;
    //        int treads = cratnost * 20;
    //        counts = new long[treads];
    //        Thread[] t = new Thread[treads];
    //        for (int i = 0; i < t.Length; i++)
    //        {
    //            t[i] = new Thread(ThreadFunc);
    //            t[i].Priority = (ThreadPriority)(i % cratnost);
    //        }

    //        // Запускаем потоки
    //        for(int i=0; i<t.Length; i++)
    //            t[i].Start(i % cratnost);
    //        // Даём потокам возможность поработать 10 c
    //        Thread.Sleep(5000);
    //        // Сигнал о завершении
    //        finish = true;
    //        // Ожидаем завершения всех потоков
    //        for(int i=0; i<t.Length; i++)
    //             t[i].Join();
    //        // Вывод результатов
    //        for(int i=0; i<t.Length; i++)
    //            Console.WriteLine("Thread with priority {0, 15}, Counts: {1}", (ThreadPriority)(i % cratnost), counts[i]);
    //        Console.ReadLine();
    //    }
    //}

    //---------------------------------------------------------------------------------------


}
