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
                    // ��ȡѡ�����ļ�·��
                    string imagePath = openFileDialog.FileName;
                    // ��ͼƬ���ص�PictureBox��
                    roiPictureBox1.Image = Image.FromFile(imagePath);
                    // ����SizeModeΪZoom��ʹͼƬ��������ӦPictureBox�Ĵ�С
                    roiPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
    }
}
