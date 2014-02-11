using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        private enum JunctionTool
        {
            None,
            PutNode,
            MoveNode,
            AddLinkFindStartNode,
            AddLinkFindEndNode,
            UpdateNodeType,
            UpdateDenominator,
        };

        private JunctionTool junctionTool_ = JunctionTool.None;

        private Node.NodeType? newNodeType_ = Node.NodeType.Isolation;


        private void img_MouseMove(object sender, MouseEventArgs e)
        {
            repository_.UpdateSelectionStates(e.Location);
            switch (junctionTool_)
            {
                case JunctionTool.None:
                    break;
                case JunctionTool.PutNode:
                    if (tempNode_ != null)
                        tempNode_.Position = e.Location;
                    break;
                case JunctionTool.MoveNode:
                    if (movingNodeRef_ != null)
                        movingNodeRef_.Position = e.Location;
                    break;
                case JunctionTool.AddLinkFindStartNode:
                    break;
                case JunctionTool.AddLinkFindEndNode:
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
                case JunctionTool.UpdateNodeType:
                    break;
                case JunctionTool.UpdateDenominator:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            img.Invalidate();
        }


        private void img_MouseDown(object sender, MouseEventArgs e)
        {
            var selectedNode = repository_.GetFirstSelectedNode();
            switch (junctionTool_)
            {
                case JunctionTool.None:
                    break;
                case JunctionTool.PutNode:
                    if (e.Button.HasFlag(MouseButtons.Right))
                    {
                        repository_.RemoveNode(selectedNode);
                    }
                    else if (e.Button.HasFlag(MouseButtons.Left))
                    {
                        tempNode_ = new Node {Position = e.Location};
                    }
                    break;
                case JunctionTool.MoveNode:
                    movingNodeRef_ = selectedNode;
                    break;
                case JunctionTool.AddLinkFindStartNode:
                    var startNode = selectedNode;
                    if (startNode != null)
                    {
                        tempNode_ = new Node {Position = e.Location};
                        tempLink_ = new Link(startNode, tempNode_);
                        junctionTool_ = JunctionTool.AddLinkFindEndNode;
                    }
                    break;
                case JunctionTool.AddLinkFindEndNode:
                    tempLink_.To = selectedNode ?? tempNode_;
                    break;
                case JunctionTool.UpdateNodeType:
                    if (selectedNode != null && newNodeType_.HasValue)
                        selectedNode.Type = newNodeType_.Value;
                    break;
                case JunctionTool.UpdateDenominator:
                    if (selectedNode != null)
                    {
                        tempNode_ = selectedNode;
                        DenominatorsList.Left = e.Location.X;
                        DenominatorsList.Top = e.Location.Y + DenominatorsList.Height;
                        DenominatorsList.Show();
                    }
                    else
                    {
                        tempNode_ = null;
                        DenominatorsList.Hide();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            img.Invalidate();
        }


        private void img_MouseUp(object sender, MouseEventArgs e)
        {
            switch (junctionTool_)
            {
                case JunctionTool.None:
                    break;
                case JunctionTool.PutNode:
                    if (tempNode_ != null)
                    {
                        tempNode_.Position = e.Location;
                        tempNode_.Title = repository_.ListNodes().Count().ToString(CultureInfo.InvariantCulture);
                        repository_.AddNode(tempNode_);
                        tempNode_ = null;
                    }
                    break;
                case JunctionTool.MoveNode:
                    movingNodeRef_ = null;
                    break;
                case JunctionTool.AddLinkFindStartNode:
                    tempLink_ = null;
                    break;
                case JunctionTool.AddLinkFindEndNode:
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

                    junctionTool_ = JunctionTool.AddLinkFindStartNode;
                    break;
                case JunctionTool.UpdateNodeType:
                    break;
                case JunctionTool.UpdateDenominator:
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

        #region All tools

        private void ToolPutNodes_Click(object sender, EventArgs e)
        { SelectActiveToolTypeButton(JunctionTool.PutNode); }


        private void ToolMoveNodes_Click(object sender, EventArgs e)
        { SelectActiveToolTypeButton(JunctionTool.MoveNode); }


        private void ToolCreateLink_Click(object sender, EventArgs e)
        { SelectActiveToolTypeButton(JunctionTool.AddLinkFindStartNode); }

        private void ToolSetBase_Click(object sender, EventArgs e)
        { SelectActiveToolTypeButton(JunctionTool.UpdateDenominator); }

        private void SelectActiveToolTypeButton(JunctionTool tool)
        {
            ToolNodeTypeDock.Checked = false;
            ToolNodeTypeIsolation.Checked = false;
            ToolNodeTypeEntrance.Checked = false;
            ToolNodeTypePPP.Checked = false;
            ToolNodeTypeCross.Checked = false;

            ToolPutNodes.Checked = JunctionTool.PutNode == tool;
            ToolMoveNodes.Checked = JunctionTool.MoveNode == tool;
            ToolCreateLink.Checked = JunctionTool.AddLinkFindStartNode == tool;
            ToolUpdateCrossDenominator.Checked = JunctionTool.UpdateDenominator == tool;

            junctionTool_ = tool;
        }

        #endregion


        #region Node type tools

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


        private void SelectActiveToolTypeButton(Node.NodeType nodeType)
        {
            ToolPutNodes.Checked = false;
            ToolMoveNodes.Checked = false;
            ToolCreateLink.Checked = false;
            ToolUpdateCrossDenominator.Checked = false;

            junctionTool_ = JunctionTool.UpdateNodeType;

            ToolNodeTypeDock.Checked = Node.NodeType.Dock == nodeType;
            ToolNodeTypeIsolation.Checked = Node.NodeType.Isolation == nodeType;
            ToolNodeTypeEntrance.Checked = Node.NodeType.Entrance == nodeType;
            ToolNodeTypePPP.Checked = Node.NodeType.Ppp == nodeType;
            ToolNodeTypeCross.Checked = Node.NodeType.Cross == nodeType;

            newNodeType_ = nodeType;
        }

        #endregion


        public JunctionRepository Repository
        {
            get { return repository_; }
        }

        private void ToolClearEditor_Click(object sender, EventArgs e)
        {
            repository_.Clear();
        }

        private void ToolLoadFromFile_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            
            var filename = openFileDialog.FileName;
            var text = File.ReadAllText(filename);
            repository_.Deserialize(text);
            Invalidate(true);
        }

        private void ToolSaveToFile_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            var filename = saveFileDialog.FileName;
            var serializedData = repository_.Serialize();
            File.WriteAllText(filename, serializedData);
        }

        private void DenominatorsList_DropDownClosed(object sender, EventArgs e)
        {
            tempNode_.Denominator = int.Parse(DenominatorsList.Text);
            DenominatorsList.Hide();
        }

        private void DenominatorsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
