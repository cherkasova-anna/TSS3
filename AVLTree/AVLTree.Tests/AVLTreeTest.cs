using NUnit.Framework;
using AVLTree;

namespace AVLTree.Tests
{
    [TestFixture]
    public class AVLTreeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(5)]
        public void TestConstructor(int data)
        {
            AVLTree t = new AVLTree(data);
            Assert.AreEqual(data, t.root.data);
        }

        [Test]
        public void TestInsert()
        {
            AVLTree t = new AVLTree(7);

            AVLTree.Node n = new AVLTree.Node(5);
            t.Insert(t.root, n);
            Assert.AreEqual(n, t.root.left);

            n = new AVLTree.Node(8);
            t.Insert(t.root, n);
            Assert.AreEqual(n, t.root.right);

            n = new AVLTree.Node(6);
            t.Insert(t.root, n);
            Assert.AreEqual(n, t.root.left.right);
        }

        [Test]
        public void TestGetHeight()
        {
            AVLTree t = new AVLTree(7);
            t.Insert(t.root, new AVLTree.Node(5));
            t.Insert(t.root, new AVLTree.Node(8));
            t.Insert(t.root, new AVLTree.Node(6));

            int h;
            h = t.GetHeight(t.root.left.left);
            Assert.AreEqual(h, -1);

            h = t.GetHeight(t.root.left.right);
            Assert.AreEqual(h, 0);

            h = t.GetHeight(t.root.left);
            Assert.AreEqual(h, 1);

            h = t.GetHeight(t.root);
            Assert.AreEqual(h, 2);

            h = t.GetHeight(t.root.right);
            Assert.AreEqual(h, 0);
        }

        [Test]
        public void TestGetBalance()
        {
            AVLTree t = new AVLTree(7);
            t.Insert(t.root, new AVLTree.Node(5));
            t.Insert(t.root, new AVLTree.Node(8));
            t.Insert(t.root, new AVLTree.Node(6));

            int b;

            b = t.GetBalance(t.root.left.right);
            Assert.AreEqual(b, 0);

            b = t.GetBalance(t.root.left);
            Assert.AreEqual(b, -1);

            b = t.GetBalance(t.root);
            Assert.AreEqual(b, 1);

            b = t.GetBalance(t.root.right);
            Assert.AreEqual(b, 0);
        }

        [Test]
        public void TestRotateR()
        {
            AVLTree t = new AVLTree(7);
            t.Insert(t.root, new AVLTree.Node(5));
            t.Insert(t.root, new AVLTree.Node(8));
            t.Insert(t.root, new AVLTree.Node(6));
            t.Insert(t.root, new AVLTree.Node(4));

            AVLTree.Node n = t.RotateR(t.root);
            Assert.AreEqual(n.data, 5);
            Assert.AreEqual(n.left.data, 4);
            Assert.AreEqual(n.right.data, 7);
            Assert.AreEqual(n.right.left.data, 6);
            Assert.AreEqual(n.right.right.data, 8);
        }

        [Test]
        public void TestRotateL()
        {
            AVLTree t = new AVLTree(5);
            t.Insert(t.root, new AVLTree.Node(4));
            t.Insert(t.root, new AVLTree.Node(7));
            t.Insert(t.root, new AVLTree.Node(6));
            t.Insert(t.root, new AVLTree.Node(8));

            AVLTree.Node n = t.RotateL(t.root);
            Assert.AreEqual(n.data, 7);
            Assert.AreEqual(n.left.data, 5);
            Assert.AreEqual(n.right.data, 8);
            Assert.AreEqual(n.left.left.data, 4);
            Assert.AreEqual(n.left.right.data, 6);
        }

        [Test]
        public void TestRotateRL()
        {
            AVLTree t = new AVLTree(1);
            t.Insert(t.root, new AVLTree.Node(3));
            t.Insert(t.root, new AVLTree.Node(2));

            AVLTree.Node n = t.RotateRL(t.root);
            Assert.AreEqual(n.data, 2);
            Assert.AreEqual(n.left.data, 1);
            Assert.AreEqual(n.right.data, 3);
        }

        [Test]
        public void TestRotateLR()
        {
            AVLTree t = new AVLTree(3);
            t.Insert(t.root, new AVLTree.Node(1));
            t.Insert(t.root, new AVLTree.Node(2));

            AVLTree.Node n = t.RotateLR(t.root);
            Assert.AreEqual(n.data, 2);
            Assert.AreEqual(n.left.data, 1);
            Assert.AreEqual(n.right.data, 3);
        }

        [Test]
        public void TestBalance()
        {
            AVLTree t = new AVLTree(1);
            t.Insert(t.root, new AVLTree.Node(3));
            t.Insert(t.root, new AVLTree.Node(2));

            AVLTree.Node n = t.Balance(t.root);
            Assert.AreEqual(n.data, 2);
            Assert.AreEqual(n.left.data, 1);
            Assert.AreEqual(n.right.data, 3);

            t = new AVLTree(3);
            t.Insert(t.root, new AVLTree.Node(1));
            t.Insert(t.root, new AVLTree.Node(2));

            n = t.Balance(t.root);
            Assert.AreEqual(n.data, 2);
            Assert.AreEqual(n.left.data, 1);
            Assert.AreEqual(n.right.data, 3);

            t = new AVLTree(3);
            t.Insert(t.root, new AVLTree.Node(2));
            t.Insert(t.root, new AVLTree.Node(1));

            n = t.Balance(t.root);
            Assert.AreEqual(n.data, 2);
            Assert.AreEqual(n.left.data, 1);
            Assert.AreEqual(n.right.data, 3);

            t = new AVLTree(1);
            t.Insert(t.root, new AVLTree.Node(2));
            t.Insert(t.root, new AVLTree.Node(3));

            n = t.Balance(t.root);
            Assert.AreEqual(n.data, 2);
            Assert.AreEqual(n.left.data, 1);
            Assert.AreEqual(n.right.data, 3);
        }

        [Test]
        public void TestAdd_InSubtree()
        {
            AVLTree t = new AVLTree(1);
            AVLTree.Node n;
            n = t.Add(t.root, new AVLTree.Node(2));
            Assert.AreEqual(1, n.data);
            n = t.Add(t.root, new AVLTree.Node(3));
            Assert.AreEqual(2, n.data);

            t.root = n;

            Assert.AreEqual(t.root.data, 2);
            Assert.AreEqual(t.root.left.data, 1);
            Assert.AreEqual(t.root.right.data, 3);
        }

        [Test]
        public void TestAdd()
        {
            AVLTree t = new AVLTree(1);
            t.Add(2);
            t.Add(3);

            Assert.AreEqual(t.root.data, 2);
            Assert.AreEqual(t.root.left.data, 1);
            Assert.AreEqual(t.root.right.data, 3);
        }

        [Test]
        public void TestFind()
        {
            AVLTree t = new AVLTree(1);
            t.Add(2);
            t.Add(3);

            AVLTree.Node n = t.Find(2, t.root);
            Assert.AreEqual(n, t.root);

            n = t.Find(4, t.root);
            Assert.AreEqual(n, null);
        }

        [Test]
        public void TestDelete_FromSubtree()
        {
            AVLTree t = new AVLTree(1);
            t.Add(2);
            t.Add(3);
            t.Add(0);

            t.root = t.Delete(t.root, 3);
            Assert.AreEqual(t.root.data, 1);
            Assert.AreEqual(t.root.left.data, 0);
            Assert.AreEqual(t.root.right.data, 2);

            t.root = t.Delete(t.root, 2);
            Assert.AreEqual(t.root.data, 1);
            Assert.AreEqual(t.root.left.data, 0);
        }

        [Test]
        public void TestDelete()
        {
            AVLTree t = new AVLTree(1);
            t.Add(2);
            t.Add(3);
            t.Add(0);

            t.Delete(3);
            Assert.AreEqual(t.root.data, 1);
            Assert.AreEqual(t.root.left.data, 0);
            Assert.AreEqual(t.root.right.data, 2);

            t.Delete(2);
            Assert.AreEqual(t.root.data, 1);
            Assert.AreEqual(t.root.left.data, 0);
        }
    }
}