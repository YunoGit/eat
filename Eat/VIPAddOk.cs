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
    public partial class VIPAddOk : Form
    {
        //会员编号
        public string id;
        public VIPAddOk()
        {
            InitializeComponent();
        }
        //打开窗体
        private void VIPAddOk_Load(object sender, EventArgs e)
        {
            this.textId.Text = id;
        }
        //关闭按钮
        private void botLvUp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}