using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatterns1;

namespace UnitTestProject.NodeTest
{
    [TestClass]
    public class OrNodeTest
    {
        private Circuit circuit;

        private InputNode high1;
        private InputNode high2;
        private InputNode low1;
        private InputNode low2;

        private OutputNode output;
        private OrNode orNode;
        [TestInitialize]
        public void TestInitialize()
        {
            circuit = new Circuit();

            high1 = new InputNode(ref circuit, 1);
            high2 = new InputNode(ref circuit, 1);

            low1 = new InputNode(ref circuit, 0);
            low2 = new InputNode(ref circuit, 0);

            output = new OutputNode(ref circuit);
            orNode = new OrNode(ref circuit);
        }

        [TestMethod]
        public void OrNode_Execute_TwoLow()
        {
            // Arrange
            low1.observers.Add(orNode);
            low2.observers.Add(orNode);

            orNode.subjects.Add(low1);
            orNode.subjects.Add(low2);

            orNode.observers.Add(output);

            output.subjects.Add(orNode);

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
        public void OrNode_Execute_OneLow()
        {
            // Arrange
            low1.observers.Add(orNode);
            high1.observers.Add(orNode);

            orNode.subjects.Add(low1);
            orNode.subjects.Add(high1);

            orNode.observers.Add(output);

            output.subjects.Add(orNode);

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
        public void OrNode_Execute_TwoHigh()
        {
            // Arrange
            high1.observers.Add(orNode);
            high2.observers.Add(orNode);

            orNode.subjects.Add(high1);
            orNode.subjects.Add(high2);

            orNode.observers.Add(output);

            output.subjects.Add(orNode);

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
