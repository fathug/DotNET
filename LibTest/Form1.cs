namespace LibTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                    roiPictureBox1.Image = Image.FromFile(imagePath);
                    // 设置SizeMode为Zoom，使图片缩放以适应PictureBox的大小
                    roiPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
    }
}
