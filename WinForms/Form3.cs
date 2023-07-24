using System;
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // 创建并配置打开文件对话框
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.gif;*.bmp|所有文件|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 从文件中加载图片
                        Image image = Image.FromFile(openFileDialog.FileName);

                        // 调整PictureBox的大小以适应图片
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                        // 在PictureBox中显示图片
                        pictureBox1.Image = image;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"无法加载图片：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

