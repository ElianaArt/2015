using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNodeTreee
{
    public static class NodeEtensions
    {
        /// <summary>
        /// Сортировка
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Node">Текущий список</param>
        /// <returns>Отсортированнный по алфавиту список</returns>
        public static INode<T> Sort<T>(this INode<T> Node)
        {
            if (Node.Next != null)
            {
                if (CompareTo(Node) == 1)
                    Swap(Node);

                Node.Next.Sort();
            }
            return Node;
        }

        /// <summary>
        /// Сравнение стрковых значений списков
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="other">сравниваемый список</param>
        /// <returns></returns>
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

        /// <summary>
        /// Добавить новый элемент в список
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Node"></param>
        /// <param name="NewNode">Новый элемент</param>
        public static void Add<T>(this INode<T> Node, INode<T> NewNode)
        {
            if (Node.Next != null)
            {
                Add(Node.Next, NewNode);
            }
            else if (Node.Next == null)
            {
                Node.Next = NewNode;
            }
        }

        private static int valueToReturn;
        private static int counter;
        /// <summary>
        /// Пересчет количества элементов в списке
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Node"></param>
        /// <returns></returns>
        public static int Count<T>(this INode<T> Node)
        {
            if (Node != null)
            {
                counter++;
                if (Node.Next != null)
                {
                    Count(Node.Next);
                }


                else
                {

                    return counter;
                }
            }

            if (counter != 0)
                valueToReturn = counter;
            counter = 0;

            return valueToReturn;

        }

        public static INode<T> Swap<T>(INode<T> Node)
        {
            var temp = Node.Next.data;
            Node.Next.data = Node.data;
            Node.data = temp;
            return Node;
        }


        #region Приватный поиск для индексатора
        private static int fcounter;
        public static INode<T> FindNode<T>(this INode<T> Node, int index, int fcounter = 0)
        {
            INode<T> ResultNode = Node;

            while (fcounter < index)
            {
                ResultNode = ResultNode.Next;
                fcounter++;
            }
            return ResultNode;


        }
        #endregion

    }
}
