using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Timer t = new Timer(TimerCallBack, null, 0, 2000);

        //    Console.WriteLine("THE END.");
        //    Console.ReadLine();
        //}

        //private static void TimerCallBack(Object o)
        //{
        //    Console.WriteLine("In TimerCallback: "+ DateTime.Now);
        //    GC.Collect();
        //}
        //------------------------------------------------------------

        //class Tree
        //{
        //    public string Pol = null; //w  false - m
        //    public string Name = null;
        //    public Tree[] Next = null;
        //}
 
        //static void Search(Tree tree)
        //{
        //    if (tree.Pol.ToUpper().Trim() == "W") Console.WriteLine(tree.Name);
        //    if (tree.Next != null) foreach (var _ in tree.Next) Search(_);
        //}

        //static void Main(string[] args)
        //{
        //    //init - до 12 вершин сам будешь инициализировать
        //    Tree tree = new Tree
        //    {
        //        Pol = "W",
        //        Name = "Olga",
        //        Next = new[] {
        //            new Tree{ Pol="M", Name="Jan", Next=null},
        //            new Tree{ Pol="W",Name="Janna", Next=new[]{new Tree{ Pol="W",Name="Sandra", Next=new Tree[0]}}},
        //            new Tree{ Pol="M", Name="Arnold",Next=new[]{
        //                new Tree{ Pol="W",Name="Angela", Next=null}, 
        //                new Tree{ Pol="W", Name="Pamela",Next=new[]{new Tree{ Pol="M", Name="Jim",Next=null}}}
        //                }
        //            }     
        //        }
        //    };
        //    Search(tree);
        //    Console.ReadLine();
        //}

        //------------------------------------------------------------

        //static void Main(string[] args)
        //{
        //    A a = new A();
        //    B b = new B();

        //    A ab = new B();
        //    A ac = new C();

        //    a.Print();   // A
        //    b.Print();   // B
        //    ab.Print();  // A
        //    ac.Print();  // C

        //    Console.ReadLine();
        //}

        //public class A
        //{
        //    public virtual void Print()
        //    {
        //        Console.WriteLine("A");
        //    }
        //}

        //public class B : A
        //{
        //    new public virtual void Print()
        //    {
        //        Console.WriteLine("B");
        //    }
        //}

        //public class C : A
        //{
        //    public override void Print()
        //    {
        //        Console.WriteLine("C");
        //    }
        //}
        //------------------------------------------------------------

        // Напишите функцию, возвращающую все элементы дерева в коллекции IEnumerable<Tree> 
        //class Three
        //{
        //    public IEnumerable<Three> Children { get; }
        //}
    //    Three th = new...

       // решение

        //class Three
        //{
        //    public IEnumerable<Three> Children { get; set; }
        //}

        //static List<Three> list;
        //private static void MainExtracted()
        //{
        //    list = new List<Three>();
        //}

        //static IEnumerable<Three> SearchValues(Three three)
        //{
        //    if (three.Children != null)
        //    {
        //        foreach (var child in three.Children)
        //        {
        //            list.Add(child);
        //            SearchValues(child);
        //        }
        //    }
        //    return list;
        //}

        //static void Main(string[] args)
        //{
        //    MainExtracted();
        //    Three three = new Three() { Children = new List<Three>()};
        //    three.Children = new List<Three>() { new Three(){Children = new List<Three>()} };
        //    SearchValues(three);
        //    Console.ReadLine();
        //}
        //------------------------------------------------------------


        //static void Main(string[] args)
        //{
        //    int i = 0;
        //    var bytes = new Byte[] { 1, 2, 3 };

        //    var myBytes = bytes.Where(sel => sel > i && sel != sel / i++);
        //    i++;

        //    foreach (var a in myBytes)
        //        Console.WriteLine(a);
        //    Console.ReadLine();
        //}

    }
}
