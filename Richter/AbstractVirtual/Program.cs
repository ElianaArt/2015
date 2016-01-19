using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractVirtual
{
    class Program
    {
        static void Main(string[] args)
        {
            RealTest rt = new RealTest();
            rt.ToDo();
            rt.Write();
            Console.ReadLine();
        }
    }

    public class RealTest : Test
    {
        public override void Write()
        {
            base.ToDo();
        }

        public override void ToDo()
        {
            Console.WriteLine("RealTest ToDo");
            //base.ToDo();
        }
    }

    public abstract class Test
    {
        public abstract void Write();

        public virtual void ToDo()
        {
            Console.WriteLine("Test ToDo");
        }
    }

}
