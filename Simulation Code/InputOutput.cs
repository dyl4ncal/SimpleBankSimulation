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
        private static int outputFileCount = 0;

        //Method to read in one line of the data file at a time.
        public static string ReadDataLine()
        {
            try
            {

                char[] f = { ' ', '\n', '\r' };
                if ((dataLine = MainWindow.GetFile().ReadLine()) != null)
                {
                    String[] textData = dataLine.Split(null);

                    if (textData.Length == 2 && textData[0].All(char.IsDigit) && textData[1].All(char.IsDigit))
                    {
                        return dataLine;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (FormatException e)
            {
                System.Windows.MessageBox.Show("Invalid data file. Simulation has been aborted.\n" +
                    "Please re-execute the program and select a valid data file.");
                return "Bad Input";
            }
        }

        //Method to export the simulation output to a text file.
        public static void ExportResult(TextBox outputText)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            filePath = filePath + "/SimOutput" + outputFileCount.ToString() + ".txt";
            outputFileCount++;

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
 
                using (FileStream fs = File.Create(filePath))
                {
                    if(outputText.Text.Equals("Please Select a Data File to Run the Simulation With!") || outputText.Text.Equals(""))
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
            catch (System.IO.IOException e)
            {
                System.Windows.MessageBox.Show("This file is being used by another process.");
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
 
