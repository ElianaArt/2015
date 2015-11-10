using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming_07
{

    #region
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

        #region .....
        static void Main(string[] args)
        {
            #region ------

            Action IsPool = () => {
                                      Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
            };
            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine("Paralle.Invoke");
            Parallel.Invoke(IsPool, IsPool, IsPool, IsPool, IsPool);
            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine("Paralle.For");
            Parallel.For(0, 5, i => IsPool());
            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine("Task");
            Task.Factory.StartNew(IsPool).Wait();
            Task.Factory.StartNew(IsPool).Wait();
            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine("Thread");
            new Thread(() => IsPool()).Start();
            #endregion

            
            Console.ReadLine();
        }
        #endregion

    }
}
