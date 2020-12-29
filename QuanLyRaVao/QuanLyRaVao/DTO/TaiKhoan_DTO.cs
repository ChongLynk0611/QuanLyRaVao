using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao.DTO
{
    class TaiKhoan_DTO
    {
        private string id_taiKhoan;
        private string matKhau;
        private string hoTen;
        private DateTime ngaySinh;
        private int id_capBac;
        private int id_chucVu;
        private int id_donVi;
        private int id_chuyenNganh;
        private int xacNhan;
        private byte[] Avatar;
        public string Id_taiKhoan { get => id_taiKhoan; set => id_taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public int Id_capBac { get => id_capBac; set => id_capBac = value; }
        public int Id_chucVu { get => id_chucVu; set => id_chucVu = value; }
        public int Id_donVi { get => id_donVi; set => id_donVi = value; }
        public int Id_chuyenNganh { get => id_chuyenNganh; set => id_chuyenNganh = value; }
        public int XacNhan { get => xacNhan; set => xacNhan = value; }
        public byte[] Avatar1 { get => Avatar; set => Avatar = value; }
    }
}
