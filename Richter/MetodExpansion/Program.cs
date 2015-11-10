using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodExpansion
{
    class Program
    {
        static void Main(string[] args)
        {

            // расширение для StringBuilder (public, static not implement, first argument is this)
            string str = "hello World for test!";
            StringBuilder sb = new StringBuilder(str);
            Int32 index = sb.IndexOf('W');
            Console.WriteLine("sb.IndexOf('W') = "+ index);

            // расширение для IEnumerable (public, static not implement, first argument is this)
            List<string> list = new List<string>() { "1", "2", "3", "4", "5" };
            list.ShowItems();

            "hello my little pony".ShowItems();

            //list.Count();
            Console.ReadLine();
        }
    }
}
