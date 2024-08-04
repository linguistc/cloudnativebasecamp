using System;


namespace Tree
{
    public class BinaryTree <Tdata> where Tdata : IComparable<Tdata>
    {
        private TreeNode _root;

        public bool IsExist(Tdata data)
        {
            return BinarySearchFind(data) != null;
        }

        public void Balance()
        {
            List<Tdata> nodes = new List<Tdata>();

            InOrderToArray(this._root, nodes);
            this._root = RecursiveBalance(0, nodes.Count - 1, nodes);
        }

        private void InOrderToArray(TreeNode node, List<Tdata> nodes) 
        {
            if (node == null) return;

            InOrderToArray(node.Left, nodes);
            nodes.Add(node.Data);
            InOrderToArray(node.Right, nodes);
        }

        private TreeNode RecursiveBalance(int start, int end, List<Tdata> nodes)
        {
            if (start > end) return null;

            int mid = (start + end) / 2;

            TreeNode newNode = new TreeNode(nodes[mid]);

            newNode.Left = RecursiveBalance(start, mid - 1, nodes);
            newNode.Right = RecursiveBalance(mid + 1, end, nodes);

            return newNode;
        }

        NodeAndParent FindNodeAndParent(Tdata data)
        {
            TreeNode currentNode = this._root;
            TreeNode parent = null;
            NodeAndParent nodeAndParent = null;
            bool isLeft = false;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                {
                    nodeAndParent = new NodeAndParent()
                    {
                        Node = currentNode,
                        Parent = parent,
                        IsLeft = isLeft
                    };
                    break;

                }
                else if (currentNode.Data.CompareTo(data) > 0)
                {
                    parent = currentNode;
                    currentNode = currentNode.Left;
                    isLeft = true;
                }
                else
                {
                    parent = currentNode;
                    currentNode = currentNode.Right;
                    isLeft = false;
                }

            }

                return nodeAndParent;

        }

        private TreeNode BinarySearchFind(Tdata data)
        {
            TreeNode currentNode = this._root;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                    return currentNode;

                else if (currentNode.Data.CompareTo(data) > 0)
                    currentNode = currentNode.Left;

                else
                    currentNode = currentNode.Right;               
            }

            return null;
        }

        public void BinarySearchInsert(Tdata data)
        {
            TreeNode newNode = new TreeNode(data);

            if (this._root == null) 
            {
                this._root = newNode;
                return;
            }

            TreeNode currentNode = this._root;

            while (currentNode != null)
            {
                if (currentNode.Data.CompareTo(data) > 0) 
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = newNode;
                        break;
                    }
                    else
                        currentNode = currentNode.Left;
                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = newNode;
                        break;
                    }
                    else
                        currentNode = currentNode.Right;
                }
            }
        }

        public void BinarySearchDelete(Tdata data)
        {
            NodeAndParent nodeAndParentInfo = this.FindNodeAndParent(data);

            if (nodeAndParentInfo.Node == null) return;

            if (nodeAndParentInfo.Node.Left != null && nodeAndParentInfo.Node.Right != null)
            {
                this.BinarySearchDelete_HasChilds(nodeAndParentInfo.Node);
            }
            else if (nodeAndParentInfo.Node.Left != null ^ nodeAndParentInfo.Node.Right != null)
            {
                this.BinarySearchDelete_HasOneChild(nodeAndParentInfo.Node);
            }
            else
            {
                this.BinarySearchDelete_Leaf(nodeAndParentInfo);
            }

        }

        private void BinarySearchDelete_Leaf(NodeAndParent nodeAndParentInfo)
        {
            if (nodeAndParentInfo.Parent == null)
                this._root = null;
            else
            {
                if (nodeAndParentInfo.IsLeft)
                    nodeAndParentInfo.Parent.Left = null;
                
                else
                    nodeAndParentInfo.Parent.Right = null;
            }
        }

        private void BinarySearchDelete_HasOneChild(TreeNode nodeToDelete)
        {
            TreeNode nodeToReplace = null;

            if (nodeToDelete.Left != null)
                nodeToReplace = nodeToDelete.Left;
            else
                nodeToReplace = nodeToDelete.Right;

            nodeToDelete.Data = nodeToReplace.Data;
            nodeToDelete.Left = nodeToReplace.Left;
            nodeToDelete.Right = nodeToReplace.Right;
        }

        private void BinarySearchDelete_HasChilds(TreeNode nodeToDelete)
        {
            TreeNode currentNode = nodeToDelete.Right;
            TreeNode parent = null;

            // Find the leftmost node in the right subtree of nodeToDelete
            while (currentNode.Left != null)
            {
                parent = currentNode;
                currentNode = currentNode.Left;
            }

            // Re-link the parent node's left child to currentNode's right child, if applicable
            if (parent != null)
            {
                parent.Left = currentNode.Right;
            }
            else
            {
                // If the parent is null, it means nodeToDelete's right child had no left child
                nodeToDelete.Right = currentNode.Right;
            }

            nodeToDelete.Data = currentNode.Data;
        }


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

        private class NodeAndParent
        {
            public TreeNode Node;
            public TreeNode Parent;
            public bool IsLeft;
        }

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
