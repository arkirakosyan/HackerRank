using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Other
{
    public class SinglyLinkedList : _ProblemBase
    {
        public SinglyLinkedListNode head;

        public override void MainRun()
        {
            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                SinglyLinkedListNode llist_head = insertNodeAtTail(llist.head, llistItem);
                llist.head = llist_head;

            }
            int data = Convert.ToInt32(Console.ReadLine());

            int position = Convert.ToInt32(Console.ReadLine());

            SinglyLinkedListNode a = insertNodeAtPosition(llist.head, data, position);

        }

        public SinglyLinkedListNode insertNodeAtTail(SinglyLinkedListNode head, int data)
        {
            //return head;
            if (head == null) return new SinglyLinkedListNode(data);
            if (head.next == null)
            {
                head.next = new SinglyLinkedListNode(data);
                return head;
            }

            insertNodeAtTail(head.next, data);
            return head;
        }
        public SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
        {
            var temp = head;
            int currentPostion = 0;

            while (currentPostion++ < position - 1)
            {
                temp = temp.next;
            }

            var newNode = new SinglyLinkedListNode(data);
            newNode.next = temp.next;
            temp.next = newNode;
            return head;
        }

        public class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int data)
            {
                this.data = data;
            }
        }

    }
}
