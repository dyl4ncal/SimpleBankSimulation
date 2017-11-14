using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC300A2.Simulation_Code
{
    class Queue
    {
        private Node head;
        private Node tail;
        private static int size;

        public Queue()
        {
            head = null;
            tail = null;
            size = 0;
        }

        //This method inserts a node at the end of the queue.
        public void Enqueue(int arrivalTime, int currentTime, int serviceTime, int customerNumber, string eventType, int departureTime, int waitTime)
        {
            Node n = new Node(arrivalTime, currentTime, serviceTime, customerNumber, eventType, departureTime, waitTime);

            Node oldtail = tail;
            tail = n;

            tail.SetNext(null);

            if (IsEmpty())
            {
                head = tail;
            }
            else
            {
                oldtail.SetNext(tail);
            }
            size++;
        }

        //This method removes the node at the front of the queue and returns it.
        public Node Dequeue()
        {
            if (IsEmpty())
            {
                System.Windows.MessageBox.Show("You are attempting to run the simulation again.\nHowever, the data has already been consumed. You may re-execute the program.");

                Environment.Exit(1);
            }
            Node queueFront = new Node(head.GetArrivalTime(), head.GetCurrentTime(),
                head.GetServiceTime(), head.GetCustomerNumber(), head.GetEventType(), head.GetDepartureTime(), head.GetWaitTime());

            head = head.GetNext();
            size--;

            if (IsEmpty())
            {
                tail = null;
            }
            return queueFront;
        }

        //This method checks if the queue is currently empty.
        public bool IsEmpty()
        {
            return head == null;
        }

        //This method returns the first node in the queue.
        public Node GetFirst()
        {
            return head;
        }

        //This method returns the current number of nodes in the queue.
        public int GetSize()
        {
            return size;
        }

        //This method prints the nodes in the queue.
        public String PrintQueue()
        {
            StringBuilder str = new StringBuilder();
            Node n = head;
            while (n != null)
            {
                str.Append(n.PrintNode(n)).Append(" , ");
                n = n.GetNext();
            }
            return str.ToString();
        }
    }
}
