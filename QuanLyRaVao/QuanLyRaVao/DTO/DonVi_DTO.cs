using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao.DTO
{
    class DonVi_DTO
    {
        private int id_donVi;
        private string tenDonVi;

        public string TenDonVi { get => tenDonVi; set => tenDonVi = value; }
        public int Id_donVi { get => id_donVi; set => id_donVi = value; }
    }
}
