using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpeedTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int count = 10000000;

            start = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                Property1 = "i" + i;
            }
            WriteLog("Set Property1");



            var action = new Action<int>(SetProperty);
            start = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                action(i);
            }
            WriteLog("Set action");

            start = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                this.GetType().GetField("Property1").SetValue(this, "i" + i);
            }
            WriteLog("reflection");

            //var method = this.GetType().GetField("Property1").S;
            //for (int i = 0; i < count; i++)
            //{
            //    method.Invoke(this, new object[] { "i" + i });
            //}
            //WriteLog("reflection 2");
        }

        string _property1;
        public string Property1;
        //{
        //    get { return _property1; }
        //    set { _property1 = value; }
        //}

        void SetProperty(int i)
        {
            Property1 = "i" + i;
        }


        DateTime start = DateTime.Now;

        public void WriteLog(string message)
        {
            Console.WriteLine((DateTime.Now - start).TotalMilliseconds + "ms " + message);
            start = DateTime.Now;
        }
    }
}
