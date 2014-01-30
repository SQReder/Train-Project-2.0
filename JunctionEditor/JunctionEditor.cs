using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace TrainProject.JunctionEditor
{
    public partial class JEditor : UserControl
    {
        #region vars
        
        private List<Node> nodes = new List<Node>();
        private List<Link> links = new List<Link>(); 

        private Node tempNode_;
        private Node movingNodeRef_;
        private Link tempLink_;

        #endregion

        public JEditor()
        {
            InitializeComponent();
        }

        #region mouse events

        private Point lastMousePos;

        private enum MouseAction
        {
            None,
            PutNode,
            MoveNode,
            AddLinkFindStartNode,
            AddLinkFindEndNode,
            UpdateNodeType
        };

        private MouseAction mouseAction_ = MouseAction.None;

        private Node.NodeType? newNodeType_ = Node.NodeType.Isolation;


        private void img_MouseMove(object sender, MouseEventArgs e)
        {
            switch (mouseAction_)
            {
                case MouseAction.None:
                    break;
                case MouseAction.PutNode:
                    UpdateSelectionStates(e.Location);
                    if (tempNode_ != null)
                        tempNode_.SetPosition(e.Location);
                    break;
                case MouseAction.MoveNode:
                    if (movingNodeRef_ == null)
                        UpdateSelectionStates(e.Location);
                    else
                        movingNodeRef_.SetPosition(e.Location);
                    break;
                case MouseAction.AddLinkFindStartNode:
                    UpdateSelectionStates(e.Location);
                    break;
                case MouseAction.AddLinkFindEndNode:
                    UpdateSelectionStates(e.Location);
                    tempNode_.SetPosition(e.Location);
                    break;
                case MouseAction.UpdateNodeType:
                    UpdateSelectionStates(e.Location);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            img.Invalidate();
        }


        private void img_MouseDown(object sender, MouseEventArgs e)
        {
            Node node;
            switch (mouseAction_)
            {
                case MouseAction.None:
                    break;
                case MouseAction.PutNode:
                    if (e.Button.HasFlag(MouseButtons.Right))
                    {
                        RemoveSelectedNode();
                    }
                    else if (e.Button.HasFlag(MouseButtons.Left))
                    {
                        tempNode_ = new Node();
                        tempNode_.SetPosition(e.Location);
                    }
                    break;
                case MouseAction.MoveNode:
                    movingNodeRef_ = GetFirstSelectedNode();
                    break;
                case MouseAction.AddLinkFindStartNode:
                    var startNode = GetFirstSelectedNode();
                    if (startNode != null)
                    {
                        tempNode_ = new Node();
                        tempNode_.SetPosition(e.Location);
                        tempLink_ = new Link(startNode, tempNode_);
                        mouseAction_ = MouseAction.AddLinkFindEndNode;
                    }
                    break;
                case MouseAction.AddLinkFindEndNode:
                    UpdateSelectionStates(e.Location);
                    tempLink_.To = GetFirstSelectedNode() ?? tempNode_;
                    break;
                case MouseAction.UpdateNodeType:
                    node = GetFirstSelectedNode();
                    if (node != null && newNodeType_.HasValue)
                        node.Type = newNodeType_.Value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            img.Invalidate();
        }


        private void img_MouseUp(object sender, MouseEventArgs e)
        {
            switch (mouseAction_)
            {
                case MouseAction.None:
                    break;
                case MouseAction.PutNode:
                    if (tempNode_ != null)
                    {
                        tempNode_.SetPosition(e.Location);
                        tempNode_.Title = nodes.Count.ToString(CultureInfo.InvariantCulture);
                        nodes.Add(tempNode_);
                        tempNode_ = null;
                    }
                    break;
                case MouseAction.MoveNode:
                    movingNodeRef_ = null;
                    break;
                case MouseAction.AddLinkFindStartNode:
                    tempLink_ = null;
                    break;
                case MouseAction.AddLinkFindEndNode:
                    var node = GetFirstSelectedNode();
                    if (node != null)
                    {
                        tempLink_.To = node;
                        var sameLink =
                            links.FirstOrDefault(l => l.From == tempLink_.From && l.To == tempLink_.To);
                        var reverseLink = links.FirstOrDefault(l => l.From == tempLink_.To && l.To == tempLink_.From);
                        if (sameLink != null)
                            links.Remove(sameLink);
                        else if (reverseLink != null)
                        {
                            links.Remove(reverseLink);
                            links.Add(tempLink_);
                        }
                        else
                            links.Add(tempLink_);
                    }
                    else if (CreateNewNodeForLinks.Checked)
                    {
                        tempNode_.Title = nodes.Count.ToString(CultureInfo.InvariantCulture);
                        nodes.Add(tempNode_);
                        links.Add(tempLink_);
                    }

                    tempNode_ = null;
                    tempLink_ = null;

                    mouseAction_ = MouseAction.AddLinkFindStartNode;
                    break;
                case MouseAction.UpdateNodeType:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            img.Invalidate();
        }

        #endregion


        #region draw routines

        private void img_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawSomething(graphics, links);
            DrawSomething(graphics, nodes);
            DrawSomething(graphics, tempNode_);
            DrawSomething(graphics, tempLink_);
        }


        private void DrawSomething(Graphics g, IEnumerable<IDrawable> drawables)
        {
            foreach (var drawable in drawables)
            {
                DrawSomething(g, drawable);
            }
        }


        private void DrawSomething(Graphics g, IDrawable drawable)
        {
            if (drawable != null)
                drawable.Draw(g);
        }


        #endregion

        private void RemoveSelectedNode()
        {
            var node = GetFirstSelectedNode();
            if (node != null)
            {
                var nodeToRemove = nodes.FirstOrDefault(n => n == node);

                var linksToRemove = links.Where(l => l.From == nodeToRemove || l.To == nodeToRemove).ToList();
                foreach (var link in linksToRemove)
                    links.Remove(link);

                nodes.Remove(nodeToRemove);
            }
        }

        private void UpdateSelectionStates(Point position)
        {
            foreach (var node in nodes)
                node.UpdateSelectionState(position);
        }


        private Node GetFirstSelectedNode()
        {
            return nodes.FirstOrDefault(node => node.IsSelected());
        }


        private void img_Click(object sender, EventArgs e)
        {
            Invalidate(true);
        }


        private void ToolPutNodes_Click(object sender, EventArgs e)
        {
            ToolMoveNodes.Checked = false;
            ToolCreateLink.Checked = false;
            ToolNodeTypeDock.Checked = false;
            mouseAction_ = ToolPutNodes.Checked ? MouseAction.PutNode : MouseAction.None;            
        }


        private void ToolMoveNodes_Click(object sender, EventArgs e)
        {
            ToolPutNodes.Checked = false;
            ToolCreateLink.Checked = false;
            ToolNodeTypeDock.Checked = false;
            mouseAction_ = ToolMoveNodes.Checked ? MouseAction.MoveNode : MouseAction.None;
        }


        private void ToolCreateLink_Click(object sender, EventArgs e)
        {
            ToolPutNodes.Checked = false;
            ToolMoveNodes.Checked = false;
            ToolNodeTypeDock.Checked = false;
            mouseAction_ = ToolCreateLink.Checked ? MouseAction.AddLinkFindStartNode : MouseAction.None;
        }


        private void ToolNodeTypeDock_Click(object sender, EventArgs e)
        { SelectActiveToolTypeButton(Node.NodeType.Dock); }

        private void ToolNodeTypeIsolation_Click(object sender, EventArgs e)
        { SelectActiveToolTypeButton(Node.NodeType.Isolation); }

        private void ToolNodeTypeEntrance_Click(object sender, EventArgs e)
        { SelectActiveToolTypeButton(Node.NodeType.Entrance); }

        private void ToolNodeTypePPP_Click(object sender, EventArgs e)
        { SelectActiveToolTypeButton(Node.NodeType.Ppp); }

        private void SelectActiveToolTypeButton(Node.NodeType? nodeType)
        {
            ToolPutNodes.Checked = false;
            ToolMoveNodes.Checked = false;
            ToolCreateLink.Checked = false;

            mouseAction_ = MouseAction.UpdateNodeType;

            if (nodeType.HasValue)
            {
                ToolNodeTypeDock.Checked = Node.NodeType.Dock == nodeType.Value;
                ToolNodeTypeIsolation.Checked = Node.NodeType.Isolation == nodeType.Value;
                ToolNodeTypeEntrance.Checked = Node.NodeType.Entrance == nodeType.Value;
                ToolNodeTypePPP.Checked = Node.NodeType.Ppp == nodeType.Value;
            }

            newNodeType_ = nodeType;
        }
    }
}
