using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrainProject.JunctionEditor
{
    public partial class JEditor : UserControl
    {
        private List<Node> nodes = new List<Node>();
        private Node tempNode_;
        private Node movingNodeRef_;

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
            AddLink
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
                    img.Invalidate();
                    break;
                case MouseAction.MoveNode:
                    if (movingNodeRef_ == null)
                        UpdateSelectionStates(e.Location);
                    else
                        movingNodeRef_.SetPosition(e.Location);
                    img.Invalidate();
                    break;
                case MouseAction.AddLink:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
                    img.Invalidate();
                    break;
                case MouseAction.MoveNode:
                    movingNodeRef_ = nodes.FirstOrDefault(n => n.IsSelected());
                    break;
                case MouseAction.AddLink:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
                    img.Invalidate();
                    break;
                case MouseAction.MoveNode:
                    movingNodeRef_ = null;
                    break;
                case MouseAction.AddLink:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion

        #region draw routines

        private void img_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            DrawSomething(graphics, nodes);
            DrawSomething(graphics, tempNode_);
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

        private void img_Click(object sender, EventArgs e)
        {
            Invalidate(true);
        }

        private void ToolPutNodes_Click(object sender, EventArgs e)
        {
            ToolMoveNodes.Checked = false;
            mouseAction_ = ToolPutNodes.Checked ? MouseAction.PutNode : MouseAction.None;            
        }

        private void ToolMoveNodes_Click(object sender, EventArgs e)
        {
            ToolPutNodes.Checked = false;
            mouseAction_ = ToolMoveNodes.Checked ? MouseAction.MoveNode : MouseAction.None;
        }
    }
}
