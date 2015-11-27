using System;
using System.Collections.Generic;
using System.Globalization;
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
            #region StringComparison, CultureInfo
            //Char[] cmass = new[] {'1', 's', '3'};
            //string s = new string(cmass);

            //String s1 = "Strasse";
            //String s2 = "Straße";
            //Boolean eq;
            //// CompareOrdinal возвращает ненулевое значение
            //eq = String.Compare(s1, s2, StringComparison.Ordinal) == 0;
            //Console.WriteLine("Ordinal comparison: '{0}' {2} '{1}'", s1, s2,
            //eq ? "==" : "!=");
            //// Сортировка строк для немецкого языка (de) в Германии (DE)
            //CultureInfo ci = new CultureInfo("de-DE");
            //// Compare возвращает нуль
            //eq = String.Compare(s1, s2, true, ci) == 0;
            //Console.WriteLine("Cultural comparison: '{0}' {2} '{1}'", s1, s2,
            //eq ? "==" : "!=");
            //
            #endregion

            #region String.Intern, ReferenceEquals
            // При первом вызове метода ReferenceEquals переменная s1 ссылается на объ-
            // ект-строку "Hello" в куче, а s2 — на другую объект-строку "Hello". Поскольку
            // ссылки разные, выводится значение False. Однако если выполнить этот код в CLR
            // версии 4.5, будет выведено значение True. Дело в том, что эта версия CLR игно-
            // рирует атрибут/флаг, созданный компилятором C#, и интернирует литеральную
            // строку "Hello" при загрузке сборки в домен приложений.

            //String s1 = "Hello";
            //String s2 = "Hello";
            //Console.WriteLine(Object.ReferenceEquals(s1, s2)); // Должно быть 'False'
            //s1 = String.Intern(s1);
            //s2 = String.Intern(s2);
            //Console.WriteLine(Object.ReferenceEquals(s1, s2)); // 'True'

            #endregion

            #region SubstringByTextElements, EnumTextElements, EnumTextElementIndexes
            // Следующая строка содержит комбинированные символы
            //String s = "a\u0304\u0308bc\u0327";
            //SubstringByTextElements(s);
            //EnumTextElements(s);
            //EnumTextElementIndexes(s);
            #endregion

            #region StringBuilder (maximum capacity = Int32)
            //StringBuilder sb = new StringBuilder();
            //sb.Append("a");
            
            //sb.Append("bcd");

            //sb.Append("e");

            //sb.Append("fg");
            #endregion

            #region String.Format

            String s = String.Format("On {0:D}, {1} is {2:F} years old.",
                            new DateTime(2012, 4, 22, 14, 35, 5), "Aidan", 9);

            Int32 x = Int32.Parse("1A", NumberStyles.HexNumber, null);
            Int32 xy = Int32.Parse(" 123", NumberStyles.AllowLeadingWhite, null);

            #endregion

            Console.WriteLine(s);
            Console.ReadLine();
        }

        #region SubstringByTextElements, EnumTextElements, EnumTextElementIndexes
        //  private static void SubstringByTextElements(String s) 
      //  {
      //      String output = String.Empty;
      //      StringInfo si = new StringInfo(s);
      //      for (Int32 element = 0; element < si.LengthInTextElements; element++) 
      //      {
      //          output += String.Format(
      //          "Text element {0} is '{1}'{2}",
      //          element, si.SubstringByTextElements(element, 1),
      //          Environment.NewLine);
      //      }

      //      Console.WriteLine(output, "Result of SubstringByTextElements");
      //  }

      //  private static void EnumTextElements(String s) 
      //  {
      //      String output = String.Empty;
      //      TextElementEnumerator charEnum = StringInfo.GetTextElementEnumerator(s);

      //      while (charEnum.MoveNext()) 
      //      {
      //          output += String.Format(
      //          "Character at index {0} is '{1}'{2}",
      //          charEnum.ElementIndex, charEnum.GetTextElement(),
      //          Environment.NewLine);
      //      }

      //      Console.WriteLine(output, "Result of GetTextElementEnumerator");
      // }

      //  private static void EnumTextElementIndexes(String s)
      //{
      //      String output = String.Empty;
      //      Int32[] textElemIndex = StringInfo.ParseCombiningCharacters(s);

      //      for (Int32 i = 0; i < textElemIndex.Length; i++) 
      //      {
      //          output += String.Format(
      //          "Character {0} starts at index {1}{2}",
      //          i, textElemIndex[i], Environment.NewLine);
      //      }

      //      Console.WriteLine(output, "Result of ParseCombiningCharacters");
        //}
        #endregion
    }
}
 