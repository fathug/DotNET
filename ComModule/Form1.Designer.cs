namespace ComModule
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
            groupBox1 = new GroupBox();
            btnStopServer = new Button();
            btnStartServer = new Button();
            txtPort = new TextBox();
            txtReceivedData = new TextBox();
            txtCommand = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnStopServer);
            groupBox1.Controls.Add(btnStartServer);
            groupBox1.Controls.Add(txtPort);
            groupBox1.Location = new Point(12, 29);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(528, 106);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "服务器状态";
            // 
            // btnStopServer
            // 
            btnStopServer.Location = new Point(295, 39);
            btnStopServer.Name = "btnStopServer";
            btnStopServer.Size = new Size(94, 29);
            btnStopServer.TabIndex = 2;
            btnStopServer.Text = "关闭服务器";
            btnStopServer.UseVisualStyleBackColor = true;
            btnStopServer.Click += btnStopServer_Click;
            // 
            // btnStartServer
            // 
            btnStartServer.Location = new Point(174, 40);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(94, 29);
            btnStartServer.TabIndex = 1;
            btnStartServer.Text = "启动服务器";
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Click += btnStartServer_Click;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(6, 40);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(125, 27);
            txtPort.TabIndex = 0;
            // 
            // txtReceivedData
            // 
            txtReceivedData.Location = new Point(12, 171);
            txtReceivedData.Multiline = true;
            txtReceivedData.Name = "txtReceivedData";
            txtReceivedData.Size = new Size(528, 267);
            txtReceivedData.TabIndex = 1;
            // 
            // txtCommand
            // 
            txtCommand.Location = new Point(566, 171);
            txtCommand.Multiline = true;
            txtCommand.Name = "txtCommand";
            txtCommand.Size = new Size(158, 267);
            txtCommand.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtCommand);
            Controls.Add(txtReceivedData);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnStartServer;
        private TextBox txtPort;
        private TextBox txtReceivedData;
        private TextBox txtCommand;
        private Button btnStopServer;
    }
}
