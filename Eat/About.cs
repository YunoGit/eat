﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eat
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }
        //关闭按钮
        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}