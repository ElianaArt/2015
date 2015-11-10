using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming_03
{
    internal class Program
    {
        #region 
        #endregion

        #region @@@
        //  ---------------------------------------
        //  @@@ 
        //  ---------------------------------------

        #endregion

        #region два типа ожидания, активное и пассивное

        //  ---------------------------------------
        //  два типа ожидания, активное и пассивное
        //  ---------------------------------------

        ////static bool b;
        ////static double res;
        ////static void SomeWork()
        ////{
        ////    for (int i=0; i<100000; i++)
        ////    for(int j=0; j<20; j++)
        ////    res += Math.Pow(i, 1.33);
        ////    b = true;
        ////}

        ////static void Main()
        ////{
        ////    Stopwatch sw = new Stopwatch();
        ////    Thread thr1 = new Thread(SomeWork);
        ////    thr1.Start();
        ////    sw.Start();
        ////    // Активное ожидание в цикле
        ////    while(!b) ;
        ////    Console.WriteLine("1) Result = {0}, time ={1}",res, sw.ElapsedTicks);
        ////    sw = new Stopwatch();
        ////    res = 0;
        ////    Thread thr2 = new Thread(SomeWork);
        ////    thr2.Start();
        ////    sw.Start();
        ////    // Ожидание с выгружением контекста
        ////    thr2.Join();
        ////    Console.WriteLine("2) Result = {0}, time ={1}", res, sw.ElapsedTicks);
        ////    Console.ReadLine();
        ////}
        #endregion

        #region блокировка потоков  с помощью lock

        //  ---------------------------------------
        // блокировка потоков  с помощью lock
        //  ---------------------------------------

        //public string data;

        //private static Program GetParam()
        //{
        //    Program program = new Program();
        //    return program;
        //}

        //public static Program programProperty
        //{
        //    get
        //    {
        //        return GetParam();
        //    }
        //}

        //static void Main()
        //{
        //    Thread th1 = new Thread(new ThreadStart(programProperty.DoSomeWork1));
        //    th1.Name = "First";
        //    Thread th2 = new Thread(new ThreadStart(programProperty.DoSomeWork2));
        //    th2.Name = "Second";
        //    th1.Start(); th2.Start();

        //    Console.ReadLine();
        //}

        //void DoSomeWork1()
        //{
        //    lock(this)
        //    {
        //        Thread.Sleep(100);
        //        data = "AAAA";
        //        Console.WriteLine("Thread: {0}, Data: {1}", Thread.CurrentThread.Name, data);
        //    }
        //}
        //void DoSomeWork2()
        //{
        //    Thread.Sleep(100);
        //    data ="BBBB";
        //    Console.WriteLine("Thread: {0}, Data: {1}", Thread.CurrentThread.Name, data);
        //}
        #endregion

        #region проверка запущенности потока через Mutex
        //  ---------------------------------------
        // проверка запущенности потока через Mutex
        //  ---------------------------------------


        //class MyApplication
        //{
        //    static void Main()
        //    {   
        //        var mutex = new Mutex(false, "MyApp ver 2.0");
        //        if(!mutex.WaitOne(TimeSpan.FromSeconds(5), false))
        //        {
        //            Console.WriteLine("Приложение уже запущено");
        //            return;
        //        }
        //        Run();
        //        mutex.Dispose();
        //        Console.ReadLine();
        //    }

        //    static void Run()
        //    {
        //        Console.WriteLine("Welcome to MyApp ver 2.0");
        //    }
        //}
        #endregion

        #region  ManualResetEvent
        //  ---------------------------------------
        //  Вызов метода WaitOne блокирует первый поток в ожидании сигнала от второго потока. Сигнал генерируется при вызове метода Set. 
        //  ManualResetEvent(false)!!!
        //  ---------------------------------------

        //private static string data;
        //private static Program GetParam()
        //{
        //    Program program = new Program();
        //    return program;
        //}

        //public static Program programProperty
        //{
        //    get
        //    {
        //        return GetParam();
        //    }
        //}
        //static void Main()
        //{
        //    object obj = new ManualResetEvent(false);
        //    Thread th1 = new Thread(new ParameterizedThreadStart(programProperty.OneThread));
        //    Thread th2 = new Thread(new ParameterizedThreadStart(programProperty.SecondThread));
        //    th1.Start(obj);
        //    th2.Start(obj);

        //    Console.ReadLine();
        //}

        //void OneThread(object o)
        //{
        //    ManualResetEvent mre = (ManualResetEvent)o;
        //   // Console.WriteLine("mre.Equals(o): " + mre.Equals(o));
        //    mre.WaitOne();
        //    Console.WriteLine("Data from thread #2: " + data);
        //}

        //void SecondThread(object o)
        //{
        //    ManualResetEvent mre = (ManualResetEvent)o;
        //    Console.WriteLine("Writing data");
        //    data = "BBBBBB";
        //    mre.Set();
        //}
        #endregion

        #region ManualResetEvent WaitOne() Set() Reset()
       
        //  ---------------------------------------
        //  Вызов метода WaitOne блокирует первый поток в ожидании сигнала от второго потока. Сигнал генерируется при вызове метода Set. 
        //  РАБОТАЮЩИЙ ПРИМЕР
        //  ---------------------------------------

        // private class MyThread
        // {
        //     public Thread Thrd;
        //     private ManualResetEvent mre;

        //     public MyThread(string name, ManualResetEvent evt)
        //     {
        //         Thrd = new Thread(this.Run);
        //         Thrd.Name = name;
        //         mre = evt;
        //         Thrd.Start();
        //     }

        //     private void Run()
        //     {
        //         Console.WriteLine("Внутри потока " + Thrd.Name);

        //         for (int i = 0; i < 5; i++)
        //         {
        //             Console.WriteLine(Thrd.Name);
        //             Thread.Sleep(500);
        //         }

        //         Console.WriteLine(Thrd.Name + " завершен!");

        //         // Уведомление о событии
        //       mre.Set();
        //     }
        // }

        //private static void Main()
        //     {
        //         ManualResetEvent evtObj = new ManualResetEvent(false);

        //         MyThread mt1 = new MyThread("Событийный поток 1", evtObj);

        //         Console.WriteLine("Основной поток ожидает событие");

        //         evtObj.WaitOne();

        //         Console.WriteLine("Основной поток получил уведомление о событии от первого потока");

        //         evtObj.Reset();

        //         mt1 = new MyThread("Событийный поток 2", evtObj);

        //         evtObj.WaitOne();

        //         Console.WriteLine("Основной поток получил уведомление о событии от второго потока");
        //         Console.ReadLine();
        //     }
        #endregion

        #region AutoResetEvent
        //  ---------------------------------------
        //  AutoResetEvent последовательный доступ к критической скции
        //  ---------------------------------------

        //static void ThreadFunc(object o)
        //{
        //    var lockEvent = o as AutoResetEvent;
        //    ParallelWork(Thread.CurrentThread.Name);
        //    lockEvent.WaitOne();
        //    CriticalWork(Thread.CurrentThread.Name);
        //    lockEvent.Set();
        //}

        //private static void CriticalWork(string threadName)
        //{
        //    Console.WriteLine("CriticalWork - " + threadName);
        //}

        //private static void ParallelWork(string threadName)
        //{
        //    Console.WriteLine("ParallelWork - " + threadName);

        //}
        //static void Main()
        //{
        //    Thread[] workers = new Thread[5];
        //    for (int i = 0; i < 5; i++)
        //    {
        //        workers[i] = new Thread(ThreadFunc);
        //        workers[i].Name = "Поток №" + i;
        //    }
        //    var lockEvent = new AutoResetEvent(true);
        //    for (int i = 0; i < 5; i++)
        //        workers[i].Start(lockEvent);
        //    Console.ReadLine();
        //}
        #endregion

        #region Семафоры
        //  ---------------------------------------
        //  Семафоры 
        //  ---------------------------------------

        // Применение семафоров
        //class SemaphoreSlimTesting
        //{
        //    private static SemaphoreSlim sem;

        //    private static void Worker(object num)
        //    {
        //        // Ждем сигнала от управляющего
        //        sem.Wait();
        //        // Начинаем работу
        //        Console.WriteLine("Worker {0} starting", num);
        //    }

        //    private static void Main()
        //    {
        //        // Максимальная емкость семафора: 5
        //        // Начальное состояние: 0 (все блокируются)
        //        sem = new SemaphoreSlim(0, 5);
        //        Thread[] workers = new Thread[10];
        //        for(int i=0; i<workers.Length; i++)
        //        {
        //            workers[i] = new Thread(Worker);
        //            workers[i].Start(i);
        //        }

        //        Thread.Sleep(300);
        //        Console.WriteLine("Разрешаем работу трем рабочим");

        //        sem.Release(3);

        //        Thread.Sleep(200);
        //        Console.WriteLine("Разрешаем работу еще двум рабочим");

        //        sem.Release(2);
        //        Console.ReadLine();
        //    }
        //}
        #endregion

        #region Атомарные операторы
        //  ---------------------------------------
        //  Increment
        //  ---------------------------------------

        //private static int counter;
        //private class MyThread
        //{
        //    private  Thread Thrd;
        //    private ManualResetEvent mre;

        //    public MyThread(string name)
        //    {
        //        Thrd = new Thread(this.Run);
        //        Thrd.Name = name;
        //        Thrd.Start();
        //    }

        //    private void Run()
        //    {
        //        Stopwatch sw = new Stopwatch();
        //        sw.Start();
        //        lock (this)
        //        {
        //            counter++;
        //        }
        //        Console.WriteLine("за {2} поток № {0}) увеличил counter, новое значение которго = {1}", Thrd.Name, counter, sw.ElapsedTicks.ToString());
        //        sw.Stop();
        //        sw = new Stopwatch();
        //        sw.Start();
        //        // можно выполнить с помощью атомарного оператора
        //        Interlocked.Decrement(ref counter);
        //        Console.WriteLine("за {2} поток № {0}) уменьшил  counter, новое значение которго = {1}", Thrd.Name, counter, sw.ElapsedTicks.ToString());
        //        sw.Stop();
        //    }
        //}

        //private static void Main()
        //{
        //    MyThread[] workers = new MyThread[10];
        //    for (int i = 0; i < workers.Length; i++)
        //    {
        //        workers[i] = new MyThread(i.ToString());
        //    }
        //    Console.ReadLine();

        //}

        #endregion

        #region Конкурентные коллекции

        /// <summary>
        /// ConcurrentBag - Неупорядоченная коллекция
        /// ConcurrentQueue - FIFO-очередь
        /// ConcurrentStack - LIFO-стэк
        /// ConcurrentDictionary - Словарь
        /// BlockingCollection - Ограниченная коллекция
        /// </summary>

        #region ConcurrentBag

        //
        //извлечение элементов из ConcurrentBag осуществляется по принципу LIFO с учетом локальности.
        ///
        //private static void Main()
        //{
        // ----------------------------------------------
        //var bag = new ConcurrentBag<int>();
        //Parallel.For(0, 100000, i =>
        //{
        //    bag.Add(i);
        //});

        //Console.WriteLine("Кол-во элементов в неупорядочной коллекции: {0}", bag.Count);
        //Console.ReadLine();
        //   ----------------------------------------------

        // Обычные коллекции не позволяют изменять объект, который используется в foreach-перечислении.
        // Конкурентные коллекции, обеспечивая многопоточный доступ, позволяют добавлять элементы внутри цикла foreach при переборе элементов
        //var bag = new ConcurrentBag<int>();
        //for(int i=0; i<10; i++)
        //    bag.Add(i);

        //foreach(int k in bag)
        //{
        //    bag.Add(k);
        //    Console.Write(bag.Count + " ");
        //}
        //Console.ReadLine();
        //}

        #endregion

        #region BlockingCollection
        ////private static void Main()
        ////{
        ////    BlockingCollection<int> bc = new BlockingCollection<int>(new ConcurrentStack<int>());
        ////    Parallel.For(0, 10, i =>
        ////    {
        ////        bc.Add(i);
                
        ////    });

        ////    Console.WriteLine("Кол-во элементов в неупорядочной коллекции: {0}", bc.Count);

        ////    foreach (int k in bc)
        ////    {
        ////        var a = bc.Take();
        ////        Console.Write(a + " ");
        ////    }

        ////    Console.ReadLine();
        ////}
        #endregion

        #region ConcurrentDictionary
        //private static void Main()
        //{
        //   // Создаем конкурентный словарь
        //    var cd = new ConcurrentDictionary<string, int>();
        //    // Хотим получить элемент с ключом “b”, если нет - создаем
        //    int value = cd.GetOrAdd("b", (key) => 555);
        //    // Проверяем: value = 555;
        //    value = cd.GetOrAdd("b", -333);
        //    // Параллельно пытаемся обновить элемент с ключом “a”
        //    Parallel.For(0, 100000, i =>
        //    {
        //        // Если ключа нет – добавляем
        //        // Если есть – обновляем значение
        //        cd.AddOrUpdate("a", 1, (key, oldValue) => oldValue + 1);
        //    });

        //    Console.WriteLine("Element “a”: {0}", cd["a"]);
        //    Console.WriteLine("Element “b”: {0}", cd["b"]);
        //    Console.ReadLine();
        //}
        #endregion

        #endregion

    }

}
