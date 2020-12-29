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
    class TrangCaNhanVB
    {
        DBAccess db = new DBAccess();
        //public DataTable VeBinh()
        //{

        //}
        public DataTable InfoVB(string id_TK)
        {
            string sql = "select *from TaiKhoan where id_TaiKhoan = '" + id_TK + "'";
            return db.getDS(sql);
        }
        public DataTable dsCapBac()
        {
            string sql = "select *from CapBac";
            return db.getDS(sql);
        }
        public DataTable dsChucVu()
        {
            string sql = "select *from ChucVu";
            return db.getDS(sql);
        }
        public DataTable dsDonVi()
        {
            string sql = "select *from DonVi";
            return db.getDS(sql);
        }
        public DataTable GetCapBac(string id_TK)
        {
            string sql = "select TaiKhoan.id_CapBac from CapBac,TaiKhoan where CapBac.id_CapBac=TaiKhoan.id_CapBac and id_TaiKhoan = '" + id_TK + "'";
            return db.getDS(sql);
        }
        public DataTable GetChucVu(string id_TK)
        {
            string sql = "select TaiKhoan.id_ChucVu from ChucVu,TaiKhoan where ChucVu.id_ChucVu=TaiKhoan.id_ChucVu and id_TaiKhoan = '" + id_TK + "'";
            return db.getDS(sql);
        }
        public DataTable GetDonVi(string id_TK)
        {
            string sql = "select TaiKhoan.id_DonVi from DonVi,TaiKhoan where DonVi.id_DonVi=TaiKhoan.id_DonVi and id_TaiKhoan = '" + id_TK + "'";
            return db.getDS(sql);
        }
        public bool editUser(TaiKhoan_DTO user)
        {
            string NgaySinh = user.NgaySinh.Year.ToString() + "-" + user.NgaySinh.Month.ToString() + "-" + user.NgaySinh.Day.ToString();
            string[] param = { "@id_TK", "@hoTen", "@ngaySinh", "@id_CapBac"};
            object[] values = { user.Id_taiKhoan, user.HoTen, NgaySinh, user.Id_capBac};
            string query = "update TaiKhoan set HoTen=@hoTen,NgaySinh=@ngaySinh,id_CapBac=@id_CapBac where id_TaiKhoan=@id_TK";
            return db.ExecuteNonQueryPara(query, param, values);
        }
        public bool deleteUser(TaiKhoan_DTO user)
        {
            string[] param = { "@id_TK"};
            object[] values = { user.Id_taiKhoan };
            string query = "delete TaiKhoan where id_TaiKhoan=@id_TK";
            return db.ExecuteNonQueryPara(query, param, values);
        }
        public bool editpass(TaiKhoan_DTO user)
        {
            string[] param = { "@id_TK", "@matKhau"};
            object[] values = { user.Id_taiKhoan, user.MatKhau };
            string query = "update TaiKhoan set MatKhau=@matKhau where id_TaiKhoan=@id_TK";
            return db.ExecuteNonQueryPara(query, param, values);
        }
    }
}
