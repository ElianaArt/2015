using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventSet
{

    public sealed class EventKey : Object { }

    public sealed class EventSet
    {

        private readonly Dictionary<EventKey, Delegate> m_events = new Dictionary<EventKey, Delegate>();

        public void Add(EventKey eventKey, Delegate handler)
        {
            Monitor.Enter(m_events);
            Delegate d;
            m_events.TryGetValue(eventKey, out d);
            m_events[eventKey] = Delegate.Combine(d, handler);
            Monitor.Exit(m_events);
        }


        public void Remove(EventKey eventKey, Delegate handler)
        {
            Monitor.Enter(m_events);
            Delegate d;
            if (m_events.TryGetValue(eventKey, out d))
            {
                d = Delegate.Remove(d, handler);
            }
            if (d != null) m_events[eventKey] = d;
            else m_events.Remove(eventKey);
            m_events[eventKey] = Delegate.Combine(d, handler);
            Monitor.Exit(m_events);
        }

        public void Raise(EventKey eventKey, Object sender, EventArgs e)
        {
            Monitor.Enter(m_events);
            Delegate d;
            m_events.TryGetValue(eventKey, out d);
            Monitor.Exit(m_events);
          
            if (d != null)
            {
                d.DynamicInvoke(new object[] {sender, e});
            }
        }
    }

    // Определение типа, унаследованного от EventArgs для этого события
    public class FooEventArgs : EventArgs { }

    public class TypeWithLotsOfEvents
    {
        // Определение закрытого экземплярного поля, ссылающегося на коллекцию.
        // Коллекция управляет множеством пар "Event/Delegate"
        // Примечание: Тип EventSet не входит в FCL,
        // это мой собственный тип
        private readonly EventSet m_eventSet = new EventSet();
        // Защищенное свойство позволяет производным типам работать с коллекцией
        protected EventSet EventSet { get { return m_eventSet; } }

        #region Code to support the Foo event (repeat this pattern for additional events)
        // Определение членов, необходимых для события Foo.
        // 2a. Создайте статический, доступный только для чтения объект
        // для идентификации события.
        // Каждый объект имеет свой хеш-код для нахождения связанного списка
        // делегатов события в коллекции.
        protected static readonly EventKey s_fooEventKey = new EventKey();
        // 2b. Определение для события методов доступа для добавления
        // или удаления делегата из коллекции.
        public event EventHandler<FooEventArgs> Foo
        {
            add { m_eventSet.Add(s_fooEventKey, value); }
            remove { m_eventSet.Remove(s_fooEventKey, value); }
        }
        // 2c. Определение защищенного виртуального метода On для этого события.
        protected virtual void OnFoo(FooEventArgs e)
        {
            m_eventSet.Raise(s_fooEventKey, this, e);
        }
        // 2d. Определение метода, преобразующего входные данные этого события
        public void SimulateFoo() { OnFoo(new FooEventArgs()); }
        #endregion
    }

    public sealed class Program
    {
        public static void Main()
        {
            TypeWithLotsOfEvents twle = new TypeWithLotsOfEvents();
            // Добавление обратного вызова
            twle.Foo += HandleFooEvent;
            twle.Foo += FooEvent;
            // Проверяем работоспособность
            twle.SimulateFoo();
           
            Console.ReadLine();
        }
        private static void HandleFooEvent(object sender, FooEventArgs e)
        {
            Console.WriteLine("Handling Foo Event here...");
        }

        private static void FooEvent(object sender, FooEventArgs e)
        {
            Console.WriteLine("Foo Event here...");
        }
    }
}
