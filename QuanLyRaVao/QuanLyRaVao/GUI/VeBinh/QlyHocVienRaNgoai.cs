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
using System.IO;

namespace QuanLyRaVao.GUI.VeBinh
{
    public partial class QlyHocVienRaNgoai : UserControl
    {
        private string id_TaiKhoan;
        QlyHocVienRaNgoai_BLL QlHVRN = new QlyHocVienRaNgoai_BLL();
        public QlyHocVienRaNgoai(string id_TaiKhoan)
        {
            this.id_TaiKhoan = id_TaiKhoan;
            InitializeComponent();
        }

        private void QlyHocVienRaNgoai_Load(object sender, EventArgs e)
        {
            txtHoTen.Enabled = false;
            txtCapBac.Enabled = false;
            txtNgaySinh.Enabled = false;
            txtDonVi.Enabled = false;
            txtMaVe.Enabled = false;
            txtLyDo.Enabled = false;
            txtDiaDiem.Enabled = false;
            txtTGDKdi.Enabled = false;
            txtTGDKVe.Enabled = false;
            txtTenDk.Enabled = false;
            checkCBduyetDi.Enabled = false;
            checkCBduyetVe.Enabled = false;
            checkVBduyetDi.Enabled = false;
            checkVBduyetVe.Enabled = false;
            btnThemLoi.Enabled = false;
            txtMaDk.Dispose();
        }
        //private VeRaNgoai_DTO getdataVRN()
        //{
        //    VeRaNgoai_DTO vrn = new VeRaNgoai_DTO();
        //    vrn.Id_veRaNgoai = Convert.ToInt32(txtMaVe.Text);
        //    vrn.Id_dangKy = Convert.ToInt32(txtMaDk.Text);
        //    vrn.VbduyetDi = Convert.ToDateTime(txtTGdi.Text.Substring(0,19));
        //    vrn.VbduyetVe = Convert.ToDateTime(txtTGve.Text.Substring(0, 19));

        //    return vrn;
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMaHV.Text != "")
            {
                DataTable dt = QlHVRN.InfoHV(txtMaHV.Text);
                if (dt.Rows.Count != 0)
                {
                    txtHoTen.Text = dt.Rows[0]["HoTen"].ToString();
                    txtNgaySinh.Text = dt.Rows[0]["NgaySinh"].ToString().Substring(0, 11);
                    txtCapBac.Text = dt.Rows[0]["TenCapBac"].ToString();
                    txtDonVi.Text = dt.Rows[0]["TenDV"].ToString();

                    DataTable dtg = QlHVRN.DKyRN(txtMaHV.Text);

                    txtMaDk.Text = dtg.Rows[0]["id_DangKy"].ToString();
                    txtMaVe.Text = dtg.Rows[0]["id_VeRaNgoai"].ToString();
                    txtLyDo.Text = dtg.Rows[0]["LyDo"].ToString();
                    txtTenDk.Text = dtg.Rows[0]["TenDangKy"].ToString();
                    txtDiaDiem.Text = dtg.Rows[0]["DiaDiem"].ToString();
                    txtTGDKdi.Text = dtg.Rows[0]["ThoiGianDi"].ToString();
                    txtTGDKVe.Text = dtg.Rows[0]["ThoiGianVe"].ToString();
                    if(dt.Rows[0]["Avatar"] != null)
                    {
                        try
                        {
                            byte[] b = (byte[])(dt.Rows[0]["Avatar"]);
                            Avatar.Image = byteToImage(b);
                            Avatar.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch
                        {
                            Avatar.Image = null;
                        }

                    }

                    if (dtg.Rows[0]["cDuyetDi"].ToString() != "")
                    {
                        checkCBduyetDi.Checked = true;
                    }
                    else
                    {
                        checkCBduyetDi.Checked = false;
                    }
                    if (dtg.Rows[0]["cDuyetVe"].ToString() != "")
                    {
                        checkCBduyetVe.Checked = true;
                    }
                    else
                    {
                        checkCBduyetVe.Checked = false;
                    }

                    if (dtg.Rows[0]["vbDuyetDi"].ToString() != "")
                    {
                        checkVBduyetDi.Checked = true;
                        checkVBduyetDi.Enabled = false;
                    }
                    else
                    {
                        checkVBduyetDi.Enabled = true;
                        checkVBduyetDi.Checked = false;
                    }
                    if (dtg.Rows[0]["vbDuyetVe"].ToString() != "")
                    {
                        checkVBduyetVe.Checked = true;
                        checkVBduyetVe.Enabled = false;
                    }
                    else
                    {
                        checkVBduyetVe.Checked = false;
                    }   

                    if (checkCBduyetDi.Checked == true)
                    {
                        checkVBduyetDi.Enabled = true;
                    }
                    else
                    {
                        checkVBduyetDi.Enabled = false;
                    }
                    if (checkVBduyetDi.Checked == true)
                    {
                        checkVBduyetDi.Enabled = false;
                        checkVBduyetVe.Enabled = true;
                    }
                    else
                    {
                        txtTGdi.Text = "";
                    }
                    if (checkVBduyetVe.Checked == true)
                    {
                        checkVBduyetVe.Enabled = false;
                    }
                    else
                    {
                        txtTGve.Text = "";
                    }
                    btnThemLoi.Enabled = true;

                    
                }
                else
                {
                    MessageBox.Show("Không tìm thấy học viên phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void checkVBduyetDi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVBduyetDi.Checked == true)
            {
                checkVBduyetVe.Enabled = true;
                checkVBduyetDi.Enabled = false;
                txtTGdi.Text = DateTime.Now.ToString();
                QlHVRN.CapNhatVRN1(txtMaVe.Text);
            }
        }

        private void checkVBduyetVe_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVBduyetVe.Checked == true)
            {
                checkVBduyetVe.Enabled = false;
                txtTGve.Text = DateTime.Now.ToString();
                QlHVRN.CapNhatVRN2(txtMaVe.Text);
            }
        }

        private void btnThemLoi_Click(object sender, EventArgs e)
        {
            ThemLoi them_Loi = new ThemLoi(txtMaHV.Text, id_TaiKhoan);
            them_Loi.ShowDialog();
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
