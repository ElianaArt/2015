using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Char[] cmass = new[] {'1', 's', '3'};
            string s = new string(cmass);

            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var query = from pathname in Directory.GetFiles(myDocuments)
                where pathname.ToUpper().EndsWith("PNG")
                        select new { Path = pathname, Name = pathname.Trim(myDocuments.ToCharArray()) };

            string newStr = myDocuments + @"\JPEG\";

            if (query != null && !Directory.Exists(newStr))
                Directory.CreateDirectory(myDocuments + @"\JPEG");

            foreach (var file in query)
            {
                File.Move(file.Path,newStr+file.Name);
                Console.WriteLine("LastWriteTime = {0}, Path = {1}", file , newStr);
            }

            //if (s.ToUpperInvariant().Substring(10, 21).EndsWith("EXE")) {

            //}

            Console.WriteLine(s);
            Console.ReadLine();
        }

    }
}
 