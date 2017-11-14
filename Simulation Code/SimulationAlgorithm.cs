using System;

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

            //This primes the simulation with the first arrival.
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
                    //If the event is an arrival, a future departure event is inserted into the event list.
                    //The wait time of the customer is also tracked for later analysis.
                    case "arrives":
                    {
                        qWasEmpty = customerLine.IsEmpty();
                        customerLine.Enqueue(n.GetArrivalTime(), n.GetCurrentTime(), n.GetServiceTime(), n.GetCustomerNumber(), n.GetEventType(), n.GetDepartureTime(), n.GetWaitTime());

                        if (qWasEmpty)
                        {
                            //Log the event for output.
                            output = string.Concat(output, Events.LogArrivalNoWait(n) + Environment.NewLine);
                            n = Events.DepartureEvent(n);
                            eventList.Insert(n.GetArrivalTime(), n.GetCurrentTime(), n.GetServiceTime(), n.GetCustomerNumber(), n.GetEventType(), n.GetDepartureTime(), n.GetWaitTime());
                        }

                        waitTracker = n.GetDepartureTime();

                        //Process the next arrival if there is one.
                        n = Events.ArrivalEvent(n);

                        if (n.GetCustomerNumber() != 0)
                        {
                            n.SetWaitTime(waitTracker - n.GetArrivalTime());

                            //Log the event for output.
                            output = string.Concat(output, Events.LogArrivalWithWait(n) + Environment.NewLine);

                            eventList.Insert(n.GetArrivalTime(), n.GetCurrentTime(), n.GetServiceTime(), n.GetCustomerNumber(), n.GetEventType(), n.GetDepartureTime(), n.GetWaitTime());
                        }

                        waitTracker = 0;
                        break;
                    }

                    //If the event is a departure, dequeue the customer from the front of the line
                    //and insert them into the record table for later data analysis.
                    case "departs":
                    {
                        //Log the event for output.
                        output = string.Concat(output, Events.LogCustomerFinished(n) + Environment.NewLine);
                       
                        customerLine.Dequeue();

                        recordTable.Enqueue(n.GetArrivalTime(), n.GetCurrentTime(), n.GetServiceTime(), n.GetCustomerNumber(), n.GetEventType(), n.GetDepartureTime(), n.GetWaitTime());

                        //If another customer is waiting in the line up, insert a future departure event for them.
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

        //A getter for the output of the simulation in string format.
        public static string GetOutputString()
        {
            return output;
        }

        //A getter for the data structure holding the records of customers who visted the bank.
        public static Queue GetRecordTable()
        {
            return recordTable;
        }

        //Returns the number of the customer currently seeing the teller.
        public static string GetCustomerAtTellerNumber()
        {
            return customerLine.GetFirst().GetCustomerNumber().ToString();
        }
    }
}
