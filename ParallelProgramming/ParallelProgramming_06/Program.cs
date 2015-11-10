using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming_06
{

    #region
    #endregion


    #region @@@
    //static void Main(string[] args)
    //{

    //Console.ReadLine();
    //}

    #endregion

    #region .....
        //static void Main(string[] args)
        //{
        //    #region ------
        
        //    #endregion

        //    #region ------

        //    #endregion

        //    #region ------


        //    #endregion

        //    #region ------

        //    #endregion

        //    Console.ReadLine();
        //}
        #endregion

    class Program
    {

        #region PLINQ
        //static void Main(string[] args)
        //{
            #region Примеры параллельного запроса к массиву
            //IEnumerable<int> numbers = Enumerable.Range(1, 100);

            //var parQ2 = from n in ParallelEnumerable.Range(1, 100)
            //            where n % 2 == 0
            //            select Math.Pow(n, 2);

            //// Последовательный запрос
            //var seqQ = from n in numbers
            //           where n % 2 == 0
            //           select Math.Pow(n, 2);
            //// Объявляем запрос, который выполняется параллельно
            //var parQ = from n in numbers.AsParallel()
            //           where n % 2 == 0
            //           select Math.Pow(n, 2);

            //var selPow = numbers.AsParallel().Select(n => Math.Pow(n, 2)).ToArray();

            //var parEn = ParallelEnumerable.Range(1, 6).Where(n => n % 2 != 0).Select(n => n * n).ToArray();

            //var threads =   from n in ParallelEnumerable.Range(1, 1000)
            //                select Thread.CurrentThread.ManagedThreadId;
            #endregion

            #region Повышение быстродействия при выполнении операторов типа Distinct
            //-----------------------------------------------------
            /// , так как запросы Take, TakeWhile, Skip, SkipWhile работают только с исходным порядком элементов.
            /// Быстродействие выполнения второго варианта в 2 – 2.5 раза превышает параллельную версию. 
            /// Разный порядок операторов приводит к тому, что метод Distinct применяется для массива, 
            /// то есть типа IEnumerable<T>, а не для типа ParallelQuery<T>. 
            /// Поэтому вызывается последовательная версия поиска различных элементов.
            /// 
            //foreach (var VARIABLE in threads.ToArray().Distinct().OrderBy(i => i))
            //{
            //    Console.Write(VARIABLE + " ");
            //}

            // Console.WriteLine();

            //-------------------------------------------------------
            #endregion

            #region При изменении порядка элементов запрос не рапараллеливается 

            // В этом фрагменте получаем число потоков, участвовавших в обработке элементов. 
            // Оператор Where выполняет отбор элементов и изменяет индексы элементов в структуре - двойка была вторым элементом, становится первым. 
            // Изменения индексов препятствует распараллеливанию индексной версии Select. 
            // Поэтому запрос не распараллеливается и число потоков nThr равно одному.

            //var threadsSecond = ParallelEnumerable.Range(1, 1000)
            //                .Where(n => n % 2 == 0)
            //                .Select((int n, int i) =>
            //                Thread.CurrentThread.ManagedThreadId);
            //int nThr = threadsSecond.ToArray().Distinct().Count();
            //Console.Write(nThr + " ");

            //-------------------------------------------------------
            #endregion

            #region Принудительное распараллеливание ForceParallelism
            // Несмотря на то, что оператор Where фактически пропускает все элементы, анализатор
            //PLINQ-запросов по умолчанию не распараллеливал бы выполнение запроса. 
            //Но режим ForceParallelism позволяет включить распараллеливание, например, в отладочных целях.
            
            //var threadsForceParallelism = "abcdef".AsParallel()
            //                                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            //                                .Where(c => true)
            //                                .Take(3)
            //                                .Select(c=> Thread.CurrentThread.ManagedThreadId);
            //int nThr = threadsForceParallelism.ToArray().Distinct().Count();

            //foreach (var VARIABLE in threadsForceParallelism)
            //{
            //    Console.Write(VARIABLE + " ");
            //}
            //Console.WriteLine();
            //Console.WriteLine("nThr = {0}", nThr);
            //-------------------------------------------------------
            // обратное преобразование ParallelEnumerable в IEnumerable с помощью метода AsSequential.
            //var q = data.AsParallel()
            //            .Select(item => DoSome(item)).Where(item => IsValid(item))
            //            .AsSequential().Select(item => DoSomeSeq(item))
            //            .ToArray();
            #endregion

          //  Console.ReadLine();
        //}
        #endregion

        #region Буферизация
        //static void Main(string[] args)
        //{
            #region AutoBuffered
            //по умолчанию
            //объем буфера для вычисления результатов определяется исполняющей средой
            //var numbers = ParallelEnumerable.Range(1, 10);
            //var query = numbers.Select(n =>
            //            {
            //            Thread.Sleep(500);
            //            Console.WriteLine("Prepare item {0}, thread {1}", n, Thread.CurrentThread.ManagedThreadId);
            //            return n;
            //            });

            //foreach(int i in query)
            //    Console.WriteLine("Got item {0}", i);
            #endregion

            #region Fully-buffered
            // Позволяет выполнить запрос полностью до предоставления результатов вне зависимости от числа элементов.
            // Обращение к первому элементу инициирует параллельную обработку всех элементов

            //var numbers = ParallelEnumerable.Range(1, 10);
            //    var query = numbers.WithMergeOptions(ParallelMergeOptions.FullyBuffered)
            //                        .Select((n) =>
            //                            {
            //                                Thread.Sleep(500);
            //                                Console.WriteLine("Prepare item {0}, thread {1}", n, Thread.CurrentThread.ManagedThreadId);
            //                                return n;
            //                            });

            //foreach(int i in query)
            //    Console.WriteLine("Got item {0}", i);

            #endregion

            #region NotBuffered

            //var numbers = ParallelEnumerable.Range(1, 10);

            //var query = numbers.WithMergeOptions(ParallelMergeOptions.NotBuffered)
            //        .Select((n) =>
            //        {
            //            Thread.Sleep(500);
            //            Console.WriteLine("Prepare item {0}, thread {1}", n, Thread.CurrentThread.ManagedThreadId);
            //            return n;
            //        });

            //foreach(int i in query)
            //    Console.WriteLine("Got item {0}", i);

            #endregion

        //    Console.ReadLine();
        //}
        #endregion

        #region Порядок элементов
        static void Main(string[] args)
        {
            #region ------
            var q = "abcdefgh".AsParallel().Select(c=>Char.ToUpper(c)).AsOrdered().ToArray();

            foreach (var param in q)
            {
                Console.WriteLine("item {0}", param);
            }
            #endregion

            Console.ReadLine();
        }
        #endregion

    }
}
