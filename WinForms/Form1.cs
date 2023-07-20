namespace WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // 初始化窗体基本信息
            InitializeComponent();
            //一般将其他的窗体应用卸载form1之外，这部分用来进行初始化
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = ("使用窗口绑定事件对标题进行修改");
        }

        //如果使用电脑的进程管理器对窗口进行关闭的时候，closing、closed程序就不会触发事件，不会往下执行
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //点击X关闭的时候立即执行这部分
            //如果有对象、线程需要销毁，放在这里（如果放在closed中，可能就无法销毁）
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //在closing之后执行
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int w = this.Width;
            int h = this.Height;
            this.Text = string.Format("当前窗口大小：{0}*{1}", w, h);
        }
    }
}