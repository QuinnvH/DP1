using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatterns1;

namespace UnitTestProject.NodeTest
{
    [TestClass]
    public class NotNodeTest
    {
        private Circuit circuit;

        private InputNode high1;
        private InputNode low1;

        private OutputNode output;
        private NotNode notNode;
        [TestInitialize]
        public void TestInitialize()
        {
            circuit = new Circuit();

            high1 = new InputNode(ref circuit, 1);

            low1 = new InputNode(ref circuit, 0);

            output = new OutputNode(ref circuit);
            notNode = new NotNode(ref circuit);
        }

        [TestMethod]
        public void NotNode_Execute_OneHigh()
        {
            // Arrange
            high1.observers.Add(notNode);

            notNode.subjects.Add(high1);

            notNode.observers.Add(output);

            output.subjects.Add(notNode);

            circuit.AddToQueue(high1);
            // Act
            circuit.RunCircuit();

            int actual = output.output;
            int expected = 0;
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NotNode_Execute_OneLow()
        {
            // Arrange
            low1.observers.Add(notNode);

            notNode.subjects.Add(low1);

            notNode.observers.Add(output);

            output.subjects.Add(notNode);
            
            circuit.AddToQueue(low1);
            // Act
            circuit.RunCircuit();

            int actual = output.output;
            int expected = 1;
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
