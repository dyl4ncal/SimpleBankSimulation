using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC300A2.Simulation_Code
{
    class Node
    {
        private int customerNumber;
        private int currentTime;
        private int serviceTime;
        private int arrivalTime;
        private int waitTime;
        private int departureTime;
        private String eventType;
        private Node next;
        private Node previous;

        public Node()
        {
            next = null;
        }

        public Node(int arrivalTime, int serviceTime)
        {
            this.arrivalTime = arrivalTime;
            this.serviceTime = serviceTime;
            this.next = null;
        }

        public Node(int arrivalTime, int currentTime, int serviceTime, int customerNumber, string eventType, int departureTime, int waitTime)
        {
            this.arrivalTime = arrivalTime;
            this.currentTime = currentTime;
            this.serviceTime = serviceTime;
            this.customerNumber = customerNumber;
            this.eventType = eventType;
            this.departureTime = departureTime;
            this.waitTime = waitTime;
            this.next = null;
        }

        //This method returns the string representation of a node for printing.
        public String PrintNode(Node n)
        {
            String s = this.GetCurrentTime() + " " + this.GetServiceTime();
            return s;
        }

        //**Setters and Getters for EventNodes**//
        public void SetNext(Node n)
        {
            this.next = n;
        }

        public void SetPrevious(Node n)
        {
            this.previous = n;
        }

        public void SetCustomerNumber(int n)
        {
            this.customerNumber = n;
        }

        public void SetCurrentTime(int n)
        {
            this.currentTime = n;
        }

        public void SetEventType(String str)
        {
            this.eventType = str;
        }

        public void SetServiceTime(int n)
        {
            this.serviceTime = n;
        }

        public void SetArrivalTime(int n)
        {
            this.arrivalTime = n;
        }

        public void SetDepartureTime(int n)
        {
            this.departureTime = n;
        }

        public void SetWaitTime(int n)
        {
            this.waitTime = n;
        }

        public Node GetNext()
        {
            return this.next;
        }

        public Node GetPrevious()
        {
            return this.previous;
        }

        public int GetCustomerNumber()
        {
            return this.customerNumber;
        }

        public int GetCurrentTime()
        {
            return this.currentTime;
        }

        public String GetEventType()
        {
            return this.eventType;
        }

        public int GetServiceTime()
        {
            return this.serviceTime;
        }

        public int GetArrivalTime()
        {
            return this.arrivalTime;
        }

        public int GetDepartureTime()
        {
            return this.departureTime;
        }

        public int GetWaitTime()
        {
            return this.waitTime;
        }
    }
}
