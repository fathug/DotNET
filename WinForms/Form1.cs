namespace WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // ��ʼ�����������Ϣ
            InitializeComponent();
            //һ�㽫�����Ĵ���Ӧ��ж��form1֮�⣬�ⲿ���������г�ʼ��
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = ("ʹ�ô��ڰ��¼��Ա�������޸�");
        }

        //���ʹ�õ��ԵĽ��̹������Դ��ڽ��йرյ�ʱ��closing��closed����Ͳ��ᴥ���¼�����������ִ��
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //���X�رյ�ʱ������ִ���ⲿ��
            //����ж����߳���Ҫ���٣���������������closed�У����ܾ��޷����٣�
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //��closing֮��ִ��
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int w = this.Width;
            int h = this.Height;
            this.Text = string.Format("��ǰ���ڴ�С��{0}*{1}", w, h);
        }
    }
}