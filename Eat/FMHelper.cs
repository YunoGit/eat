using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eat
{
    public static class FMHelper
    {
        //店内
        public static void OpenDeskMenu()
        {
            DeskMenu frm = new DeskMenu();
            frm.Show();
        }
        //会员
        public static void OpenVip()
        {
            VIP frm = new VIP();
            frm.Show();
        }
        //点餐
        public static void OpenAddFood()
        {
            AddFood frm = new AddFood();
            frm.Show();
        }
        //结账
        public static void OpenPay()
        {
            Pay frm = new Pay();
            frm.Show();
        }
        //账单
        public static void OpenZhngDan()
        {
            ZhangDan frm = new ZhangDan();
            frm.Show();
        }
        //菜品
        public static void OpenFoodMenu()
        {
            FoodMenu frm = new FoodMenu();
            frm.Show();
        }
        //提示
        public static void OpenOk(string text)
        {
            Ok frm = new Ok();
            frm.text = text;
            frm.ShowDialog();
        }
        //确认
        public static bool OpenYesNo(string text)
        {
            YesNo frm = new YesNo();
            frm.text = text;
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //添加会员
        public static void OpenVipAdd()
        {
            VIPAdd frm = new VIPAdd();
            frm.ShowDialog();
        }
        //添加会员成功提示
        public static void OpenVipAddOk()
        {
            VIPAddOk frm = new VIPAddOk();
            frm.ShowDialog();
        }
        //会员等级信息
        public static void OpenVIPLv()
        {
            VIPLv frm = new VIPLv();
            frm.ShowDialog();
        }
        //新增菜品
        public static void OpenFoodMenuAdd()
        {
            FoodMenuAdd frm = new FoodMenuAdd();
            frm.ShowDialog();
        }
        //关于
        public static void OpenAbout()
        {
            AboutBack frm1 = new AboutBack();
            frm1.Show();
            About frm2 = new About();
            frm2.ShowDialog();
            frm1.Close();
        }
        //退出程序
        public static void AllClose()
        {
            if (FMHelper.OpenYesNo("要退出程序吗"))
            {
                Application.Exit();
            }
        }
    }
}