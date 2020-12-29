using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao.DTO
{
    class DSDangKy_DTO
    {
        private int id_dsDangKy;
        private int id_lopTruong;
        private int id_canBo;
        private DateTime thoiGianDuyet;
        private int lopDuyet;
        private int cDuyet;

        public int Id_lopTruong { get => id_lopTruong; set => id_lopTruong = value; }
        public int Id_canBo { get => id_canBo; set => id_canBo = value; }
        public DateTime ThoiGianDuyet { get => thoiGianDuyet; set => thoiGianDuyet = value; }
        public int LopDuyet { get => lopDuyet; set => lopDuyet = value; }
        public int CDuyet { get => cDuyet; set => cDuyet = value; }
        public int Id_dsDangKy { get => id_dsDangKy; set => id_dsDangKy = value; }
    }
}
