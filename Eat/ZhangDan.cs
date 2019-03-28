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
    public partial class ZhangDan : Form
    {
        DBHelper dbh = new DBHelper();
        string text;
        public void ShowMessage()
        {
            MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //查单条件
        public string selectNeed;
        //构造器
        SqlDataAdapter sda;
        //临时数据库
        DataSet ds;
        //获取账单列表
        public void GetZDList(string addSql)
        {
            try
            {
                string sql = "select zhangdan.id,desk.name,money,truemoney,zhuangtainame,vipid from zhangdan,desk,zhangdanzt where zhangdan.deskid=desk.id and zhangdan.zhuangtai=zhangdanzt.zhuangtaiid" + addSql;
                sda = new SqlDataAdapter(sql, dbh.Conn);
                ds = new DataSet();
                sda.Fill(ds, "zhangdan");
                this.ZDList.DataSource = ds.Tables["zhangdan"];
            }
            catch (Exception ex)
            {
                text = ex.Message;
                ShowMessage();
            }
        }
        //获取订单全部信息
        public void GetInfo()
        {
            this.txtName.Text = "无";
            this.txtPhone.Text = "无";
            this.txtTime.Text = "无";
            this.FoodList.DataSource = null;
            this.txtNum.Text = "×0";
            this.txtPrice.Text = "￥0";
            this.txtYouHui.Text = "无";
            this.txtZheKou.Text = "无";
            if (this.ZDList.RowCount > 0)
            {
                GetFoodList();
                GetFoodNum();
                GetZDInfo();
                GetVIPInfo();
            }
        }
        //获取点菜单详细信息
        public void GetFoodList()
        {
            try
            {
                dbh.DBOpen();
                string sql = "select * from buyfood,food where buyfood.foodid=food.id and zhangdanid='" + this.ZDList.SelectedRows[0].Cells[0].Value + "'";
                sda = new SqlDataAdapter(sql, dbh.Conn);
                ds = new DataSet();
                sda.Fill(ds, "food");
                this.FoodList.DataSource = ds.Tables["food"];
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
        //合计
        public void GetFoodNum()
        {
            try
            {
                dbh.DBOpen();
                string sql = "select sum(number),sum(moeny*Number) from buyfood,food where buyfood.foodid=food.id and zhangdanid='" + this.ZDList.SelectedRows[0].Cells[0].Value + "'";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                if (reader[0] != DBNull.Value)
                {
                    this.txtNum.Text = "×" + reader[0].ToString();
                    this.txtPrice.Text = "￥" + reader[1].ToString();
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
        //获取账单信息
        public void GetZDInfo()
        {
            try
            {
                dbh.DBOpen();
                string sql = "select * from zhangdan where id='" + this.ZDList.SelectedRows[0].Cells[0].Value + "'";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                string youhui = reader["youhui"].ToString();
                string zhekou = reader["zhekou"].ToString();
                this.txtTime.Text = reader["jiezhangtime"].ToString();
                if (!youhui.Equals("0"))
                {
                    this.txtYouHui.Text = youhui;
                }
                if (!zhekou.Equals("0"))
                {
                    this.txtZheKou.Text = zhekou;
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
        //获取会员信息
        public void GetVIPInfo()
        {
            try
            {
                dbh.DBOpen();
                string sql = "select * from vipcard where Phone='" + this.ZDList.SelectedRows[0].Cells[5].Value + "'";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    this.txtName.Text = reader["name"].ToString();
                    this.txtPhone.Text = reader["phone"].ToString();
                }
                else
                {
                    this.txtName.Text = "无";
                    this.txtPhone.Text = "无";
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
        //获取月消费总额
        public void GetAllMoney(string addSql)
        {
            try
            {
                dbh.DBOpen();
                if (addSql == null || addSql == string.Empty)
                {
                    this.labAllMoney.Text = "本月营业总额";
                }
                string sql = "select sum(truemoney) from zhangdan where datepart(yy,jiezhangtime)=datepart(yy,getdate()) and datepart(MM,jiezhangtime)=datepart(MM,getdate())" + addSql;
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                this.txtAllMoney.Text = comm.ExecuteScalar().ToString();
                if (this.txtAllMoney.Text == string.Empty)
                {
                    this.txtAllMoney.Text = "0";
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
        //日期验证
        public bool CheckDate()
        {
            if (this.time1.Value > this.time2.Value)
            {
                FMHelper.OpenOk("请选择正确的日期");
            }
            else
            {
                return true;
            }
            return false;
        }
        public ZhangDan()
        {
            InitializeComponent();
        }
        //窗体打开
        private void ZangDan_Load(object sender, EventArgs e)
        {
            this.ZDList.AutoGenerateColumns = false;
            this.ZDList.RowTemplate.Height = 50;
            this.FoodList.AutoGenerateColumns = false;
            this.FoodList.RowTemplate.Height = 40;
            GetZDList(selectNeed);
            GetInfo();
            GetAllMoney(selectNeed);
        }
        //关闭按钮
        private void button1_Click(object sender, EventArgs e)
        {
            FMHelper.AllClose();
        }
        //点击账单列表
        private void ZDList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetInfo();
        }
        //查询按钮
        private void button7_Click(object sender, EventArgs e)
        {
            string sql;
            if (this.txtSeZD.Text.Trim() != string.Empty)
            {
                sql = " and zhangdan.id='" + this.txtSeZD.Text.Trim() + "'";
            }
            else
            {
                if (CheckDate())
                {
                    if (string.Format("{0:yyyy-MM-dd}", time1.Value).Equals(string.Format("{0:yyyy-MM-dd}", time2.Value)))
                    {
                        sql = " and jiezhangtime between '" + string.Format("{0:yyyy-MM-dd} 00:00:00", time1.Value) + "' and '" + string.Format("{0:yyyy-MM-dd } 23:59:59", time1.Value) + "'";
                    }
                    else
                    {
                        sql = " and jiezhangtime between '" + string.Format("{0:yyyy-MM-dd} 00:00:00", time1.Value) + "' and '" + string.Format("{0:yyyy-MM-dd} 23:59:59", time2.Value) + "'";
                    }
                }
                else
                {
                    return;
                }
            }
            GetZDList(sql);
            GetInfo();
        }
        //显示全部按钮
        private void button8_Click(object sender, EventArgs e)
        {
            GetZDList(string.Empty);
            GetInfo();
            GetAllMoney(string.Empty);
        }
        //店内按钮
        private void button3_Click(object sender, EventArgs e)
        {
            FMHelper.OpenDeskMenu();
            this.Close();
        }
        //会员按钮
        private void button5_Click(object sender, EventArgs e)
        {
            FMHelper.OpenVip();
            this.Close();
        }
        //刷新按钮
        private void button2_Click(object sender, EventArgs e)
        {
            this.txtSeZD.Text = string.Empty;
            GetZDList(string.Empty);
            GetInfo();
            GetAllMoney(string.Empty);
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