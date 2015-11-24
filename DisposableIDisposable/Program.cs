using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DisposableIDisposable
{
    /// <summary>
    /// При вызове интерфейсного
    ///  метода объекта вызывается реализация, связанная с типом самого объекта.
    /// </summary>
    public static class Program
    {
        public static void Main()
        {
            #region New interface example
            //Base b = new Base();
            //b.Dispose();
            //((IDisposable)b).Dispose();

            //Derived d = new Derived();
            //d.Dispose();
            //((IDisposable)d).Dispose();

            //b = new Derived();
            //b.Dispose();
            //((IDisposable)b).Dispose();
            #endregion

            //SimpleType st = new SimpleType();
            //st.Dispose();
            //((IDisposable)st).Dispose();

            SimpleDaughter sd = new SimpleDaughter();
             sd.Start();
            ((IDisposable)(sd)).Dispose();
            Console.ReadLine();
        }
    }

    #region New interface example
    // Этот класс является производным от Object и реализует IDisposable
    internal class Base : IDisposable
    {
        // Этот метод неявно запечатан и его нельзя переопределить
        public void Dispose()
        {
            Console.WriteLine("Base's Dispose");
        }
    }

    // Этот класс наследует от Base и повторно реализует IDisposable
    internal class Derived : Base, IDisposable
    {
        // Этот метод не может переопределить Dispose из Base.
        // Ключевое слово 'new' указывает на то, что этот метод
        // повторно реализует метод Dispose интерфейса IDisposable
        new public void Dispose()
        {
            Console.WriteLine("Derived's Dispose");
            // ПРИМЕЧАНИЕ: следующая строка кода показывает,
            // как вызвать реализацию базового класса (если нужно)
            // base.Dispose();
        }
    }
    #endregion

    internal  class SimpleType : IDisposable
    {    public void Dispose() { Console.WriteLine("public Dispose"); }
        // No virtual!
        void  IDisposable.Dispose() { Console.WriteLine("IDisposable Dispose"); }
    }

    internal sealed class SimpleDaughter : SimpleType
    {
        public void Start()
        {
            Dispose();
            //base.Dispose();;
        }


    }

}
