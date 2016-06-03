using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatterns1;
using System.Collections.Generic;

namespace UnitTestProject.CircuitTest
{
    [TestClass]
    public class CircuitBuilderTest
    {
        CircuitBuilder circuitBuilder;
        Circuit circuit;
        [TestInitialize]
        public void TestInitialize()
        {
            circuitBuilder = new CircuitBuilder();
            circuit = new Circuit();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Er bevindt zich een circulaire verbinding binnen het circuit met een poort zijn naam: ")]
        public void CircularDependencyTest()
        {
            // Arrange
            Dictionary<string, BaseNode> dict = new Dictionary<string, BaseNode>();
            BaseNode inputNode = new InputNode(ref circuit, 1);

            BaseNode not1 = new NotNode(ref circuit);
            BaseNode not2 = new NotNode(ref circuit);
            BaseNode not3 = new NotNode(ref circuit);
            BaseNode not4 = new NotNode(ref circuit);

            BaseNode outputNode = new OutputNode(ref circuit);

            inputNode.AttachObserver(not1);
            not1.AttachSubject(inputNode);

            not1.AttachObserver(not2);
            not2.AttachSubject(not1);

            not2.AttachObserver(not3);
            not3.AttachSubject(not2);

            not2.AttachObserver(outputNode);
            outputNode.AttachSubject(not2);

            not3.AttachObserver(not4);
            not4.AttachSubject(not3);

            not4.AttachObserver(not2);
            not2.AttachSubject(not4);

            dict.Add("Cin", inputNode);
            dict.Add("Not1", not1);
            dict.Add("Not2", not2);
            dict.Add("Not3", not3);
            dict.Add("Not4", not4);
            dict.Add("Cout", outputNode);

            circuit.AddToQueue(inputNode);
            circuitBuilder.circuit = circuit;
            // Act & Assert
            circuitBuilder.CircuitErrorCheck(ref dict);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Er bevindt zich een niet verbonden poort binnen het circuit met de naam: ")]
        public void UnlinkedNodesTest()
        {
            // Arrange
            Dictionary<string, BaseNode> dict = new Dictionary<string, BaseNode>();
            BaseNode inputNode = new InputNode(ref circuit, 1);

            BaseNode not1 = new NotNode(ref circuit);
            BaseNode not2 = new NotNode(ref circuit);
            BaseNode not3 = new NotNode(ref circuit);
            BaseNode not4 = new NotNode(ref circuit);

            BaseNode outputNode = new OutputNode(ref circuit);

            inputNode.AttachObserver(not1);
            not1.AttachSubject(inputNode);

            not1.AttachObserver(not2);
            not2.AttachSubject(not1);

            not2.AttachObserver(not3);
            not3.AttachSubject(not2);

            not2.AttachObserver(outputNode);
            outputNode.AttachSubject(not2);

            dict.Add("Cin", inputNode);
            dict.Add("Not1", not1);
            dict.Add("Not2", not2);
            dict.Add("Not3", not3);
            dict.Add("Not4", not4);
            dict.Add("Cout", outputNode);

            circuit.AddToQueue(inputNode);
            circuitBuilder.circuit = circuit;
            // Act & Assert
            circuitBuilder.CircuitErrorCheck(ref dict);
        }

        [TestMethod]
        public void SuccesTest()
        {
            // Arrange
            Dictionary<string, BaseNode> dict = new Dictionary<string, BaseNode>();
            BaseNode inputNode = new InputNode(ref circuit, 1);

            BaseNode not1 = new NotNode(ref circuit);
            BaseNode not2 = new NotNode(ref circuit);
            BaseNode not3 = new NotNode(ref circuit);
            BaseNode not4 = new NotNode(ref circuit);

            BaseNode outputNode = new OutputNode(ref circuit);

            inputNode.AttachObserver(not1);
            not1.AttachSubject(inputNode);

            not1.AttachObserver(not2);
            not2.AttachSubject(not1);

            not2.AttachObserver(not3);
            not3.AttachSubject(not2);

            not3.AttachObserver(not4);
            not4.AttachSubject(not3);

            not4.AttachObserver(outputNode);
            outputNode.AttachSubject(not4);

            dict.Add("Cin", inputNode);
            dict.Add("Not1", not1);
            dict.Add("Not2", not2);
            dict.Add("Not3", not3);
            dict.Add("Not4", not4);
            dict.Add("Cout", outputNode);

            circuit.AddToQueue(inputNode);
            circuitBuilder.circuit = circuit;
            // Act & Assert
            try
            {
                circuitBuilder.CircuitErrorCheck(ref dict);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}
