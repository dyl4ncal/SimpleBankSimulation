using System;
using System.IO;
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
using Microsoft.Win32;
using CPSC300A2.Simulation_Code;

namespace CPSC300A2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OpenFileDialog searchWindow = new OpenFileDialog();
        private static string fileName = "";
        private static System.IO.StreamReader file;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileSearchClick(object sender, RoutedEventArgs e)
        {
            searchWindow.CheckFileExists = true;
            searchWindow.CheckPathExists = true;
            searchWindow.InitialDirectory = @"C:\";
            searchWindow.Title = "Select Bank Data File";
            searchWindow.DefaultExt = "txt";
            searchWindow.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            searchWindow.ShowDialog();

            fileName = searchWindow.FileName;

            fileTextBox.IsReadOnly = true;
            fileTextBox.Text = fileName;
            file = new System.IO.StreamReader(@fileName);
        }

        private void ExportClick(object sender, RoutedEventArgs e)
        {
            InputOutput.ExportResult(outputTextBox);
        }

        private void RunSimulationClick(object sender, RoutedEventArgs e)
        {
            outputTextBox.IsReadOnly = true;
            //outputTextBox.Text = "";
            if (GetFile() == null)
            {
                outputTextBox.Text = "Please Select a Data File to Run the Simulation With!";
            }
            else
            {
                SimulationAlgorithm.PerformSimulation();
                outputTextBox.Text = InputOutput.GetSimStartLabel();
                outputTextBox.AppendText(SimulationAlgorithm.GetOutputString());
                outputTextBox.AppendText(InputOutput.GetSimFinishedLabel());

                if(SimulationAlgorithm.GetOutputString().Equals(""))
                {
                    outputTextBox.Text = "";
                }
            }
        }

        public static System.IO.StreamReader GetFile()
        {
            return file;
        }
    }
}
