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
    public partial class VIP : Form
    {
        DBHelper dbh = new DBHelper();
        string text;
        public void ShowMessage()
        {
            MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //构造器
        SqlDataAdapter sda;
        //临时数据库
        DataSet ds;
        //检查是否选择会员
        public bool CheckVIPId()
        {
            if (this.textID.Text == string.Empty)
            {
                FMHelper.OpenOk("未选择任何会员");
            }
            else
            {
                return true;
            }
            return false;
        }
        //获取会员列表
        public void GetVIPList()
        {
            long a;
            try
            {
                dbh.DBOpen();
                string sql = "select * from VIPCard,CardClass where VIPCard.TypeID=CardClass.TypeID and zhuangtai=0";
                if (this.textSelect.Text.Trim() != string.Empty && long.TryParse(this.textSelect.Text.Trim(), out a))
                {
                    sql += " and VIPCard.Phone='" + this.textSelect.Text.Trim() + "'";
                }
                sda = new SqlDataAdapter(sql, dbh.Conn);
                ds = new DataSet();
                sda.Fill(ds, "VIPCard");
                this.VIPList.DataSource = ds.Tables["VIPCard"];
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
        //获取会员信息
        public void GetVIPInfo()
        {
            if (this.VIPList.Rows.Count == 0)
            {
                this.textID.Text = string.Empty;
                this.textName.Text = string.Empty;
                this.textSex.Text = string.Empty;
                this.textType.Text = string.Empty;
                this.textJiFen.Text = string.Empty;
                this.textTime.Text = string.Empty;
                this.textBeiZhu.Text = string.Empty;
                return;
            }
            try
            {
                dbh.DBOpen();
                string sql = "select * from VIPCard,CardClass where VIPCard.TypeID=CardClass.TypeID and Phone='" + this.VIPList.SelectedRows[0].Cells[0].Value + "'";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                this.textID.Text = reader["Phone"].ToString();
                this.textName.Text = reader["Name"].ToString();
                this.textSex.Text = reader["Sex"].ToString();
                this.textType.Text = reader["TypeName"].ToString();
                this.textJiFen.Text = reader["JIFen"].ToString();
                this.textTime.Text = reader["CardTime"].ToString();
                this.textBeiZhu.Text = reader["BeiZhu"].ToString();
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
        //修改会员信息
        public void ChangeVIPInfo()
        {
            try
            {
                dbh.DBOpen();
                string sql = "update VIPCard set Name='" + this.textName.Text.Trim() + "',Sex='" + this.textSex.Text.Trim() + "',BeiZhu='" + this.textBeiZhu.Text.Trim() + "' where Phone='" + this.textID.Text + "'";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                comm.ExecuteNonQuery();
                FMHelper.OpenOk("修改成功");
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
        //表单验证
        public bool CheckInput()
        {
            if (this.textName.Text.Trim() == string.Empty)
            {
                FMHelper.OpenOk("请输入姓名");
            }
            else if (this.textSex.Text.Trim() == string.Empty)
            {
                FMHelper.OpenOk("请输入性别");
            }
            else
            {
                return true;
            }
            return false;
        }
        //删除会员信息
        public void DeVIPInfo()
        {
            try
            {
                dbh.DBOpen();
                string sql = "update vipcard set zhuangtai=1 where phone='" + this.textID.Text + "'";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                comm.ExecuteNonQuery();
                FMHelper.OpenOk("注销成功");
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
        public VIP()
        {
            InitializeComponent();
        }
        //打开窗体
        private void Menu_Load(object sender, EventArgs e)
        {
            this.VIPList.RowTemplate.Height = 50;
            this.VIPList.AutoGenerateColumns = false;
            GetVIPList();
            GetVIPInfo();
        }
        //确认修改按钮
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckVIPId())
            {
                if (CheckInput())
                {
                    if (FMHelper.OpenYesNo("要保存修改吗"))
                    {
                        ChangeVIPInfo();
                    }
                }
            }
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
        //退出按钮
        private void button1_Click_1(object sender, EventArgs e)
        {
            FMHelper.AllClose();
        }
        //刷新按钮
        private void button2_Click(object sender, EventArgs e)
        {
            this.textSelect.Text = string.Empty;
            GetVIPList();
        }
        //会员列表
        private void VIPList_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            GetVIPInfo();
        }
        //添加会员按钮
        private void botAdd_Click(object sender, EventArgs e)
        {
            FMHelper.OpenVipAdd();
            GetVIPList();
        }
        //等级信息按钮
        private void botGift_Click(object sender, EventArgs e)
        {
            FMHelper.OpenVIPLv();
        }
        //注销会员按钮
        private void botDe_Click(object sender, EventArgs e)
        {
            if (CheckVIPId())
            {
                if (FMHelper.OpenYesNo("要注销会员吗"))
                {
                    DeVIPInfo();
                    GetVIPList();
                    GetVIPInfo();
                }
            }
        }
        //搜索框
        private void textSelect_TextChanged(object sender, EventArgs e)
        {
            GetVIPList();
        }
        //店内按钮
        private void button3_Click(object sender, EventArgs e)
        {
            FMHelper.OpenDeskMenu();
            this.Close();
        }
        //账单按钮
        private void button6_Click(object sender, EventArgs e)
        {
            FMHelper.OpenZhngDan();
            this.Close();
        }
        //消费查询按钮
        private void botLvUp_Click(object sender, EventArgs e)
        {
            if (CheckVIPId())
            {
                ZhangDan frm = new ZhangDan();
                frm.selectNeed = " and vipid=" + this.VIPList.SelectedRows[0].Cells[0].Value.ToString();
                frm.Show();
                this.Close();
            }
        }
        //关于
        private void button4_Click(object sender, EventArgs e)
        {
            this.botAbout.BackColor = Color.Black;
            this.botAbout.FlatAppearance.BorderColor = Color.Black;
            FMHelper.OpenAbout();
            this.botAbout.BackColor = Color.Transparent;
            this.botAbout.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
        }
        //菜品
        private void button4_Click_1(object sender, EventArgs e)
        {
            FMHelper.OpenFoodMenu();
            this.Close();
        }
    }
}