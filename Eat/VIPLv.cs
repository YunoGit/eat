using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Eat
{
    public partial class VIPLv : Form
    {
        DBHelper dbh = new DBHelper();
        string text;
        public void ShowMessage()
        {
            MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //获取信息
        public void GetInfo()
        {
            try
            {
                string sql = "select * from cardclass";
                SqlDataAdapter sda = new SqlDataAdapter(sql, dbh.Conn);
                DataSet ds = new DataSet();
                sda.Fill(ds, "info");
                this.dgvInfo.DataSource=ds.Tables["info"];
            }
            catch (Exception ex)
            {
                text = ex.Message;
                ShowMessage();
            }
        }
        public VIPLv()
        {
            InitializeComponent();
        }
        //窗体打开
        private void VIPLv_Load(object sender, EventArgs e)
        {
            this.dgvInfo.AutoGenerateColumns = false;
            this.dgvInfo.RowTemplate.Height = 40;
            GetInfo();
        }
        //确认按钮
        private void botLvUp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}