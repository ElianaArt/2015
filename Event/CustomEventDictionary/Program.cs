using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomEventDictionary
{

    public class CustomEventArgs : Object { }

    internal class MyFax
    {
        public MyFax(CustomEventManger cmManger)
        {
            cmManger += OnEvent;
        }

        public void OnEvent(Object sender, CustomEventArgs e)
        {
            Console.WriteLine("Hello world!!");
        }
    }
    
    internal class CustomEventManger
    {
        event EventHandler<CustomEventArgs> CustomEventArgs;

        public void OnNewEvent(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> tmp = Interlocked.CompareExchange(ref CustomEventArgs, null, null);
            if (tmp != null)
                tmp(this, e);
        }

        public void SimulateNewEvent(CustomEventArgs eventArgs)
        {
            OnNewEvent(eventArgs);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            CustomEventManger customEvent = new CustomEventManger();
            MyFax fax = new MyFax(customEvent);
            customEventSimulateNewEvent("arr");
           fax. += WriteHeloWorld;
        }


    }
}
