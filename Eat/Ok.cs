using System;
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
    public partial class Ok : Form
    {
        //提示信息
        public string text;
        public Ok()
        {
            InitializeComponent();
        }
        //打开窗体
        private void YesNo_Load(object sender, EventArgs e)
        {
            this.txtMessage.Text = text;
        }
        //确认按钮
        private void botYes_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}