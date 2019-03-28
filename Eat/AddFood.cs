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
    public partial class AddFood : Form
    {
        DBHelper dbh = new DBHelper();
        string text;
        public void ShowMessage()
        {
            MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //操作方式
        int doType;
        //食物编号
        string foodId;
        //总金额
        double allMoney;
        //账单号
        public string ZhangDanId;
        //获取菜单
        public void GetMenu(string foodClass)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "select * from food where zhuangtai=0" + foodClass + " order by danwei";
                SqlDataAdapter sda = new SqlDataAdapter(sql, dbh.Conn);
                sda.Fill(ds, "list");
                this.dgvMenu.DataSource = ds.Tables["list"];
            }
            catch (Exception ex)
            {
                text = ex.Message;
                ShowMessage();
            }
        }
        //初始化信息
        public void StartInfo()
        {
            try
            {
                dbh.DBOpen();
                //获取点菜单
                string sql = "select * from buyfood,food where buyfood.foodid=food.id and zhangdanid='" + ZhangDanId + "'";
                SqlDataAdapter sda = new SqlDataAdapter(sql, dbh.Conn);
                DataSet ds = new DataSet();
                sda.Fill(ds, "buyfood");
                this.FoodList.DataSource = ds.Tables["buyfood"];
                //计算总金额
                sql = "select sum(buyfood.number*food.Moeny) from buyfood,food where buyfood.FoodID=food.id and zhangdanid='" + ZhangDanId + "'";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                double.TryParse(comm.ExecuteScalar().ToString(), out allMoney);
                this.txtMoney.Text = allMoney.ToString();
                //更新消费
                sql = "update zhangdan set money='" + allMoney + "' where id='" + ZhangDanId + "'";
                comm = new SqlCommand(sql, dbh.Conn);
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
        //点菜信息
        public void BuyFoodInfo()
        {
            try
            {
                this.txtFoodName.Text = this.dgvMenu.SelectedRows[0].Cells[1].Value.ToString();
                this.txtFoodDanWei.Text = this.dgvMenu.SelectedRows[0].Cells[2].Value.ToString();
                this.txtFoodPrice.Text = this.dgvMenu.SelectedRows[0].Cells[3].Value.ToString();
                this.labNum.Text = "请输入点菜份数";
                foodId = this.dgvMenu.SelectedRows[0].Cells[0].Value.ToString();
                doType = 0;
            }
            catch (Exception ex)
            {
                text = ex.Message;
                ShowMessage();
            }
        }
        //退菜信息
        public void DeFoodInfo()
        {
            try
            {
                this.txtFoodName.Text = this.FoodList.SelectedRows[0].Cells[1].Value.ToString();
                this.txtFoodDanWei.Text = this.FoodList.SelectedRows[0].Cells[3].Value.ToString();
                this.txtFoodPrice.Text = this.FoodList.SelectedRows[0].Cells[4].Value.ToString();
                this.labNum.Text = "请输入退菜份数";
                foodId = this.FoodList.SelectedRows[0].Cells[0].Value.ToString();
                doType = 1;
            }
            catch (Exception ex)
            {
                text = ex.Message;
                ShowMessage();
            }
        }
        //点菜
        public void BuyFood(int foodNum)
        {
            try
            {
                dbh.DBOpen();
                //获取点菜数
                string sql = "select count(*) from buyfood where zhangdanid='" + ZhangDanId + "' and foodid='" + foodId + "'";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                if ((int)comm.ExecuteScalar() == 0)
                {
                    //新建菜品
                    sql = "insert buyfood select '" + ZhangDanId + "','" + foodId + "'," + foodNum;
                }
                else
                {
                    //点菜数+1
                    sql = "update buyfood set number=number+" + foodNum + " where zhangdanid='" + ZhangDanId + "' and foodid='" + foodId + "'";
                }
                comm = new SqlCommand(sql, dbh.Conn);
                comm.ExecuteNonQuery();
                StartInfo();
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
        //退菜
        public void DeFood(int foodNum)
        {
            try
            {
                dbh.DBOpen();
                //获取点菜数
                string sql = "select sum(number) from buyfood where zhangdanid='" + ZhangDanId + "' and foodid='" + foodId + "'";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                if (comm.ExecuteScalar() == DBNull.Value)
                {
                    return;
                }
                if ((int)comm.ExecuteScalar() <= foodNum)
                {
                    //删除该菜品
                    sql = "delete buyfood where zhangdanid='" + ZhangDanId + "' and foodid='" + foodId + "'";
                }
                else
                {
                    //该菜品数量减少
                    sql = "update buyfood set number=number-" + foodNum + " where zhangdanid='" + ZhangDanId + "' and foodid='" + foodId + "'";
                }
                comm = new SqlCommand(sql, dbh.Conn);
                comm.ExecuteNonQuery();
                StartInfo();
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
        //取消账单
        public void DeZhnagDan()
        {
            try
            {
                dbh.DBOpen();
                //初始化桌台，删除账单
                string sql = "update desk set zhuangtai=0,dingdanid=null where dingdanid='" + ZhangDanId + "' update zhangdan set zhuangtai=3 where id=" + ZhangDanId;
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
        //数量验证
        public bool CheckNum()
        {
            int a;
            if (this.txtBuyNum.Text.Trim() == string.Empty)
            {
                FMHelper.OpenOk("请输入数量");
            }
            else if (!int.TryParse(this.txtBuyNum.Text.Trim(), out a) || a < 1)
            {
                FMHelper.OpenOk("请输入正确的数量");
            }
            else
            {
                return true;
            }
            return false;
        }
        //结账验证
        public bool JZCheck()
        {
            if (this.FoodList.Rows.Count == 0)
            {
                FMHelper.OpenOk("未点菜，无法进行结账操作");
            }
            else
            {
                return true;
            }
            return false;
        }
        public AddFood()
        {
            InitializeComponent();
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
        //关闭按钮
        private void button1_Click(object sender, EventArgs e)
        {
            FMHelper.AllClose();
        }
        //结账按钮
        private void botAdd_Click(object sender, EventArgs e)
        {
            if (JZCheck())
            {
                Pay frm = new Pay();
                frm.ZhangDanId = ZhangDanId;
                frm.Show();
                this.Close();
            }
        }
        //窗体打开
        private void AddFood_Load(object sender, EventArgs e)
        {
            this.dgvMenu.RowTemplate.Height = 50;
            this.dgvMenu.AutoGenerateColumns = false;
            this.FoodList.RowTemplate.Height = 50;
            this.FoodList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.FoodList.AutoGenerateColumns = false;
            GetMenu(string.Empty);
            StartInfo();
            BuyFoodInfo();
        }
        //取消订单按钮
        private void button7_Click(object sender, EventArgs e)
        {
            if (FMHelper.OpenYesNo("要取消订单吗"))
            {
                DeZhnagDan();
                FMHelper.OpenOk("取消订单成功");
                FMHelper.OpenDeskMenu();
                this.Close();
            }
        }
        //账单按钮
        private void button6_Click(object sender, EventArgs e)
        {
            FMHelper.OpenZhngDan();
            this.Close();
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
            StartInfo();
            this.txtSelect.Text = string.Empty;
            this.txtBuyNum.Text = string.Empty;
        }
        //搜索框
        private void textSelect_TextChanged(object sender, EventArgs e)
        {
            GetMenu(" and name like '%" + this.txtSelect.Text.Trim() + "%'");
        }
        //单击菜单
        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BuyFoodInfo();
        }
        //单击清单
        private void FoodList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DeFoodInfo();
        }
        //确认按钮
        private void button12_Click(object sender, EventArgs e)
        {
            if (CheckNum())
            {
                if (doType == 0)
                {
                    BuyFood(Convert.ToInt32(this.txtBuyNum.Text.Trim()));
                }
                else
                {
                    DeFood(Convert.ToInt32(this.txtBuyNum.Text.Trim()));
                }
            }
        }
        //关于按钮
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