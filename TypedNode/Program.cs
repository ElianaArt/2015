using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypedNode
{
    class Program
    {
        static void Main(string[] args)
        {
            DifferentDataLinkedList();
            Console.ReadLine();
        }

        private static void DifferentDataLinkedList()
        {
            Node head = new TypedNode<Char>('.');
            head = new TypedNode<DateTime>(DateTime.Now, head);
            head = new TypedNode<String>("Today is ", head);
            CW(head);
           
            
        }

        public static void CW<T>(T inparam)
        {
            Console.WriteLine(inparam.ToString());
        }

    }
}
