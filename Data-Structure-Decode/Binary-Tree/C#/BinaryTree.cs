using System;


namespace Tree
{
    public class BinaryTree <Tdata> where Tdata : IComparable<Tdata>
    {
        private TreeNode _root;

        public void Insert(Tdata data)
        {
            TreeNode newNode = new TreeNode(data);
            if (this._root == null)
            {
                this._root = newNode;
                return;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(this._root);

            TreeNode currentNode;
            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();
                
                if(currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(currentNode.Right);
                }
            }
        }

        public int Height()
        {
            return this._height(this._root);
        }

        public void PreOrder()
        {
            this._preOrder(this._root);
            Console.WriteLine();
        }

        public void InOrder()
        {
            this._inOrder(this._root);
            Console.WriteLine();
        }

        public void PostOrder()
        {
            this._postOrder(this._root);
            Console.WriteLine();
        }

        //public Tdata TestLastNode()
        //{
        //    return this._lastNode(this._root).Data;
        //}

        
        // Not Completed
        public void Delete(Tdata data)
        {
            TreeNode target = this._find(data);

            if (target == null) return;


            TreeNode targetParent = this._findParent(data);

            TreeNode lastNode = this._lastNode();
            TreeNode lastNodeParent = this._findParent(lastNode.Data);
            
            if (target == lastNode)
            {
                if (targetParent == null) // Target is root and only node in tree
                {
                    this._root = null;
                }
                else
                {
                    if (targetParent.Left == target) targetParent.Left = null;
                    else targetParent.Right = null;
                }
                return;
            }

            // Preserve the target's children
            TreeNode targetLeft = target.Left;
            TreeNode targetRight = target.Right;

            // Clear the last node from its previous position
            if (lastNodeParent != null)
            {
                if (lastNodeParent.Left == lastNode)
                    lastNodeParent.Left = null;
                else
                    lastNodeParent.Right = null;
            }

            // If target is the root
            if (targetParent == null)
            {
                this._root = lastNode;
            }
            else
            {
                if (targetParent.Left == target)
                    targetParent.Left = lastNode;
                else
                    targetParent.Right = lastNode;
            }

            lastNode.Left = targetLeft;
            lastNode.Right = targetRight;

            //// If the target was the root, update the root reference
            //if (target == this._root)
            //{
            //    this._root = lastNode;
            //}



            //// Move the last node to the target's position
            //if (targetParent != null)
            //{
            //    if (targetParent.Left == target)
            //        targetParent.Left = lastNode;
            //    else
            //        targetParent.Right = lastNode;
            //}
            //else
            //{
            //    // Target is root
            //    this._root = lastNode;
            //}

            //lastNode.Left = target.Left;
            //lastNode.Right = target.Right;




            //// clearing the pointer of last node parent
            //if (lastNodeParent != null)
            //{
            //    if (lastNodeParent.Left == lastNode)
            //        lastNodeParent.Left = null;
            //    else
            //        lastNodeParent.Right = null;
            //}



        }

        TreeNode _find(Tdata data)
        {
            if (this._root == null)
                return null;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(this._root);

            while (queue.Count > 0)
            {
                TreeNode currentNode = queue.Dequeue();

                if (currentNode.Data.Equals(data))
                    return currentNode;

                if (currentNode.Left != null)
                    queue.Enqueue(currentNode.Left);
                if (currentNode.Right != null)
                    queue.Enqueue(currentNode.Right);
            }

            return null;
        }

        //public Tdata FindParent(Tdata data)
        //{
        //    if (this._findParent(data) == null)
        //    {
        //        Console.WriteLine($"{data} Has No Parent");
        //        return default(Tdata);
        //    }

        //    Tdata Parent = this._findParent(data).Data;
        //    return Parent;
        //}

        // Don't use it unless the target is found;
        TreeNode _findParent(Tdata data)
        {

            if (this._root == null || this._root.Data.Equals(data))
                return null;


            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(this._root);

            while (queue.Count > 0)
            {
                TreeNode parentNode = queue.Dequeue();
                if ( parentNode.Left == null || parentNode.Right == null)
                    break;
                

                if (parentNode.Left.Data.Equals(data) || parentNode.Right.Data.Equals(data))
                    return parentNode;


                if(parentNode.Left != null)
                    queue.Enqueue(parentNode.Left);
                if (parentNode.Right != null)    
                    queue.Enqueue(parentNode.Right);

            }

            return null;
        }

        TreeNode _lastNode()
        {
            if (this._root == null)
                return null;

            TreeNode currentNode = this._root;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(this._root);

            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();

                if (currentNode.Left != null)
                    queue.Enqueue(currentNode.Left);

                if (currentNode.Right != null)
                    queue.Enqueue(currentNode.Right);
               
            }


            return currentNode;
        }

        private int _height(TreeNode node)
        {
            if (node == null)
                return 0;
            
            return ( 1 + Math.Max(_height(node.Left), _height(node.Right)) );
        }

        private void _preOrder(TreeNode node)
        {
            if (node == null) return;

            Console.Write(node.Data + " -> ");
            this._preOrder(node.Left);
            this._preOrder(node.Right);
        }

        private void _inOrder(TreeNode node)
        {
            if (node == null) return;
            
            this._inOrder(node.Left);
            Console.Write(node.Data + " -> ");
            this._inOrder(node.Right);
        }

        private void _postOrder(TreeNode node)
        {
            if (node == null) return;

            this._postOrder(node.Left);
            this._postOrder(node.Right);
            Console.Write(node.Data + " -> ");
        }

        private class TreeNode
        {
            public Tdata Data;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(Tdata data)
            {
                this.Data = data;
            }

        } // class TreeNode

        //============================ Printer
        class NodeInfo
        {
            public TreeNode Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }

        public void Print(int topMargin = 2, int LeftMargin = 2)
        {
            if (this._root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = this._root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.Data.ToString() };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + 1;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = LeftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.Left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                    }
                }
                next = next.Left ?? next.Right;
                for (; next == null; item = item.Parent)
                {
                    Print(item, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos;
                        next = item.Parent.Node.Right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos;
                        else
                            item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }
        private void Print(NodeInfo item, int top)
        {
            SwapColors();
            Print(item.Text, top, item.StartPos);
            SwapColors();
            if (item.Left != null)
                PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
            if (item.Right != null)
                PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
        }

        private void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
        }

        private void Print(string s, int top, int Left, int Right = -1)
        {
            Console.SetCursorPosition(Left, top);
            if (Right < 0) Right = Left + s.Length;
            while (Console.CursorLeft < Right) Console.Write(s);
        }

        private void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }

    } // class BinaryTree
}// namespace
