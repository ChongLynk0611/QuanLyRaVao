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

namespace QuanLyRaVao
{
    public partial class frmRegister : DevExpress.XtraEditors.XtraForm
    {
        Register_BLL DKuser = new Register_BLL();
        public frmRegister()
        {
            InitializeComponent();
        }
        private TaiKhoan_DTO getdataUser()
        {
            TaiKhoan_DTO user = new TaiKhoan_DTO();
            user.Id_taiKhoan = txtUser.Text;
            user.MatKhau = Register_BLL.EncryptMD5(txtRePass.Text);
            user.HoTen = txtHoTen.Text;
            user.NgaySinh = Convert.ToDateTime(dateNgaySinh.Value);
            user.Id_capBac = Convert.ToInt32(cbCapBac.EditValue.ToString());
            user.Id_chucVu = Convert.ToInt32(cbChucVu.EditValue.ToString());
            user.Id_donVi = Convert.ToInt32(cbDonVi.EditValue.ToString());
            user.Id_chuyenNganh = Convert.ToInt32(cbChuyenNganh.EditValue.ToString());

            return user;
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            DataTable dt1 = DKuser.dsCapBac();
            cbCapBac.Properties.DataSource = dt1;
            cbCapBac.Properties.DisplayMember = "TenCapBac";
            cbCapBac.Properties.ValueMember = "id_CapBac";

            DataTable dt2 = DKuser.dsChucVu();
            cbChucVu.Properties.DataSource = dt2;
            cbChucVu.Properties.DisplayMember = "TenChucVu";
            cbChucVu.Properties.ValueMember = "id_ChucVu";

            DataTable dt3 = DKuser.dsDonVi();
            cbDonVi.Properties.DataSource = dt3;
            cbDonVi.Properties.DisplayMember = "TenDV";
            cbDonVi.Properties.ValueMember = "id_DonVi";

            DataTable dt4 = DKuser.dsChuyenNganh();
            cbChuyenNganh.Properties.DataSource = dt4;
            cbChuyenNganh.Properties.DisplayMember = "TenChuyenNganh";
            cbChuyenNganh.Properties.ValueMember = "id_ChuyenNganh";

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin fm = new frmLogin();
            fm.Show();
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtUser.Text == "" || txtHoTen.Text == "" || txtPass.Text == "" || txtRePass.Text == "" 
                || cbCapBac.Text == "" || cbChucVu.Text == "" || cbDonVi.Text == "" 
                || cbChuyenNganh.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ các thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
            else if(txtPass.Text != txtRePass.Text)
            {
                MessageBox.Show("Bạn cần nhập lại mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(dateNgaySinh.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh bạn nhập không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
            else
            {
                DataTable dt = DKuser.KtraTK(txtUser.Text);
                if(dt.Rows.Count == 0)
                {
                    TaiKhoan_DTO user = getdataUser();
                    DKuser.addTK(user);
                    DialogResult result = MessageBox.Show("Đăng ký tài khoản thành công", "Thông báo", MessageBoxButtons.OK);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Hide();
                        frmLogin fm = new frmLogin();
                        fm.Show();
                    }
                }    
                else
                {
                    MessageBox.Show("Tài khoản bạn nhập đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }    
        }

        private void cbChucVu_EditValueChanged(object sender, EventArgs e)
        {
            if (cbChucVu.Text.ToString() == "Vệ binh")
            {
                cbDonVi.Enabled = false;
                cbDonVi.EditValue = 10;
                cbChuyenNganh.Enabled = false;
                cbChuyenNganh.EditValue = 1;
                cbChuyenNganh.Hide();
            }
            else if (cbChucVu.Text.ToString() == "Học viên" || cbChucVu.Text.ToString() == "Lớp trưởng")
            {
                cbDonVi.Enabled = true;
                cbChuyenNganh.Enabled = true;
                cbChuyenNganh.Show();
                cbChuyenNganh.EditValue = null;
                cbDonVi.EditValue = null;
            }
            else
            {
                cbChuyenNganh.Enabled = false;
                cbChuyenNganh.EditValue = null;
                cbChuyenNganh.Hide();
            }
        }
    }
}