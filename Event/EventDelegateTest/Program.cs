using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventDelegateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MyEvent mailEvent = new MyEvent();
            
            mailEvent.myEvent += OnNewMail;
            mailEvent.OnEventCoplete("Hello, my dear Lena!");
            Console.ReadLine();
        }


        private static void OnNewMail(object sender, MyEventArgs e)
        {
            Console.WriteLine("New mail! : {0}",e.Letter);
         }

        public class MyEventArgs : EventArgs
        {
            private string _Letter;
            public string Letter
            {
                get { return _Letter; }
                set { if (!value.Equals(_Letter)) _Letter = value; }
            }
        }

        public class MyEvent
        {
            //public static MyEvent operator+ (MyEvent aa, MyEvent ss)
            //{

            //}

            public EventHandler<MyEventArgs> myEvent;

            public void OnChange(MyEventArgs e)
            {
                EventHandler<MyEventArgs> temp = Interlocked.CompareExchange(ref myEvent, null, null);
                if (temp != null)
                    temp(this, e);
            }

            public void OnEventCoplete(string letter)
            {
                OnChange(new MyEventArgs()
                {
                   Letter = letter
                });
            }

        }

    }
}
