using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    public class AVLTree
    {
        public class Node
        {
            public int data;
            public Node left = null;
            public Node right = null;
            public Node(int data)
            {
                this.data = data;
            }
        }
        public Node root;
        public AVLTree(int data)
        {
            root = new Node(data);
        }

        public void Insert(Node current, Node n)
        {
            if (current == null)
            {
                return;
            }
            if (n.data < current.data)
            {
                if (current.left == null)
                {
                    current.left = n;
                }
                else
                {
                    Insert(current.left, n);
                }
            }
            else
            {
                if (current.right == null)
                {
                    current.right = n;
                }
                else
                {
                    Insert(current.right, n);
                }
            }
        }

        public int GetHeight(Node current)
        {
            if (current == null)
            {
                return -1;
            }
            else
            {
                int lh = GetHeight(current.left);
                int rh = GetHeight(current.right);
                int height = lh > rh ? lh : rh;
                return ++height;
            }
        }

        public int GetBalance(Node current)
        {
            return (GetHeight(current.left) - GetHeight(current.right));
        }

        public Node RotateR(Node parent)
        {
            Node point = parent.left;
            parent.left = point.right;
            point.right = parent;
            return point;
        }

        public Node RotateL(Node parent)
        {
            Node point = parent.right;
            parent.right = point.left;
            point.left = parent;
            return point;
        }
    }
}
