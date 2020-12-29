using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao.DTO
{
    class LoaiDangKy_DTO
    {
        private int id_loaiDangKy;
        private string tenDangKy;

        public string TenDangKy { get => tenDangKy; set => tenDangKy = value; }
        public int Id_loaiDangKy { get => id_loaiDangKy; set => id_loaiDangKy = value; }
    }
}
