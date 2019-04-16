using System;
using Emgu.CV;
using Emgu.CV.Structure;

namespace VideoAnalysis
{
    public class Node
    {
        public Image<Gray, byte> data;
        public Node next;
        public Node(Image<Gray, byte> dataValue) : this(dataValue, null)
        {

        }
        public Node(Image<Gray, byte> dataValue, Node nextNode)
        {
            data = dataValue;
            next = nextNode;
        }
    }
    
    public class NodeList
    {
        public int count;
        public Node firstNode;
        public Node lastNode;

        public NodeList()
        {
            count = 0;
            firstNode = lastNode = null;
        }

        public void PushFront(Image<Gray, byte> insertItem)
        {
            if (IsEmpty())
                firstNode = lastNode = new Node(insertItem);
            else firstNode = new Node(insertItem, firstNode);
            ++count;
        }
        
        public void Push(Image<Gray, byte> insertItem)
        {
            if (IsEmpty())
                firstNode = lastNode = new Node(insertItem);
            else lastNode = lastNode.next = new Node(insertItem);
            ++count;
        }

        public Image<Gray, byte> PopFront()
        {
            if (IsEmpty()) throw new NullReferenceException();
            Image<Gray, byte> removeItem = firstNode.data;
            if (firstNode == lastNode)
                firstNode = lastNode = null;
            else firstNode = firstNode.next;
            --count;
            return removeItem;
        }
        
        public Image<Gray, byte> Pop()
        {
            if (IsEmpty()) throw new NullReferenceException();
            Image<Gray, byte> removeItem = lastNode.data;
            if (firstNode == lastNode)
                firstNode = lastNode = null;
            else
            {
                Node current = firstNode;
                while (current.next != lastNode)
                {
                    current = current.next;
                }
                lastNode = current;
                current.next = null;
            }
            --count;
            return removeItem;
        }

        public bool IsEmpty() => firstNode == null;
    }
}
