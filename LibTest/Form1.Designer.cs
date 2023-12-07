namespace LibTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            roiPictureBox1 = new VisualLib.Control.RoiPictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)roiPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // roiPictureBox1
            // 
            roiPictureBox1.Location = new Point(46, 38);
            roiPictureBox1.Name = "roiPictureBox1";
            roiPictureBox1.Size = new Size(247, 360);
            roiPictureBox1.TabIndex = 0;
            roiPictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(375, 38);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(roiPictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)roiPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private VisualLib.Control.RoiPictureBox roiPictureBox1;
        private Button button1;
    }
}
