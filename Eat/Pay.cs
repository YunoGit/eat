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
    public partial class Pay : Form
    {
        DBHelper dbh = new DBHelper();
        string text;
        public void ShowMessage()
        {
            MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //账单编号
        public string ZhangDanId;
        //总金额
        double allMoney;
        //实际消费
        double realMoney;
        //找零
        double zhaoLin;
        //会员折扣
        double zheKou;
        //优惠券
        double youHui;
        //积分
        int jiFen;
        //构造器
        SqlDataAdapter sda;
        //临时数据库
        DataSet ds;
        //初始化信息
        public void StartInfo()
        {
            try
            {
                dbh.DBOpen();
                ds = new DataSet();
                //获取点菜单
                string sql = "select * from BuyFood,Food where FoodID=ID and zhangdanid='" + ZhangDanId + "'";
                sda = new SqlDataAdapter(sql, dbh.Conn);
                sda.Fill(ds, "FoodList");
                this.FoodList.DataSource = ds.Tables["FoodList"];
                //获取餐台号
                sql = "select name from desk where dingdanid='" + ZhangDanId + "'";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                this.txtZhangDanId.Text = ZhangDanId;
                this.txtDeskId.Text = comm.ExecuteScalar().ToString();
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
            zheKou = 0;
            this.textName.Text = string.Empty;
            this.textType.Text = string.Empty;
            this.textZheKou.Text = string.Empty;
            this.textJiFen.Text = string.Empty;
            long a;
            try
            {
                dbh.DBOpen();
                //获取会员信息
                if (this.textSelect.Text.Trim() != string.Empty && long.TryParse(this.textSelect.Text.Trim(), out a))
                {
                    string sql = "select * from VIPCard,CardClass where VIPCard.TypeID=CardClass.TypeID and VIPCard.Phone='" + this.textSelect.Text.Trim() + "' and zhuangtai=0";
                    SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        zheKou = Convert.ToDouble(reader["ZheKou"]);
                        this.textName.Text = reader["Name"].ToString();
                        this.textType.Text = reader["TypeName"].ToString();
                        this.textZheKou.Text = zheKou.ToString();
                        this.textJiFen.Text = reader["JIFen"].ToString();
                    }
                    reader.Close();
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
        //获取总金额
        public void GetAllMoney()
        {
            try
            {
                dbh.DBOpen();
                //获取账单消费总金额
                string sql = "select sum(buyfood.number*food.Moeny) from buyfood,food where buyfood.FoodID=food.id and zhangdanid='" + ZhangDanId + "'";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                allMoney = Math.Round(Convert.ToDouble(comm.ExecuteScalar()), 1);
                this.txtAllMoney.Text = allMoney.ToString();
                //根据消费金额判断优惠券可用
                if (allMoney < 300)
                {
                    this.yh3.Enabled = false;
                }
                if (allMoney < 200)
                {
                    this.yh2.Enabled = false;
                }
                if (allMoney < 100)
                {
                    this.yh1.Enabled = false;
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
        //计算实际消费
        public void GetRealMoney()
        {
            realMoney = allMoney;
            //会员折扣
            if (zheKou != 0)
            {
                realMoney = Math.Round(allMoney * zheKou, 1);
            }
            //优惠券
            youHui = 0;
            if (this.yh1.Checked == true)
            {
                youHui = 5;
            }
            else if (this.yh2.Checked == true)
            {
                youHui = 20;
            }
            else if (this.yh3.Checked == true)
            {
                youHui = 50;
            }
            realMoney -= youHui;
            this.txtTrueMoney.Text = realMoney.ToString();
        }
        //计算找零
        public void GetZhaoLin()
        {
            if (this.textPay.Text != string.Empty)
            {
                zhaoLin = Math.Round((Convert.ToDouble(this.textPay.Text) - realMoney), 1);
                if (zhaoLin < 0)
                {
                    this.txtZL.Text = "还需支付" + (-zhaoLin) + "元";
                }
                else if (zhaoLin == 0)
                {
                    this.txtZL.Text = "不需要找零";
                }
                else
                {
                    this.txtZL.Text = zhaoLin.ToString();
                }
            }
            else
            {
                zhaoLin = -realMoney;
                this.txtZL.Text = "还需支付" + realMoney + "元";
            }
        }
        //结账
        public void PayYes()
        {
            try
            {
                dbh.DBOpen();
                //修改桌台状态，修改账单信息
                string sql = "update desk set zhuangtai=0,dingdanid=null where dingdanid='" + ZhangDanId + "' update zhangdan set jiezhangtime=getdate(),truemoney='" + realMoney + "',zhuangtai=2,youhui='" + youHui + "',zhekou='" + zheKou + "' where id='" + ZhangDanId + "'";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                comm.ExecuteNonQuery();
                if (this.textName.Text != string.Empty)
                {
                    jiFen = (int)(realMoney / 2);
                    //记录会员信息，赠送会员积分
                    sql = "update zhangdan set vipid='" + this.textSelect.Text.Trim() + "' where id='" + ZhangDanId + "' update vipcard set jifen=jifen+" + jiFen + " where phone='" + this.textSelect.Text.Trim()+"'";
                    comm = new SqlCommand(sql, dbh.Conn);
                    comm.ExecuteNonQuery();
                    //查询会员可升级至最高等级
                    sql = "select top 1 typeid from cardclass where neednum between 0 and (select jifen from vipcard where Phone='" + this.textSelect.Text.Trim() + "') order by neednum desc";
                    comm = new SqlCommand(sql, dbh.Conn);
                    //会员升级
                    sql = "update vipcard set typeid=" + comm.ExecuteScalar().ToString() + " where Phone='" + this.textSelect.Text.Trim() + "'";
                    comm = new SqlCommand(sql, dbh.Conn);
                    comm.ExecuteNonQuery();
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
        //付款验证
        public bool PayCheck()
        {
            if (zhaoLin < 0)
            {
                FMHelper.OpenOk("请输入正确的付款金额");
            }
            else
            {
                return true;
            }
            return false;
        }
        //计算器验证
        public bool JSQCheck()
        {
            string[] a = new string[3];
            a = this.textPay.Text.Split('.');
            if (this.textPay.Text.Length == 15)
            {
                return false;
            }
            else if (a.Length > 1 && a[1].Length > 0)
            {
                return false;
            }
            return true;
        }
        public Pay()
        {
            InitializeComponent();
        }
        //窗体打开
        private void Pay_Load(object sender, EventArgs e)
        {
            this.FoodList.RowTemplate.Height = 50;
            this.FoodList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.FoodList.AutoGenerateColumns = false;
            this.yhNo.Checked = true;
            StartInfo();
            GetAllMoney();
            GetRealMoney();
            GetZhaoLin();
        }
        #region 数字键盘
        private void button16_Click(object sender, EventArgs e)
        {
            if (JSQCheck())
            {
                this.textPay.Text += "7";
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (JSQCheck())
            {
                this.textPay.Text += "8";
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (JSQCheck())
            {
                this.textPay.Text += "9";
            }
        }
        private void button19_Click(object sender, EventArgs e)
        {
            if (JSQCheck())
            {
                this.textPay.Text += "4";
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            if (JSQCheck())
            {
                this.textPay.Text += "5";
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            if (JSQCheck())
            {
                this.textPay.Text += "6";
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (JSQCheck())
            {
                this.textPay.Text += "1";
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (JSQCheck())
            {
                this.textPay.Text += "2";
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (JSQCheck())
            {
                this.textPay.Text += "3";
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (JSQCheck())
            {
                if (this.textPay.Text != string.Empty)
                {
                    this.textPay.Text += "0";
                }
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (JSQCheck())
            {
                if (this.textPay.Text != string.Empty)
                {
                    this.textPay.Text += "00";
                }
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (JSQCheck())
            {
                string[] a = new string[3];
                a = this.textPay.Text.Split('.');
                if (a.Length < 2 && this.textPay.Text != string.Empty)
                {
                    this.textPay.Text += ".";
                }
            }
        }
        #endregion
        //减号按钮
        private void button20_Click(object sender, EventArgs e)
        {
            if (this.textPay.Text.Length > 0)
            {
                this.textPay.Text = this.textPay.Text.Substring(0, this.textPay.Text.Length - 1);
            }
        }
        //搜索框
        private void textSelect_TextChanged(object sender, EventArgs e)
        {
            GetVIPInfo();
            GetRealMoney();
            GetZhaoLin();
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
        #region 优惠券
        private void yhNo_CheckedChanged(object sender, EventArgs e)
        {
            GetRealMoney();
            GetZhaoLin();
        }
        private void yh1_CheckedChanged(object sender, EventArgs e)
        {
            GetRealMoney();
            GetZhaoLin();
        }
        private void yh2_CheckedChanged(object sender, EventArgs e)
        {
            GetRealMoney();
            GetZhaoLin();
        }
        private void yh3_CheckedChanged(object sender, EventArgs e)
        {
            GetRealMoney();
            GetZhaoLin();
        }
        #endregion
        //付款金额文本框
        private void textPay_TextChanged(object sender, EventArgs e)
        {
            GetZhaoLin();
        }
        //结账按钮
        private void button7_Click(object sender, EventArgs e)
        {
            if (PayCheck())
            {
                if (FMHelper.OpenYesNo("要确认结账吗"))
                {
                    PayYes();
                    PayOk frm = new PayOk();
                    frm.zhangDanId = ZhangDanId;
                    frm.money = realMoney.ToString();
                    if (this.textName.Text != string.Empty)
                    {
                        frm.vip = this.textSelect.Text;
                    }
                    frm.jiFen = jiFen.ToString();
                    frm.ShowDialog();
                    FMHelper.OpenDeskMenu();
                    this.Close();
                }
            }
        }
        //账单按钮
        private void button6_Click(object sender, EventArgs e)
        {
            FMHelper.OpenZhngDan();
            this.Close();
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
        //刷新
        private void button2_Click(object sender, EventArgs e)
        {
            this.textSelect.Text = string.Empty;
            this.yhNo.Checked = true;
        }
    }
}