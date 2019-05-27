using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.DataStructures
{
    public class SinglyLinkedList : _ProblemBase
    {
        public ListNode head;

        public override void MainRun()
        {
            ListNode llist = new ListNode();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                ListNode llist_head = insertNodeAtTail(llist.next, llistItem);
                llist.next = llist_head;

            }
            int data = Convert.ToInt32(Console.ReadLine());

            int position = Convert.ToInt32(Console.ReadLine());

            ListNode a = insertNodeAtPosition(llist.next, data, position);

        }

        public ListNode insertNodeAtTail(ListNode head, int data)
        {
            //return head;
            if (head == null) return new ListNode(data);
            if (head.next == null)
            {
                head.next = new ListNode(data);
                return head;
            }

            insertNodeAtTail(head.next, data);
            return head;
        }
        public ListNode insertNodeAtPosition(ListNode head, int data, int position)
        {
            var temp = head;
            int currentPostion = 0;

            while (currentPostion++ < position - 1)
            {
                temp = temp.next;
            }

            var newNode = new ListNode(data);
            newNode.next = temp.next;
            temp.next = newNode;
            return head;
        }
    }
}
