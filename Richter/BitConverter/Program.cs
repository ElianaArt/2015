using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Получаем набор из 10 байт, сгенерированных случайным образом
            Byte[] bytes = new Byte[10];
            new Random().NextBytes(bytes);
            // Отображаем байты
            Console.WriteLine(System.BitConverter.ToString(bytes));
            // Декодируем байты в строку в кодировке base-64 и выводим эту строку
            String s = Convert.ToBase64String(bytes);
            Console.WriteLine(s);
            // Кодируем строку в кодировке base-64 обратно в байты и выводим их
            bytes = Convert.FromBase64String(s);
            Console.WriteLine(System.BitConverter.ToString(bytes));
            Console.ReadLine();
        }
    }
}
