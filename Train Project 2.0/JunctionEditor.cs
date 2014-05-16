using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TrainProject.Interfaces;
using TrainProject.Model;

namespace TrainProject
{
    public partial class JEditor : UserControl
    {
        #region vars
        
        private readonly JunctionRepository repository_ = new JunctionRepository();

        private Node tempNode_;
        private Node movingNodeRef_;
        private Link tempLink_;

        public JunctionRepository Repository
        {
            get { return repository_; }
        }

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
            UpdateLinkLength,
            SplitLink
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
                case JunctionTool.UpdateLinkLength:
                    break;
                case JunctionTool.SplitLink:
                    var selectedLink = repository_.GetFirstSelectedLink();
                    if (selectedLink != null)
                    {
                        if (tempNode_ == null)
                            tempNode_ = new Node();

                        tempNode_.Position = selectedLink.MapPointToLine(e.Location);

                        var oldFixedLength = selectedLink.Length;
                        var oldRealLen = new Vector(selectedLink.From, selectedLink.To).Length;
                        var ratio = oldFixedLength / oldRealLen;

                        var newRealLengthOne = new Vector(selectedLink.From, tempNode_).Length;

                        var newFixedLengthOne = (int)Math.Round(newRealLengthOne * ratio);
                        
                        tempNode_.Title = newFixedLengthOne.ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                            tempNode_ = null;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            img.Invalidate();
        }


        private void img_MouseDown(object sender, MouseEventArgs e)
        {
            var selectedNode = repository_.GetFirstSelectedNode();
            var selectedLink = repository_.GetFirstSelectedLink();
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
                    if (selectedNode != null && selectedNode.Type == Node.NodeType.Cross)
                    {
                        tempNode_ = selectedNode;
                        DenominatorsList.Left = e.Location.X;
                        DenominatorsList.Top = e.Location.Y + DenominatorsList.Height;
                        if (selectedNode.Denominator != null)
                            DenominatorsList.SelectedItem =
                                selectedNode.Denominator.Value.ToString(CultureInfo.InvariantCulture);
                        else
                            DenominatorsList.SelectedIndex = -1;
                        DenominatorsList.Show();
                        DenominatorsList.Focus();
                    }
                    else
                    {
                        tempNode_ = null;
                        DenominatorsList.Hide();
                    }
                    break;
                case JunctionTool.UpdateLinkLength:
                    if (selectedLink != null)
                    {
                        tempLink_ = selectedLink;
                        LinkLength.Left = e.Location.X;
                        LinkLength.Top = e.Location.Y + LinkLength.Height;
                        LinkLength.Text = tempLink_.Length.ToString(CultureInfo.InvariantCulture);
                        LinkLength.Show();
                        LinkLength.Focus();
                        LinkLength.SelectAll();
                    }
                    else
                    {
                        tempLink_ = null;
                        LinkLength.Hide();
                    }
                    break;
                case JunctionTool.SplitLink:
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
                            repository_.ListLinks().FirstOrDefault(l => Equals(l.From, tempLink_.From) &&
                                                                        Equals(l.To, tempLink_.To));
                        var reverseLink = repository_.ListLinks().FirstOrDefault(l =>
                            Equals(l.From, tempLink_.To) && Equals(l.To, tempLink_.From));
                        
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
                case JunctionTool.UpdateLinkLength:
                    break;
                case JunctionTool.SplitLink:
                    var selectedLink = repository_.GetFirstSelectedLink();
                    if (selectedLink != null)
                    {
                        var oldFixedLength = selectedLink.Length;
                        var oldRealLen = new Vector(selectedLink.From, selectedLink.To).Length;
                        var ratio = oldFixedLength / oldRealLen;

                        var newRealLengthOne = new Vector(selectedLink.From, tempNode_).Length;
                        var newRealLengthTwo = new Vector(tempNode_, selectedLink.To).Length;

                        var newFixedLengthOne = (int)Math.Round(newRealLengthOne * ratio);
                        var newFixedLengthTwo = (int)Math.Round(newRealLengthTwo * ratio);

                        repository_.AddNode(tempNode_);
                        
                        var l = new Link(tempNode_, selectedLink.To)
                        {
                            Length = newFixedLengthTwo
                        };

                        repository_.AddLink(l);

                        selectedLink.To = tempNode_;
                        selectedLink.Length = newFixedLengthOne;
                        tempNode_ = null;
                    }
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

        #region All tools

        private void ToolPutNodes_Click(object sender, EventArgs e)
        { SelectActiveToolTypeButton(JunctionTool.PutNode); }

        private void ToolMoveNodes_Click(object sender, EventArgs e)
        { SelectActiveToolTypeButton(JunctionTool.MoveNode); }

        private void ToolCreateLink_Click(object sender, EventArgs e)
        { SelectActiveToolTypeButton(JunctionTool.AddLinkFindStartNode); }

        private void ToolSetBase_Click(object sender, EventArgs e)
        { SelectActiveToolTypeButton(JunctionTool.UpdateDenominator); }

        private void ToolSetLinkLength_Click(object sender, EventArgs e)
        { SelectActiveToolTypeButton(JunctionTool.UpdateLinkLength); }

        private void ToolSplitLink_Click(object sender, EventArgs e)
        { SelectActiveToolTypeButton(JunctionTool.SplitLink); }


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
            ToolSetLinkLength.Checked = JunctionTool.UpdateLinkLength == tool;
            ToolSplitLink.Checked = JunctionTool.SplitLink == tool;

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
            ToolSetLinkLength.Checked = false;
            ToolSplitLink.Checked = false;

            junctionTool_ = JunctionTool.UpdateNodeType;

            ToolNodeTypeDock.Checked = Node.NodeType.Dock == nodeType;
            ToolNodeTypeIsolation.Checked = Node.NodeType.Isolation == nodeType;
            ToolNodeTypeEntrance.Checked = Node.NodeType.Entrance == nodeType;
            ToolNodeTypePPP.Checked = Node.NodeType.Ppp == nodeType;
            ToolNodeTypeCross.Checked = Node.NodeType.Cross == nodeType;

            newNodeType_ = nodeType;
        }

        #endregion

        #region LSD // thank McGee for that

        private void ToolClearEditor_Click(object sender, EventArgs e)
        {
            repository_.Clear();
            img.Invalidate();
            tempNode_ = null;
            tempLink_ = null;
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

        #endregion

        private void img_Click(object sender, EventArgs e)
        {
            Invalidate(true);
        }

        private void DenominatorsList_DropDownClosed(object sender, EventArgs e)
        {
            Node.DenominationValues? denominator = null;
            switch (DenominatorsList.Text)
            {
                case "1/6": denominator = Node.DenominationValues.dv6;
                    break;
                case "1/9": denominator = Node.DenominationValues.dv9;
                    break;
                case "1/11": denominator = Node.DenominationValues.dv11;
                    break;
                case "1/18": denominator = Node.DenominationValues.dv18;
                    break;
                case "1/22": denominator = Node.DenominationValues.dv22;
                    break;
            }
            if (denominator.HasValue)
                    tempNode_.Denominator = denominator;
            DenominatorsList.Hide();
        }

        private void LinkLength_TextChanged(object sender, EventArgs e)
        {
            int length;

            int.TryParse(LinkLength.Text, out length);
            Debug.Assert(tempLink_ != null);

            tempLink_.Length = length;
            Invalidate(true);
        }

        private void LinkLength_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int length;
                
                int.TryParse(LinkLength.Text, out length);
                Debug.Assert(tempLink_ != null);

                tempLink_.Length = length;

                LinkLength.Hide();
            }
        }
    }
}
