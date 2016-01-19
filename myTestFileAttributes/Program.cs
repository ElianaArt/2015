using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace myTestFileAttributes
{
    class Program
    {
        [Flags] // Теперь это просто комментарий
        internal enum Actions 
        {
            None = 0,
            Read = 0x0001,
            Write = 0x0002,
            ReadWrite = Actions.Read | Actions.Write,
            Delete = 0x0004,
            Query = 0x0008,
            Sync = 0x0010
        }

        static void Main(string[] args)
        {
            // Так как Query определяется как 8, 'a' получает начальное значение 8
            Actions a = (Actions)Enum.Parse(typeof(Actions), "Query", true);
            // Создаем экземпляр перечисления Actions enum со значением 28
            a = (Actions)Enum.Parse(typeof(Actions), "28", false);
            Console.WriteLine(a.ToString()); // "Delete, Query, Sync"

            ///---------------------------------------------------------------------
            //String file = Assembly.GetEntryAssembly().Location;
            //FileAttributes attributes = File.GetAttributes(file);

            //Console.WriteLine("Is {0} hidden? {1}", file, attributes.HasFlag(FileAttributes.Hidden));

            //File.SetAttributes(file, FileAttributes.ReadOnly | FileAttributes.Hidden);

            Console.ReadLine();
        }
    }
}
