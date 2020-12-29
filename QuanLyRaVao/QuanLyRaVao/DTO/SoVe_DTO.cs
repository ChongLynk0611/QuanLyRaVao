using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao.DTO
{
    class SoVe_DTO
    {
        private int id_soVe;
        private int soVe;
        private int id_donVi;
        private int trangThai;

        public int SoVe { get => soVe; set => soVe = value; }
        public int Id_donVi { get => id_donVi; set => id_donVi = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public int Id_soVe { get => id_soVe; set => id_soVe = value; }
    }
}
