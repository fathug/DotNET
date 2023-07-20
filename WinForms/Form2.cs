using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //点击按钮的操作
            //button1.BackColor = Color.Yellow; button1.ForeColor = Color.Blue;
            string str_textbox = textBox1.Text; //获取文本框内的文本
            MessageBox.Show(str_textbox);   //弹窗显示
        }
    }
}
