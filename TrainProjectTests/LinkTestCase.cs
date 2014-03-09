using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainProject.Model;

namespace TrainProjectTests
{
    [TestClass]
    public class LinkTestCase
    {
        [TestMethod]
        public void DynamicLengthTest()
        {
            var start = new Node
            {
                Position = new PointF(0, 0)
            };

            var end = new Node
            {
                Position = new PointF(0, 100)
            };

            var link = new Link(start, end);
            
            Assert.AreEqual(100, link.Length);
        }

        [TestMethod]
        public void FixedLengthTest()
        {
            var start = new Node
            {
                Position = new PointF(0, 0)
            };

            var end = new Node
            {
                Position = new PointF(0, 100)
            };

            var link = new Link(start, end) {Length = 10};

            Assert.AreEqual(10, link.Length);
        }
    }
}
