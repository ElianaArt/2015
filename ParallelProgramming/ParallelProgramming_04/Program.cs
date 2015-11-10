using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming_04
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
        
        // Отличия потоков от задач
        //Thread threadOne = new Thread(SomeWork);
        //threadOne.Start();
        //threadOne.Join();

        //Task taskOne = new Task(SomeWork);
        //taskOne.Start();
        //taskOne.Wait();

        #region Tasks
        //static void HelloWorld()
        //{
        //    Console.WriteLine("Hello, world!");
        //}
        
        //static void Main()
        //{
        //    // Используем обычный метод
        //    Task t1 = new Task(HelloWorld);

        //    // Используем делегат Action
        //    Task t2 = new Task(new Action(HelloWorld));

        //    // Используем безымянный делегат
        //    Task t3 = new Task(delegate
        //        {
        //            HelloWorld();
        //        });

        //    // Используем лямбда-выражение
        //    Task t4 = new Task(() => HelloWorld());

        //    // Используем лямбда-выражение
        //    Task t5 = new Task(() =>
        //        {
        //             HelloWorld();
        //        });

        //    Task t6 = new Task(() =>
        //    {
        //         Console.WriteLine("Hello, world!");
        //    });

        //    // Запускаем задачи
        //    t1.Start(); t2.Start(); t3.Start();
        //    t4.Start(); t5.Start(); t6.Start();

        //    // Дожидаемся завершения задач
        //    Task.WaitAll(t1, t2, t3, t4, t5, t6);
        //    Console.ReadLine();
        //}
        #endregion


        #region TaskFactory
        //static void HelloWorld()
        //{
        //    Console.WriteLine("Hello, world!");
        //}

        //static void Main()
        //{
        //    Task t = Task.Factory.StartNew(HelloWorld);
        //    Task t1 = Task.Factory.StartNew(HelloWorld);
        //    Task t2 = Task.Factory.StartNew(HelloWorld);
        //    Task t3 = Task.Factory.StartNew(HelloWorld);
        //    // Дожидаемся завершения хотя бы одной задачи
        //    int firstTask = Task.WaitAny(t1, t2, t3);
        //    Console.WriteLine("firstTask = " + firstTask);
        //    // Дожидаемся завершения всех задач
        //    Task.WaitAll(t1, t2, t3);
        //    Console.ReadLine();
        //}
        #endregion


        #region Работа с данными в задаче
        //static string programName;
        //static void ShowTaskInfo(object taskName)
        //{
        //    Console.WriteLine("Task name: {0}, Task ID: {1}, thread id: {2}, Program name: {3}",
        //        taskName, Task.CurrentId, Thread.GetDomainID(), programName);
        //}
            
        //static void Main()
        //{
        //    programName ="Working with data";
        //    Task t1 = Task.Factory.StartNew(new Action<object>(ShowTaskInfo), "First worker");
        //    Task t2 = Task.Factory.StartNew(o => ShowTaskInfo(o), "Second worker");
        //    string t3Name = "Third worker";
        //    Task t3 = Task.Factory.StartNew(() => ShowTaskInfo(t3Name));
        //    Console.ReadLine();
        //}
        #endregion


        #region Свойство Result
        // Обращение к свойству блокирует поток до завершения задачи.

        //static void Main(string[] args)
        //{
        //    long lNumber = 123456789123456789;

        //    Task<double> SqrtTask = Task.Factory.StartNew((obj) =>
        //        {
        //            return Math.Sqrt((long)obj);
        //        }, lNumber);

        //    // Дожидаемся завершения вычислений без явной блокировки
        //    double sqrtNumber = SqrtTask.Result;
        //    Console.WriteLine("Result: {0}", sqrtNumber);
        //    Console.ReadLine();
        //}

        #endregion


        #region Вложенные задачи
        // Обращение к свойству блокирует поток до завершения задачи.
        // OUTPUT:
        //Parent task starts
        //Parent task ends 
        //Child task 
        //Parent task really ends
        //Inner task

        //static void Main(string[] args)
        //{
        //    Task tParent = Task.Factory.StartNew(() =>
        //    {
        //        Console.WriteLine("Parent task starts");

        //        Task t1 = Task.Factory.StartNew(() => Console.WriteLine("Child task"), TaskCreationOptions.AttachedToParent);
        //        Task t2 = Task.Factory.StartNew(() => 
        //            { 
        //                Thread.Sleep(100);
        //                Console.WriteLine("Inner task");
        //            }); // вложенная на один уровень
                    
        //            Console.WriteLine("Parent task ends");
        //        });

        //    tParent.Wait();

        //    Console.WriteLine("Parent task really ends");

        //    Console.ReadLine();
        //}

        #endregion


        #region Механизм отмены задач
        //static void Main()
        //{
        //    var cts = new CancellationTokenSource();
        //    var token = cts.Token;

        //    Task t1 = new Task (() =>
        //    {
        //        while(true)
        //        {
        //            DoSomeWork();
        //            if(token.IsCancellationRequested)
        //            {
        //                // Код обработки отмены
        //                SaveSomeData();
        //               // token.ThrowIfCancellationRequested();
        //                break;
        //            }
        //        }
        //    }, token);

        //    t1.Start();
        //    Thread.Sleep(100);
        //    cts.Cancel();
        //    t1.Wait();

        //    var cts2 = new CancellationTokenSource();
        //    var token2 = cts2.Token;

        //    // Регистрируем обработчик отмены
        //    token2.Register(() => {
        //        Console.WriteLine("Task #2 was cancelled");
        //        throw new TaskCanceledException();
        //    });

        //    Task t2 = new Task(() => {

        //        while(true)
        //             DoSomeWork();
               
        //    }, token2);

        //    t2.Start();
        //    Thread.Sleep(1000);
        //    cts2.Cancel();
        //    t2.Wait();

        //    Console.ReadLine();
        //}

        //private static void SaveSomeData()
        //{
        //    Console.WriteLine("Save some data");
        //}

        //private static void DoSomeWork()
        //{
        //    Console.WriteLine("Do some work");
        //}
        

        #endregion


        #region Исключения в задачах

        //private static void Main(string[] args)
        //{

        //    Task t1 = new Task(() =>
        //    {
        //        throw new OutOfMemoryException();
        //    });
        //    Task t2 = new Task(() =>
        //    {
        //        throw new DivideByZeroException();
        //    });
        //    t1.Start(); t2.Start();
        //    try
        //    {
        //        Task.WaitAll(t1, t2);
        //    }
        //    catch (AggregateException ae)
        //    {
        //        ae.Handle((inner) =>
        //        {
        //            if (inner is OutOfMemoryException)
        //            {
        //                // обработчик исключения
        //                MessageSurrogateFilter  
        //                return true;
        //            }
        //            else if (inner is DivideByZeroException)
        //            {
        //                // обработчик исключения
        //                return true;
        //            }
        //            else
        //                return false;
        //        });
        //    }

        //}

        #endregion
        
        

    }
}
