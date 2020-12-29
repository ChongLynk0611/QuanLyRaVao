using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyRaVao.BLL;
using QuanLyRaVao.DTO;
using QuanLyRaVao.GUI;
using QuanLyRaVao.GUI.VeBinh;
using System.IO;

namespace QuanLyRaVao.GUI.VeBinh
{
    public partial class TrangCaNhan : UserControl
    {
        private string id_TaiKhoan;
        TrangCaNhanVB TcnUser = new TrangCaNhanVB();
        public TrangCaNhan(string id_TaiKhoan)
        {
            this.id_TaiKhoan = id_TaiKhoan;
            InitializeComponent();
        }

        private TaiKhoan_DTO getdataUser()
        {
            TaiKhoan_DTO user = new TaiKhoan_DTO();
            user.Id_taiKhoan = txtUser.Text;
            user.MatKhau = Register_BLL.EncryptMD5(txtPass.Text);
            user.HoTen = txtHoTen.Text;
            user.NgaySinh = Convert.ToDateTime(dateNgaySinh.Value);
            user.Id_capBac = Convert.ToInt32(cbCapBac.EditValue.ToString());
            user.Id_chucVu = Convert.ToInt32(cbChucVu.EditValue.ToString());
            user.Id_donVi = Convert.ToInt32(cbDonVi.EditValue.ToString());

            return user;
        }


        private void TrangCaNhan_Load(object sender, EventArgs e)
        {
            txtUser.Text = id_TaiKhoan;
            txtUser.Enabled = false;
            txtPass.Enabled = false;
            txtHoTen.Enabled = false;
            dateNgaySinh.Enabled = false;
            cbCapBac.Enabled = false;
            cbChucVu.Enabled = false;
            cbDonVi.Enabled = false;
            btnUpdate.Enabled = false;

            DataTable dt = TcnUser.InfoVB(id_TaiKhoan);
            DataTable dtCB = TcnUser.GetCapBac(id_TaiKhoan);
            DataTable dtCV = TcnUser.GetChucVu(id_TaiKhoan);
            DataTable dtDV = TcnUser.GetDonVi(id_TaiKhoan);
            
            DataTable dtCB1 = TcnUser.dsCapBac();
            cbCapBac.Properties.DataSource = dtCB1;
            cbCapBac.Properties.DisplayMember = "TenCapBac";
            cbCapBac.Properties.ValueMember = "id_CapBac";

            DataTable dtCV1 = TcnUser.dsChucVu();
            cbChucVu.Properties.DataSource = dtCV1;
            cbChucVu.Properties.DisplayMember = "TenChucVu";
            cbChucVu.Properties.ValueMember = "id_ChucVu";

            DataTable dtDV1 = TcnUser.dsDonVi();
            cbDonVi.Properties.DataSource = dtDV1;
            cbDonVi.Properties.DisplayMember = "TenDV";
            cbDonVi.Properties.ValueMember = "id_DonVi";

            txtPass.Text = dt.Rows[0]["MatKhau"].ToString();
            txtHoTen.Text = dt.Rows[0]["HoTen"].ToString();
            dateNgaySinh.Text = dt.Rows[0]["NgaySinh"].ToString();
            cbCapBac.EditValue = Convert.ToInt32(dt.Rows[0]["id_CapBac"].ToString());
            cbChucVu.EditValue = Convert.ToInt32(dt.Rows[0]["id_ChucVu"].ToString());
            cbDonVi.EditValue = Convert.ToInt32(dt.Rows[0]["id_DonVi"].ToString());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDoiMK.Enabled = false;
            txtHoTen.Enabled = true;
            dateNgaySinh.Enabled = true;
            cbCapBac.Enabled = true;

            DataTable dtCB = TcnUser.dsCapBac();
            cbCapBac.Properties.DataSource = dtCB;
            cbCapBac.Properties.DisplayMember = "TenCapBac";
            cbCapBac.Properties.ValueMember = "id_CapBac";

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnDoiMK.Enabled = true;
            txtHoTen.Enabled = false;
            dateNgaySinh.Enabled = false;
            cbCapBac.Enabled = false;
            btnUpdate.Enabled = false;

            TaiKhoan_DTO user = getdataUser();
            if (TcnUser.editUser(user))
            {
                MessageBox.Show("Chỉnh sửa tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra. Chỉnh sửa thất bại!");
            }

        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMK = new DoiMatKhau(id_TaiKhoan);
            doiMK.Show();
        }

        private void btnTDADD_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            //Filter
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Avatar.Image = Image.FromFile(open.FileName);
                Avatar.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        // chuyển image thành byte[]
        byte[] imagetoarray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        // chuyển byte[] về image
        Image byteToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }
    }
}
