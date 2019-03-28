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
    public partial class FoodMenu : Form
    {
        DBHelper dbh = new DBHelper();
        string text;
        public void ShowMessage()
        {
            MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //食物编号
        string foodId;
        //营业验证
        public bool CheckUse()
        {
            try
            {
                dbh.DBOpen();
                string sql = "select count(*) from desk where zhuangtai=1";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                if ((int)comm.ExecuteScalar() > 0)
                {
                    FMHelper.OpenOk("有未处理账单，无法操作");
                    return false;
                }
                else
                {
                    return true;
                }
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
        public bool CheckInput()
        {
            string[] a = new string[3];
            a = this.txtFoodPrice.Text.Split('.');
            double price;
            if (this.txtFoodName.Text.Trim() == string.Empty)
            {
                FMHelper.OpenOk("请输入菜名");
            }
            else if (this.txtFoodDanWei.Text.Trim() == string.Empty)
            {
                FMHelper.OpenOk("请输入单位");
            }
            else if (this.txtFoodPrice.Text.Trim() == string.Empty)
            {
                FMHelper.OpenOk("请输入单价");
            }
            else if (!double.TryParse(this.txtFoodPrice.Text.Trim(), out price) || (a.Length > 1 && a[1].Length > 1))
            {
                FMHelper.OpenOk("请输入正确的价格");
            }
            else
            {
                return true;
            }
            return false;
        }
        //修改信息
        public void ChangeInfo()
        {
            try
            {
                dbh.DBOpen();
                string sql = "select id from food where danwei='" + this.txtFoodDanWei.Text.Trim() + "' and name='" + this.txtFoodName.Text.Trim() + "' and moeny='" + this.txtFoodPrice.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                if (comm.ExecuteScalar() == null)
                {
                    sql = "insert food select '" + this.txtFoodDanWei.Text.Trim() + "','" + this.txtFoodName.Text.Trim() + "','" + this.txtFoodPrice.Text.Trim() + "',0 update food set zhuangtai=1 where id=" + foodId;
                    comm = new SqlCommand(sql, dbh.Conn);
                    comm.ExecuteNonQuery();
                }
                else
                {
                    string id = comm.ExecuteScalar().ToString();
                    sql = "update food set zhuangtai=1 where id=" + foodId + " update food set zhuangtai=0 where id=" + id;
                    comm = new SqlCommand(sql, dbh.Conn);
                    comm.ExecuteNonQuery();
                }
                FMHelper.OpenOk("信息修改成功");
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
        //删除信息
        public void DeInfo()
        {
            try
            {
                dbh.DBOpen();
                string sql = "update food set zhuangtai=1 where id=" + this.foodId;
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                comm.ExecuteNonQuery();
                FMHelper.OpenOk("菜品删除成功");
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
        //获取菜单
        public void GetMenu(string foodClass)
        {
            try
            {
                dbh.DBOpen();
                DataSet ds = new DataSet();
                string sql = "select * from food where zhuangtai=0" + foodClass + " order by danwei";
                SqlDataAdapter sda = new SqlDataAdapter(sql, dbh.Conn);
                sda.Fill(ds, "list");
                this.dgvMenu.DataSource = ds.Tables["list"];
                sql = "select count(*) from food where zhuangtai=0";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                this.txtAllNum.Text = comm.ExecuteScalar().ToString();
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
        //菜品信息
        public void FoodInfo()
        {
            try
            {
                this.txtFoodName.Text = this.dgvMenu.SelectedRows[0].Cells[1].Value.ToString();
                this.txtFoodDanWei.Text = this.dgvMenu.SelectedRows[0].Cells[2].Value.ToString();
                this.txtFoodPrice.Text = this.dgvMenu.SelectedRows[0].Cells[3].Value.ToString();
                foodId = this.dgvMenu.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                text = ex.Message;
                ShowMessage();
            }
        }
        public FoodMenu()
        {
            InitializeComponent();
        }
        //窗体打开
        private void FoodMenu_Load(object sender, EventArgs e)
        {
            this.dgvMenu.RowTemplate.Height = 50;
            this.dgvMenu.AutoGenerateColumns = false;
            GetMenu(string.Empty);
            FoodInfo();
        }
        //单击菜单
        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FoodInfo();
        }
        //家常菜
        private void button8_Click(object sender, EventArgs e)
        {
            GetMenu(" and danwei='份'");
        }
        //瓦罐汤
        private void button9_Click(object sender, EventArgs e)
        {
            GetMenu(" and danwei='罐'");
        }
        //饮料
        private void button10_Click(object sender, EventArgs e)
        {
            GetMenu(" and danwei='瓶'");
        }
        //小吃
        private void button11_Click(object sender, EventArgs e)
        {
            GetMenu(" and danwei not in ('份','罐','瓶')");
        }
        //刷新按钮
        private void button2_Click(object sender, EventArgs e)
        {
            GetMenu(string.Empty);
            this.txtSelect.Text = string.Empty;
        }
        //关闭按钮
        private void button1_Click(object sender, EventArgs e)
        {
            FMHelper.AllClose();
        }
        //保存修改
        private void button13_Click(object sender, EventArgs e)
        {
            if (CheckUse())
            {
                if (CheckInput())
                {
                    if (FMHelper.OpenYesNo("要保存修改吗"))
                    {
                        ChangeInfo();
                        GetMenu(string.Empty);
                        FoodInfo();
                    }
                }
            }
        }
        //删除菜品
        private void button12_Click(object sender, EventArgs e)
        {
            if (CheckUse())
            {
                if (FMHelper.OpenYesNo("要删除该菜品吗"))
                {
                    DeInfo();
                    GetMenu(string.Empty);
                    FoodInfo();
                }
            }
        }
        //搜索框
        private void txtSelect_TextChanged(object sender, EventArgs e)
        {
            GetMenu(" and name like '%" + this.txtSelect.Text.Trim() + "%'");
        }
        //店内
        private void button3_Click(object sender, EventArgs e)
        {
            FMHelper.OpenDeskMenu();
            this.Close();
        }
        //会员
        private void button5_Click(object sender, EventArgs e)
        {
            FMHelper.OpenVip();
            this.Close();
        }
        //账单
        private void button6_Click(object sender, EventArgs e)
        {
            FMHelper.OpenZhngDan();
            this.Close();
        }
        //关于
        private void botAbout_Click(object sender, EventArgs e)
        {
            this.botAbout.BackColor = Color.Black;
            this.botAbout.FlatAppearance.BorderColor = Color.Black;
            FMHelper.OpenAbout();
            this.botAbout.BackColor = Color.Transparent;
            this.botAbout.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
        }
        //添加菜品
        private void botAdd_Click(object sender, EventArgs e)
        {
            FMHelper.OpenFoodMenuAdd();
            GetMenu(string.Empty);
            FoodInfo();
        }
    }
}