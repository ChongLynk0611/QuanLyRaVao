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
using QuanLyRaVao.GUI;
using System.IO;

namespace QuanLyRaVao.GUI.HocVien
{
    public partial class TrangCaNhan_GUI : DevExpress.XtraEditors.XtraUserControl
    {
        TrangCaNhan TCNBLL = new TrangCaNhan();
        DBAccess db = new DBAccess();

        private string maHV;
        private List<string> loiCapNhat;
        public TrangCaNhan_GUI(string maHV)
        {
            //string maHV
            this.maHV = maHV;
            loiCapNhat = new List<string>();
            InitializeComponent();
        }


        //  load form lên tất cả các trường dữ liệu chỉ xem chưa đc sửa
        private void TrangCaNhan_GUI_Load(object sender, EventArgs e)
        {
            btnCapNhat.Enabled = false;
            btn_DoiAvatar.Enabled = false;
            txt_MaHV.Enabled = false;
            txt_HoVaTen.Enabled = false;
            dtpNgaySinh.Enabled = false;
            cbLop.Enabled = false;
            cbDonVi.Enabled = false;
            cbCapBac.Enabled = false;
            cbChucVu.Enabled = false;
            loadData();
            loadDataCombobox();
        }

        // load dữ liệu của học viên lên form Trang cá nhân
        private void loadData()
        {
            DataRow r = TCNBLL.infoHocVien(maHV);
            txt_MaHV.Text = r[0].ToString();
            txt_HoVaTen.Text = r[1].ToString();
            dtpNgaySinh.Text = r[2].ToString();
            cbLop.Text = r[6].ToString();
            cbDonVi.Text = r[5].ToString();
            cbCapBac.Text = r[3].ToString();
            cbChucVu.Text = r[4].ToString();

            try
            {
                byte[] b = (byte[])(r[7]);
                Avatar.Image = byteToImage(b);
                Avatar.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
                Avatar.Image = null;
            }

        }

        // load các trường dữ liệu vào combobox
        private void loadDataCombobox()
        {
            // load data lớp
            DataTable dataLop = TCNBLL.DSLop();
            cbLop.DataSource = dataLop;
            cbLop.DisplayMember = "TenChuyenNganh";
            cbLop.ValueMember = "id_ChuyenNganh";

            // load data đơn vị
            DataTable dataDonVi = TCNBLL.DSDonVi();
            cbDonVi.DataSource = dataDonVi;
            cbDonVi.DisplayMember = "TenDV";
            cbDonVi.ValueMember = "id_DonVi";

            // load data cấp bậc
            DataTable dataCapBac = TCNBLL.DSCapBac();
            cbCapBac.DataSource = dataCapBac;
            cbCapBac.DisplayMember = "TenCapBac";
            cbCapBac.ValueMember = "id_CapBac";

            // load data chức vụ
            DataTable dataChucVu = TCNBLL.DSChucVu();
            cbChucVu.DataSource = dataChucVu;
            cbChucVu.DisplayMember = "TenChucVu";
            cbChucVu.ValueMember = "id_ChucVu";



        }

        // click btn_sua các trường dữ liệu cho phép sửa thông tin
        private void btnSua_Click(object sender, EventArgs e)
        {
            btnCapNhat.Enabled = true;
            btn_DoiAvatar.Enabled = true;
            txt_HoVaTen.Enabled = true;
            dtpNgaySinh.Enabled = true;
            cbLop.Enabled = true;
            cbDonVi.Enabled = true;
            cbCapBac.Enabled = true;
            cbChucVu.Enabled = true;
            btnCapNhat.Enabled =true;
            btnSua.Enabled = false;
        }

