using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace Canon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static string myDocuments;

        public MainWindow()
        {
            
            InitializeComponent();

            DataContext = this;

            myDocuments = Directory.GetCurrentDirectory();
            FolderPath = myDocuments;
        }

        public static readonly DependencyProperty PathProperty = DependencyProperty.Register(
            "FolderPath", typeof(string), typeof(MainWindow), new PropertyMetadata(default(string)));

        public string FolderPath
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }


        private void CopyAndRemove()
        {
            DO("JPEG");
            DO("CR2");
        }

        private void DO (string fileType)
        {
            var files = from pathname in Directory.GetFiles(FolderPath)
                        where pathname.ToUpper().EndsWith(fileType) || fileType.ToUpper() == "JPEG" ? pathname.ToUpper().EndsWith("JPG") : fileType.ToUpper() == "JPEG"
                        select new { Path = pathname, Name = pathname.Trim(FolderPath.ToCharArray()) };

            string newStr = FolderPath + @"\"+fileType+@"\";

            if (files.Count() != 0 && !Directory.Exists(newStr))
                Directory.CreateDirectory(FolderPath + @"\" + fileType);

            //files.First().Name.Contains("JPG") || files.First().Name.Contains("JPEG") || files.First().Name.Contains("CR2")
            if (files.Count() != 0)
            {
                foreach (var file in files)
                {
                    File.Move(file.Path, newStr + file.Name);
                    Console.WriteLine("LastWriteTime = {0}, Path = {1}", file, newStr);
                }
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
           // openFileDialog.ShowDialog();
            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    FolderPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то случилось ({0})", ex.Message);
            }
            finally
            {
                CopyAndRemove();
            }

        }
    }

 
}
