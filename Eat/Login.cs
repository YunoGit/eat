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
    public partial class Login : Form
    {
        DBHelper dbh = new DBHelper();
        string text;
        public void ShowMessage()
        {
            MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //表单验证
        public bool CheckInput()
        {
            if (this.textId.Text.Trim() == string.Empty)
            {
                FMHelper.OpenOk("请输入用户名");
            }
            else if (this.textPwd.Text.Trim() == string.Empty)
            {
                FMHelper.OpenOk("请输入密码");
            }
            else
            {
                return true;
            }
            return false;
        }
        //管理员登陆
        public void AdminLogin()
        {
            try
            {
                dbh.DBOpen();
                string sql = "select count(*) from [user] where id='"+this.textId.Text.Trim()+"' and pwd='"+this.textPwd.Text.Trim()+"'";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                if ((int)comm.ExecuteScalar() == 1)
                {
                    FMHelper.OpenDeskMenu();
                    this.Hide();
                }
                else
                {
                    FMHelper.OpenOk("账号或密码错误");
                }
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
        //图片序列
        int i;
        public Login()
        {
            InitializeComponent();
        }
        //关闭按钮
        private void label5_Click(object sender, EventArgs e)
        {
            FMHelper.AllClose();
        }
        //登陆按钮
        private void botLogin_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                AdminLogin();
            }
        }
        //登陆文本
        private void label3_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                AdminLogin();
            }
        }
        //计数器
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i > 4)
            {
                i = 0;
            }
            if (i==0)
            {
                this.pbLogin.Image = global::Eat.Properties.Resources.lhy018;
            }
            else if (i==1)
            {
                this.pbLogin.Image = global::Eat.Properties.Resources.lhy019;
            }
            else if (i==2)
            {
                this.pbLogin.Image = global::Eat.Properties.Resources.lhy020;
            }
            else if (i==3)
            {
                this.pbLogin.Image = global::Eat.Properties.Resources.lhy021;
            }
            else if (i==4)
            {
                this.pbLogin.Image = global::Eat.Properties.Resources.lhy003;
            }
            i++;
        }
    }
}