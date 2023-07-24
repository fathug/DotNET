using System;
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WinForms
{
    public partial class Form3 : Form
    {
        private Image originalImage;

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
                        originalImage = Image.FromFile(openFileDialog.FileName);

                        // 调整PictureBox的大小以适应图片
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                        // 在PictureBox中显示图片
                        pictureBox1.Image = originalImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"无法加载图片：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGrayScale_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("请先加载一张图片。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 创建一个新的Bitmap对象用于存储灰度图像
                Bitmap grayImage = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);

                // 通过Graphics对象绘制灰度图像
                using (Graphics graphics = Graphics.FromImage(grayImage))
                {
                    ColorMatrix colorMatrix = new ColorMatrix(
                        new float[][]
                        {
                            new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                            new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                            new float[] {0.114f, 0.114f, 0.114f, 0, 0},
                            new float[] {0, 0, 0, 1, 0},
                            new float[] {0, 0, 0, 0, 1}
                        });

                    ImageAttributes attributes = new ImageAttributes();
                    attributes.SetColorMatrix(colorMatrix);

                    graphics.DrawImage(pictureBox1.Image,
                        new Rectangle(0, 0, grayImage.Width, grayImage.Height),
                        0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height,
                        GraphicsUnit.Pixel, attributes);
                }

                // 在PictureBox中显示灰度图像
                pictureBox1.Image = grayImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"灰度处理出现错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = ("图像显示窗体");
        }
    }
}

