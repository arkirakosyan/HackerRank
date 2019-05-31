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
            root.next = new ListNode(4);
            root.next.next = new ListNode(5);
            root.next.next.next = new ListNode(8);
            root.next.next.next.next = new ListNode(101);
            var t = SwapPairs(root);

            ListNode root1 = new ListNode(1);
            root1.next = new ListNode(2);
            root1.next.next = new ListNode(3);
            root1.next.next.next = new ListNode(4);
            root1.next.next.next.next = new ListNode(5);
            root1.next.next.next.next.next = new ListNode(6);

            // RemoveNthFromEnd(root, 1);
            // MergeTwoLists(root, root1);

            var t2 = ReverseKGroup(root1, 4);
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

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            ListNode mergeedHead = null;
            if (l1.val < l2.val)
            {
                mergeedHead = l1;
                l1 = l1.next;
            }
            else
            {
                mergeedHead = l2;
                l2 = l2.next;
            }

            ListNode mergeedCurrent = mergeedHead;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    mergeedCurrent.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    mergeedCurrent.next = l2;
                    l2 = l2.next;
                }
                mergeedCurrent = mergeedCurrent.next;
            }
            if (l1 != null) mergeedCurrent.next = l1;
            if (l2 != null) mergeedCurrent.next = l2;

            return mergeedHead;
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            return MergeKListRecursive(lists, 0, lists.Length - 1);
        }

        public ListNode MergeKListRecursive(ListNode[] lists, int start, int end)
        {
            if (start == end) return lists[start];
            if (end - start == 1) return MergeTwoLists(lists[start], lists[end]);

            int halfPoint = start + (end - start) / 2;
            return MergeTwoLists(MergeKListRecursive(lists, start, halfPoint), MergeKListRecursive(lists, halfPoint + 1, end));
        }

        public ListNode SwapPairs(ListNode head)
        {
            if (head == null) return null;

            ListNode firsNode = head;
            ListNode newHead = firsNode.next ?? firsNode;
            ListNode secondNode = null;

            while (firsNode.next != null)
            {
                ListNode tempNode = firsNode.next;
                firsNode.next = firsNode.next.next;
                tempNode.next = firsNode;
                if (secondNode != null)
                {
                    secondNode.next = tempNode;
                }
                secondNode = firsNode;

                if (firsNode.next != null)
                {
                    firsNode = firsNode.next;
                }
            }

            return newHead;
        }

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode knthNode;
            var newHead = ReverseKGroupRecursive(null, head, out knthNode, k);

            var tempHead = newHead;

            while (!(tempHead == null || knthNode.next == null))
            {
                tempHead = ReverseKGroupRecursive(knthNode, knthNode.next, out knthNode, k);
            }
            return newHead ?? head;
        }

        private ListNode ReverseKGroupRecursive(ListNode headPrevious, ListNode head, out ListNode knthNode, int k)
        {
            if (head == null || k == 1)
            {
                knthNode = head;
                return head;
            }
            if (k > 1 && head.next == null)
            {
                knthNode = head;
                return null;
            }

            var t = ReverseKGroupRecursive(head, head.next, out knthNode, k - 1);

            if (t == null)
            {
                knthNode = head;
                return null;
            }

            if (headPrevious != null)
                headPrevious.next = head.next;

            var newHead = head.next;

            var temp = knthNode.next;
            knthNode.next = head;
            head.next = temp;
            knthNode = head;

            return newHead;
        }
    }
}
