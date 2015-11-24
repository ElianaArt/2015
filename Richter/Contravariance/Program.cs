using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contravariance
{
    class Program
    {
        private static void Main(string[] args)
        {

            var items = new MyCollection<A<object>>();


            B<object> b = new B<object>();
            A<object> a = new A<object>();

            B<object> c = new B<object>();
            A<object> d = new A<object>();

            items.AddItem(a);
            items.AddItem(b);
            items.AddItem(c);
            items.AddItem(d);

            Console.WriteLine(items);

            Console.WriteLine();

            for (int i = 0; i < items.GetCount(); i++)
            {
                var it = items.GetItem(i);
                Console.WriteLine(i+ ") "+it.GetType());
                if (it is B<object>)
                    items.RemoveItem(a);
            }
            
            Console.WriteLine(items);

            Console.ReadLine();
        }

    }

    class A<T>
    {
        public override string ToString()
        {
            return "(Object)";
        }

        public static implicit operator A<T>(T a)
        {
            return new A<T>();
        }
    }

    class B<T> : A<object>
    {
        public override string ToString()
        {
            return "(String)";
        }

        public static explicit operator B<T>(T a)
        {
            return new B<T>();
        }
    }

    public interface IMyCollection<T>
    {
        void AddItem(T item);
        int GetCount();
        T GetItem(int index);
    }

    
    interface IMyEnumerator<in T> : IMyCollection<object>
    {
        void RemoveItem(T item);
        
    }

    public class MyCollection<T> : IMyEnumerator<T>
    {
        private List<T> collection = new List<T>();

        public void AddItem(object item)
        {
            var type = typeof(T);
            collection.Add((T)item);
        }

        public object GetItem(int index)
        {
            return collection[index];
        }

        public int GetCount()
        {
            return collection.Count;
        }

        public void PrintCollection()
        {
            for (int i = 0; i < GetCount(); i++)
            {
                Console.WriteLine(GetItem(i));
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (var item in collection)
            {
                str += item.ToString();
            }
            return str;
        }


        public void RemoveItem(T item)
        {
           
            collection.Remove(item);
        }


    }

}
