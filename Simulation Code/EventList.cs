using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC300A2.Simulation_Code
{
    class EventList
    {
        private Node head;
        private int size;

        public EventList()
        {
            head = null;
            size = 0;
        }

        //This method checks if the list is currently empty.
        public bool IsEmpty()
        {
            return head == null;
        }

        //This method inserts a node into the list in the proper position.
        public void Insert(int arrivalTime, int currentTime, int serviceTime, int customerNumber, string eventType, int departureTime, int waitTime)
        {
            Node n = new Node(arrivalTime, currentTime, serviceTime, customerNumber, eventType, departureTime, waitTime);

            if (IsEmpty())
            {
                head = n;
                n.SetNext(null);
            }
            else
            {
                Node current = head;
                Node prevNode = current;

                do
                {
                    //Insert nodes in order of time, priority, then patient number.
                    if (n.GetCurrentTime() == head.GetCurrentTime()
                        && n.GetArrivalTime() < head.GetArrivalTime())
                    {
                        break;
                    }
                    else if (n.GetCurrentTime() < head.GetCurrentTime())
                    {
                        break;
                    }
                    else if (n.GetCurrentTime() < current.GetCurrentTime())
                    {
                        break;
                    }
                    else if (n.GetCurrentTime() == current.GetCurrentTime()
                        && n.GetArrivalTime() < current.GetArrivalTime())
                    {
                        break;
                    }

                    prevNode = current;
                    current = current.GetNext();
                }
                while (current != null);

                n.SetNext(current);
                if (n.GetCurrentTime() < head.GetCurrentTime())
                {
                    head = n;
                }
                else if (n.GetCurrentTime() == head.GetCurrentTime()
                        && n.GetArrivalTime() < head.GetArrivalTime())
                {
                    head = n;
                }
                else
                {
                    prevNode.SetNext(n);
                }
            }
            size++;
        }

        //This method deletes a node from the front of the list and returns it.
        public Node Delete()
        {
            if (IsEmpty())
            {
                return null;
            }
            Node n = head;
            head = head.GetNext();
            size--;

            return n;
        }

        //This method returns the number of nodes in the list.
        public int GetSize()
        {
            return size;
        }

        //This method returns the front of the event list.
        public Node GetHead()
        {
            return head;
        }

        //This method prints the nodes in the list.
        public String PrintEventList()
        {
            StringBuilder str = new StringBuilder();
            Node n = head;
            int i = 0;
            while (i < GetSize())
            {
                str.Append(n.PrintNode(n)).Append(" , ");
                n = n.GetNext();
                i++;
            }
            return str.ToString();
        }

    }
}
