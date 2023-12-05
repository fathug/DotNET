using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualLib
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            pictureBox1.Paint += pictureBox1_Paint;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取选定的文件路径
                    string imagePath = openFileDialog.FileName;

                    // 将图片加载到PictureBox中
                    pictureBox1.Image = Image.FromFile(imagePath);

                    // 设置SizeMode为Zoom，使图片缩放以适应PictureBox的大小
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private bool isMouseDown = false;
        private Point startPoint;
        private Rectangle selectionRectangle;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                startPoint = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                int width = e.X - startPoint.X;
                int height = e.Y - startPoint.Y;
                selectionRectangle = new Rectangle(startPoint.X, startPoint.Y, width, height);
                pictureBox1.Invalidate(); // 使PictureBox重新绘制以显示矩形
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
            MessageBox.Show(selectionRectangle.ToString());
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (isMouseDown)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, selectionRectangle);
                }
            }
        }

    }
}
