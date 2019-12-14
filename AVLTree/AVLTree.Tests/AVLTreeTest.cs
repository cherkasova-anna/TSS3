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

        
    }
}