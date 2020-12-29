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
using QuanLyRaVao.DAL;
using QuanLyRaVao.BLL.HocVien;
using QuanLyRaVao.DTO;

namespace QuanLyRaVao.GUI.HocVien
{
    public partial class DangKyRaVao_GUI : DevExpress.XtraEditors.XtraUserControl
    {

        DangKyRaVao_BLL DKRV = new DangKyRaVao_BLL();

        private List<string> Errors;
        private string maHV;
        public DangKyRaVao_GUI(string mahv)
        {
            this.maHV = mahv;
            Errors = new List<string>();
            InitializeComponent();
        }

        private void SetEnable() {
            cbKieuDK.Enabled = false;
            dtpTGDi.Enabled = false;
            dtpTGVe.Enabled = false;
            txtlyDo.Enabled = false;
            txtDiaDiem.Enabled = false;

        }

        private void DangKyRaVao_GUI_Load(object sender, EventArgs e)
        {
            dtpTGDi.Format = DateTimePickerFormat.Custom;
            dtpTGDi.CustomFormat = "dd/MM/yyyy hh:mm tt";
            dtpTGVe.Format = DateTimePickerFormat.Custom;
            dtpTGVe.CustomFormat = "dd/MM/yyyy hh:mm tt";

            // load dữ liệu kiểu đăng ký
            DataTable dataKieuDK = DKRV.GetLoaiDK();
            cbKieuDK.Properties.DataSource= dataKieuDK;
            cbKieuDK.Properties.DisplayMember = "TenDangKy";
            cbKieuDK.Properties.ValueMember = "id_LoaiDangKy";

            // check xem tài học viên đã đăng ký chưa
            int id_DangKy = DKRV.CheckPhieuDK(this.maHV);

            // trường hợp đã có phiếu mà chưa được lớp duyệt thì vẫn sửa đc
            if (id_DangKy != -1)
            {
                btn_Tao.Enabled = true;
                DataRow PhieuDK = DKRV.GetDK(id_DangKy);
                SetEnable();
                btn_Tao.Enabled = false;
                btn_CapNhat.Enabled = false;
                // cập nhật các trường dữ liệu
                cbKieuDK.Text = PhieuDK[3].ToString();
                dtpTGDi.Text = PhieuDK[6].ToString();
                dtpTGVe.Text = PhieuDK[7].ToString();
                txtDiaDiem.Text = PhieuDK[5].ToString();
                txtlyDo.Text = PhieuDK[4].ToString();
                MessageBox.Show("đã đăng ký mà lớp chưa duyệt");
            }
            // trường hợp không thể sửa đc 
            else
            {
                bool c = DKRV.checkTao(this.maHV);
                if (c)
                {
                    btn_Tao.Enabled = true;
                    btn_CapNhat.Enabled = false;
                    btn_Sua.Enabled = false;
                }
                else
                {
                    btn_CapNhat.Enabled =true;
                    btn_Sua.Enabled = true;
                    cbKieuDK.Enabled= true;
                    dtpTGDi.Enabled =true;
                    dtpTGVe.Enabled =true;
                    txtDiaDiem.Enabled = true;
                }
            
            }
            


        }

        private bool check()
        {
            int check = 0;
            if(cbKieuDK.Text == "[EditValue is null]")
            {
                this.Errors.Add("Chưa chọn loại đăng ký");
                check = 1;
            }
            if(txtDiaDiem.Text == "")
            {
                this.Errors.Add("Chưa nhập địa điểm đăng ký");
                check = 1;
            }
            if (txtlyDo.Text == "")
            {
                this.Errors.Add("Chưa nhập lý do");
                check = 1;
            }
            if(DateTime.Compare(dtpTGDi.Value , DateTime.Now) == -1)
            {
                this.Errors.Add("Ngày đăng ký đi không hợp lệ");
                check = 1;
            }
            if (DateTime.Compare(dtpTGVe.Value, DateTime.Now) == -1)
            {
                this.Errors.Add("Ngày đăng ký về không hợp lệ");
                check = 1;
            }

            if (DateTime.Compare(dtpTGDi.Value, dtpTGVe.Value) == 1)
            {
                this.Errors.Add("Ngày đăng ký đi không được sau ngày đăng ký về");
                check = 1;
            }

            if(check == 1)
            {
                return false;
            }

            return true;



        }
        // sự kiện tạo đăng ký
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // đã check hết các điều kiện
            if (check())
            {
                int id_DSDK =  DKRV.CheckDSDangKy(this.maHV);
                // Người đầu tiên của lớp đăng ký
                if(id_DSDK == -1)
                {
                    DangKy_DTO dk = new DangKy_DTO();
                    dk.Id_DSdangKy = id_DSDK;
                    dk.Id_taiKhoan = this.maHV;
                    dk.Id_loaiDangKy = (int)cbKieuDK.EditValue;
                    dk.LyDo = txtlyDo.Text;
                    dk.DiaDiem = txtDiaDiem.Text;
                    dk.ThoiDangKyDi = dtpTGDi.Value;
                    dk.ThoiDangKyVe = dtpTGVe.Value;
                    DKRV.InsertDangKy(dk);
                    MessageBox.Show("Đăng ký thành công");
                    btn_Tao.Enabled = false;
                    btn_Sua.Enabled = true;
                  
                }
                // đã có người đăng ký trước đó
                else
                {
                    DangKy_DTO dk = new DangKy_DTO();
                    dk.Id_DSdangKy = id_DSDK;
                    dk.Id_taiKhoan = this.maHV;
                    dk.Id_loaiDangKy = (int)cbKieuDK.EditValue;
                    dk.LyDo = txtlyDo.Text;
                    dk.DiaDiem = txtDiaDiem.Text;
                    dk.ThoiDangKyDi = dtpTGDi.Value;
                    dk.ThoiDangKyVe = dtpTGVe.Value;
                    DKRV.InsertDangKy(dk);
                    MessageBox.Show("Đăng ký thành công");
                    btn_Tao.Enabled = false;
                    btn_Sua.Enabled = true;
                }
            }
            //còn lỗi chưa cho phép đăng ký
            else
            {
                string Loi = "";
                foreach(var loi in this.Errors)
                {
                    Loi += loi + "\n";
                }
                MessageBox.Show(Loi);
                this.Errors.Clear();
            }

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            cbKieuDK.Enabled = true;
            dtpTGDi.Enabled = true;
            dtpTGVe.Enabled = true;
            txtlyDo.Enabled = true;
            txtDiaDiem.Enabled = true;
            btn_Sua.Enabled = false;
            btn_CapNhat.Enabled = true;
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {

        }
    }
}
