using TrainProject.JunctionEditor;

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
            this.junctionEditor1 = new TrainProject.JunctionEditor.JEditor();
            this.SuspendLayout();
            // 
            // junctionEditor1
            // 
            this.junctionEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.junctionEditor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.junctionEditor1.Location = new System.Drawing.Point(0, 0);
            this.junctionEditor1.Name = "junctionEditor1";
            this.junctionEditor1.Size = new System.Drawing.Size(615, 406);
            this.junctionEditor1.TabIndex = 0;
            this.junctionEditor1.Load += new System.EventHandler(this.junctionEditor1_Load);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 407);
            this.Controls.Add(this.junctionEditor1);
            this.Name = "FormMain";
            this.Text = "Junction Editor";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private JEditor junctionEditor1;
    }
}

