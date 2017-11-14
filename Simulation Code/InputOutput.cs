using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace CPSC300A2.Simulation_Code
{
    class InputOutput
    {
        private static string dataLine;
        private static int outputFileCount = 0;
        private static Queue queue = SimulationAlgorithm.GetRecordTable();
        private static double totalWaitTime = 0;
        private static int totalCustomers = 0;

        //Method to read in one line of the data file at a time.
        //This is where the validity of the data file is also checked.
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
                        totalCustomers++;
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
        public static void ExportResult(TextBox outputText, TextBox analysis)
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
                        Byte[] output = new UTF8Encoding(true).GetBytes(GetSimStartLabel()
                            + SimulationAlgorithm.GetOutputString() + GetSimFinishedLabel() + analysis.Text);
                        fs.Write(output, 0, output.Length);
                    }
                }
            }
            catch (System.IO.IOException e)
            {
                System.Windows.MessageBox.Show("This file is being used by another process.");
            }
        }

        //Returns a string to be displayed as the start label.
        public static string GetSimStartLabel()
        {
            string s = "-----------------------------"
                +Environment.NewLine+"Running "
                + "Bank Simulation..."+Environment.NewLine
                +"-----------------------------" + Environment.NewLine;
            return s;
        }

        //Returns a string to be displayed as the finished label.
        public static string GetSimFinishedLabel()
        {
            string s = "-------------------------" + Environment.NewLine
                + "Simulation Complete..." + Environment.NewLine 
                + "-------------------------";
            return s;
        }

        //This method displays the analysis column names in the GUI.
        public static string PrintColumnNames()
        {
            string columns = Environment.NewLine + "Summary Report:" + Environment.NewLine + Environment.NewLine
            + "Customer      Arrival      Service      Departure      Waiting" + Environment.NewLine
            + "  Number         Time         Time              Time           Time" + Environment.NewLine
            + "-----------      -------      --------      ----------       --------" + Environment.NewLine;

            return columns;
        }

        //This method fills out the simulation analysis summary report with information.
        public static string CreateSummaryReport()
        {
            string results = "";
            for (int i = 0; i < totalCustomers; i++)
            {
                Node n = queue.Dequeue();

                string resultLine = String.Format("{0,0}{1,22}{2,14}{3,17}{4,21}" ,n.GetCustomerNumber()
                        , n.GetArrivalTime(), n.GetServiceTime()
                        , n.GetDepartureTime(), n.GetWaitTime() + Environment.NewLine);

                results = string.Concat(results, resultLine);

                totalWaitTime += n.GetWaitTime();  
            }
            results = string.Concat(results, Environment.NewLine + "Total customers helped: " + Events.GetTotalCustomerCount() + Environment.NewLine);
            results = string.Concat(results, "Average waiting time per customer: " + CalculateAverageWaitingTime() + Environment.NewLine + "-----");
            return results;
        }

        //This method calculates the average waiting time of all the 
        //customers who visited the bank.
        public static double CalculateAverageWaitingTime()
        {
            double averageWaitTime = (totalWaitTime / totalCustomers);

            String s = String.Format("{0:.######}", averageWaitTime);

            averageWaitTime = Convert.ToDouble(s);
            return averageWaitTime;
        }

    }
} 
 
