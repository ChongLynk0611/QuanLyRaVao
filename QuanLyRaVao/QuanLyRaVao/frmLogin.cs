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
using QuanLyRaVao.DAL;
using QuanLyRaVao.BLL;

namespace QuanLyRaVao
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        DBAccess db = new DBAccess();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.login();
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
        private void login()
        {
            string mk = MD5(txtPass.Text);

            string tk = "Select *from TaiKhoan where id_TaiKhoan = '" + txtUser.Text + "' and MatKhau = '" + mk + "' and XacNhan = 1";
            try
            {
                DataTable dt = db.getDS(tk);

                if(dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    if(r["id_ChucVu"].ToString() == "1" || r["id_ChucVu"].ToString() == "2")
                    {
                        this.Hide();
                        frmMainHV fm = new frmMainHV(r["id_TaiKhoan"].ToString());
                        fm.ShowDialog();
                        this.Close();
                    }
                    else if(r["id_ChucVu"].ToString() == "4")
                    {
                        this.Hide();
                        frmMainVB fm = new frmMainVB(r["id_TaiKhoan"].ToString());
                        fm.ShowDialog();
                        this.Close();
                    }
                    else if (r["id_ChucVu"].ToString() == "3")
                    {
                        this.Hide();
                        frmMainCB fm = new frmMainCB(r["id_TaiKhoan"].ToString());
                        fm.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegister fm = new frmRegister();
            fm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}