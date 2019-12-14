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
    }
}
