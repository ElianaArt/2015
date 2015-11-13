using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mass = new[] {1, 2, 3, 4, 5, 6, 7};

           
            List<MergeSort<int>> masInt = new List<MergeSort<int>>()
            {
                new MergeSort<int>(), 
                new MergeSort<int>(),
                new MergeSort<int>(),
                new MergeSort<int>(), 
                new MergeSort<int>(), 
                new MergeSort<int>()
            };

            for (int i = 0; i < masInt.Count; i++)
            {

                Console.WriteLine(masInt[i]);
                
            }
            masInt.Sort();
            Console.WriteLine("--------------------------");

            for (int i = 0; i < masInt.Count; i++)
            {

                Console.WriteLine(masInt[i]);

            }

            Console.ReadLine();
        }
    }

    class MergeSort<T> : IComparable<MergeSort<T>>
    {
        static Random rnd = new Random();
        public int id { get; set; }
        public MergeSort()
        {
            
            id = rnd.Next(100);
        }

        public override string ToString()
        {
            return id.ToString();
        }


        public int CompareTo(MergeSort<T> other)
        {
            if (this.id > other.id)
                return 1;
            if (this.id < other.id)
                return -1;
            else
                return 0;
        }
    }
}
