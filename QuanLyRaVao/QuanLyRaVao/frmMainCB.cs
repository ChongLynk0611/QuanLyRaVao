using System;
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
using QuanLyRaVao.GUI;

namespace QuanLyRaVao
{
    public partial class frmMainCB : DevExpress.XtraBars.Ribbon.RibbonForm//giải thích chỗ này
    {
        private string maCB;
        
        public frmMainCB(string maCB)
        {
            this.maCB = maCB;
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


        // sự kiện button duyệt danh sách ra ngoài
        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            DuyetRaNgoai DuyetDS = new DuyetRaNgoai(this.maCB);
            addpage(fr_main, "Danh sách ra ngoài", DuyetDS);
        }

        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            DangKyRaVao_GUI DKRV = new DangKyRaVao_GUI(this.maCB);
            addpage(fr_main, "Đăng ký ra ngoài", DKRV);
        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
            DuyetTranhThu TT = new DuyetTranhThu(this.maCB);

            addpage(fr_main, "Duyệt danh sách tranh thủ", TT);
        }

        private void barButtonItem36_ItemClick(object sender, ItemClickEventArgs e)
        {
            XacNhanRaNgoai RN = new XacNhanRaNgoai(this.maCB);
            addpage(fr_main, "Xác nhận ra ngoài", RN);
        }

        private void barButtonItem37_ItemClick(object sender, ItemClickEventArgs e)
        {
            XacNhanTranhThu TT = new XacNhanTranhThu(this.maCB);
            addpage(fr_main, "Xác nhạn tranh thủ", TT);
        }
    }
}