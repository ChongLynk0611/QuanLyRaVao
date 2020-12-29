using QuanLyRaVao.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao.BLL.HocVien
{
    class DuyetDSRaVao_BLL
    {
        DBAccess db = new DBAccess();
        public DataTable GetDSDangKyLop(string maHV)
        {
            string query1 = "select id_DonVi ,id_ChuyenNganh from TaiKhoan where id_TaiKhoan  ='" + maHV + "'";
            DataTable LopTruong = db.getDS(query1);
            DataRow r = LopTruong.Rows[0];
            string query2 = "select id_DangKy, TaiKhoan.id_TaiKhoan as MaHV ,HoTen,id_DonVi, id_ChuyenNganh, TenDangKy, LyDo, ThoiGianDi, ThoiGianVe, TTLop from DangKy, LoaiDangKy, TaiKhoan, DSDangKy where DangKy.id_LoaiDangKy = LoaiDangKy.id_LoaiDangKy and TaiKhoan.id_TaiKhoan = DangKy.id_TaiKhoan and DSDangKy.id_DSDangKy = DangKy.id_DSDangKy and LopDuyet = 0 and id_DonVi =" + r[0].ToString() +"and id_ChuyenNganh = " +r[1].ToString() + " order by ThoiGianDi";
            return db.getDS(query2);
        }

        public int getIdDSDangKy(string maHV)
        {
            string query1 = "select id_DonVi ,id_ChuyenNganh from TaiKhoan where id_TaiKhoan  ='" + maHV + "'";
            DataTable LopTruong = db.getDS(query1);
            DataRow r = LopTruong.Rows[0];
            string query2 = "select id_DangKy, TaiKhoan.id_TaiKhoan as MaHV ,HoTen,id_DonVi, id_ChuyenNganh, TenDangKy, LyDo, ThoiGianDi, ThoiGianVe, TTLop from DangKy, LoaiDangKy, TaiKhoan, DSDangKy where DangKy.id_LoaiDangKy = LoaiDangKy.id_LoaiDangKy and TaiKhoan.id_TaiKhoan = DangKy.id_TaiKhoan and DSDangKy.id_DSDangKy = DangKy.id_DSDangKy and LopDuyet = 0 and id_DonVi =" + r[0].ToString() + "and id_ChuyenNganh = " + r[1].ToString() + " order by ThoiGianDi";
            DataTable dtb = db.getDS(query2);
            int id_DangKy = 0;
            if (dtb.Rows.Count > 0)
            {
                id_DangKy = (int)dtb.Rows[0][0];
            }
            string query3 = "select id_DSDangKy from DangKy where id_DangKy = " + id_DangKy.ToString();
            if(db.getDS(query3).Rows.Count > 0)
            {
                return (int)db.getDS(query3).Rows[0][0];
            }
            return -1;
            
        }
        public int GetQuanSo(string maHV)
        {
            string query1 = "select id_DonVi ,id_ChuyenNganh from TaiKhoan where id_TaiKhoan  ='" + maHV + "'";
            DataTable LopTruong = db.getDS(query1);
            DataRow r = db.getDS(query1).Rows[0];
            string query = "select COUNT(*) as QuanSo from TaiKhoan,DonVi, ChuyenNganh where TaiKhoan.id_DonVi = DonVi.id_DonVi and TaiKhoan.id_ChuyenNganh = ChuyenNganh.id_ChuyenNganh and TaiKhoan.id_ChuyenNganh = " + r[1].ToString() + " and TaiKhoan.id_DonVi = " + r[0].ToString();
            int QuanSo = db.excuteScalar(query);
            
            return QuanSo;
        
        }

        public DataRow GetLopVaDonVi(string maHV)
        {
            string query = "select  TenChuyenNganh, TenDV from ChuyenNganh, DonVi, TaiKhoan where ChuyenNganh.id_ChuyenNganh = TaiKhoan.id_ChuyenNganh and TaiKhoan.id_DonVi = DonVi.id_DonVi and id_TaiKhoan = '"+maHV+"'";
            DataTable LvaDv = db.getDS(query);
            return LvaDv.Rows[0];
        }
        public bool updateTrangThai(int id_DangKy , bool trangThai)
        {
            string[] param = { "@TrangThai", "@id_DangKy" };
            object[] values = { !trangThai, id_DangKy };
            string query = "";
            if (trangThai)
            {
                query ="update DangKy set TTLop = 0 where id_DangKy = " + id_DangKy.ToString();
            }
            else
            {
                query = "update DangKy set TTLop = 1 where id_DangKy = " + id_DangKy.ToString();
            }

            return db.ExecuteNonQueryPara(query, param, values);
        }

        public DataTable GetLoi(string maHV) {
            string query = "select * from ViPham where id_HocVien ='" + maHV + "'";
            return db.getDS(query);
        }
        public bool updateLopDuyet(int id_DSDangKy)
        {
            string[] param = { "@idDSDangKy" };
            object[] values = { id_DSDangKy };
            string query = "update DSDangKy set LopDuyet =1 where id_DSDangKy = " + id_DSDangKy.ToString();
            return db.ExecuteNonQueryPara(query, param, values);
        }
    }
}
