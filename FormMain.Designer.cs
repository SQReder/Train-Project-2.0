﻿using TrainProject.JunctionEditor;

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
            this.btnSerialize = new System.Windows.Forms.Button();
            this.tbSerializedJunction = new System.Windows.Forms.TextBox();
            this.btnDeserialize = new System.Windows.Forms.Button();
            this.junctionEditor = new TrainProject.JunctionEditor.JEditor();
            this.SuspendLayout();
            // 
            // btnSerialize
            // 
            this.btnSerialize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSerialize.Location = new System.Drawing.Point(697, 173);
            this.btnSerialize.Name = "btnSerialize";
            this.btnSerialize.Size = new System.Drawing.Size(32, 32);
            this.btnSerialize.TabIndex = 1;
            this.btnSerialize.Text = "=>";
            this.btnSerialize.UseVisualStyleBackColor = true;
            this.btnSerialize.Click += new System.EventHandler(this.btnSerialize_Click);
            // 
            // tbSerializedJunction
            // 
            this.tbSerializedJunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSerializedJunction.Location = new System.Drawing.Point(735, 12);
            this.tbSerializedJunction.Multiline = true;
            this.tbSerializedJunction.Name = "tbSerializedJunction";
            this.tbSerializedJunction.Size = new System.Drawing.Size(224, 393);
            this.tbSerializedJunction.TabIndex = 2;
            // 
            // btnDeserialize
            // 
            this.btnDeserialize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDeserialize.Location = new System.Drawing.Point(697, 211);
            this.btnDeserialize.Name = "btnDeserialize";
            this.btnDeserialize.Size = new System.Drawing.Size(32, 32);
            this.btnDeserialize.TabIndex = 3;
            this.btnDeserialize.Text = "<=";
            this.btnDeserialize.UseVisualStyleBackColor = true;
            this.btnDeserialize.Click += new System.EventHandler(this.btnDeserialize_Click);
            // 
            // junctionEditor
            // 
            this.junctionEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.junctionEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.junctionEditor.Location = new System.Drawing.Point(12, 12);
            this.junctionEditor.Name = "junctionEditor";
            this.junctionEditor.Size = new System.Drawing.Size(679, 393);
            this.junctionEditor.TabIndex = 0;
            this.junctionEditor.Load += new System.EventHandler(this.junctionEditor1_Load);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 417);
            this.Controls.Add(this.btnDeserialize);
            this.Controls.Add(this.tbSerializedJunction);
            this.Controls.Add(this.btnSerialize);
            this.Controls.Add(this.junctionEditor);
            this.Name = "FormMain";
            this.Text = "Junction Editor";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JEditor junctionEditor;
        private System.Windows.Forms.Button btnSerialize;
        private System.Windows.Forms.TextBox tbSerializedJunction;
        private System.Windows.Forms.Button btnDeserialize;
    }
}

