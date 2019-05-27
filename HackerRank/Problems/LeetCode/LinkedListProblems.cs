using HackerRank.Problems.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class LinkedListProblems : _ProblemBase
    {
        public override void MainRun()
        {
            ListNode root = new ListNode(1);
            root.next = new ListNode(2);
            root.next.next = new ListNode(3);
            root.next.next.next = new ListNode(4);
            root.next.next.next.next = new ListNode(5);

            RemoveNthFromEnd(root, 1);
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null) return null;

            int nodesCount = 1;
            var temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
                nodesCount++;
            }

            if (n > nodesCount) return head;

            int removalNodeIndex = nodesCount - n + 1;

            int i = 1;
            temp = head;

            if (removalNodeIndex == 1)
            {
                return temp.next;
            }

            ListNode prevNode = null;
            ListNode nextMode = null;
            while (removalNodeIndex > i)
            {
                prevNode = temp;
                temp = temp.next;
                nextMode = temp.next;
                i++;
            }

            prevNode.next = nextMode;
            return head;
        }
    }
}
