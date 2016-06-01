using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatterns1;

namespace UnitTestProject.NodeTest
{
    [TestClass]
    public class NorNodeTest
    {
        private Circuit circuit;

        private InputNode high1;
        private InputNode high2;
        private InputNode low1;
        private InputNode low2;

        private OutputNode output;
        private NorNode norNode;
        [TestInitialize]
        public void TestInitialize()
        {
            circuit = new Circuit();

            high1 = new InputNode(ref circuit, 1);
            high2 = new InputNode(ref circuit, 1);

            low1 = new InputNode(ref circuit, 0);
            low2 = new InputNode(ref circuit, 0);

            output = new OutputNode(ref circuit);
            norNode = new NorNode(ref circuit);
        }

        [TestMethod]
        public void NorNode_Execute_TwoLow()
        {
            // Arrange
            low1.observers.Add(norNode);
            low2.observers.Add(norNode);

            norNode.subjects.Add(low1);
            norNode.subjects.Add(low2);

            norNode.observers.Add(output);

            output.subjects.Add(norNode);

            circuit.AddToQueue(low1);
            circuit.AddToQueue(low2);
            // Act
            circuit.RunCircuit();

            int actual = output.output;
            int expected = 1;
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NorNode_Execute_OneLow()
        {
            // Arrange
            low1.observers.Add(norNode);
            high1.observers.Add(norNode);

            norNode.subjects.Add(low1);
            norNode.subjects.Add(high1);

            norNode.observers.Add(output);

            output.subjects.Add(norNode);

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
        public void NorNode_Execute_TwoHigh()
        {
            // Arrange
            high1.observers.Add(norNode);
            high2.observers.Add(norNode);

            norNode.subjects.Add(high1);
            norNode.subjects.Add(high2);

            norNode.observers.Add(output);

            output.subjects.Add(norNode);

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
