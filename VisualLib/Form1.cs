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

    private void ROICanvas_ROISelected(object sender, EventArgs e)
    {
        // 获取ROI参数
        Rectangle selectedROI = roiCanvas.SelectedROI;
        MessageBox.Show($"Selected ROI: X={selectedROI.X}, Y={selectedROI.Y}, Width={selectedROI.Width}, Height={selectedROI.Height}");
    }
}
