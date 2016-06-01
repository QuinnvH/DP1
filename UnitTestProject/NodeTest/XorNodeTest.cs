using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatterns1;

namespace UnitTestProject.NodeTest
{
    [TestClass]
    public class XorNodeTest
    {
        private Circuit circuit;

        private InputNode high1;
        private InputNode high2;
        private InputNode low1;
        private InputNode low2;

        private OutputNode output;
        private XorNode xorNode;
        [TestInitialize]
        public void TestInitialize()
        {
            circuit = new Circuit();

            high1 = new InputNode(ref circuit, 1);
            high2 = new InputNode(ref circuit, 1);

            low1 = new InputNode(ref circuit, 0);
            low2 = new InputNode(ref circuit, 0);

            output = new OutputNode(ref circuit);
            xorNode = new XorNode(ref circuit);
        }

        [TestMethod]
        public void XorNode_Execute_TwoLow()
        {
            // Arrange
            low1.observers.Add(xorNode);
            low2.observers.Add(xorNode);

            xorNode.subjects.Add(low1);
            xorNode.subjects.Add(low2);

            xorNode.observers.Add(output);

            output.subjects.Add(xorNode);

            circuit.AddToQueue(low1);
            circuit.AddToQueue(low2);
            // Act
            circuit.RunCircuit();

            int actual = output.output;
            int expected = 0;
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void XorNode_Execute_OneLow()
        {
            // Arrange
            low1.observers.Add(xorNode);
            high1.observers.Add(xorNode);

            xorNode.subjects.Add(low1);
            xorNode.subjects.Add(high1);

            xorNode.observers.Add(output);

            output.subjects.Add(xorNode);

            circuit.AddToQueue(low1);
            circuit.AddToQueue(high1);
            // Act
            circuit.RunCircuit();

            int actual = output.output;
            int expected = 1;
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void XorNode_Execute_TwoHigh()
        {
            // Arrange
            high1.observers.Add(xorNode);
            high2.observers.Add(xorNode);

            xorNode.subjects.Add(high1);
            xorNode.subjects.Add(high2);

            xorNode.observers.Add(output);

            output.subjects.Add(xorNode);

            circuit.AddToQueue(high1);
            circuit.AddToQueue(high2);
            // Act
            circuit.RunCircuit();

            int actual = output.output;
            int expected = 0;
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
