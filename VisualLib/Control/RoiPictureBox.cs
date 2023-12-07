using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace VisualLib.Control;
/// <summary>
/// 包含矩形ROI的PictureBox
/// </summary>
public class RoiPictureBox : PictureBox
{
    private Rectangle selectionRectangle = new Rectangle(50, 50, 100, 100); // 初始化矩形
    private Point startPoint;
    private bool isResizing = false;
    private bool isMoving = false;
    private int resizingCorner = -1;    // 拖动手柄的编号

    public RoiPictureBox()
    {
        MouseDown += RoiPictureBox_MouseDown;
        MouseMove += RoiPictureBox_MouseMove;
        MouseUp += RoiPictureBox_MouseUp;
        Paint += RoiPictureBox_Paint;
    }

    private void RoiPictureBox_MouseDown(object sender, MouseEventArgs e)
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

    private void RoiPictureBox_MouseMove(object sender, MouseEventArgs e)
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
                        if (selectionRectangle.Width > -deltaX && selectionRectangle.Right + deltaX <= Width)
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
                        if (selectionRectangle.Width > -deltaX && selectionRectangle.Right + deltaX <= Width)
                        {
                            selectionRectangle.Width += deltaX;
                        }
                        if (selectionRectangle.Height > -deltaY && selectionRectangle.Bottom + deltaY <= Height)
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
                        if (selectionRectangle.Height > -deltaY && selectionRectangle.Bottom + deltaY <= Height)
                        {
                            selectionRectangle.Height += deltaY;
                        }
                    }
                    break;
            }

            startPoint = e.Location;
            Invalidate();
        }
        else if (isMoving)
        {
            // 移动整个矩形
            int deltaX = e.X - startPoint.X;
            int deltaY = e.Y - startPoint.Y;
            selectionRectangle.X += deltaX;
            selectionRectangle.Y += deltaY;

            startPoint = e.Location;
            Invalidate();
        }
    }

    private void RoiPictureBox_MouseUp(object sender, MouseEventArgs e)
    {
        isResizing = false;
        isMoving = false;
        // MessageBox.Show(selectionRectangle.ToString());
    }

    private void RoiPictureBox_Paint(object sender, PaintEventArgs e)
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
        const int resizeHandleSize = 10;  // 手柄矩形大小
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
