using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNodeTreee
{

    public class Node<T> : INode<T>
    {
        public object data { get; set; } // String описание что там у нас
        public T Tdata { get; set; }     // Какой-нибудь класс, который мы храним в связанном списке       

        public INode<T> Next { get; set; } // Указатель на следующий элемент


        #region Конструкторы
        public Node(object data, INode<T> Next)
        {
            this.data = data;
            this.Next = Next;

        }
        public Node(object value)
            : this(value, null)
        {

        }

        public Node(INode<T> Next) 
            : this(null, Next)
        {

        }

        public Node(object data, T _Value, INode<T> Next)
        {
            this.data = data;
            this.Next = Next;
            this.Tdata = _Value;

        }
        public Node(object value, T _Value)
            : this(value, null)
        {
            this.Tdata = _Value;
        }

        public Node(INode<T> Next, T _Value)
            : this(null, Next)
        {
            this.Tdata = _Value;
        }

        #endregion


        public int Count
        {
            get { return Next.Count() + 1; }
        }

        public override string ToString()
        {
            return data.ToString() + " " + ((Next != null) ? Next.ToString() : null);
        }


        /// <param name="index">Индекс текущего элемента</param>
        /// <returns></returns>
        public INode<T> this[int index]
        {
            get
            {
                try
                {
                    if (index == 0)
                        return this;
                    if (index < Count)
                    {
                        // Next.FindNode(index - 1) тк индекс равный нулю у нас текущее значение this 
                        var finderKeeper = Next.FindNode(index - 1);
                        if (finderKeeper != null)
                            return finderKeeper;
                    }

                    else throw new IndexOutOfRangeException();
                }
                catch (Exception e)
                {
                    throw new Exception(String.Format("Данный индекс [\"{0}\"] не найден.", index), e);
                }

                return this;
            }
            set
            {
                try
                {
                    if (index < Count)
                    {
                        var finderKeeper = Next.FindNode(index - 1);
                        if (finderKeeper != null)
                            finderKeeper.data = value;
                    }
                    else if (index == Next.Count())
                    {
                        this.data = value;
                    }
                    else throw new ArgumentException();
                }
                catch (Exception e)
                {
                    throw new Exception(String.Format("[\"{0}\"] не совпадает по типу. Ожидается Int32", value), e);
                }
            }

        }


    }

}
