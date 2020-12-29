using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao.DTO
{
    class DangKy_DTO
    {
        private int id_dangKy;

        private int id_DSdangKy;

        private string id_taiKhoan;

        private int id_loaiDangKy;

        private string lyDo;
        private string diaDiem;

        private DateTime thoiDangKyDi;

        private DateTime thoiDangKyVe;

        private bool trangThai;
        private bool TTLop;

        public int Id_dangKy { get => id_dangKy; set => id_dangKy = value; }
        public int Id_DSdangKy { get => id_DSdangKy; set => id_DSdangKy = value; }
        public string Id_taiKhoan { get => id_taiKhoan; set => id_taiKhoan = value; }
        public int Id_loaiDangKy { get => id_loaiDangKy; set => id_loaiDangKy = value; }
        public string LyDo { get => lyDo; set => lyDo = value; }
        public DateTime ThoiDangKyDi { get => thoiDangKyDi; set => thoiDangKyDi = value; }
        public DateTime ThoiDangKyVe { get => thoiDangKyVe; set => thoiDangKyVe = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
        public string DiaDiem { get => diaDiem; set => diaDiem = value; }
        public bool TTLop1 { get => TTLop; set => TTLop = value; }
    }
}
