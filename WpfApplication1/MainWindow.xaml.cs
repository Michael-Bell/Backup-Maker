using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro;
using MahApps.Metro.Controls;
using Ionic.Zip;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        string dir2;
        string dir1 = "C:/Users/788732/Desktop/pics";
        List<TodoItem> items = new List<TodoItem>();
        public MainWindow()
        {
            InitializeComponent();



            lbTodoList.ItemsSource = items;

            //createZip();
        }

        private void createZip()
        {
            // dir1 = "C:/Users/788732/Desktop/pics";
            // dir2 = "C:/Users/788732/Desktop/asdf.zip";
            if (!System.IO.Directory.Exists(dir1))
            {
                text.Text = text.Text + "The directory does not exist!\n";

            }
            if (System.IO.File.Exists(dir2))
            {
                text.Text = text.Text + "That zipfile already exists!\n";

            }
            if (!dir2.EndsWith(".zip"))
            {
                text.Text = text.Text + "The filename must end with .zip!\n";

            }

            string ZipFileToCreate = dir2;
            string DirectoryToZip = dir1;
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.StatusMessageTextWriter = System.Console.Out;
                    zip.AddDirectory(DirectoryToZip); // recurses subdirectories
                    zip.Save(ZipFileToCreate);
                }
            }
            catch (System.Exception ex1)
            {
                text.Text = text.Text + "exception: " + ex1;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            dir2 = zipDir.Text;
            text.Text = dir2;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            createZip();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            System.Windows.Forms.MessageBox.Show(fbd.SelectedPath, "Message");
            items.Add(new TodoItem() { Title = fbd.SelectedPath });
            dir1 = fbd.SelectedPath;
            lbTodoList.ItemsSource = items;
        }
    }
    public class TodoItem
    {
        public string Title { get; set; }
        public int Completion { get; set; }
    }
}
