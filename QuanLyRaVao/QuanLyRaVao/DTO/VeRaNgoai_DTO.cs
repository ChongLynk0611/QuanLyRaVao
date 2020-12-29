using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao.DTO
{
    class VeRaNgoai_DTO
    {
        private int id_veRaNgoai;
        private int id_dangKy;
        private DateTime cduyetDi;
        private DateTime cduyetVe;
        private DateTime vbduyetDi;
        private DateTime vbduyetVe;

        public int Id_dangKy { get => id_dangKy; set => id_dangKy = value; }
        public DateTime CduyetDi { get => cduyetDi; set => cduyetDi = value; }
        public DateTime CduyetVe { get => cduyetVe; set => cduyetVe = value; }
        public DateTime VbduyetDi { get => vbduyetDi; set => vbduyetDi = value; }
        public DateTime VbduyetVe { get => vbduyetVe; set => vbduyetVe = value; }
        public int Id_veRaNgoai { get => id_veRaNgoai; set => id_veRaNgoai = value; }
    }
}
