using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisualLib;

public partial class Form1 : Form
{
    private ROICanvas roiCanvas;

    public Form1()
    {
        InitializeComponent();

        roiCanvas = new ROICanvas();

        roiCanvas.Size = new Size(600, 500);

        roiCanvas.ROISelected += ROICanvas_ROISelected;

        Controls.Add(roiCanvas);
    }

    private void button1_Click_1(object sender, EventArgs e)
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

    private void ROICanvas_ROISelected(object sender, EventArgs e)
    {
        // 获取ROI参数
        Rectangle selectedROI = roiCanvas.SelectedROI;
        MessageBox.Show($"Selected ROI: X={selectedROI.X}, Y={selectedROI.Y}, Width={selectedROI.Width}, Height={selectedROI.Height}");
    }
}
