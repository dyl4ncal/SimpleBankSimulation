using System;
using System.Windows;
using Microsoft.Win32;
using CPSC300A2.Simulation_Code;

namespace CPSC300A2
{
    /* This software is a simple event-driven bank simulation.
     * It was written for UNBC CPSC300 "Software Engineering"
     * on November 13th, 2017.
     * 
     * The purpose of this simulation is to model how customers
     * at a bank are served by a teller from a line up. The output
     * produced by the simulation shows the events that occur, along
     * with some additional information. The analysis of the simulation
     * shows the statistics of each customer and then displays the
     * calculated average time each customer spends waiting in the line
     * up for service.
     * 
     * Author: Dylan Calado
     */
    public partial class MainWindow : Window
    {
        private OpenFileDialog searchWindow = new OpenFileDialog();
        private static string fileName = "";
        private static System.IO.StreamReader file;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Opens the file search dialog box to select a data file.
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

        //Exports the output of the simulation the the users Desktop.
        private void ExportClick(object sender, RoutedEventArgs e)
        {
            InputOutput.ExportResult(outputTextBox, analysisTextBox);
            outputTextBox.AppendText(Environment.NewLine + "Output has been exported to Desktop!" + Environment.NewLine);
        }

        //Performs the simulation and displays the results on a GUI.
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

                int start_index = analysisTextBox.Text.IndexOf("Total");

                analysisTextBox.Focus();
                analysisTextBox.Select(start_index, 80);

                if (SimulationAlgorithm.GetOutputString().Equals(""))
                {
                    outputTextBox.Text = "";
                }
            }
        }

        //Returns the data file selected by the user.
        public static System.IO.StreamReader GetFile()
        {
            return file;
        }
    }
}
