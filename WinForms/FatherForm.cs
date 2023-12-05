﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class FatherForm : Form
    {
        public FatherForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SonForm1 sonForm1 = new SonForm1();     //实例化窗口
            this.Hide();    //先隐藏父窗口
            sonForm1.ShowDialog();      //路径逻辑绑定的窗口
            //Debug.WriteLine("子窗口1显示完毕");
            this.Show();
        }
    }
}