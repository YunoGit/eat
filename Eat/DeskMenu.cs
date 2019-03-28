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
    public partial class DeskMenu : Form
    {
        DBHelper dbh = new DBHelper();
        string text;
        public void ShowMessage()
        {
            MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #region 餐台
        //A区
        string ddA1, ddA2, ddA3, ddA4, ddA5, ddA6, ddA7, ddA8, ddA9, ddA10;
        int ztA1, ztA2, ztA3, ztA4, ztA5, ztA6, ztA7, ztA8, ztA9, ztA10;
        //B区
        string ddB1, ddB2, ddB3, ddB4, ddB5, ddB6, ddB7, ddB8, ddB9, ddB10;
        int ztB1, ztB2, ztB3, ztB4, ztB5, ztB6, ztB7, ztB8, ztB9, ztB10;
        //C区
        string ddC1, ddC2, ddC3, ddC4, ddC5;
        int ztC1, ztC2, ztC3, ztC4, ztC5;
        //VIP区
        string ddV1, ddV2, ddV3;
        int ztV1, ztV2, ztV3;
        #endregion
        //初始化信息
        public void StartInfo()
        {
            try
            {
                dbh.DBOpen();
                //获取并设置桌台订单，状态
                string sql = "select * from desk";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                SqlDataReader reader = comm.ExecuteReader();
                #region A区
                reader.Read();
                ddA1 = reader["DingDanID"].ToString();
                ztA1 = (int)reader["ZhuangTai"];
                if (ztA1 == 1)
                {
                    txtA1.Text = "已开台";
                }
                else
                {
                    txtA1.Text = string.Empty;
                }
                reader.Read();
                ddA2 = reader["DingDanID"].ToString();
                ztA2 = (int)reader["ZhuangTai"];
                if (ztA2 == 1)
                {
                    txtA2.Text = "已开台";
                }
                else
                {
                    txtA2.Text = string.Empty;
                }
                reader.Read();
                ddA3 = reader["DingDanID"].ToString();
                ztA3 = (int)reader["ZhuangTai"];
                if (ztA3 == 1)
                {
                    txtA3.Text = "已开台";
                }
                else
                {
                    txtA3.Text = string.Empty;
                }
                reader.Read();
                ddA4 = reader["DingDanID"].ToString();
                ztA4 = (int)reader["ZhuangTai"];
                if (ztA4 == 1)
                {
                    txtA4.Text = "已开台";
                }
                else
                {
                    txtA4.Text = string.Empty;
                }
                reader.Read();
                ddA5 = reader["DingDanID"].ToString();
                ztA5 = (int)reader["ZhuangTai"];
                if (ztA5 == 1)
                {
                    txtA5.Text = "已开台";
                }
                else
                {
                    txtA5.Text = string.Empty;
                }
                reader.Read();
                ddA6 = reader["DingDanID"].ToString();
                ztA6 = (int)reader["ZhuangTai"];
                if (ztA6 == 1)
                {
                    txtA6.Text = "已开台";
                }
                else
                {
                    txtA6.Text = string.Empty;
                }
                reader.Read();
                ddA7 = reader["DingDanID"].ToString();
                ztA7 = (int)reader["ZhuangTai"];
                if (ztA7 == 1)
                {
                    txtA7.Text = "已开台";
                }
                else
                {
                    txtA7.Text = string.Empty;
                }
                reader.Read();
                ddA8 = reader["DingDanID"].ToString();
                ztA8 = (int)reader["ZhuangTai"];
                if (ztA8 == 1)
                {
                    txtA8.Text = "已开台";
                }
                else
                {
                    txtA8.Text = string.Empty;
                }
                reader.Read();
                ddA9 = reader["DingDanID"].ToString();
                ztA9 = (int)reader["ZhuangTai"];
                if (ztA9 == 1)
                {
                    txtA9.Text = "已开台";
                }
                else
                {
                    txtA9.Text = string.Empty;
                }
                reader.Read();
                ddA10 = reader["DingDanID"].ToString();
                ztA10 = (int)reader["ZhuangTai"];
                if (ztA10 == 1)
                {
                    txtA10.Text = "已开台";
                }
                else
                {
                    txtA10.Text = string.Empty;
                }
                #endregion
                #region B区
                reader.Read();
                ddB1 = reader["DingDanID"].ToString();
                ztB1 = (int)reader["ZhuangTai"];
                if (ztB1 == 1)
                {
                    txtB1.Text = "已开台";
                }
                else
                {
                    txtB1.Text = string.Empty;
                }
                reader.Read();
                ddB2 = reader["DingDanID"].ToString();
                ztB2 = (int)reader["ZhuangTai"];
                if (ztB2 == 1)
                {
                    txtB2.Text = "已开台";
                }
                else
                {
                    txtB2.Text = string.Empty;
                }
                reader.Read();
                ddB3 = reader["DingDanID"].ToString();
                ztB3 = (int)reader["ZhuangTai"];
                if (ztB3 == 1)
                {
                    txtB3.Text = "已开台";
                }
                else
                {
                    txtB3.Text = string.Empty;
                }
                reader.Read();
                ddB4 = reader["DingDanID"].ToString();
                ztB4 = (int)reader["ZhuangTai"];
                if (ztB4 == 1)
                {
                    txtB4.Text = "已开台";
                }
                else
                {
                    txtB4.Text = string.Empty;
                }
                reader.Read();
                ddB5 = reader["DingDanID"].ToString();
                ztB5 = (int)reader["ZhuangTai"];
                if (ztB5 == 1)
                {
                    txtB5.Text = "已开台";
                }
                else
                {
                    txtB5.Text = string.Empty;
                }
                reader.Read();
                ddB6 = reader["DingDanID"].ToString();
                ztB6 = (int)reader["ZhuangTai"];
                if (ztB6 == 1)
                {
                    txtB6.Text = "已开台";
                }
                else
                {
                    txtB6.Text = string.Empty;
                }
                reader.Read();
                ddB7 = reader["DingDanID"].ToString();
                ztB7 = (int)reader["ZhuangTai"];
                if (ztB7 == 1)
                {
                    txtB7.Text = "已开台";
                }
                else
                {
                    txtB7.Text = string.Empty;
                }
                reader.Read();
                ddB8 = reader["DingDanID"].ToString();
                ztB8 = (int)reader["ZhuangTai"];
                if (ztB8 == 1)
                {
                    txtB8.Text = "已开台";
                }
                else
                {
                    txtB8.Text = string.Empty;
                }
                reader.Read();
                ddB9 = reader["DingDanID"].ToString();
                ztB9 = (int)reader["ZhuangTai"];
                if (ztB9 == 1)
                {
                    txtB9.Text = "已开台";
                }
                else
                {
                    txtB9.Text = string.Empty;
                }
                reader.Read();
                ddB10 = reader["DingDanID"].ToString();
                ztB10 = (int)reader["ZhuangTai"];
                if (ztB10 == 1)
                {
                    txtB10.Text = "已开台";
                }
                else
                {
                    txtB10.Text = string.Empty;
                }
                #endregion
                #region C区
                reader.Read();
                ddC1 = reader["DingDanID"].ToString();
                ztC1 = (int)reader["ZhuangTai"];
                if (ztC1 == 1)
                {
                    txtC1.Text = "已开台";
                }
                else
                {
                    txtC1.Text = string.Empty;
                }
                reader.Read();
                ddC2 = reader["DingDanID"].ToString();
                ztC2 = (int)reader["ZhuangTai"];
                if (ztC2 == 1)
                {
                    txtC2.Text = "已开台";
                }
                else
                {
                    txtC2.Text = string.Empty;
                }
                reader.Read();
                ddC3 = reader["DingDanID"].ToString();
                ztC3 = (int)reader["ZhuangTai"];
                if (ztC3 == 1)
                {
                    txtC3.Text = "已开台";
                }
                else
                {
                    txtC3.Text = string.Empty;
                }
                reader.Read();
                ddC4 = reader["DingDanID"].ToString();
                ztC4 = (int)reader["ZhuangTai"];
                if (ztC4 == 1)
                {
                    txtC4.Text = "已开台";
                }
                else
                {
                    txtC4.Text = string.Empty;
                }
                reader.Read();
                ddC5 = reader["DingDanID"].ToString();
                ztC5 = (int)reader["ZhuangTai"];
                if (ztC5 == 1)
                {
                    txtC5.Text = "已开台";
                }
                else
                {
                    txtC5.Text = string.Empty;
                }
                #endregion
                #region VIP区
                reader.Read();
                ddV1 = reader["DingDanID"].ToString();
                ztV1 = (int)reader["ZhuangTai"];
                if (ztV1 == 1)
                {
                    txtV1.Text = "已开台";
                }
                else
                {
                    txtV1.Text = string.Empty;
                }
                reader.Read();
                ddV2 = reader["DingDanID"].ToString();
                ztV2 = (int)reader["ZhuangTai"];
                if (ztV2 == 1)
                {
                    txtV2.Text = "已开台";
                }
                else
                {
                    txtV2.Text = string.Empty;
                }
                reader.Read();
                ddV3 = reader["DingDanID"].ToString();
                ztV3 = (int)reader["ZhuangTai"];
                if (ztV3 == 1)
                {
                    txtV3.Text = "已开台";
                }
                else
                {
                    txtV3.Text = string.Empty;
                }
                #endregion
                reader.Close();
                //获取未开台数
                sql = "select count(*) from desk where zhuangtai=0";
                comm = new SqlCommand(sql, dbh.Conn);
                this.txtNone.Text = comm.ExecuteScalar().ToString();
                //获取开台数
                sql = "select count(*) from desk where zhuangtai=1";
                comm = new SqlCommand(sql, dbh.Conn);
                this.txtUse.Text = comm.ExecuteScalar().ToString();
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
        //一键清台
        public void EndInfo()
        {
            try
            {
                dbh.DBOpen();
                string sql = "update zhangdan set zhuangtai=3 where id in (select dingdanid from desk) update desk set ZhuangTai=0,DingDanID=null";
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
        //开台
        public void Pay(ref string ZhangDanId, string desk)
        {
            if (ZhangDanId == string.Empty)
            {
                try
                {
                    dbh.DBOpen();
                    //获取桌台编号
                    string sql = "select id from desk where name='" + desk + "'";
                    SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                    string deskid = comm.ExecuteScalar().ToString();
                    //新建订单
                    ZhangDanId = string.Format("{0:yyMMddHHmmss}", DateTime.Now);
                    sql = "insert ZhangDan select '" + ZhangDanId + "','" + deskid + "',null,getdate(),'0','0',1,'0','0' select top 1 id from zhangdan order by id desc";
                    comm = new SqlCommand(sql, dbh.Conn);
                    comm.ExecuteNonQuery();
                    //修改桌台状态
                    sql = "update desk set zhuangtai=1,dingdanid='" + ZhangDanId + "' where id='" + deskid + "'";
                    comm = new SqlCommand(sql, dbh.Conn);
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    text = ex.Message;
                    ShowMessage();
                    return;
                }
                finally
                {
                    dbh.DBClose();
                }
            }
            AddFood frm = new AddFood();
            frm.ZhangDanId = ZhangDanId;
            frm.Show();
            this.Close();
        }
        public DeskMenu()
        {
            InitializeComponent();
        }
        //打开窗体
        private void DeskMenu_Load(object sender, EventArgs e)
        {
            StartInfo();
        }
        //退出按钮
        private void button1_Click(object sender, EventArgs e)
        {
            FMHelper.AllClose();
        }
        //会员按钮
        private void button5_Click(object sender, EventArgs e)
        {
            FMHelper.OpenVip();
            this.Close();
        }
        //一键清台
        private void botAdd_Click(object sender, EventArgs e)
        {
            if (FMHelper.OpenYesNo("要清空所有桌台吗"))
            {
                EndInfo();
                StartInfo();
                FMHelper.OpenOk("已清理所有桌台");
            }
        }
        #region 餐台按钮
        //A区
        private void A1_Click(object sender, EventArgs e)
        {
            Pay(ref ddA1, "A1");
        }
        private void A2_Click(object sender, EventArgs e)
        {
            Pay(ref ddA2, "A2");
        }
        private void A3_Click(object sender, EventArgs e)
        {
            Pay(ref ddA3, "A3");
        }
        private void A4_Click(object sender, EventArgs e)
        {
            Pay(ref ddA4, "A4");
        }
        private void A5_Click(object sender, EventArgs e)
        {
            Pay(ref ddA5, "A5");
        }
        private void A6_Click(object sender, EventArgs e)
        {
            Pay(ref ddA6, "A6");
        }
        private void A7_Click(object sender, EventArgs e)
        {
            Pay(ref ddA7, "A7");
        }
        private void A8_Click(object sender, EventArgs e)
        {
            Pay(ref ddA8, "A8");
        }
        private void A9_Click(object sender, EventArgs e)
        {
            Pay(ref ddA9, "A9");
        }
        private void A10_Click(object sender, EventArgs e)
        {
            Pay(ref ddA10, "A10");
        }
        //B区
        private void B1_Click(object sender, EventArgs e)
        {
            Pay(ref ddB1, "B1");
        }
        private void B2_Click(object sender, EventArgs e)
        {
            Pay(ref ddB2, "B2");
        }
        private void B3_Click(object sender, EventArgs e)
        {
            Pay(ref ddB3, "B3");
        }
        private void B4_Click(object sender, EventArgs e)
        {
            Pay(ref ddB4, "B4");
        }
        private void B5_Click(object sender, EventArgs e)
        {
            Pay(ref ddB5, "B5");
        }
        private void B6_Click(object sender, EventArgs e)
        {
            Pay(ref ddB6, "B6");
        }
        private void B7_Click(object sender, EventArgs e)
        {
            Pay(ref ddB7, "B7");
        }
        private void B8_Click(object sender, EventArgs e)
        {
            Pay(ref ddB8, "B8");
        }
        private void B9_Click(object sender, EventArgs e)
        {
            Pay(ref ddB9, "B9");
        }
        private void B10_Click(object sender, EventArgs e)
        {
            Pay(ref ddB10, "B10");
        }
        //C区
        private void C1_Click(object sender, EventArgs e)
        {
            Pay(ref ddC1, "C1");
        }
        private void C2_Click(object sender, EventArgs e)
        {
            Pay(ref ddC2, "C2");
        }
        private void C3_Click(object sender, EventArgs e)
        {
            Pay(ref ddC3, "C3");
        }
        private void C4_Click(object sender, EventArgs e)
        {
            Pay(ref ddC4, "C4");
        }
        private void C5_Click(object sender, EventArgs e)
        {
            Pay(ref ddC5, "C5");
        }
        //VIP区
        private void V1_Click(object sender, EventArgs e)
        {
            Pay(ref ddV1, "V1");
        }
        private void V2_Click(object sender, EventArgs e)
        {
            Pay(ref ddV2, "V2");
        }
        private void V3_Click(object sender, EventArgs e)
        {
            Pay(ref ddV3, "V3");
        }
        #endregion
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
    }
}