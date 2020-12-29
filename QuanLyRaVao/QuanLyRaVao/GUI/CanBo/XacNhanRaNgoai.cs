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
    public partial class XacNhanRaNgoai : DevExpress.XtraEditors.XtraUserControl
    {
        DBAccess db = new DBAccess();
        XacNhanRaNgoai_BLL XNRN = new XacNhanRaNgoai_BLL();
        private string maCB;
        public XacNhanRaNgoai(string macb)
        {
            this.maCB = macb;
            InitializeComponent();
        }

        private void XacNhanRaNgoai_Load(object sender, EventArgs e)
        {
            DataRow dtr = XNRN.infoCanBo(this.maCB);
            
            txTenCanBo.Text = dtr[0].ToString();
            tcCapbacCanBo.Text = dtr[1].ToString();
            txChucvuCanBo.Text = dtr[2].ToString();
            DataRow dtr1 = XNRN.Load_datetime();
            
            DataTable dtr2 = XNRN.ComboboxLop(this.maCB);
            cmbLop.DataSource = dtr2;
            cmbLop.DisplayMember = "TenChuyenNganh";
            cmbLop.ValueMember = "id_ChuyenNganh";
        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dtgvXemDSRaNgoai_DataMemberChanged(object sender, EventArgs e)
        {
            int i = dtgvXemDSRaNgoai.CurrentRow.Index;
            int j = dtgvXemDSRaNgoai.CurrentCell.ColumnIndex;
            if(dtgvXemDSRaNgoai.Rows[i].Cells[6].ReadOnly = true && Convert.ToInt32(dtgvXemDSRaNgoai.Rows[i].Cells[5].Value) == 1&& Convert.ToInt32(dtgvXemDSRaNgoai.Rows[i].Cells[6].Value) == 0)
            {
                string sql = "update VeRANgoai"
                       + "set cDuyetDi = '" + DateTime.Now + "'";
                DataTable dtb = db.getDS(sql);
                dtgvXemDSRaNgoai.Rows[i].Cells[5].ReadOnly = true;
                dtgvXemDSRaNgoai.Rows[i].Cells[6].ReadOnly = false;
            }    
            if(dtgvXemDSRaNgoai.Rows[i].Cells[5].ReadOnly = true && Convert.ToInt32(dtgvXemDSRaNgoai.Rows[i].Cells[6].Value) == 1 && Convert.ToInt32(dtgvXemDSRaNgoai.Rows[i].Cells[5].Value) == 1)
            {
                string sql = "update VeRANgoai"
                       + "set cDuyetVe = '" + DateTime.Now + "'";
                DataTable dtb = db.getDS(sql);
                dtgvXemDSRaNgoai.Rows[i].Cells[6].ReadOnly = true;
            }
        }

        private void dtgvXemDSRaNgoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXemChiTiet.Enabled = true;
        }

        private void cmbLop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow dtr = XNRN.LoadQuanSo(cmbLop.Text, this.maCB);
            txQuanSo.Text = dtr[0].ToString();
            //load datagridview
            DataRow dtr1 = XNRN.TenLopTruong(cmbLop.Text, this.maCB);
            txLopTruong.Text = dtr1[0].ToString();
            DataTable dtb = XNRN.Load_dtgv( dtpThoiGianDuyet.Text, this.maCB);
            dtgvXemDSRaNgoai.DataSource = dtb;
        }
    }
}
