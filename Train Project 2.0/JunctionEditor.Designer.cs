namespace TrainProject
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.ToolClearEditor = new System.Windows.Forms.ToolStripButton();
            this.ToolLoadFromFile = new System.Windows.Forms.ToolStripButton();
            this.ToolSaveToFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolPutNodes = new System.Windows.Forms.ToolStripButton();
            this.ToolMoveNodes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolCreateLink = new System.Windows.Forms.ToolStripButton();
            this.ToggleCreateNewNodeForLinks = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ToolNodeTypeEntrance = new System.Windows.Forms.ToolStripButton();
            this.ToolNodeTypeIsolation = new System.Windows.Forms.ToolStripButton();
            this.ToolNodeTypeCross = new System.Windows.Forms.ToolStripButton();
            this.ToolNodeTypeDock = new System.Windows.Forms.ToolStripButton();
            this.ToolNodeTypePPP = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolUpdateCrossDenominator = new System.Windows.Forms.ToolStripButton();
            this.ToolSetLinkLength = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolSplitLink = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.DenominatorsList = new System.Windows.Forms.ComboBox();
            this.LinkLength = new System.Windows.Forms.TextBox();
            this.img = new System.Windows.Forms.PictureBox();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolClearEditor,
            this.ToolLoadFromFile,
            this.ToolSaveToFile,
            this.toolStripSeparator2,
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
            this.ToolNodeTypePPP,
            this.toolStripButton1,
            this.ToolUpdateCrossDenominator,
            this.ToolSetLinkLength,
            this.toolStripSeparator3,
            this.ToolSplitLink});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(498, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // ToolClearEditor
            // 
            this.ToolClearEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolClearEditor.Image = global::TrainProject.Properties.Resources.document_16xLG;
            this.ToolClearEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolClearEditor.Name = "ToolClearEditor";
            this.ToolClearEditor.Size = new System.Drawing.Size(23, 22);
            this.ToolClearEditor.Text = "New junction";
            this.ToolClearEditor.Click += new System.EventHandler(this.ToolClearEditor_Click);
            // 
            // ToolLoadFromFile
            // 
            this.ToolLoadFromFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolLoadFromFile.Image = global::TrainProject.Properties.Resources.folder_Open_16xLG;
            this.ToolLoadFromFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolLoadFromFile.Name = "ToolLoadFromFile";
            this.ToolLoadFromFile.Size = new System.Drawing.Size(23, 22);
            this.ToolLoadFromFile.Text = "toolStripButton3";
            this.ToolLoadFromFile.Click += new System.EventHandler(this.ToolLoadFromFile_Click);
            // 
            // ToolSaveToFile
            // 
            this.ToolSaveToFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolSaveToFile.Image = global::TrainProject.Properties.Resources.save_16xLG;
            this.ToolSaveToFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolSaveToFile.Name = "ToolSaveToFile";
            this.ToolSaveToFile.Size = new System.Drawing.Size(23, 22);
            this.ToolSaveToFile.Text = "toolStripButton4";
            this.ToolSaveToFile.Click += new System.EventHandler(this.ToolSaveToFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            this.ToolMoveNodes.Image = global::TrainProject.Properties.Resources.ToolMoveNode;
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
            this.ToggleCreateNewNodeForLinks.Name = "ToggleCreateNewNodeForLinks";
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
            // ToolNodeTypeCross
            // 
            this.ToolNodeTypeCross.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolNodeTypeCross.Image = global::TrainProject.Properties.Resources.NodeTypeCross;
            this.ToolNodeTypeCross.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolNodeTypeCross.Name = "ToolNodeTypeCross";
            this.ToolNodeTypeCross.Size = new System.Drawing.Size(23, 22);
            this.ToolNodeTypeCross.Text = "Set node type to cross";
            this.ToolNodeTypeCross.Click += new System.EventHandler(this.ToolNodeTypeCross_Click);
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
            // ToolNodeTypePPP
            // 
            this.ToolNodeTypePPP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolNodeTypePPP.Image = global::TrainProject.Properties.Resources.ToolNodeTypePPP;
            this.ToolNodeTypePPP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolNodeTypePPP.Name = "ToolNodeTypePPP";
            this.ToolNodeTypePPP.Size = new System.Drawing.Size(23, 22);
            this.ToolNodeTypePPP.Text = "Set node type to PPP";
            this.ToolNodeTypePPP.Click += new System.EventHandler(this.ToolNodeTypePPP_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolUpdateCrossDenominator
            // 
            this.ToolUpdateCrossDenominator.CheckOnClick = true;
            this.ToolUpdateCrossDenominator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolUpdateCrossDenominator.Image = global::TrainProject.Properties.Resources.ToolDenominatorUpdate;
            this.ToolUpdateCrossDenominator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolUpdateCrossDenominator.Name = "ToolUpdateCrossDenominator";
            this.ToolUpdateCrossDenominator.Size = new System.Drawing.Size(23, 22);
            this.ToolUpdateCrossDenominator.Text = "Set cross denominator";
            this.ToolUpdateCrossDenominator.Click += new System.EventHandler(this.ToolSetBase_Click);
            // 
            // ToolSetLinkLength
            // 
            this.ToolSetLinkLength.CheckOnClick = true;
            this.ToolSetLinkLength.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolSetLinkLength.Image = global::TrainProject.Properties.Resources.LinkLengths;
            this.ToolSetLinkLength.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolSetLinkLength.Name = "ToolSetLinkLength";
            this.ToolSetLinkLength.Size = new System.Drawing.Size(23, 22);
            this.ToolSetLinkLength.Text = "Set link length";
            this.ToolSetLinkLength.Click += new System.EventHandler(this.ToolSetLinkLength_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolSplitLink
            // 
            this.ToolSplitLink.CheckOnClick = true;
            this.ToolSplitLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolSplitLink.Image = global::TrainProject.Properties.Resources.SplitLink;
            this.ToolSplitLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolSplitLink.Name = "ToolSplitLink";
            this.ToolSplitLink.Size = new System.Drawing.Size(23, 22);
            this.ToolSplitLink.Text = "Split link";
            this.ToolSplitLink.Click += new System.EventHandler(this.ToolSplitLink_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "*.jun";
            this.openFileDialog.Filter = "Junction files|*.jun|All files|*.*";
            this.openFileDialog.InitialDirectory = ".";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Junction files|*.jun|All files|*.*";
            this.saveFileDialog.InitialDirectory = ".";
            // 
            // DenominatorsList
            // 
            this.DenominatorsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DenominatorsList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DenominatorsList.FormattingEnabled = true;
            this.DenominatorsList.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.DenominatorsList.Location = new System.Drawing.Point(14, 40);
            this.DenominatorsList.Name = "DenominatorsList";
            this.DenominatorsList.Size = new System.Drawing.Size(43, 21);
            this.DenominatorsList.TabIndex = 2;
            this.DenominatorsList.Visible = false;
            this.DenominatorsList.SelectedIndexChanged += new System.EventHandler(this.DenominatorsList_SelectedIndexChanged);
            this.DenominatorsList.DropDownClosed += new System.EventHandler(this.DenominatorsList_DropDownClosed);
            // 
            // LinkLength
            // 
            this.LinkLength.AcceptsReturn = true;
            this.LinkLength.Location = new System.Drawing.Point(77, 40);
            this.LinkLength.MaxLength = 5;
            this.LinkLength.Name = "LinkLength";
            this.LinkLength.Size = new System.Drawing.Size(53, 20);
            this.LinkLength.TabIndex = 4;
            this.LinkLength.Visible = false;
            this.LinkLength.TextChanged += new System.EventHandler(this.LinkLength_TextChanged);
            this.LinkLength.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LinkLength_KeyDown);
            // 
            // img
            // 
            this.img.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.img.Location = new System.Drawing.Point(3, 28);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(492, 266);
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
            this.Controls.Add(this.LinkLength);
            this.Controls.Add(this.DenominatorsList);
            this.Controls.Add(this.img);
            this.Controls.Add(this.toolStrip);
            this.Name = "JEditor";
            this.Size = new System.Drawing.Size(498, 297);
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
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton ToolClearEditor;
        private System.Windows.Forms.ToolStripButton ToolLoadFromFile;
        private System.Windows.Forms.ToolStripButton ToolSaveToFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripButton ToolUpdateCrossDenominator;
        private System.Windows.Forms.ComboBox DenominatorsList;
        private System.Windows.Forms.ToolStripButton ToolSetLinkLength;
        private System.Windows.Forms.TextBox LinkLength;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ToolSplitLink;
    }
}
