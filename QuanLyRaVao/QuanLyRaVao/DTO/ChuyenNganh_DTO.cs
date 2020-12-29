using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao.DTO
{
    class ChuyenNganh_DTO
    {
        private string tenChuyenNganh;
        private int id_chuyenNganh;

        public string TenChuyenNganh { get => tenChuyenNganh; set => tenChuyenNganh = value; }
        public int Id_chuyenNganh { get => id_chuyenNganh; set => id_chuyenNganh = value; }
    }
}
