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
        public void NodeEqualTest()
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

        [TestMethod]
        public void NodeMoveToPositionTest()
        {
            var actual = new Node();        
            actual.MoveTo(new PointF(100,100));

            var expected = new Node
            {
                Position = new PointF(100, 100)
            };

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void NodeSelectableTest()
        {
            var node = new Node
            {
                Position = new PointF(100,100)
            };
            Assert.AreEqual(false, node.IsSelected(), "Default selected flag must be false");

            node.UpdateSelectionState(new Point(100,100));
            Assert.AreEqual(true, node.IsSelected(), "Broken selection update when must be selected");

            node.UpdateSelectionState(new Point(0,0));
            Assert.AreEqual(false, node.IsSelected(), "Broken selection update when must be unselected");
        }
    }
}
