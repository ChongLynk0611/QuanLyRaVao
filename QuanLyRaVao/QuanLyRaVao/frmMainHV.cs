﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.SqlClient;
using QuanLyRaVao.GUI.HocVien;
using QuanLyRaVao.DAL;

namespace QuanLyRaVao
{
    public partial class frmMainHV : DevExpress.XtraBars.Ribbon.RibbonForm//giải thích chỗ này
    {
        private string maHV;
        DBAccess db = new DBAccess();
        public frmMainHV(string mahv)
        {
            this.maHV = mahv;
            InitializeComponent();
          
            

        }
        // giao diện của sự kiện khi load form lên sẽ mặc định là office 2007 green
        private void skin()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel def = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            def.LookAndFeel.SkinName = "Office 2007 Green";
        }
        // khi load form gọi tới skin() => để laod giao diện mặc định lên
        private void home_Load(object sender, EventArgs e)
        {
            Home_GUI home = new Home_GUI();
            addpage(fr_main, "Trang chủ", home);
            skin();

            string query = "select id_ChucVu from TaiKhoan where id_TaiKhoan = '" + this.maHV + "'";
            DataTable dtb = db.getDS(query);
            DataRow r = dtb.Rows[0];
            if(r[0].ToString() == "1")
            {
                btn_DuyetDS.Enabled = false;
                btn_DKViPham.Enabled = false;
            }


        }
        /* phương thức thêm 1 page vào xtratabcontrol 
            - xtratabcha: Tên của xtratabcontrol được dùng để thêm các tabpage con
            - tabname: Tên sẽ hiển thị ra của tabpage con
            - usetr: usercontrol được thêm vào cái page mới được tạo ra
         */
        public  void addpage(DevExpress.XtraTab.XtraTabControl xtratabCha , string tabNameAdd ,System.Windows.Forms.UserControl useCtr )    
        {
            int dem = 0;        // biến đếm tabpage trùng tên
            foreach(DevExpress.XtraTab.XtraTabPage tab in fr_main.TabPages)                 // chạy vòng lặp để ktra xem form muốn add vào đã có chưa
            {
                if(tab.Name == tabNameAdd)                                                  // nếu tên form mới đã có
                {                   
                    fr_main.SelectedTabPage = tab;                          // focus vào page muốn tạo nhưng đã tồn tại 
                    dem = 1;                                                // thay đổi biến đếm =1
                }

            }   
            // chạy xong vòng lặp, nếu dem = 1 = > page đã tồn tại, nếu dem !=1 => page chưa tồn tại nên sẽ addpage vào extratab
            if(dem != 1)
            {
                DevExpress.XtraTab.XtraTabPage TabAdd = new DevExpress.XtraTab.XtraTabPage();           // tạo ra page  để add usercontrol và sau đó add vào extratab
                TabAdd.Text = tabNameAdd;                       // gán tên của tabpage mới được tạo bằng tên mình muốn
                TabAdd.Name = tabNameAdd;                       // gán tên cho tabpage
                TabAdd.Controls.Add(useCtr);                    // add usercontrol vào tabpage vừa tạo ra
                useCtr.Dock = DockStyle.Fill;                   // fill cho nó đầy ra tabpage
                fr_main.TabPages.Add(TabAdd);                   // thêm tabpage vào xtratabcontrol 
                fr_main.SelectedTabPage = TabAdd;               // focus vào tabpage vừa được tạo ra
            }


           
        }

        // sự kiện khi click vào dấu x của page con trong xtratabcontrol
        private void fr_main_CloseButtonClick(object sender, EventArgs e)
        {// dong tab
            DevExpress.XtraTab.XtraTabControl tabControl = sender as DevExpress.XtraTab.XtraTabControl;
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            (arg.Page as DevExpress.XtraTab.XtraTabPage).Dispose();
            

            
        }

        // đăng ký ra ngoài
        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            DangKyRaVao_GUI RV= new DangKyRaVao_GUI(this.maHV);
            addpage(fr_main, "Phiếu đăng ký", RV);
        }

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        // Trang cá nhân
        private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
        {
            TrangCaNhan_GUI TCN = new TrangCaNhan_GUI(this.maHV);
            addpage(fr_main, "Trang cá nhân", TCN);
        }

        // sự kiện button duyệt danh sách ra ngoài
        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            DuyetDSRaVao_GUI DuyetDS = new DuyetDSRaVao_GUI(this.maHV);
            addpage(fr_main, "Danh sách ra ngoài", DuyetDS);
        }

        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
            frmLogin login = new frmLogin();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }
    }
}