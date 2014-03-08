using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainProject.JunctionEditor;

namespace TrainProjectTests
{
    [TestClass]
    public partial class JunctionReposytoryTest
    {
        [TestMethod]
        public void AddNodeTest()
        {
            var jr = new JunctionRepository();

            var node = new Node()
            {
                Title = "Node 0",
                Type = Node.NodeType.Entrance
            };
            jr.AddNode(node);

            var nodes = jr.ListNodes();
            var storedProperly = nodes.Contains(node);

            Assert.AreEqual(true, storedProperly, "Node not stored properly in repo");
        }

        [TestMethod]
        public void AddLinkForExistNodesTest()
        {
            var jr = new JunctionRepository();

            var @from = new Node
            {
                Position = new PointF(0,0),
                Title = "Already store node"
            };

            var to = new Node
            {
                Position = new PointF(0, 100),
                Title = "Another already stored node"
            };

            jr.AddNode(@from);
            jr.AddNode(to);

            var link = new Link(@from, to);

            jr.AddLink(link);

            var nodeCount = jr.ListNodes().Count();
            
            Assert.AreEqual(2, nodeCount, "Wrong populate nodes");
            Assert.AreEqual(true, jr.ListLinks().Contains(link));
        }

        [TestMethod]
        public void AddLinkForNonExistentStartNode()
        {
            var jr = new JunctionRepository();

            var @from = new Node
            {
                Position = new PointF(1, 1),
                Title = "Not already stored start node"
            };
            
            var to = new Node
            {
                Position = new PointF(0, 0),
                Title = "Already store node"
            };
            jr.AddNode(to);

            var link = new Link(@from, to);
            jr.AddLink(link);

            Assert.AreEqual(true, jr.ListNodes().Contains(@from));
            Assert.AreEqual(true, jr.ListLinks().Contains(link));
        }

        [TestMethod]
        public void AddLinkForNonExistentEndNode()
        {
            var jr = new JunctionRepository();

            var @from = new Node
            {
                Position = new PointF(0, 0),
                Title = "Already store node"
            }; 
            jr.AddNode(@from);

            var to = new Node
            {
                Position = new PointF(2, 2),
                Title = "Not already stored end node"
            };

            var link = new Link(@from, to);

            jr.AddLink(link);

            Assert.AreEqual(true, jr.ListNodes().Contains(to));
            Assert.AreEqual(true, jr.ListLinks().Contains(link));
        }

        [TestMethod]
        public void RemoveNodeTest()
        {
            var jr = new JunctionRepository();
            var node = new Node();
            jr.AddNode(node);

            jr.RemoveNode(node);

            Assert.AreEqual(false, jr.ListNodes().Any());
        }

        [TestMethod]
        public void RemoveLinkTest()
        {
            var jr = new JunctionRepository();
            var @from = new Node
            {
                Position = new PointF(0, 0),
                Title = "Already store node"
            };
            jr.AddNode(@from);

            var to = new Node
            {
                Position = new PointF(0, 0),
                Title = "Another already store node"
            };
            jr.AddNode(to);

            var link = new Link(@from, to);
            jr.AddLink(link);
            jr.RemoveLink(jr.ListLinks().First());

            Assert.AreEqual(false, jr.ListLinks().Any(), "Link wasn't removed");
            Assert.AreEqual(true, jr.ListNodes().Count() == 2, "Something strange with nodes");
        }

        [TestMethod]
        public void DuplicateNodeAdd()
        {
            var jr = new JunctionRepository();
            var one = new Node
            {
                Position = new PointF(1, 1),
                Title = "Node",
                Type = Node.NodeType.Ppp
            };

            jr.AddNode(one);
            jr.AddNode(one);

             var two = new Node
            {
                Position = new PointF(1, 1),
                Title = "Node",
                Type = Node.NodeType.Ppp
            };

            jr.AddNode(two);

            Assert.AreEqual(1, jr.ListNodes().Count());
        }

        [TestMethod]
        public void CheckConsistenceOfAddedLink()
        {
            var jr = new JunctionRepository();

            var @from = new Node
            {
                Position = new PointF(0, 0),
                Title = "Not already stored node"
            };

            var @to = new Node
            {
                Position = new PointF(0, 100),
                Title = "Another not already stored node"
            };

            var expected = new Link()
            {
                From = @from,
                To = @to,
                Length = 100,
            };

            jr.AddLink(expected);
            var actual = jr.ListLinks().First();

            Assert.AreEqual(expected, actual);
        }
    }
}
