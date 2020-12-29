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
    class TrangCaNhan
    {
        DBAccess db = new DBAccess();

        public DataRow infoHocVien(string maHV)
        {
            string query = "select * from infoHocVien where maHV = '"+maHV+"'";
            DataTable dtb = db.getDS(query);
            DataRow r = dtb.Rows[0];
            return r;
        }
        public DataTable DSLop()
        {
            string query = "select * from ChuyenNganh";
            DataTable dtb = db.getDS(query);
            return dtb;
        }
        public DataTable DSChucVu()
        {
            string query = "select * from ChuCVu";
            DataTable dtb = db.getDS(query);
            return dtb;
        }
        public DataTable DSCapBac()
        {
            string query = "select * from CapBac";
            DataTable dtb = db.getDS(query);
            return dtb;
        }
        public DataTable DSDonVi()
        {
            string query = "select * from DonVi";
            DataTable dtb = db.getDS(query);
            return dtb;
        }
        public bool UpdateHocVien(string maHV , TaiKhoan_DTO HV)
        {
            if(HV.Avatar1 != null)
            {
                string[] param = { "@HoTen", "@NgaySinh", "@id_ChuyenNganh", "@id_DonVi", "@id_CapBac", "@id_ChucVu", "@Avatar", "@maHV" };
                object[] values = { HV.HoTen, HV.NgaySinh, HV.Id_chuyenNganh, HV.Id_donVi, HV.Id_capBac, HV.Id_chucVu, HV.Avatar1, maHV };
                string query = "update TaiKhoan set HoTen =@HoTen , NgaySinh =@NgaySinh , id_ChuyenNganh =@id_ChuyenNganh , id_DonVi = @id_DonVi,id_CapBac = @id_ChucVu,Avatar = @Avatar  where id_TaiKhoan = @maHV ";
                return db.ExecuteNonQueryPara(query, param, values);
            }
            else
            {
                string[] param = { "@HoTen", "@NgaySinh", "@id_ChuyenNganh", "@id_DonVi", "@id_CapBac", "@id_ChucVu", "@maHV" };
                object[] values = { HV.HoTen, HV.NgaySinh, HV.Id_chuyenNganh, HV.Id_donVi, HV.Id_capBac, HV.Id_chucVu, maHV };
                string query = "update TaiKhoan set HoTen =@HoTen , NgaySinh =@NgaySinh , id_ChuyenNganh =@id_ChuyenNganh , id_DonVi = @id_DonVi,id_CapBac = @id_ChucVu  where id_TaiKhoan = @maHV ";
                return db.ExecuteNonQueryPara(query, param, values);
            }
            
        }
        
        public bool UpdateMK(string maHV ,  string mkMoi)
        {
            string[] param = { "@MatKhau","@maHV" };
            object[] values = { mkMoi, maHV};
            string query = "update TaiKhoan set MatKhau =@MatKhau where id_TaiKhoan = @maHV ";
            return db.ExecuteNonQueryPara(query, param, values);
        }


    }
}
