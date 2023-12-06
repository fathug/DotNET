using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
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

        private Rectangle selectionRectangle = new Rectangle(50, 50, 100, 100); // 初始化矩形
        private Point startPoint;
        private bool isResizing = false;
        private bool isMoving = false;
        private int resizingCorner = -1;    // 拖动手柄的编号


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;

            for (int i = 0; i < GetResizeHandles().Length; i++)
            {
                if (GetResizeHandles()[i].Contains(e.Location))
                {
                    isResizing = true;
                    resizingCorner = i;
                    break;
                }
                else if (selectionRectangle.Contains(e.Location))
                {
                    isMoving = true;
                    break;
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing)
            {
                // 调整大小
                int deltaX = e.X - startPoint.X;
                int deltaY = e.Y - startPoint.Y;

                switch (resizingCorner)
                {
                    case 0: //左上
                        if (selectionRectangle.Width > deltaX && selectionRectangle.X + deltaX >= 0)
                        {
                            selectionRectangle.X += deltaX;
                            selectionRectangle.Width -= deltaX;
                        }
                        if (selectionRectangle.Height - deltaY > 0 && selectionRectangle.Y + deltaY >= 0)
                        {
                            selectionRectangle.Y += deltaY;
                            selectionRectangle.Height -= deltaY;
                        } 
                        break;
                    case 1: //右上
                        {
                            if (selectionRectangle.Width > (-deltaX) && selectionRectangle.Right + deltaX <= pictureBox1.Width)
                            {
                                selectionRectangle.Width += deltaX;
                            }
                            if (selectionRectangle.Height - deltaY > 0 && selectionRectangle.Y + deltaY >= 0)
                            {
                                selectionRectangle.Y += deltaY;
                                selectionRectangle.Height -= deltaY;
                            }
                        }
                        break;
                    case 2: //右下
                        {
                            if (selectionRectangle.Width > (-deltaX) && selectionRectangle.Right + deltaX <= pictureBox1.Width)
                            {
                                selectionRectangle.Width += deltaX;
                            }
                            if (selectionRectangle.Height > (-deltaY) && selectionRectangle.Bottom + deltaY <= pictureBox1.Height)
                            {
                                selectionRectangle.Height += deltaY;
                            }
                        }
                        break;
                    case 3: //左下
                        {
                            if (selectionRectangle.Width > deltaX && selectionRectangle.X + deltaX >= 0)
                            {
                                selectionRectangle.X += deltaX;
                                selectionRectangle.Width -= deltaX;
                            }
                            if (selectionRectangle.Height > (-deltaY) && selectionRectangle.Bottom + deltaY <= pictureBox1.Height)
                            {
                                selectionRectangle.Height += deltaY;
                            }
                        }
                        break;

                }

                startPoint = e.Location;
                pictureBox1.Invalidate();
            }
            else
            {
                // 移动整个矩形
                //if (e.Button == MouseButtons.Left)
                if (isMoving)
                {
                    int deltaX = e.X - startPoint.X;
                    int deltaY = e.Y - startPoint.Y;
                    selectionRectangle.X += deltaX;
                    selectionRectangle.Y += deltaY;

                    startPoint = e.Location;
                    pictureBox1.Invalidate();
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isResizing = false;
            isMoving = false;
            //MessageBox.Show(selectionRectangle.ToString());
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawRectangle(pen, selectionRectangle);

                // 绘制调整大小的手柄
                foreach (var handle in GetResizeHandles())
                {
                    e.Graphics.FillRectangle(Brushes.White, handle);
                    e.Graphics.DrawRectangle(pen, handle);
                }
            }
        }

        private Rectangle[] GetResizeHandles()
        {
            int resizeHandleSize = 10;  // 手柄矩形大小
            Rectangle[] handles = new Rectangle[8];
            // 角点顺序为左上、右上、右下、左下
            handles[0] = new Rectangle(selectionRectangle.X - resizeHandleSize / 2, selectionRectangle.Y - resizeHandleSize / 2, resizeHandleSize, resizeHandleSize);
            handles[1] = new Rectangle(selectionRectangle.Right - resizeHandleSize / 2, selectionRectangle.Y - resizeHandleSize / 2, resizeHandleSize, resizeHandleSize);
            handles[2] = new Rectangle(selectionRectangle.Right - resizeHandleSize / 2, selectionRectangle.Bottom - resizeHandleSize / 2, resizeHandleSize, resizeHandleSize);
            handles[3] = new Rectangle(selectionRectangle.X - resizeHandleSize / 2, selectionRectangle.Bottom - resizeHandleSize / 2, resizeHandleSize, resizeHandleSize);

            // 其余手柄只起到显示作用
            handles[4] = new Rectangle(selectionRectangle.X + selectionRectangle.Width / 2 - resizeHandleSize / 2, selectionRectangle.Y - resizeHandleSize / 2, resizeHandleSize, resizeHandleSize);
            handles[5] = new Rectangle(selectionRectangle.Right - resizeHandleSize / 2, selectionRectangle.Y + selectionRectangle.Height / 2 - resizeHandleSize / 2, resizeHandleSize, resizeHandleSize);
            handles[6] = new Rectangle(selectionRectangle.X + selectionRectangle.Width / 2 - resizeHandleSize / 2, selectionRectangle.Bottom - resizeHandleSize / 2, resizeHandleSize, resizeHandleSize);
            handles[7] = new Rectangle(selectionRectangle.X - resizeHandleSize / 2, selectionRectangle.Y + selectionRectangle.Height / 2 - resizeHandleSize / 2, resizeHandleSize, resizeHandleSize);

            return handles;
        }

    }
}
