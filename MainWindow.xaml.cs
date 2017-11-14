using System;
using System.Windows;
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
            try
            {
                file = new System.IO.StreamReader(@fileName);
            }
            catch(ArgumentException a)
            {
                fileTextBox.Text = "File Path Empty";
            }
        }

        private void ExportClick(object sender, RoutedEventArgs e)
        {
            InputOutput.ExportResult(outputTextBox);
            outputTextBox.AppendText(Environment.NewLine + "Output has been exported to Desktop!" + Environment.NewLine);
        }

        private void RunSimulationClick(object sender, RoutedEventArgs e)
        {
            outputTextBox.IsReadOnly = true;
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
                analysisTextBox.Text = InputOutput.PrintColumnNames();
                analysisTextBox.AppendText(InputOutput.CreateSummaryReport());

                if (SimulationAlgorithm.GetOutputString().Equals(""))
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
