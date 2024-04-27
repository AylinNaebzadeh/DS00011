class BinaryTreeTraversals
{
        public static long[] InOrder(long[][] nodes)
        {
            List<long> result = new List<long>();
            Stack<long> inOrder = new Stack<long>();
            long number_of_rows = nodes.GetLength(0);
            long cursor = 0;
            while (inOrder.Count != 0 || cursor != -1)
            {
                if (cursor >= 0 && cursor <= number_of_rows)
                {
                    inOrder.Push(cursor);
                    cursor = nodes[cursor][1];
                }
                else
                {
                    long visited = inOrder.Pop();
                    result.Add(nodes[visited][0]);
                    cursor = nodes[visited][2];
                }
            }
            return result.ToArray();
        }

        public static long[] PreOrder(long[][] nodes)
        {
            List<long> result = new List<long>();
            Stack<long> preOrder = new Stack<long>();
            long number_of_rows = nodes.GetLength(0);
            long cursor = 0;
            preOrder.Push(cursor);
            while (preOrder.Count != 0)
            {
                if (cursor >= 0 && cursor <= number_of_rows)
                {
                    result.Add(nodes[cursor][0]);
                    if (nodes[cursor][2] != -1)
                    {
                        preOrder.Push(nodes[cursor][2]);
                    }
                    cursor = nodes[cursor][1];
                }
                else
                {
                    cursor = preOrder.Pop();
                }
            }
            return result.ToArray();
        }

        public static long[] PostOrder(long[][] nodes)
        {
            Stack<long> result = new Stack<long>();
            Stack<long> postOrder = new Stack<long>();
            long cursor = 0;
            postOrder.Push(cursor);

            while (postOrder.Count != 0)
            {
                cursor = postOrder.Pop();
                result.Push(nodes[cursor][0]);

                if (nodes[cursor][1] != -1)
                {
                    postOrder.Push(nodes[cursor][1]);
                }

                if (nodes[cursor][2] != -1)
                {
                    postOrder.Push(nodes[cursor][2]);
                }
            }
            return result.ToArray();
        }
        public static long[][] Solve(long[][] nodes)
        {
            var inorder_res = InOrder(nodes);
            var preorder_res = PreOrder(nodes);
            var postorder_res = PostOrder(nodes);
            long[][] output = new long[][]
            {
                inorder_res,
                preorder_res,
                postorder_res,
            };
            return output;
        }
}