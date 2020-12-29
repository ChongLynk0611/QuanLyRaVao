using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao.DTO
{
    class ViPham_DTO
    {
        private int id_viPham;
        private string id_hocVien;
        private string id_nguoiGhi;
        private DateTime thoiGian;
        private string chiTietLoi;

        public string Id_hocVien { get => id_hocVien; set => id_hocVien = value; }
        public string Id_nguoiGhi { get => id_nguoiGhi; set => id_nguoiGhi = value; }
        public DateTime ThoiGian { get => thoiGian; set => thoiGian = value; }
        public string ChiTietLoi { get => chiTietLoi; set => chiTietLoi = value; }
        public int Id_viPham { get => id_viPham; set => id_viPham = value; }
    }
}
