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
using CopyFunctions;
using System.IO;


namespace Copy_Directories
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // path to file you want to copy
        public string SourcePath { get; set; }

        // destination path where copied file will end up

        public string DestinationPath { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearBTNClick(object sender, RoutedEventArgs e)
        {
            // clear all boxes in program
            FileNameTB.Text = "";
            SourceTB.Text = "";
            DestinationTB.Text = "";
           

        }
        // function that handles the copy single file button on UI
        private void Destination1BTNClick(object sender, RoutedEventArgs e)
        {
            string FullPathToFile = System.IO.Path.Combine(SourceTB.Text, FileNameTB.Text);

            FileInfo fi = new FileInfo(FullPathToFile);
            
            // forces user to enter a destination to use button
            if (string.IsNullOrWhiteSpace(DestinationTB.Text))
            {
                MessageBox.Show("Please enter a destination");
            }
            else if (fi.Exists)
            {
                CopyDirectory.SingleFileCopy(FullPathToFile, DestinationTB.Text,FileNameTB.Text);
                
                MessageBox.Show($"{FileNameTB.Text} succefully copied to {DestinationTB.Text}");
            }
            else
            {
                MessageBox.Show("File copy failed, check FileName or source path");
            }
        }

        // function that handles the copy folder button on UI
        private void CopyAllBTNClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FileNameTB.Text) && DestinationTB.Text != FileNameTB.Text)
            {
                DirectoryInfo dir = new DirectoryInfo(FileNameTB.Text);


                // forces user to enter a destination to use button
                if (string.IsNullOrWhiteSpace(DestinationTB.Text))
                {
                    MessageBox.Show("Please enter a destination or source");
                }


                else if (dir.Exists)
                {
                    CopyDirectory.DirectoryCopy(FileNameTB.Text, DestinationTB.Text, true);
                    MessageBox.Show($"{FileNameTB.Text} copied to {DestinationTB.Text}");
                }



                else
                {
                    MessageBox.Show("Folder copy failed, check full folder path");
                }
            }
        }

    }
}
