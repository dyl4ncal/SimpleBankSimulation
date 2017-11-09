using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CPSC300A2.Simulation_Code
{
    class InputOutput
    {
        private static string dataLine;

        //Method to read in one line of the data file at a time.
        public static string ReadDataLine()
        {
            if ((dataLine = MainWindow.GetFile().ReadLine()) != null)
            {
                return dataLine;
            }
            else
            {
                return null;
            }
        }

        //Method to export the simulation output to a text file.
        public static void ExportResult(TextBox t)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            filePath = filePath + "/SimulationOutput.txt";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
         
            using (FileStream fs = File.Create(filePath))
            {
                if(t.Text.Equals("Please Select a Data File to Run the Simulation With!") || t.Text.Equals(""))
                {
                    Byte[] output = new UTF8Encoding(true).GetBytes("");
                    fs.Write(output, 0, output.Length);
                }
                else
                {
                    Byte[] output = new UTF8Encoding(true).GetBytes(GetSimStartLabel() + SimulationAlgorithm.GetOutputString() + GetSimFinishedLabel());
                    fs.Write(output, 0, output.Length);
                }
            }
        }

        public static string GetSimStartLabel()
        {
            string s = "-----------------------------"
                +Environment.NewLine+"Running "
                + "Bank Simulation..."+Environment.NewLine
                +"-----------------------------" + Environment.NewLine;
            return s;
        }

        public static string GetSimFinishedLabel()
        {
            string s = "-------------------------" + Environment.NewLine
                + "Simulation Complete..." + Environment.NewLine 
                + "-------------------------";
            return s;
        }
    }
} 
 
