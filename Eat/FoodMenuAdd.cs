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
    public partial class FoodMenuAdd : Form
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
        //添加菜品
        public void AddFood()
        {
            try
            {
                dbh.DBOpen();
                string sql = "select count(*) from food where name='" + this.txtFoodName.Text.Trim() + "' and zhuangtai=0";
                SqlCommand comm = new SqlCommand(sql, dbh.Conn);
                if ((int)comm.ExecuteScalar() == 0)
                {
                    sql = "select id from food where danwei='" + this.txtFoodDanWei.Text.Trim() + "' and name='" + this.txtFoodName.Text.Trim() + "' and moeny='" + this.txtFoodPrice.Text.Trim() + "'";
                    comm = new SqlCommand(sql, dbh.Conn);
                    if (comm.ExecuteScalar() == null)
                    {
                        sql = "insert food select '" + this.txtFoodDanWei.Text.Trim() + "','" + this.txtFoodName.Text.Trim() + "','" + this.txtFoodPrice.Text.Trim() + "',0";
                        comm = new SqlCommand(sql, dbh.Conn);
                        comm.ExecuteNonQuery();
                    }
                    else
                    {
                        string id = comm.ExecuteScalar().ToString();
                        sql = "update food set zhuangtai=0 where id=" + id;
                        comm = new SqlCommand(sql, dbh.Conn);
                        comm.ExecuteNonQuery();
                    }
                    FMHelper.OpenOk("菜品添加成功");
                    this.Close();
                }
                else
                {
                    FMHelper.OpenOk("该菜品已存在");
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
        public FoodMenuAdd()
        {
            InitializeComponent();
        }
        //添加
        private void botYes_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                AddFood();
            }
        }
        //取消
        private void botLvUp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}