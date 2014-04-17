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
        
   

        public MainWindow()
        {
            InitializeComponent();



            //createZip();
        }

        private void createZip()
        {
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
                zipDir.Text = dir2 + ".zip";
                text.Text = "The filename must end with .zip!\nAppending .zip!\nLocation: '" + dir2 + "'";

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

            string[] dirArray = new string[dirList.Items.Count];
            dirList.Items.CopyTo(dirArray, 0);

            String listResults = "";
            foreach (string dir in dirArray)
            {
                listResults = listResults + dir + "\n";
            }
            text.Text = listResults;

        //  createZip();
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            dir1 = fbd.SelectedPath;
            dirList.Items.Add(dir1);
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            dirList.Items.RemoveAt(dirList.Items.IndexOf(dirList.SelectedItem));
            
        }
    }

}
