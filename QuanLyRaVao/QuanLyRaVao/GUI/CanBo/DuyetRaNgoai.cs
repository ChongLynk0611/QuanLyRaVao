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
using QuanLyRaVao.BLL;
using QuanLyRaVao.DTO;
using QuanLyRaVao.DAL;

namespace QuanLyRaVao.GUI
{
    public partial class DuyetRaNgoai : DevExpress.XtraEditors.XtraUserControl
    {
        DBAccess db = new DBAccess();
        DuyetRaNgoai_BLL DRN = new DuyetRaNgoai_BLL();
        string maCB;
        public DuyetRaNgoai(string maCB)
        {
            this.maCB = maCB;
            InitializeComponent();
        }

        private void DuyetRaNgoai_Load(object sender, EventArgs e)
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
            //string a = cmbLop.Text;
            //DataRow dtr = DRN.LoadQuanSo(cmbLop.Text);
            //txQuanSo.Text = dtr[0].ToString();
            ////load datagridview
            //DataRow dtr1 = DRN.TenLopTruong(cmbLop.Text);
            //txLopTruong.Text = dtr1[0].ToString();
            //DataTable dtb = DRN.load_dtgv(cmbLop.Text);
            //dtgvDSDuyetRaNgoai.DataSource = dtb;

        }

        private void dtgvDSDuyetRaNgoai_DataMemberChanged(object sender, EventArgs e)
        {
            MessageBox.Show("123");
            int i = dtgvDSDuyetRaNgoai.CurrentRow.Index;
            if (Convert.ToInt32(dtgvDSDuyetRaNgoai.Rows[i].Cells[9].Value) == 1)
            {
                string sql = "update DangKy"
                       + "set TrangThai = 1"
                       + "where id_TaiKhoan = '" + dtgvDSDuyetRaNgoai.Rows[i].Cells[1] + "'";
                DataTable dtb = db.getDS(sql);
            }
            if (Convert.ToInt32(dtgvDSDuyetRaNgoai.Rows[i].Cells[9].Value) == 0)
            {
                string sql = "update DangKy"
                       + "set TrangThai = 0"
                       + "where id_TaiKhoan = '" + dtgvDSDuyetRaNgoai.Rows[i].Cells[1] + "'";
                DataTable dtb = db.getDS(sql);
            }

        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            dtpThoiGianDuyet.Value = DateTime.Now;
            string sql = "update DSDangKy"
                       + "set ThoiGianDuyet = '" + dtpThoiGianDuyet.Value + "'";
            DataTable dtb = db.getDS(sql);
        }

        private void cmbLop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string a = cmbLop.Text;
            DataRow dtr = DRN.LoadQuanSo(cmbLop.Text, this.maCB);
            txQuanSo.Text = dtr[0].ToString();
            //load datagridview
            DataRow dtr1 = DRN.TenLopTruong(cmbLop.Text, this.maCB);
            txLopTruong.Text = dtr1[0].ToString();
            DataTable dtb = DRN.load_dtgv(cmbLop.Text, this.maCB);
            dtgvDSDuyetRaNgoai.DataSource = dtb;
        }

    }
}
