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
    public partial class VIPAdd : Form
    {
        DBHelper dbh = new DBHelper();
        string text;
        public void ShowMessage()
        {
            MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //检查手机号
        public bool CheckPhone()
        {
            try
            {
                dbh.DBOpen();
                string sql = "select count(*) from vipcard where phone='" + this.textPhone.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                if (Convert.ToInt32(comm.ExecuteScalar()) > 0)
                {
                    FMHelper.OpenOk("该手机号已注册过会员");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                text = ex.Message;
                ShowMessage();
                return false;
            }
            finally
            {
                dbh.DBClose();
            }
        }
        //表单验证
        public bool CheckInout()
        {
            long phone;
            if (this.textName.Text.Trim() == string.Empty)
            {
                FMHelper.OpenOk("请输入姓名");
            }
            else if (this.textPhone.Text.Trim() == string.Empty)
            {
                FMHelper.OpenOk("请输入电话");
            }
            else if (this.textPhone.Text.Trim().Length < 11 || !long.TryParse(this.textPhone.Text.Trim(), out phone))
            {
                FMHelper.OpenOk("请输入正确的手机号");
            }
            else
            {
                return true;
            }
            return false;
        }
        //添加会员
        public void VIPCardAdd()
        {
            try
            {
                dbh.DBOpen();
                string sql = "insert vipcard select '" + this.textPhone.Text.Trim() + "','" + this.textName.Text.Trim() + "','" + this.textSex.Text + "',1,0,getdate(),'" + this.textBeiZhu.Text.Trim() + "',0";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                text = ex.Message;
                ShowMessage();
            }
            finally
            {
                dbh.DBClose();
            }
        }
        public VIPAdd()
        {
            InitializeComponent();
        }
        //性别文本框
        private void textSex_Click(object sender, EventArgs e)
        {
            if (this.textSex.Text.Equals("男"))
            {
                this.textSex.Text = "女";
            }
            else
            {
                this.textSex.Text = "男";
            }
        }
        //添加按钮
        private void botYes_Click(object sender, EventArgs e)
        {
            if (CheckInout())
            {
                if (CheckPhone())
                {
                    VIPCardAdd();
                    VIPAddOk frm = new VIPAddOk();
                    frm.id = this.textPhone.Text;
                    frm.ShowDialog();
                    this.Close();
                }
            }
        }
        //取消按钮
        private void botLvUp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}