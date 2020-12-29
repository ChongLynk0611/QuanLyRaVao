using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyRaVao.BLL.HocVien;
using DevExpress.Utils;
using QuanLyRaVao.DAL;

namespace QuanLyRaVao.GUI.HocVien
{
    public partial class DuyetDSRaVao_GUI : DevExpress.XtraEditors.XtraUserControl
    {
        DuyetDSRaVao_BLL dsRV = new DuyetDSRaVao_BLL();
        DBAccess db = new DBAccess();
        private string maLopTruong;
        private int id_DSDangKy;
        public DuyetDSRaVao_GUI(string maLT)
        {
            this.maLopTruong = maLT;
            InitializeComponent();
        }

        private void DuyetDSRaVao_GUI_Load(object sender, EventArgs e)
        {
            QuanLyRaVaoEntities2 db = new QuanLyRaVaoEntities2();
            DSDangKyGrid.DataSource = dsRV.GetDSDangKyLop(this.maLopTruong);

            this.id_DSDangKy = dsRV.getIdDSDangKy(this.maLopTruong);

            lb_QuanSo.Text = dsRV.GetQuanSo(this.maLopTruong).ToString();
            DataRow r = dsRV.GetLopVaDonVi(this.maLopTruong);
            lb_TenDonVi.Text = r["TenDV"].ToString();
            lb_TenLop.Text = r["TenChuyenNganh"].ToString();
            thoiGianDi.DisplayFormat.FormatType = FormatType.DateTime;
            thoiGianDi.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            thoiGianVe.DisplayFormat.FormatType = FormatType.DateTime;
            thoiGianVe.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
        }

       
        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            bool trangThai = (bool)viewDS.GetRowCellValue(e.RowHandle, "TTLop");
            int id_DK = (int)viewDS.GetRowCellValue(e.RowHandle, "id_DangKy");
            dsRV.updateTrangThai(id_DK, trangThai);
        }

        private void viewDS_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            string maHV = viewDS.GetRowCellValue(e.RowHandle, "MaHV").ToString();
            txt_maHV.Text = maHV;
            lb_HoTen.Text = viewDS.GetRowCellValue(e.RowHandle, "HoTen").ToString();
            lb_NgayDI.Text = viewDS.GetRowCellValue(e.RowHandle, "ThoiGianDi").ToString();
            lb_NgayVe.Text = viewDS.GetRowCellValue(e.RowHandle, "ThoiGianVe").ToString();

            dataLoiViPham.DataSource = dsRV.GetLoi(maHV);


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(this.id_DSDangKy != -1)
            {
                dsRV.updateLopDuyet(id_DSDangKy);
                DSDangKyGrid.DataSource = dsRV.GetDSDangKyLop(this.maLopTruong);

                this.id_DSDangKy = dsRV.getIdDSDangKy(this.maLopTruong);
                MessageBox.Show("Duyệt thành công ");

            }
            else
            {
                MessageBox.Show("Không có đơn nào để duyệt");
            }
            
        }
    }
}
