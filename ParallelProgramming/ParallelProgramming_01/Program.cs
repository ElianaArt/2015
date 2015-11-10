using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int  N = 30000;
            

            data data1 = new data(); 
            Thread th0 = new Thread(()=>
            {
                DateTime dt = DateTime.Now;
                //Console.WriteLine(dt.ToString("fff"));
                for (int i = 0; i < N; i++)
                {
                    Thread.Sleep(1);
                  //  Console.WriteLine("Thread 0");
                    data1.x++;
                }
                
                //Console.WriteLine(DateTime.Now.ToString("fff"));
                var tmp = -(Convert.ToInt32(dt.ToString("fff"))) + Convert.ToInt32(DateTime.Now.ToString("fff"));
                Console.WriteLine("Всего затрачено(рядом) {0} ms", tmp);
            });
            Thread th1 = new Thread(() =>
            {
                for (int i = 0; i < N; i++)
                {
                    Thread.Sleep(2);
                  //  Console.WriteLine("Thread 1");
                    data1.y++;
                }
            });
            th0.IsBackground = true;
            th1.IsBackground = true;
           
            th0.Start();
            th1.Start();

            //---

            dataMod data = new dataMod();
            Thread th2 = new Thread(() =>
            {
                DateTime dt = DateTime.Now;
                //Console.WriteLine(dt.ToString("fff"));
                for (int i = 0; i < N; i++)
                {
                    Thread.Sleep(1);
                    //  Console.WriteLine("Thread 0");
                    data.x++;
                }

                //Console.WriteLine(DateTime.Now.ToString("fff"));
                var tmp = -(Convert.ToInt32(dt.ToString("fff"))) + Convert.ToInt32(DateTime.Now.ToString("fff"));
                Console.WriteLine("Всего затрачено {0} ms", tmp);
            });
            Thread th3 = new Thread(() =>
            {
                for (int i = 0; i < N; i++)
                {
                    Thread.Sleep(2);
                    //  Console.WriteLine("Thread 1");
                    data.y++;
                }
            });
            th2.IsBackground = true;
            th3.IsBackground = true;

            th2.Start();
            th3.Start();

            Console.ReadLine();
        }

        [StructLayout(LayoutKind.Explicit)]
        struct dataMod

        {
            //поля в памяти расположены НЕ последовательно
            [FieldOffset(0)]
            public int x;

            [FieldOffset(64)]
            public int y;

        }

        struct data

        {
            //поля в памяти расположены последовательно
            public int x { get; set; }
            public int y { get; set; }

        }
    }
}
