using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualLib;

public class ROICanvas : PictureBox
{
    private Point startPoint;
    private Point endPoint;
    private bool isDrawing = false;

    public Rectangle SelectedROI { get; private set; }

    public ROICanvas()
    {
        this.SizeMode = PictureBoxSizeMode.StretchImage; // 设置图片缩放方式
        this.MouseDown += ROICanvas_MouseDown;
        this.MouseMove += ROICanvas_MouseMove;
        this.MouseUp += ROICanvas_MouseUp;
    }

    private void ROICanvas_MouseDown(object sender, MouseEventArgs e)
    {
        startPoint = e.Location;
        isDrawing = true;
    }

    private void ROICanvas_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDrawing)
        {
            endPoint = e.Location;
            this.Invalidate(); // 重新绘制
        }
    }

    private void ROICanvas_MouseUp(object sender, MouseEventArgs e)
    {
        isDrawing = false;
        endPoint = e.Location;

        // 计算ROI矩形
        int x = Math.Min(startPoint.X, endPoint.X);
        int y = Math.Min(startPoint.Y, endPoint.Y);
        int width = Math.Abs(startPoint.X - endPoint.X);
        int height = Math.Abs(startPoint.Y - endPoint.Y);

        SelectedROI = new Rectangle(x, y, width, height);

        // 触发事件，通知ROI已选定
        OnROISelected(EventArgs.Empty);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // 绘制选择的ROI
        if (isDrawing)
        {
            using (Pen pen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawRectangle(pen, GetNormalizedRect());
            }
        }
    }

    private Rectangle GetNormalizedRect()
    {
        int x = Math.Min(startPoint.X, endPoint.X);
        int y = Math.Min(startPoint.Y, endPoint.Y);
        int width = Math.Abs(startPoint.X - endPoint.X);
        int height = Math.Abs(startPoint.Y - endPoint.Y);

        return new Rectangle(x, y, width, height);
    }

    // 事件声明
    public event EventHandler ROISelected;

    // 事件触发方法
    protected virtual void OnROISelected(EventArgs e)
    {
        ROISelected?.Invoke(this, e);
    }
}