        //kiểm tra điều kiện các input để cập nhật
        private bool check()
        {
            int Check = 0;      // biến để check xem có lỗi khi cập nhật hay không
            if (txt_HoVaTen.Text == "")
            {
                Check = 1;
                loiCapNhat.Add("Chưa nhập tên");
            }
            if (dtpNgaySinh.Text == "" || dtpNgaySinh.Value.Year > DateTime.Now.Year)
            {
                Check = 1;
                loiCapNhat.Add("Năm nhập chưa chính xác");
            }
            if (cbLop.Text == "")
            {
                Check = 1;
                loiCapNhat.Add("Chưa nhập lớp");
            }
            if(cbDonVi.Text == "")
            {
                Check = 1;
                loiCapNhat.Add("Chưa nhập đơn vị");
            }
            if(cbCapBac.Text == "")
            {
                Check = 1;
                loiCapNhat.Add("Chưa nhập cấp bậc");
            }
            if(cbChucVu.Text == "")
            {
                Check = 1;
                loiCapNhat.Add("Chưa nhập chức vụ");
            }
            if (!db.checkExist("ChuyenNganh", "TenChuyenNganh", cbLop.Text.ToString()))
            {
                Check = 1;
                loiCapNhat.Add("Chỉ chọn lớp trong combobox");
            }
            if (!db.checkExist("DonVi", "TenDV", cbDonVi.Text.ToString()))
            {
                Check = 1;
                loiCapNhat.Add("Chỉ chọn tên đơn vị trong combobox");
            }
            if (!db.checkExist("CapBac", "TenCapBac", cbCapBac.Text.ToString()))
            {
                Check = 1;
                loiCapNhat.Add("Chỉ chọn cấp bậc trong combobox");
            }
            if (!db.checkExist("ChucVu", "TenChucVu", cbChucVu.Text.ToString()))
            {
                Check = 1;
                loiCapNhat.Add("Chỉ chọn chức vụ có trong combobox");
            }
            if (Check == 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }


        // khi click vào button cập nhật
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            bool c = check();
            // th có lỗi
            if(c)
            {
                string Loi = "Lỗi cập nhật !!!\n";
                foreach(var loi in this.loiCapNhat)
                {
                    Loi += loi + "\n";
                }

                MessageBox.Show(Loi);
                this.loiCapNhat.Clear();
            }
            // th không có lỗi
            else
            {
                btnSua.Enabled = true;
                btnCapNhat.Enabled = false;
                btn_DoiAvatar.Enabled = false;
                TaiKhoan_DTO TK = new TaiKhoan_DTO();
                TK.HoTen = txt_HoVaTen.Text;
                TK.NgaySinh = dtpNgaySinh.Value;
                TK.Id_chuyenNganh =Convert.ToInt32( cbLop.SelectedValue);
                TK.Id_donVi = Convert.ToInt32(cbDonVi.SelectedValue);
                TK.Id_capBac = Convert.ToInt32(cbDonVi.SelectedValue);
                TK.Id_chucVu = Convert.ToInt32(cbChucVu.SelectedValue);
                if(Avatar.Image != null) { 
                    byte[] b = imagetoarray(Avatar.Image);
                    TK.Avatar1 = b;
                    TCNBLL.UpdateHocVien(this.maHV, TK);
                    txt_MaHV.Enabled = false;
                    txt_HoVaTen.Enabled = false;
                    dtpNgaySinh.Enabled = false;
                    cbLop.Enabled = false;
                    cbDonVi.Enabled = false;
                    cbCapBac.Enabled = false;
                    cbChucVu.Enabled = false;
                    MessageBox.Show("Cập nhật thành công !!!");
                }
                else
                {
                    TCNBLL.UpdateHocVien(this.maHV, TK);
                    txt_MaHV.Enabled = false;
                    txt_HoVaTen.Enabled = false;
                    dtpNgaySinh.Enabled = false;
                    cbLop.Enabled = false;
                    cbDonVi.Enabled = false;
                    cbCapBac.Enabled = false;
                    cbChucVu.Enabled = false;
                    MessageBox.Show("Cập nhật thành công !!!");
                }
               

            }
           
            
        }

        // sự kiện đổi mật khẩu
        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            DoiMatKhau_GUI dmk = new DoiMatKhau_GUI(this.maHV);
            dmk.ShowDialog();
            
        }



        // chọn ảnh đại diện
        private void simpleButton1_Click(object sender, EventArgs e)
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
