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
            this.img = new System.Windows.Forms.PictureBox();
            this.ToolPutNodes = new System.Windows.Forms.ToolStripButton();
            this.ToolMoveNodes = new System.Windows.Forms.ToolStripButton();
            this.ToolCreateLink = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolPutNodes,
            this.ToolMoveNodes,
            this.ToolCreateLink});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(262, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // img
            // 
            this.img.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.img.Location = new System.Drawing.Point(3, 28);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(256, 158);
            this.img.TabIndex = 1;
            this.img.TabStop = false;
            this.img.Click += new System.EventHandler(this.img_Click);
            this.img.Paint += new System.Windows.Forms.PaintEventHandler(this.img_Paint);
            this.img.MouseDown += new System.Windows.Forms.MouseEventHandler(this.img_MouseDown);
            this.img.MouseMove += new System.Windows.Forms.MouseEventHandler(this.img_MouseMove);
            this.img.MouseUp += new System.Windows.Forms.MouseEventHandler(this.img_MouseUp);
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
            this.ToolMoveNodes.Text = "toolStripButton1";
            this.ToolMoveNodes.Click += new System.EventHandler(this.ToolMoveNodes_Click);
            // 
            // ToolCreateLink
            // 
            this.ToolCreateLink.CheckOnClick = true;
            this.ToolCreateLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolCreateLink.Image = global::TrainProject.Properties.Resources.ToolCreateLink;
            this.ToolCreateLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolCreateLink.Name = "ToolCreateLink";
            this.ToolCreateLink.Size = new System.Drawing.Size(23, 22);
            this.ToolCreateLink.Text = "toolStripButton1";
            this.ToolCreateLink.Click += new System.EventHandler(this.ToolCreateLink_Click);
            // 
            // JEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.img);
            this.Controls.Add(this.toolStrip);
            this.Name = "JEditor";
            this.Size = new System.Drawing.Size(262, 189);
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
    }
}
