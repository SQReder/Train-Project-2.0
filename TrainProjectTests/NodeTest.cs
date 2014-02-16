using System;
using System.Drawing;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainProject.JunctionEditor;

namespace TrainProjectTests
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void EqualTest()
        {
            var actual = new Node
            {
                Type = Node.NodeType.Isolation,
                Position = new PointF(0, 0),
                Denominator = null,
                Title = "actual"
            };

            var expected = new Node
            {
                Type = Node.NodeType.Isolation,
                Position = new PointF(0, 0),
                Denominator = null,
                Title = "actual"
            };

            Assert.AreEqual<Node>(expected, actual);
        }
    }
}
