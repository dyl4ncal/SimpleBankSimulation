using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC300A2.Simulation_Code
{
    class SimulationAlgorithm
    {
        private static string output;
        private static Queue customerLine;
        private static Queue recordTable = new Queue();

        public static void PerformSimulation()
        {
            customerLine = new Queue();

            EventList eventList = new EventList();
            bool qWasEmpty;
            output = "";
            int waitTracker = 0;

            Node node = new Node();
            node = Events.ArrivalEvent(node);

            eventList.Insert(node.GetArrivalTime(), node.GetCurrentTime(), node.GetServiceTime(), node.GetCustomerNumber(), node.GetEventType(), node.GetDepartureTime(), node.GetWaitTime());

            //This is the event handling algorithm.
            while (!eventList.IsEmpty())
            {
                //Remove the first event at the front of the event list.
                Node n = eventList.Delete();

                switch (n.GetEventType())
                {
                    case "arrives":
                    {
                        qWasEmpty = customerLine.IsEmpty();
                        customerLine.Enqueue(n.GetArrivalTime(), n.GetCurrentTime(), n.GetServiceTime(), n.GetCustomerNumber(), n.GetEventType(), n.GetDepartureTime(), n.GetWaitTime());

                        if (qWasEmpty)
                        {
                            output = string.Concat(output, Events.LogArrivalNoWait(n) + Environment.NewLine);
                            n = Events.DepartureEvent(n);
                            eventList.Insert(n.GetArrivalTime(), n.GetCurrentTime(), n.GetServiceTime(), n.GetCustomerNumber(), n.GetEventType(), n.GetDepartureTime(), n.GetWaitTime());
                        }

                       waitTracker = n.GetDepartureTime();

                        n = Events.ArrivalEvent(n);

                        if (n.GetCustomerNumber() != 0)
                        {
                            n.SetWaitTime(waitTracker - n.GetArrivalTime());

                            output = string.Concat(output, Events.LogArrivalWithWait(n) + Environment.NewLine);

                            eventList.Insert(n.GetArrivalTime(), n.GetCurrentTime(), n.GetServiceTime(), n.GetCustomerNumber(), n.GetEventType(), n.GetDepartureTime(), n.GetWaitTime());
                        }

                        waitTracker = 0;
                        break;
                    }

                    case "departs":
                    {
                        output = string.Concat(output, Events.LogCustomerFinished(n) + Environment.NewLine);
                       
                        customerLine.Dequeue();

                            recordTable.Enqueue(n.GetArrivalTime(), n.GetCurrentTime(), n.GetServiceTime(), n.GetCustomerNumber(), n.GetEventType(), n.GetDepartureTime(), n.GetWaitTime());

                        if(!customerLine.IsEmpty())
                        {
                            Events.DepartureEvent(n);
                            eventList.Insert(n.GetArrivalTime(), n.GetCurrentTime(), n.GetServiceTime(), n.GetCustomerNumber(), n.GetEventType(), n.GetDepartureTime(), n.GetWaitTime());
                        }
                        break;
                    }
                }
            }
        }

        public static string GetOutputString()
        {
            return output;
        }

        public static string GetCustomerAtTellerNumber()
        {
            return customerLine.GetFirst().GetCustomerNumber().ToString();
        }
    }
}
