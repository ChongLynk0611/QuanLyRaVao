using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyRaVao.DTO;
using QuanLyRaVao.BLL;

namespace QuanLyRaVao.GUI.VeBinh
{
    public partial class ThemLoi : DevExpress.XtraEditors.XtraForm
    {
        private string id_NguoiGhi;
        private string id_HV;
        ThemLoiVP_BLL tLVP = new ThemLoiVP_BLL();
        public ThemLoi(string id_HV,string id_NguoiGhi)
        {
            this.id_HV = id_HV;
            this.id_NguoiGhi = id_NguoiGhi;
            InitializeComponent();
        }
        private void ShowQLHVRN(string id_NguoiGhi)
        {
            QlyHocVienRaNgoai frm = new QlyHocVienRaNgoai(id_NguoiGhi);
            frm.Show();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ThemLoi.ActiveForm.Close();
            ShowQLHVRN(id_NguoiGhi);
        }
        private ViPham_DTO getdataVP()
        {
            ViPham_DTO vp = new ViPham_DTO();
            vp.Id_hocVien = id_HV;
            vp.Id_nguoiGhi = id_NguoiGhi;
            vp.ThoiGian = DateTime.Now;
            vp.ChiTietLoi = rTxtChiTietLoi.Text;
            return vp;
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(rTxtChiTietLoi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ViPham_DTO vp = getdataVP();
                if(tLVP.addVP(vp))
                {
                    DialogResult result = MessageBox.Show("Thêm lỗi thành công", "Thông báo", MessageBoxButtons.OK);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        ThemLoi.ActiveForm.Close();
                        ShowQLHVRN(id_NguoiGhi);
                    }
                }
                else
                {
                    MessageBox.Show("Thêm lỗi thất bại!");
                }
            }
        }
    }
}