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
        
        private readonly JunctionRepository repository_ = new JunctionRepository();

        private Node tempNode_;
        private Node movingNodeRef_;
        private Link tempLink_;

        #endregion

        public JEditor()
        {
            InitializeComponent();
        }

        #region mouse events

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
            repository_.UpdateSelectionStates(e.Location);
            switch (mouseAction_)
            {
                case MouseAction.None:
                    break;
                case MouseAction.PutNode:
                    if (tempNode_ != null)
                        tempNode_.Position = e.Location;
                    break;
                case MouseAction.MoveNode:
                    if (movingNodeRef_ != null)
                        movingNodeRef_.Position = e.Location;
                    break;
                case MouseAction.AddLinkFindStartNode:
                    break;
                case MouseAction.AddLinkFindEndNode:
                    var firstSelectedNode = repository_.GetFirstSelectedNode();
                    if (firstSelectedNode == null)
                    {
                        tempNode_ = new Node {Position = e.Location};
                        tempLink_.To = tempNode_; 
                    }
                    else
                    {
                        tempNode_ = null;
                        tempLink_.To = firstSelectedNode;
                    }
                    break;
                case MouseAction.UpdateNodeType:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            img.Invalidate();
        }


        private void img_MouseDown(object sender, MouseEventArgs e)
        {
            var selectedNode = repository_.GetFirstSelectedNode();
            switch (mouseAction_)
            {
                case MouseAction.None:
                    break;
                case MouseAction.PutNode:
                    if (e.Button.HasFlag(MouseButtons.Right))
                    {
                        repository_.RemoveNode(selectedNode);
                    }
                    else if (e.Button.HasFlag(MouseButtons.Left))
                    {
                        tempNode_ = new Node {Position = e.Location};
                    }
                    break;
                case MouseAction.MoveNode:
                    movingNodeRef_ = selectedNode;
                    break;
                case MouseAction.AddLinkFindStartNode:
                    var startNode = selectedNode;
                    if (startNode != null)
                    {
                        tempNode_ = new Node {Position = e.Location};
                        tempLink_ = new Link(startNode, tempNode_);
                        mouseAction_ = MouseAction.AddLinkFindEndNode;
                    }
                    break;
                case MouseAction.AddLinkFindEndNode:
                    tempLink_.To = selectedNode ?? tempNode_;
                    break;
                case MouseAction.UpdateNodeType:
                    if (selectedNode != null && newNodeType_.HasValue)
                        selectedNode.Type = newNodeType_.Value;
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
                        tempNode_.Position = e.Location;
                        tempNode_.Title = repository_.ListNodes().Count().ToString(CultureInfo.InvariantCulture);
                        repository_.AddNode(tempNode_);
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
                    var selectedNode = repository_.GetFirstSelectedNode();
                    if (selectedNode != null)
                    {
                        tempLink_.To = selectedNode;
                        var sameLinkExists =
                            repository_.ListLinks().FirstOrDefault(l => l.From == tempLink_.From && l.To == tempLink_.To);
                        var reverseLink = repository_.ListLinks().FirstOrDefault(l => l.From == tempLink_.To && l.To == tempLink_.From);
                        
                        if (sameLinkExists != null)
                            repository_.RemoveLink(sameLinkExists);
                        else if (reverseLink != null)
                        {
                            repository_.RemoveLink(reverseLink);
                            repository_.AddLink(tempLink_);
                        }
                        else
                            repository_.AddLink(tempLink_);
                    }
                    else if (ToggleCreateNewNodeForLinks.Checked)
                    {
                        tempNode_.Title = repository_.ListNodes().Count().ToString(CultureInfo.InvariantCulture);
                        repository_.AddNode(tempNode_);
                        repository_.AddLink(tempLink_);
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
            DrawSomething(graphics, repository_.ListLinks());
            DrawSomething(graphics, repository_.ListNodes());
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

        private void ToolNodeTypeCross_Click(object sender, EventArgs e)
        { SelectActiveToolTypeButton(Node.NodeType.Cross); }


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
                ToolNodeTypeCross.Checked = Node.NodeType.Cross == nodeType.Value;
            }

            newNodeType_ = nodeType;
        }


        public JunctionRepository Repository
        {
            get { return repository_; }
        }
    }
}
