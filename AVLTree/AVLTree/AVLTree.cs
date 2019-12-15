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

        public void Add(int data)
        {
            Node n = new Node(data);
            if (root == null)
            {
                root = n;
            }
            else
            {
                root = Add(root, n);
            }
        }
        public Node Add(Node current, Node n)
        {
            if (current == null)
            {
                return current;
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
            return Balance(current);
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

        public Node RotateRL(Node parent)
        {
            parent.right = RotateR(parent.right);
            return RotateL(parent);
        }

        public Node RotateLR(Node parent)
        {
            parent.left = RotateL(parent.left);
            return RotateR(parent);
        }

        public Node Balance(Node current)
        {
            int b = GetBalance(current);
            if (b == 2)
            {
                if (GetBalance(current.left) < 0)
                {
                    current = RotateLR(current);
                }
                else
                {
                    current = RotateR(current);
                }
            }
            else if (b == -2)
            {
                if (GetBalance(current.right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateL(current);
                }
            }
            return current;
        }

        public Node Find(int data, Node current)
        {
            if (current == null)
            {
                return null;
            }
            if (data < current.data)
            {
                return Find(data, current.left);
            }
            else
            {
                if (data == current.data)
                {
                    return current;
                }
                else
                {
                    return Find(data, current.right);
                }
            }
        }

        public Node Delete(Node current, int data)
        {
            if (current == null)
            {
                return null;
            }
            if (data < current.data)
            {
                current.left = Delete(current.left, data);
                current = Balance(current);
            }
            else
            {
                if (data > current.data)
                {
                    current.right = Delete(current.right, data);
                    current = Balance(current);
                }
                else
                {
                    if (current.right == null)
                    {
                        return current.left;
                    }
                    else
                    {
                        Node parent = current.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }
                        current.data = parent.data;
                        current.right = Delete(current.right, parent.data);
                        current = Balance(current);
                    }
                }
            }
            return current;
        }

        public void Delete(int data)
        {
            root = Delete(root, data);
        }
    }
}
