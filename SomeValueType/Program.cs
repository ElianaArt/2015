using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertChar
{
    class Program
    {
       public static void Main() {
            Char c;
            Int32 n;
            // Преобразование "число - символ" посредством приведения типов C#
            c = (Char) 65;
            Console.WriteLine(c); // Выводится "A"
            n = (Int32) c;
            Console.WriteLine(n); // Выводится "65"
            c = unchecked((Char) (65536 + 65));
            Console.WriteLine(c); // Выводится "A"
            // Преобразование "число - символ" с помощью типа Convert

            c = Convert.ToChar(65);
            Console.WriteLine(c); // Выводится "A"
            n = Convert.ToInt32(c);
            Console.WriteLine(n); // Выводится "65"
            // Демонстрация проверки диапазона для Convert
            try
            {
                c = Convert.ToChar(70000); // Слишком много для 16 разрядов
                Console.WriteLine(c); // Этот вызов выполняться НЕ будет
            }
            catch (OverflowException)
            {
                Console.WriteLine("Can't convert 70000 to a Char.");
            }
            // Преобразование "число - символ" с помощью интерфейса IConvertible (яввная реализация интерфейса)
            c = ((IConvertible)65).ToChar(null);
            Console.WriteLine(c); // Выводится "A"
            n = ((IConvertible)c).ToInt32(null);
            Console.WriteLine(n); // Выводится "65"
           Console.ReadLine();
       }
    }

}
