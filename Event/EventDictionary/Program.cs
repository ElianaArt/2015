using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventDictionary
{

    public class EventKey : Object {}

    public class DictionaryEventArgs : EventArgs { }

    public class EventDictionary
    {
        Dictionary<EventKey, Delegate> eventSet = new Dictionary<EventKey, Delegate>();

        public void Add(EventKey key, Delegate handler)
        {
            Monitor.Enter(eventSet);
            if (!eventSet.ContainsKey(key))
                eventSet.Add(key, handler);
            Monitor.Exit(eventSet);
        }

        public void Remove(EventKey key, Delegate handler)
        {
            Monitor.Enter(eventSet);
            eventSet.Remove(key);
            Monitor.Exit(eventSet);
        }

        public void Raise(EventKey key, Object sender, DictionaryEventArgs e)
        {
            Monitor.Enter(eventSet);
            Delegate d;
            eventSet.TryGetValue(key, out d);
            try
            {
                if(d!=null)
                    d.DynamicInvoke(new object[] {this, e});
            }
            catch (Exception ex) { }
            Monitor.Exit(eventSet);
        }
    }

    public class EventContainer
    {
        EventDictionary eventDictionaryHandler = new EventDictionary();

        protected EventDictionary EventDictionaryHandler { get { return eventDictionaryHandler; } }

        EventKey eventKey = new EventKey();

        public event EventHandler<DictionaryEventArgs> Events
        {
            add { eventDictionaryHandler.Add(eventKey, value); }
            remove { eventDictionaryHandler.Remove(eventKey, value); }
        }

        protected void OnEvent(DictionaryEventArgs e)
        {
            eventDictionaryHandler.Raise(eventKey, this, e);
        }

        public void SimulateNewEvent()
        {
            OnEvent(new DictionaryEventArgs());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EventContainer eventContainer = new EventContainer();

            eventContainer.Events += WriteHelloWorld;
            eventContainer.Events += WriteHelloWorld2;
            eventContainer.SimulateNewEvent();

            Console.ReadLine();
        }

        private static void WriteHelloWorld(object sender, DictionaryEventArgs e)
        {
            Console.WriteLine("hello, world!!!");
        }

        private static void WriteHelloWorld2(object sender, DictionaryEventArgs e)
        {
            Console.WriteLine("hello, world!!!2222");
        }

    }
}
