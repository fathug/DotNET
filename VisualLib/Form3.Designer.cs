using VisualLib.Control;

namespace VisualLib
{
    partial class Form3
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
            button1 = new Button();
            roiPictureBox1 = new RoiPictureBox();
            ((System.ComponentModel.ISupportInitialize)roiPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(488, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // roiPictureBox1
            // 
            roiPictureBox1.Location = new Point(12, 12);
            roiPictureBox1.Name = "roiPictureBox1";
            roiPictureBox1.Size = new Size(368, 426);
            roiPictureBox1.TabIndex = 2;
            roiPictureBox1.TabStop = false;
            roiPictureBox1.Click += roiPictureBox1_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(roiPictureBox1);
            Controls.Add(button1);
            Name = "Form3";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)roiPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private RoiPictureBox roiPictureBox1;
    }
}