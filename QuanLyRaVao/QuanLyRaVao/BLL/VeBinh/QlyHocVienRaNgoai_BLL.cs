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
    class QlyHocVienRaNgoai_BLL
    {
        DBAccess db = new DBAccess();
        public DataTable InfoHV(string id_TK)
        {
            string sql = "select HoTen,NgaySinh,cb.TenCapBac,dv.TenDV, Avatar " +
                "from TaiKhoan as tk,CapBac as cb,DonVi as dv,DangKy as dk " +
                "where tk.id_CapBac=cb.id_CapBac and tk.id_DonVi=dv.id_DonVi " +
                "and dk.id_TaiKhoan=tk.id_TaiKhoan and dk.TrangThai=1 and dk.id_TaiKhoan = '" + id_TK + "'";
            return db.getDS(sql);
        }
        public DataTable DKyRN(string id_TK)
        {
            string sql = "select id_VeRaNgoai,vrn.id_DangKy,TenDangKy,LyDo,DiaDiem,ThoiGianDi,ThoiGianVe,cDuyetDi,cDuyetVe,vbDuyetDi,vbDuyetVe " +
                "from DangKy as dk,LoaiDangKy as ldk,VeRANgoai as vrn " +
                "where dk.id_LoaiDangKy = ldk.id_LoaiDangKy and vrn.id_DangKy = dk.id_DangKy and dk.TrangThai = 1 " +
                "and DAY(dk.ThoiGianDi)= DAY(GETDATE()) and dk.id_TaiKhoan = '" +id_TK + "'";
            return db.getDS(sql);
        }
        public DataTable CapNhatVRN1(string id_VRN)
        {
            int id = Convert.ToInt32(id_VRN);
            string sql = "update VeRANgoai set vbDuyetDi='" + DateTime.Now + "' where id_VeRaNgoai = "+id;
            return db.getDS(sql);
        }
        public DataTable CapNhatVRN2(string id_VRN)
        {
            int id = Convert.ToInt32(id_VRN);
            string sql = "update VeRANgoai set vbDuyetVe='" + DateTime.Now + "' where id_VeRaNgoai = " + id;
            return db.getDS(sql);
        }
    }
}
