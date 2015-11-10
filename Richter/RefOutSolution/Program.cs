using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefOutSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            //string song = "sing a song: lalala";
            //string name = "Vitya";

            int song = 0;
            int name = 1;

            Console.WriteLine("Main: " + song.ToString() + " " + name.ToString());

            Console.WriteLine();

            SingASongMethodRef(ref song, name);
            Console.WriteLine("--SingASongMethod_Ref     " + song.ToString() + " " + name.ToString());

            Console.WriteLine();

            SingASongMethodOut(out song, name);
            Console.WriteLine("---SingASongMethod_Out     " + song.ToString() + " " + name.ToString());

            Console.WriteLine();

            SingASongMethod(song, name);
            Console.WriteLine("---SingASongMethod_!     " + song.ToString() + " " + name.ToString());

            Console.ReadLine();
        }

        #region Int
        private static void SingASongMethodRef(ref int oneParameter, object twoParameter)
        {
            oneParameter = 123;
            Console.WriteLine("Inside_SingASongMethod_Ref     " + oneParameter.ToString() + " " + twoParameter.ToString());
        }

        private static void SingASongMethodOut(out int oneParameter, object twoParameter)
        {
            oneParameter = 456;
            Console.WriteLine("Inside_SingASongMethod_Out     " + oneParameter.ToString() + " " + twoParameter.ToString());
        }

        private static void SingASongMethod(int oneParameter, object twoParameter)
        {
            oneParameter = 789;
            Console.WriteLine("Inside_SingASongMethod_!     " + oneParameter.ToString() + " " + twoParameter.ToString());
        }
        #endregion

        #region String
        private static void SingASongMethodRef(ref string oneParameter, object twoParameter)
        {
            oneParameter = "bagbagbagbag_REF";
            Console.WriteLine("Inside_SingASongMethod_Ref     " + oneParameter.ToString() +" " + twoParameter.ToString());
        }

        private static void SingASongMethodOut(out string oneParameter, object twoParameter)
        {
         oneParameter = "bagbagbagbag_OUT";
            Console.WriteLine("Inside_SingASongMethod_Out     " + oneParameter.ToString() + " " + twoParameter.ToString());
        }

        private static void SingASongMethod(string oneParameter, object twoParameter)
        {
            oneParameter = "bagbagbagbag_!";
            Console.WriteLine("Inside_SingASongMethod_!     " + oneParameter.ToString() + " " + twoParameter.ToString());
        }
        #endregion

    }
}
