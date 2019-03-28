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
    public partial class PayOk : Form
    {
        //账单号
        public string zhangDanId;
        //消费
        public string money;
        //会员卡号
        public string vip = "无";
        //积分
        public string jiFen;
        public PayOk()
        {
            InitializeComponent();
        }
        //打开窗体
        private void PayShow_Load(object sender, EventArgs e)
        {
            this.txtId.Text = zhangDanId;
            this.txtMoney.Text = money;
            this.txtVip.Text = vip;
            this.txtJiFen.Text = jiFen;
        }
        //确认按钮
        private void botLvUp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}