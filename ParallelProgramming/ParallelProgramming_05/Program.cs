using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming_05
{
    class Program
    {

        #region
        #endregion

        #region @@@
        //static void Main(string[] args)
        //{

        //Console.ReadLine();
        //}

        #endregion

        #region Parallel.Invoke
        
        // static CancellationToken cToken { get; set; }

        // static TaskScheduler tScheduler { get; set; }

        //static void Main(string[] args)
        //{

        //    Parallel.Invoke(FuncOne, FuncTwo);

        //    Action[] actions = new Action[4];
        //    actions[0] = new Action(() => Console.WriteLine("one"));
        //    actions[1] = new Action(() => Console.WriteLine("two"));
        //    actions[2] = new Action(() => Console.WriteLine("three"));
        //    actions[3] = new Action(() => Console.WriteLine("four"));
            
        //    ParallelOptions pOptions = new ParallelOptions()
        //    {
        //        MaxDegreeOfParallelism = 4,
        //        CancellationToken = cToken,
        //        TaskScheduler = tScheduler
        //    };
        //    Parallel.Invoke(pOptions, actions);

        //    var taskTwo = Task.Factory.StartNew(() => FuncTwoTask());
        //    var taskOne = Task.Factory.StartNew(() => FuncOneTask());
        //    Task.WaitAll(taskOne, taskTwo);


        //    Console.ReadLine();
        //}

        //private static void FuncOne()
        //{
        //    Console.WriteLine("Output FuncOne");
        //}

        //private static void FuncTwo()
        //{
        //    Console.WriteLine("Output FuncTwo");
        //}

        //private static void FuncOneTask()
        //{
        //    Console.WriteLine("Output FuncOneTask");
        //}

        //private static void FuncTwoTask()
        //{
        //    Console.WriteLine("Output FuncTwoTask");
        //}

        #endregion


        #region Parallel.For и Parallel.ForEach

        //private static void Main(string[] args)
        //{
        //    //int[] data = new int[500];
        //    //int[] results = new int[500];
        //    //// Последовательный цикл
        //    //for (int i = 0; i < data.Length; i++)
        //    //    data[i] = SomeWork(i);
        //    //// Параллельный цикл
        //    //Parallel.For(0, data.Length, i =>
        //    //{
        //    //    results[i] = SomeWork(data[i]);
        //    //});
        //    //Console.WriteLine("Total sum: {0}", results.Sum());
 
        //    //private static int SomeWork(int p)
        //    //{
        //    //Console.Write(p + " ");
        //    //return p;
        //    //}
        //    //------------------------------------------

        //    //List<string> words = new List<string> {"first", "second", "third", "four", "five" };

        //    //Parallel.ForEach(words, s => Console.WriteLine(s));

        //    //Parallel.For(0, 100, new ParallelOptions()
        //    //{
        //    //    MaxDegreeOfParallelism = 4,
        //    //    CancellationToken = ctoken
        //    //}, i => { Console.Write(Math.Sqrt(i) + " "); });

        //    //Console.ReadLine();
        //}

        //public static CancellationToken ctoken { get; set; }
        

        #endregion


        #region Разделение данных, динамическая декомпазиция Partitioner.Create
        static void Main(string[] args)
        {
            // Список элементов
            //List<string> list = new List<string> { "first", "second", "third", "four", "five" };
            //Parallel.ForEach(Partitioner.Create(list, true), s =>
            //{
            //    Console.WriteLine("Total : {0}", s);
            //});
            //Console.ReadLine();
        }

        #endregion


        #region Пакетная обработка итераций
        //static void Main(string[] args)
        //{
        //    const int N = 3;
         
        //    List<int> ar = new List<int>(){1,2,3};
        //    int sum = 0;
        //    Parallel.ForEach(
        //        Partitioner.Create(0, N),
        //                        // Начальная инициализация
        //        () => 0.0,
        //                        // Обработчик цикла
        //        (range, state, partial) =>
        //        {
        //            for (int i = range.Item1; i < range.Item2; i++)
        //                partial += ar[i];
        //            return partial;
        //        },
        //                        // финальный этап
        //        partial => Interlocked.Add(ref sum, Convert.ToInt32(partial))
        //        );
        //    Console.WriteLine("Sum : {0}", sum);
        //    Console.ReadLine();
        //}

        #endregion

    }
}
