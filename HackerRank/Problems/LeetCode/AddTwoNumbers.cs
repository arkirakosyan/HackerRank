using HackerRank.Problems.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    

    public class AddTwoNumbersProblem : _ProblemBase
    {
        public override void MainRun()
        {
            ListNode node1 = new ListNode(5);
            //node1.next = new ListNode(4);
            //node1.next.next = new ListNode(3);


            ListNode node2 = new ListNode(5);
            //node2.next = new ListNode(6);
            //node2.next.next = new ListNode(4);

            ListNode t = AddTwoNumbers(node1, node2);

        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int valSum = (l1.val + l2.val);
            int val = valSum % 10;
            int carry = valSum / 10;

            ListNode sumNode = new ListNode(val);

            ListNode tempL1 = l1.next;
            ListNode tempL2 = l2.next;
            ListNode tempSumNode = sumNode;

            while (tempL1 != null || tempL2 != null)
            {
                tempSumNode.next = AddChildNodes(tempL1, tempL2, ref carry);
                if (tempL1 != null) tempL1 = tempL1.next;
                if (tempL2 != null) tempL2 = tempL1.next;

                tempL1 = tempL1 == null ? null : tempL1.next;
                tempL2 = tempL2 == null ? null : tempL2.next;
                tempSumNode = tempSumNode.next;
            }

            if (carry > 0)
            {
                tempSumNode.next = new ListNode(carry);
            }
            return sumNode;
        }

        private ListNode AddChildNodes(ListNode l1, ListNode l2, ref int carry)
        {
            int l1val = l1 == null ? 0 : l1.val;
            int l2val = l2 == null ? 0 : l2.val;

            int valSum = (l1val + l2val + carry);
            int val = valSum % 10;
            carry = valSum / 10;

            return new ListNode(val);
        }
    }
}
