using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace TrainProject.JunctionEditor
{
    public partial class JEditor : UserControl
    {
        private List<Node> nodes = new List<Node>();
        private List<Link> links = new List<Link>(); 

        private Node tempNode_;
        private Node movingNodeRef_;
        private Link tempLink_;

        public JEditor()
        {
            InitializeComponent();
        }

        #region img mouse events

        private Point lastMousePos;

        private enum MouseAction
        {
            None,
            PutNode,
            MoveNode,
            AddLinkFindStartNode,
            AddLinkFindEndNode
        };

        private MouseAction mouseAction_ = MouseAction.None;

        private void img_MouseMove(object sender, MouseEventArgs e)
        {
            switch (mouseAction_)
            {
                case MouseAction.None:
                    break;
                case MouseAction.PutNode:
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
                default:
                    throw new ArgumentOutOfRangeException();
            }
            img.Invalidate();
        }

        private void img_MouseDown(object sender, MouseEventArgs e)
        {
            switch (mouseAction_)
            {
                case MouseAction.None:
                    break;
                case MouseAction.PutNode:
                    tempNode_ = new Node();
                    tempNode_.SetPosition(e.Location);
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
                    tempNode_.SetPosition(e.Location);
                    nodes.Add(tempNode_);
                    tempNode_ = null;
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
                        links.Add(tempLink_);
                    }
                    tempNode_ = null;
                    tempLink_ = null;

                    mouseAction_ = MouseAction.AddLinkFindStartNode;
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
            DrawSomething(graphics, nodes);
            DrawSomething(graphics, links);
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
            mouseAction_ = ToolPutNodes.Checked ? MouseAction.PutNode : MouseAction.None;            
        }

        private void ToolMoveNodes_Click(object sender, EventArgs e)
        {
            ToolPutNodes.Checked = false;
            ToolCreateLink.Checked = false;
            mouseAction_ = ToolMoveNodes.Checked ? MouseAction.MoveNode : MouseAction.None;
        }

        private void ToolCreateLink_Click(object sender, EventArgs e)
        {
            ToolPutNodes.Checked = false;
            ToolMoveNodes.Checked = false;
            mouseAction_ = ToolCreateLink.Checked ? MouseAction.AddLinkFindStartNode : MouseAction.None;

        }
    }
}
