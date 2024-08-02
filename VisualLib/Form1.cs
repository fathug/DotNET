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
                // ��ȡѡ�����ļ�·��
                string imagePath = openFileDialog.FileName;
                // ��ͼƬ���ص�PictureBox��
                pictureBox1.Image = Image.FromFile(imagePath);
                // ����SizeModeΪZoom��ʹͼƬ��������ӦPictureBox�Ĵ�С
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }

    private void ROICanvas_ROISelected(object sender, EventArgs e)
    {
        // ��ȡROI����
        Rectangle selectedROI = roiCanvas.SelectedROI;
        MessageBox.Show($"Selected ROI: X={selectedROI.X}, Y={selectedROI.Y}, Width={selectedROI.Width}, Height={selectedROI.Height}");
    }
}
