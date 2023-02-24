﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Node_CreateStringNode_Success() 
        {
            Node<string> node = new("test");
            Assert.IsNotNull(node);
        }

        [TestMethod]
        public void ToString_GivenNode_ReturnValue()
        {
            Node<int> node = new(1);
            Assert.AreEqual<string>("1", node.ToString()!);
        }

        [TestMethod]
        public void Next_GivenNode_ReturnsSelf()
        {
            Node<string> node = new("test");
            Assert.AreEqual<Node<string>>(node, node.Next);
        }

        [TestMethod]
        public void Append_GivenValue_CreatesNewNode()
        {
            Node<int> node1 = new(1);
            node1.Append(2);

            Assert.AreEqual<int>(2, node1.Next.Value);
            Assert.AreNotEqual<Node<int>>(node1, node1.Next);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Append_GivenDuplicateValue_ThrowsException()
        {
            Node<int> node = new(1);
            node.Append(2);
            node.Append(1);
        }

        [TestMethod]
        public void Clear_GivenNode_Success()
        {
            Node<int> node = new(1);
            node.Append(2);
            node.Clear(node);

            Assert.AreEqual<Node<int>>(node, node.Next);
        }

        [TestMethod]
        public void Exists_GivenValue_ReturnsResult()
        {
            Node<int> node = new(1);
            node.Append(2);
            node.Append(4);
            node.Append(17);

            bool test1 = node.Exists(2);
            bool test2 = node.Exists(256);

            Assert.IsTrue(test1);
            Assert.IsFalse(test2);
        }
    }
}
