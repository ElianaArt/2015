using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TNodeTreee
{
    class Program
    {
        /// <summary>
        /// Связанный список, с возможностью обращения по индексу и сортировки
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Node<Hendler> nodePro = new Node<Hendler>("apple");

            nodePro.Add(new Node<Hendler>("wind", new Hendler(" cold"), new Node<Hendler>("12fg")));
            nodePro.Add(new Node<Hendler>("snake"));
            nodePro.Add(new Node<Hendler>("griraffe"));

            nodePro.Sort();


            for (int i = 0; i < nodePro.Count; i++)
            {
                Console.WriteLine("nodePro[{0}] = {1}", i, nodePro[i].data);
            }

            nodePro[2].data = "HELLO WORLD";
            Console.WriteLine("------------------");

            for (int i = 0; i < nodePro.Count; i++)
            {
                Console.WriteLine("nodePro[{0}] = {1}", i, nodePro[i].data);
            }
            Console.ReadLine();
        }

        public class Hendler
        {
            public String data;

            public Hendler(string _data)
            {
                data = _data;
            }
        }
   
    }

   
   

    

}
