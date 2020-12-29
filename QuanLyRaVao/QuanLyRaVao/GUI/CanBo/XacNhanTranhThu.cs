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
using QuanLyRaVao.DAL;
namespace QuanLyRaVao.GUI
{
    public partial class XacNhanTranhThu : DevExpress.XtraEditors.XtraUserControl
    {
        DBAccess db = new DBAccess();
        XacNhanTranhThu_BLL XNTT = new XacNhanTranhThu_BLL();
        string maCB;
        public XacNhanTranhThu(string macb)
        {
            this.maCB = macb;

            InitializeComponent();
        }

        private void XacNhanTranhThu_Load(object sender, EventArgs e)
        {
            DataRow dtr = XNTT.infoCanBo(this.maCB);
            txTenCanBo.Text = dtr[0].ToString();
            tcCapbacCanBo.Text = dtr[1].ToString();
            txChucvuCanBo.Text = dtr[2].ToString();
            DataRow dtr1 = XNTT.Load_datetime();
            dtpThoiGianDuyet.Text = dtr1[0].ToString();
            DataTable dtr2 = XNTT.ComboboxLop(this.maCB);
            cmbLop.DataSource = dtr2;
            cmbLop.DisplayMember = "TenChuyenNganh";
            cmbLop.ValueMember = "id_ChuyenNganh";
        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dtgvXemDSTranhThu_DataMemberChanged(object sender, EventArgs e)
        {
            int i = dtgvXemDSTranhThu.CurrentRow.Index;
            int j = dtgvXemDSTranhThu.CurrentCell.ColumnIndex;
            if (dtgvXemDSTranhThu.Rows[i].Cells[6].ReadOnly = true && Convert.ToInt32(dtgvXemDSTranhThu.Rows[i].Cells[5].Value) == 1 && Convert.ToInt32(dtgvXemDSTranhThu.Rows[i].Cells[6].Value) == 0)
            {
                string sql = "update VeRANgoai"
                       + "set cDuyetDi = '" + DateTime.Now + "'";
                DataTable dtb = db.getDS(sql);
                dtgvXemDSTranhThu.Rows[i].Cells[5].ReadOnly = true;
                dtgvXemDSTranhThu.Rows[i].Cells[6].ReadOnly = false;
            }
            if (dtgvXemDSTranhThu.Rows[i].Cells[5].ReadOnly = true && Convert.ToInt32(dtgvXemDSTranhThu.Rows[i].Cells[6].Value) == 1 && Convert.ToInt32(dtgvXemDSTranhThu.Rows[i].Cells[5].Value) == 1)
            {
                string sql = "update VeRANgoai"
                       + "set cDuyetVe = '" + DateTime.Now + "'";
                DataTable dtb = db.getDS(sql);
                dtgvXemDSTranhThu.Rows[i].Cells[6].ReadOnly = true;
            }
        }

        private void dtgvXemDSTranhThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXemChiTiet.Enabled = true;
        }

        private void cmbLop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow dtr = XNTT.LoadQuanSo(cmbLop.Text, this.maCB);
            txQuanSo.Text = dtr[0].ToString();
            //load datagridview
            DataRow dtr1 = XNTT.TenLopTruong(cmbLop.Text, this.maCB);
            txLopTruong.Text = dtr1[0].ToString();
            DataTable dtb = XNTT.Load_dtgv(dtpThoiGianDuyet.Text, this.maCB);
            dtgvXemDSTranhThu.DataSource = dtb;

        }
    }
}
