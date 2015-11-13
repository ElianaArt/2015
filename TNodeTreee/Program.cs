using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TNodeTreee
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<Program> nodePro = new Node<Program>("a", new Node<Program>("c", new Node<Program>("b", new Node<Program>("d"))));
            nodePro.Next = new Node<Program>("g", new Node<Program>("hello")); 
            Console.WriteLine("nodePro: " + nodePro);
            nodePro.Sort();
            Console.WriteLine("nodePro: " + nodePro);
            Console.ReadLine();
        }
    }

    // linked list
    public class Node<T> : INode<T>
    {
        public object data { get; set; }
        public INode<T> Next { get; set; }

        public Node(object data, Node<T> Next)
        {
            this.data = data;
            this.Next = Next;
        }
        public Node(object value) : this(value, null)
        {

        }

        public override string ToString()
        {
            return data.ToString()+" " + ((Next != null) ? Next.ToString() : null);
        }

        //public int this[int index]
        //{
        //    set
        //    {
        //        arr[index] = value;
        //    }

        //    get
        //    {
        //        return arr[index];
        //    }
        //}

    }

    public interface INode<T>
    {
        object data { get; set; }
        INode<T> Next { get; set; }
        string ToString();
    }

    public static class NodeEtensions
    {
        public static INode<T> Sort<T>(this INode<T> Node)
        {
           // Console.WriteLine("Node.Next = " + Node.Next.data);
            if (Node.Next != null)
            {
                Console.WriteLine("Node.Next = " + Node.Next.data);
                if (CompareTo(Node) == 1)
                    Swap(Node);

                Node.Next.Sort();
            }
            return Node;
        }

        
        public static int CompareTo<T>(INode<T> other)
        {
            if (other.data is String)
            {
                if (String.Compare(other.data.ToString(), other.Next.data.ToString()) == 1)
                    return 1;
                if (String.Compare(other.data.ToString(), other.Next.data.ToString()) == -1)
                    return -1;
            }
            return 0;
        }

        public static INode<T> Swap<T>(INode<T> Node)
        {
            var temp = Node.Next.data;
            Node.Next.data = Node.data;
            Node.data = temp;
            return Node;
        }
    }
}
