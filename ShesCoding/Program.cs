using System;

namespace ShesCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            Node f = new Node() { Value = "f" };
            Node e = new Node() { Value = "e", Next = f };
            Node d = new Node() { Value = "d", Next = e };
            Node c = new Node() { Value = "c", Next = d };
            Node b = new Node() { Value = "b", Next = c };
            Node a = new Node() { Value = "a", Next = b };
            var head = DeleteFromLinkedList(a, a);

        }



        static Node DeleteFromLinkedList(Node target, Node head)
        {
            Node prev = new Node();
            Node current = head;
            if (head == target)
            {
                return head.Next;
            }
            while (current != null)
            {
                if (current == target)
                {
                    prev.Next = current.Next;
                    return head;
                }
                prev = current;
                current = current.Next;
            }
            return head;
        }
    }

    public class Node
    {
        public string Value { get; set; }
        public Node Next { get; set; }
    }
}
