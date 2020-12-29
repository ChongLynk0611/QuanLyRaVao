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

namespace QuanLyRaVao.GUI.HocVien
{
    public partial class DoiMatKhau_GUI : DevExpress.XtraEditors.XtraForm
    {
        private string maHV;
        TrangCaNhan dmk = new TrangCaNhan();
        public DoiMatKhau_GUI(string maHV)
        {
            this.maHV = maHV;
            InitializeComponent();
        }

        public string MD5(string mk)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(mk);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(txt_MK.Text == "" || txt_NhapLaiMK.Text == "")
            {
                MessageBox.Show("Lỗi : Nhập đầy đủ thông tin trước khi xác nhận");
            }
            else
            {
                if(txt_MK.Text != txt_NhapLaiMK.Text) {
                    MessageBox.Show("Lỗi: Mật khẩu nhập lại không chính xác!!!");
                }
                else
                {
                    string MKMaHoa = MD5(txt_MK.Text);

                    dmk.UpdateMK(this.maHV, MKMaHoa);
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.Close();
                }
            }
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txt_MK.PasswordChar = '*';//hiện thị mật khẩu bằng dấu *
            txt_NhapLaiMK.PasswordChar = '*';//hiện thị mật khẩu bằng dấu *
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            // nếu chọn hiện mật khẩu => cấu hình lại thuộc tính password
            if (showMK.Checked)
            {
                txt_MK.PasswordChar = (Char)0;//hiển thị lại mật khẩu nhập
                txt_NhapLaiMK.PasswordChar = (Char)0;//hiển thị lại mật khẩu nhập
            }
            // bỏ chọn chức năng hiện mật khẩu = > cấu hình lại thuộc tính password
            else
            {

                txt_MK.PasswordChar = '*';//hiện thị mật khẩu bằng dấu *
                txt_NhapLaiMK.PasswordChar = '*';//hiện thị mật khẩu bằng dấu *
            }


            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}