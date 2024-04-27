using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C6
{
    public class Q1Circle : Processor
    {
        public Q1Circle(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C6Processors.ProcessQ1Circle(inStr, Solve);
        

        public long Solve(SinglyLinkedList llist)
        {
            // checck wether the list is empty or not
            if (llist.head.next == null)
            {
                return 0;
            }
            // define two nodes
            SinglyLinkedListNode slow = llist.head;
            SinglyLinkedListNode fast = llist.head;
            // now check we have a cycle or not in a while loop
            while(true)
            {
                slow = slow.next;
                if (fast.next != null)
                {
                    fast = fast.next.next;
                }
                else
                {
                    return 0;
                }
                if (slow == null || fast == null)
                {
                    return 0;
                }
                else if (slow == fast)
                {
                    return 1;
                }
            }
        }
    }
}
