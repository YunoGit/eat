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
    public partial class YesNo : Form
    {
        public string text;
        public YesNo()
        {
            InitializeComponent();
        }
        //确认按钮
        private void botYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
        //取消按钮
        private void botLvUp_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
        //窗体打开
        private void YesNo_Load(object sender, EventArgs e)
        {
            this.txtMessage.Text = text;
        }
    }
}