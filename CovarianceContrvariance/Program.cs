using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covariance
{

    class Program
    {
        private static void Main(string[] args)
        {

            var strings = new MyCollection<string>();

            object obj = "Three";
            

            strings.AddItem("One");
            strings.AddItem("Two");
            strings.AddItem(obj.ToString());

            PrintCollection(strings);

            Console.ReadLine();
        }

        public static void PrintCollection(IMyEnumerator<object> collection)
        {
            for (int i = 0; i < collection.GetCount(); i++)
            {
                Console.WriteLine(collection.GetItem(i));
            }
        }
      
    }


    public interface IMyCollection<T>
    {
        void AddItem(T item);
        
        int GetCount();
    }

    // Коваринтность в том, что в методю принимающий IMyEnumerator<object> collection,
    // мы можем передать IMyEnumerator<string> collection
    interface IMyEnumerator<out T> : IMyCollection<object>
    {
        T GetItem(int index); 
    }

    public class MyCollection<T> : IMyEnumerator<T>
    {
        private List<T> collection = new List<T>(); 

        public void AddItem(object item)
        {
            var type = typeof (T);
            var data = Convert.ChangeType(item, type);
            collection.Add((T)data);
        }

        public T GetItem(int index)
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

    }

}
