using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatterns1;

namespace UnitTestProject.NodeTest
{
    [TestClass]
    public class AndNodeTest
    {
        private Circuit circuit;

        private InputNode high1;
        private InputNode high2;
        private InputNode low1;
        private InputNode low2;

        private OutputNode output;
        private AndNode andNode;
        [TestInitialize]
        public void TestInitialize()
        {
            circuit = new Circuit();

            high1 = new InputNode(ref circuit, 1);
            high2 = new InputNode(ref circuit, 1);

            low1 = new InputNode(ref circuit, 0);
            low2 = new InputNode(ref circuit, 0);

            output = new OutputNode(ref circuit);
            andNode = new AndNode(ref circuit);
        }

        [TestMethod]
        public void AndNode_Execute_TwoLow()
        {
            // Arrange
            low1.observers.Add(andNode);
            low2.observers.Add(andNode);

            andNode.subjects.Add(low1);
            andNode.subjects.Add(low2);

            andNode.observers.Add(output);

            output.subjects.Add(andNode);

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
        public void AndNode_Execute_OneLow()
        {
            // Arrange
            low1.observers.Add(andNode);
            high1.observers.Add(andNode);

            andNode.subjects.Add(low1);
            andNode.subjects.Add(high1);

            andNode.observers.Add(output);

            output.subjects.Add(andNode);

            circuit.AddToQueue(low1);
            circuit.AddToQueue(high1);
            // Act
            circuit.RunCircuit();

            int actual = output.output;
            int expected = 0;
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AndNode_Execute_TwoHigh()
        {
            // Arrange
            high1.observers.Add(andNode);
            high2.observers.Add(andNode);

            andNode.subjects.Add(high1);
            andNode.subjects.Add(high2);

            andNode.observers.Add(output);

            output.subjects.Add(andNode);

            circuit.AddToQueue(high1);
            circuit.AddToQueue(high2);
            // Act
            circuit.RunCircuit();

            int actual = output.output;
            int expected = 1;
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
