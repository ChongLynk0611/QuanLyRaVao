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
using QuanLyRaVao.DAL;
using QuanLyRaVao.BLL;

namespace QuanLyRaVao.GUI
{
    public partial class DuyetTranhThu : DevExpress.XtraEditors.XtraUserControl
    {
        DBAccess db = new DBAccess();
        DuyetTranhThu_BLL DRN = new DuyetTranhThu_BLL();
        private string maCB;
        public DuyetTranhThu(string macb)
        {
            this.maCB = macb;
            InitializeComponent();
        }

        private void DuyetTranhThu_Load(object sender, EventArgs e)
        {
            DataRow dtr = DRN.infoCanBo(this.maCB);
            txTenCanBo.Text = dtr[0].ToString();
            tcCapbacCanBo.Text = dtr[1].ToString();
            txChucvuCanBo.Text = dtr[2].ToString();
            dtpThoiGianDuyet.Value = DateTime.Now;
            //load du lieu len combobox
            DataTable dtb = DRN.ComboboxLop(this.maCB);
            cmbLop.DataSource = dtb;
            cmbLop.ValueMember = "id_ChuyenNganh";
            cmbLop.DisplayMember = "TenChuyenNganh";
        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataRow dtr = DRN.LoadQuanSo(cmbLop.Text);
            //txQuanSo.Text = dtr[0].ToString();
            ////load datagridview
            //DataRow dtr1 = DRN.TenLopTruong(cmbLop.Text);
            //txLopTruong.Text = dtr1[0].ToString();
            //DataTable dtb = DRN.load_dtgv(cmbLop.Text);
            //dtgvDSDuyetTranhThu.DataSource = dtb;
        }

        private void dtgvDSDuyetTranhThu_DataMemberChanged(object sender, EventArgs e)
        {
            int i = dtgvDSDuyetTranhThu.CurrentRow.Index;
            if (Convert.ToInt32(dtgvDSDuyetTranhThu.Rows[i].Cells[9].Value) == 1)
            {
                string sql = "update DangKy"
                       + "set TrangThai = 1"
                       + "where id_TaiKhoan = '" + dtgvDSDuyetTranhThu.Rows[i].Cells[1] + "'";
                DataTable dtb = db.getDS(sql);
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            dtpThoiGianDuyet.Value = DateTime.Now;
        }

        private void cmbLop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow dtr = DRN.LoadQuanSo(cmbLop.Text, this.maCB);
            txQuanSo.Text = dtr[0].ToString();
            //load datagridview
            DataRow dtr1 = DRN.TenLopTruong(cmbLop.Text, this.maCB);
            txLopTruong.Text = dtr1[0].ToString();
            DataTable dtb = DRN.load_dtgv(cmbLop.Text, this.maCB);
            dtgvDSDuyetTranhThu.DataSource = dtb;
        }
    }
}
