namespace TrainProject.JunctionEditor
{
    partial class JEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JEditor));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.ToolPutNodes = new System.Windows.Forms.ToolStripButton();
            this.ToolMoveNodes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolCreateLink = new System.Windows.Forms.ToolStripButton();
            this.ToggleCreateNewNodeForLinks = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ToolNodeTypeIsolation = new System.Windows.Forms.ToolStripButton();
            this.ToolNodeTypeDock = new System.Windows.Forms.ToolStripButton();
            this.ToolNodeTypeEntrance = new System.Windows.Forms.ToolStripButton();
            this.ToolNodeTypePPP = new System.Windows.Forms.ToolStripButton();
            this.ToolNodeTypeCross = new System.Windows.Forms.ToolStripButton();
            this.img = new System.Windows.Forms.PictureBox();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolPutNodes,
            this.ToolMoveNodes,
            this.toolStripSeparator1,
            this.ToolCreateLink,
            this.ToggleCreateNewNodeForLinks,
            this.toolStripButton2,
            this.toolStripLabel1,
            this.ToolNodeTypeEntrance,
            this.ToolNodeTypeIsolation,
            this.ToolNodeTypeCross,
            this.ToolNodeTypeDock,
            this.ToolNodeTypePPP});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(439, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // ToolPutNodes
            // 
            this.ToolPutNodes.CheckOnClick = true;
            this.ToolPutNodes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolPutNodes.Image = global::TrainProject.Properties.Resources.ToolCreateNode;
            this.ToolPutNodes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolPutNodes.Name = "ToolPutNodes";
            this.ToolPutNodes.Size = new System.Drawing.Size(23, 22);
            this.ToolPutNodes.ToolTipText = "Draw lines";
            this.ToolPutNodes.Click += new System.EventHandler(this.ToolPutNodes_Click);
            // 
            // ToolMoveNodes
            // 
            this.ToolMoveNodes.CheckOnClick = true;
            this.ToolMoveNodes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolMoveNodes.Image = ((System.Drawing.Image)(resources.GetObject("ToolMoveNodes.Image")));
            this.ToolMoveNodes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolMoveNodes.Name = "ToolMoveNodes";
            this.ToolMoveNodes.Size = new System.Drawing.Size(23, 22);
            this.ToolMoveNodes.Text = "Move nodes";
            this.ToolMoveNodes.Click += new System.EventHandler(this.ToolMoveNodes_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolCreateLink
            // 
            this.ToolCreateLink.CheckOnClick = true;
            this.ToolCreateLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolCreateLink.Image = global::TrainProject.Properties.Resources.ToolCreateLink;
            this.ToolCreateLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolCreateLink.Name = "ToolCreateLink";
            this.ToolCreateLink.Size = new System.Drawing.Size(23, 22);
            this.ToolCreateLink.Text = "Create link between nodes";
            this.ToolCreateLink.Click += new System.EventHandler(this.ToolCreateLink_Click);
            // 
            // ToggleCreateNewNodeForLinks
            // 
            this.ToggleCreateNewNodeForLinks.CheckOnClick = true;
            this.ToggleCreateNewNodeForLinks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToggleCreateNewNodeForLinks.Image = global::TrainProject.Properties.Resources.CreateNewNodeForLinks;
            this.ToggleCreateNewNodeForLinks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToggleCreateNewNodeForLinks.Name = "CreateNewNodeForLinks";
            this.ToggleCreateNewNodeForLinks.Size = new System.Drawing.Size(23, 22);
            this.ToggleCreateNewNodeForLinks.Text = "Create new nodes when link to nowere";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel1.Text = "Node types:";
            // 
            // ToolNodeTypeIsolation
            // 
            this.ToolNodeTypeIsolation.CheckOnClick = true;
            this.ToolNodeTypeIsolation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolNodeTypeIsolation.Image = global::TrainProject.Properties.Resources.NodeTypeIsolation;
            this.ToolNodeTypeIsolation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolNodeTypeIsolation.Name = "ToolNodeTypeIsolation";
            this.ToolNodeTypeIsolation.Size = new System.Drawing.Size(23, 22);
            this.ToolNodeTypeIsolation.Text = "Set node type to isolation";
            this.ToolNodeTypeIsolation.Click += new System.EventHandler(this.ToolNodeTypeIsolation_Click);
            // 
            // ToolNodeTypeDock
            // 
            this.ToolNodeTypeDock.CheckOnClick = true;
            this.ToolNodeTypeDock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolNodeTypeDock.Image = global::TrainProject.Properties.Resources.ToolNodeTypeDock;
            this.ToolNodeTypeDock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolNodeTypeDock.Name = "ToolNodeTypeDock";
            this.ToolNodeTypeDock.Size = new System.Drawing.Size(23, 22);
            this.ToolNodeTypeDock.Text = "Set node type to dock";
            this.ToolNodeTypeDock.Click += new System.EventHandler(this.ToolNodeTypeDock_Click);
            // 
            // ToolNodeTypeEntrance
            // 
            this.ToolNodeTypeEntrance.CheckOnClick = true;
            this.ToolNodeTypeEntrance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolNodeTypeEntrance.Image = global::TrainProject.Properties.Resources.ToolNodeTypeInput;
            this.ToolNodeTypeEntrance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolNodeTypeEntrance.Name = "ToolNodeTypeEntrance";
            this.ToolNodeTypeEntrance.Size = new System.Drawing.Size(23, 22);
            this.ToolNodeTypeEntrance.Text = "Set node type to input";
            this.ToolNodeTypeEntrance.Click += new System.EventHandler(this.ToolNodeTypeEntrance_Click);
            // 
            // ToolNodeTypePPP
            // 
            this.ToolNodeTypePPP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolNodeTypePPP.Image = global::TrainProject.Properties.Resources.ToolNodeTypePPP;
            this.ToolNodeTypePPP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolNodeTypePPP.Name = "ToolNodeTypePPP";
            this.ToolNodeTypePPP.Size = new System.Drawing.Size(23, 22);
            this.ToolNodeTypePPP.Text = "toolStripButton1";
            this.ToolNodeTypePPP.Click += new System.EventHandler(this.ToolNodeTypePPP_Click);
            // 
            // ToolNodeTypeCross
            // 
            this.ToolNodeTypeCross.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolNodeTypeCross.Image = global::TrainProject.Properties.Resources.NodeTypeCross;
            this.ToolNodeTypeCross.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolNodeTypeCross.Name = "ToolNodeTypeCross";
            this.ToolNodeTypeCross.Size = new System.Drawing.Size(23, 22);
            this.ToolNodeTypeCross.Text = "toolStripButton1";
            this.ToolNodeTypeCross.Click += new System.EventHandler(this.ToolNodeTypeCross_Click);
            // 
            // img
            // 
            this.img.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.img.Location = new System.Drawing.Point(3, 28);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(433, 189);
            this.img.TabIndex = 1;
            this.img.TabStop = false;
            this.img.Click += new System.EventHandler(this.img_Click);
            this.img.Paint += new System.Windows.Forms.PaintEventHandler(this.img_Paint);
            this.img.MouseDown += new System.Windows.Forms.MouseEventHandler(this.img_MouseDown);
            this.img.MouseMove += new System.Windows.Forms.MouseEventHandler(this.img_MouseMove);
            this.img.MouseUp += new System.Windows.Forms.MouseEventHandler(this.img_MouseUp);
            // 
            // JEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.img);
            this.Controls.Add(this.toolStrip);
            this.Name = "JEditor";
            this.Size = new System.Drawing.Size(439, 220);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton ToolPutNodes;
        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.ToolStripButton ToolMoveNodes;
        private System.Windows.Forms.ToolStripButton ToolCreateLink;
        private System.Windows.Forms.ToolStripSeparator toolStripButton2;
        private System.Windows.Forms.ToolStripButton ToggleCreateNewNodeForLinks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ToolNodeTypeDock;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton ToolNodeTypeIsolation;
        private System.Windows.Forms.ToolStripButton ToolNodeTypeEntrance;
        private System.Windows.Forms.ToolStripButton ToolNodeTypePPP;
        private System.Windows.Forms.ToolStripButton ToolNodeTypeCross;
    }
}
