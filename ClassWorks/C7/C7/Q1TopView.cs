using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C7
{
    public class Q1TopView : Processor
    {
        public Q1TopView(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C7Processors.ProcessQ1TopView(inStr, Solve);
        
        class QueueObject
        {
            public Node node;
            public long value;
            public QueueObject(Node n, long v)
            {
                this.node = n;
                this.value = v;
            }
        }

        public string Solve(long n, BinarySearchTree tree)
        {
            Queue<QueueObject> q = new Queue<QueueObject>();
            SortedDictionary<long, Node> topViewDictionary = new SortedDictionary<long, Node>();
            if (tree.root == null)
            {
                return "";
            }
            else
            {
                q.Enqueue(new QueueObject(tree.root, 0));
            }

            while(q.Count != 0)
            {
                QueueObject tmp = q.Dequeue();

                if (!topViewDictionary.ContainsKey(tmp.value))
                {
                    topViewDictionary[tmp.value] = tmp.node;
                }

                if (tmp.node.left != null)
                {
                    q.Enqueue(new QueueObject(tmp.node.left, tmp.value - 1));
                }

                if (tmp.node.right != null)
                {
                    q.Enqueue(new QueueObject(tmp.node.right, tmp.value + 1));
                }
            }

            StringBuilder sb = new StringBuilder(topViewDictionary.Count);
            String res = sb.ToString();
            foreach (var s in topViewDictionary.Values)
            {
                res += s.info.ToString() + " ";
            }

            return res;
        }
    }
}
