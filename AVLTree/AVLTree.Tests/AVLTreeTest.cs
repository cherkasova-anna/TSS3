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
    }
}