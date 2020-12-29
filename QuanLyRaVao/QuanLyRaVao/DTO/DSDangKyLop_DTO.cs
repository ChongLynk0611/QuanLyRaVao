using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao.DTO
{
    class DSDangKyLop_DTO
    {
        private int Id_DangKy;
        private string maHV;
        private string hoTen;
        private string tenDangKy;
        private string lyDo;
        private DateTime thoiGianDi;
        private DateTime thoiGianVe;
        private string diaDiem;
        private bool trangThai;

        public int Id_DangKy1 { get => Id_DangKy; set => Id_DangKy = value; }
        public string MaHV { get => maHV; set => maHV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string TenDangKy { get => tenDangKy; set => tenDangKy = value; }
        public string LyDo { get => lyDo; set => lyDo = value; }
        public DateTime ThoiGianDi { get => thoiGianDi; set => thoiGianDi = value; }
        public DateTime ThoiGianVe { get => thoiGianVe; set => thoiGianVe = value; }
        public string DiaDiem { get => diaDiem; set => diaDiem = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
