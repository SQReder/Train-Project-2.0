namespace TrainProject
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.cbStartNode = new System.Windows.Forms.ComboBox();
            this.cbEndNode = new System.Windows.Forms.ComboBox();
            this.lPath = new System.Windows.Forms.ListBox();
            this.btnLoadNodes = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.junctionEditor = new TrainProject.JEditor();
            this.SuspendLayout();
            // 
            // cbStartNode
            // 
            this.cbStartNode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStartNode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartNode.FormattingEnabled = true;
            this.cbStartNode.Location = new System.Drawing.Point(615, 41);
            this.cbStartNode.Name = "cbStartNode";
            this.cbStartNode.Size = new System.Drawing.Size(121, 21);
            this.cbStartNode.TabIndex = 1;
            // 
            // cbEndNode
            // 
            this.cbEndNode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEndNode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndNode.FormattingEnabled = true;
            this.cbEndNode.Location = new System.Drawing.Point(615, 68);
            this.cbEndNode.Name = "cbEndNode";
            this.cbEndNode.Size = new System.Drawing.Size(121, 21);
            this.cbEndNode.TabIndex = 2;
            // 
            // lPath
            // 
            this.lPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lPath.FormattingEnabled = true;
            this.lPath.Location = new System.Drawing.Point(615, 125);
            this.lPath.Name = "lPath";
            this.lPath.Size = new System.Drawing.Size(121, 316);
            this.lPath.TabIndex = 3;
            // 
            // btnLoadNodes
            // 
            this.btnLoadNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadNodes.Location = new System.Drawing.Point(615, 12);
            this.btnLoadNodes.Name = "btnLoadNodes";
            this.btnLoadNodes.Size = new System.Drawing.Size(121, 23);
            this.btnLoadNodes.TabIndex = 4;
            this.btnLoadNodes.Text = "Load";
            this.btnLoadNodes.UseVisualStyleBackColor = true;
            this.btnLoadNodes.Click += new System.EventHandler(this.btnLoadNodes_Click);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(615, 95);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(121, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // junctionEditor
            // 
            this.junctionEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.junctionEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.junctionEditor.Location = new System.Drawing.Point(12, 12);
            this.junctionEditor.Name = "junctionEditor";
            this.junctionEditor.Size = new System.Drawing.Size(597, 428);
            this.junctionEditor.TabIndex = 0;
            this.junctionEditor.Load += new System.EventHandler(this.junctionEditor1_Load);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 452);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnLoadNodes);
            this.Controls.Add(this.lPath);
            this.Controls.Add(this.cbEndNode);
            this.Controls.Add(this.cbStartNode);
            this.Controls.Add(this.junctionEditor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Junction Editor";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private JEditor junctionEditor;
        private System.Windows.Forms.ComboBox cbStartNode;
        private System.Windows.Forms.ComboBox cbEndNode;
        private System.Windows.Forms.ListBox lPath;
        private System.Windows.Forms.Button btnLoadNodes;
        private System.Windows.Forms.Button btnFind;
    }
}

