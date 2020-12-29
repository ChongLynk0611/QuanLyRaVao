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
using QuanLyRaVao.BLL;
using QuanLyRaVao.DTO;

namespace QuanLyRaVao.GUI.VeBinh
{
    public partial class DoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        private string id_TaiKhoan;
        TrangCaNhanVB TcnUser = new TrangCaNhanVB();
        public DoiMatKhau(string id_TaiKhoan)
        {
            this.id_TaiKhoan = id_TaiKhoan;
            InitializeComponent();
        }
        private TaiKhoan_DTO getdataUser()
        {
            TaiKhoan_DTO user = new TaiKhoan_DTO();
            user.MatKhau = Register_BLL.EncryptMD5(txtPass.Text);
            return user;
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            TaiKhoan_DTO user = getdataUser();
            if (txtPass.Text == txtRePass.Text)
            {
                if (TcnUser.editpass(user))
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    ///////////////////// chuyen sang file ca nhan
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại!");
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DoiMatKhau.ActiveForm.Close();
            this.Close();
        }
    }
}