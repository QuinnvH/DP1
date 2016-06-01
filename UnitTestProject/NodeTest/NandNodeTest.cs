using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatterns1;

namespace UnitTestProject.NodeTest
{
    [TestClass]
    public class NandNodeTest
    {
        private Circuit circuit;

        private InputNode high1;
        private InputNode high2;
        private InputNode low1;
        private InputNode low2;

        private OutputNode output;
        private NandNode nandNode;
        [TestInitialize]
        public void TestInitialize()
        {
            circuit = new Circuit();

            high1 = new InputNode(ref circuit, 1);
            high2 = new InputNode(ref circuit, 1);

            low1 = new InputNode(ref circuit, 0);
            low2 = new InputNode(ref circuit, 0);

            output = new OutputNode(ref circuit);
            nandNode = new NandNode(ref circuit);
        }

        [TestMethod]
        public void NandNode_Execute_TwoLow()
        {
            // Arrange
            low1.observers.Add(nandNode);
            low2.observers.Add(nandNode);

            nandNode.subjects.Add(low1);
            nandNode.subjects.Add(low2);

            nandNode.observers.Add(output);

            output.subjects.Add(nandNode);

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
        public void NandNode_Execute_OneLow()
        {
            // Arrange
            low1.observers.Add(nandNode);
            high1.observers.Add(nandNode);

            nandNode.subjects.Add(low1);
            nandNode.subjects.Add(high1);

            nandNode.observers.Add(output);

            output.subjects.Add(nandNode);

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
        public void NandNode_Execute_TwoHigh()
        {
            // Arrange
            high1.observers.Add(nandNode);
            high2.observers.Add(nandNode);

            nandNode.subjects.Add(high1);
            nandNode.subjects.Add(high2);

            nandNode.observers.Add(output);

            output.subjects.Add(nandNode);

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
