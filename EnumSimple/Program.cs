using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace EnumSimple
{
    class Program
    {
        internal enum Color : byte
        {
            White,
            Red,
            Green,
            Blue,
            Orange
        }

        static void Main(string[] args)
        {
            //Color c = Color.Green;

            //Console.WriteLine(c); // "Blue" (Общий формат)
            //Console.WriteLine(c.ToString()); // "Blue" (Общий формат)
            //Console.WriteLine(c.ToString("G")); // "Blue" (Общий формат)
            //Console.WriteLine(c.ToString("D")); // "3" (Десятичный формат)
            //Console.WriteLine(c.ToString("X")); // "03" (Шестнадцатеричный формат)

            Color[] colors = GetEnumValues<Color>();
            Console.WriteLine("Number of symbols defined: " + colors);


            Console.WriteLine("get name: " + Enum.GetName(typeof(Color), 1));

            Console.WriteLine("Value\tSymbol\n-----\t------");


            foreach (Color c in colors)
            {
                // Выводим каждый идентификатор в десятичном и общем форматах
                Console.WriteLine("{0,5:D}\t{0:G}", c);
            }

            Console.ReadLine();
        }

        public static TEnum[] GetEnumValues<TEnum>() where TEnum : struct
        {
            return (TEnum[])Enum.GetValues(typeof(TEnum));
        }

        public void SetColor(Color c)
        {
            if (!Enum.IsDefined(typeof (Color), c))
            {
                throw (new ArgumentOutOfRangeException("c", c, "Invalid Color value."));
            }
        }

    }
}
