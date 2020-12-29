using QuanLyRaVao.DAL;
using QuanLyRaVao.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao.BLL
{
    class Register_BLL
    {
        DBAccess db = new DBAccess();
        public DataTable KtraTK(string id_TK)
        {
            string sql = "select *from TaiKhoan where id_TaiKhoan = '" + id_TK + "'";
            return db.getDS(sql);
        }
        public bool addTK(TaiKhoan_DTO user)
        {
            if(user.Id_chucVu == 1 || user.Id_chucVu == 2)
            {
                string NgaySinh = user.NgaySinh.Year.ToString() + "-" + user.NgaySinh.Month.ToString() + "-" + user.NgaySinh.Day.ToString();
                string[] param = { "@id_TK", "@matKhau", "@hoTen", "@ngaySinh", "@id_CapBac", "@id_ChucVu", "@id_DonVi", "@id_ChuyenNganh" };
                object[] values = { user.Id_taiKhoan, user.MatKhau, user.HoTen, NgaySinh, user.Id_capBac, user.Id_chucVu, user.Id_donVi, user.Id_chuyenNganh };
                string query = "insert into TaiKhoan(id_TaiKhoan,MatKhau,HoTen,NgaySinh,id_CapBac,id_ChucVu,id_DonVi,id_ChuyenNganh) values(@id_TK,@matKhau,@hoTen,@ngaySinh,@id_CapBac,@id_ChucVu,@id_DonVi,@id_ChuyenNganh)";
                return db.ExecuteNonQueryPara(query, param, values);
            }
            else if(user.Id_chucVu == 6)
            {
                string NgaySinh = user.NgaySinh.Year.ToString() + "-" + user.NgaySinh.Month.ToString() + "-" + user.NgaySinh.Day.ToString();
                int maDonVi = 10;
                string[] param = { "@id_TK", "@matKhau", "@hoTen", "@ngaySinh", "@id_CapBac", "@id_ChucVu", "@id_DonVi" };
                object[] values = { user.Id_taiKhoan, user.MatKhau, user.HoTen, NgaySinh, user.Id_capBac, user.Id_chucVu, maDonVi};
                string query = "insert into TaiKhoan(id_TaiKhoan,MatKhau,HoTen,NgaySinh,id_CapBac,id_ChucVu,id_DonVi) values(@id_TK,@matKhau,@hoTen,@ngaySinh,@id_CapBac,@id_ChucVu,@id_DonVi)";
                return db.ExecuteNonQueryPara(query, param, values);
            }
            else
            {
                string NgaySinh = user.NgaySinh.Year.ToString() + "-" + user.NgaySinh.Month.ToString() + "-" + user.NgaySinh.Day.ToString();
                string[] param = { "@id_TK", "@matKhau", "@hoTen", "@ngaySinh", "@id_CapBac", "@id_ChucVu", "@id_DonVi" };
                object[] values = { user.Id_taiKhoan, user.MatKhau, user.HoTen, NgaySinh, user.Id_capBac, user.Id_chucVu, user.Id_donVi };
                string query = "insert into TaiKhoan(id_TaiKhoan,MatKhau,HoTen,NgaySinh,id_CapBac,id_ChucVu,id_DonVi) values(@id_TK,@matKhau,@hoTen,@ngaySinh,@id_CapBac,@id_ChucVu,@id_DonVi)";
                return db.ExecuteNonQueryPara(query, param, values);
            }
        }
        public DataTable dsCapBac()
        {
            string sql = "select id_CapBac,TenCapBac from CapBac";
            return db.getDS(sql);
        }
        public DataTable dsChucVu()
        {
            string sql = "select id_ChucVu,TenChucVu from ChucVu";
            return db.getDS(sql);
        }
        public DataTable dsDonVi()
        {
            string sql = "select id_DonVi,TenDV from DonVi";
            return db.getDS(sql);
        }
        public DataTable dsChuyenNganh()
        {
            string sql = "select id_ChuyenNganh,TenChuyenNganh from ChuyenNganh";
            return db.getDS(sql);
        }
        public static string EncryptMD5(string sToEncrypt)
        {
            System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
            byte[] bytes = ue.GetBytes(sToEncrypt);

            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashBytes = md5.ComputeHash(bytes);

            string hashString = "";
            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashString += Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
            }

            return hashString.PadLeft(2, '0');
        }

    }
}
