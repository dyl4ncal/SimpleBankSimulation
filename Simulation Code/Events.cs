﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPSC300A2.Simulation_Code;
using System.Windows.Controls;

namespace CPSC300A2.Simulation_Code
{
    class Events
    {
        private static int customerNum = 1;


        //This method reads a single line of the data file and creates a new Node.
        public static Node ArrivalEvent(Node n)
        {
            String info = InputOutput.ReadDataLine();
            n = new Node();

            if (info == null)
            {
                customerNum = 1;
                return n;
            }
            else
            {
                n.SetEventType("arrives");

                char[] f = { ' ', '\n', '\r' };
                string[] dataToken = info.Split(f);

                n.SetArrivalTime(Int32.Parse(dataToken[0]));

                n.SetServiceTime(Int32.Parse(dataToken[1]));

                n.SetCurrentTime(n.GetArrivalTime());

                n.SetCustomerNumber(customerNum);
                customerNum++;

                return n;
            }
        }

        public static Node DepartureEvent(Node n)
        {
            n.SetEventType("departs");
            n.SetDepartureTime(n.GetCurrentTime() + n.GetServiceTime());

            return n;
        }
        
        //*********************************************************//
        //GUI output methods.
        public static string LogArrivalNoWait(Node n)
        {
            if(n.GetCustomerNumber() == 1)
            {
                string s = "The bank opens at time 0" + Environment.NewLine + "Customer " + n.GetCustomerNumber() + " arrived at time " + n.GetArrivalTime()
                + ", and now goes to the teller " + "(waited: " + n.GetWaitTime() + ")";

                return s;
            }
            else
            {
                string s = "Customer " + n.GetCustomerNumber() + " arrived at time " + n.GetArrivalTime()
                + ", and now goes to the teller " + "(waited: " + n.GetWaitTime() + ")";

                return s;
            } 
        }

        public static string LogArrivalWithWait(Node n)
        {
            string s = "Customer " + n.GetCustomerNumber() + " arrives at time " + n.GetArrivalTime()
                + ", and waits for customer " + SimulationAlgorithm.GetCustomerAtTellerNumber();
            return s;
        }

        public static string LogCustomerFinished(Node n)
        {
            if(n.GetNext() != null)
            {
                string s = "Customer " + n.GetCustomerNumber() + " finishes at time " + n.GetDepartureTime()
                + ", and customer " + (n.GetCustomerNumber() + 1) + " can see the teller";
                return s;
            }
            else
            {
                string s = "Customer " + n.GetCustomerNumber() + " finishes at time " + n.GetDepartureTime()
                + ". No more customers are at the bank.";
                return s;
            }
        }
    }
}
