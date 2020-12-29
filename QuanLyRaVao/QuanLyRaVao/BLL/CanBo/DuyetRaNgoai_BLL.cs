using QuanLyRaVao.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyRaVao.BLL
{
    class DuyetRaNgoai_BLL
    {
        DBAccess db = new DBAccess();
        public DataRow infoCanBo(string maCB)
        {
            string sql = "select TK.HoTen, CB.TenCapBac, CV.TenChucVu"
                         +" from DSDangKy DS, TaiKhoan TK, DonVi DV, CapBac CB, ChucVu CV"
                         +" where DS.id_CanBo = TK.id_TaiKhoan"
                         +" and DV.id_DonVi = TK.id_DonVi"
                         +" and CB.id_CapBac = TK.id_CapBac"
                         +" and CV.id_ChucVu = TK.id_ChucVu and id_TaiKhoan = '"+ maCB +"'";
            DataTable dtb = db.getDS(sql);
            DataRow r = dtb.Rows[0];
            return r;
        }
        public DataTable ComboboxLop(string maCB)
        {
            string query1 = "select id_DonVi from TaiKhoan where id_TaiKhoan = '" + maCB + "'";
            DataRow r = db.getDS(query1).Rows[0];
            string sql = "select * from ChuyenNganh CN where id_DonVi = "+r[0].ToString();

            DataTable dtb = db.getDS(sql);
            return dtb;
        }
        public DataRow LoadQuanSo(string tenlop, string maCB)
        {
            string query1 = "select id_DonVi from TaiKhoan where id_TaiKhoan = '" + maCB + "'";
            DataRow r1 = db.getDS(query1).Rows[0];
            string sql = "select COUNT(TK.id_TaiKhoan) AS QuanSo"
                         + " from TaiKhoan TK, ChuyenNganh CN"
                         + " where TK.id_ChuyenNganh = CN.id_ChuyenNganh"
                         + " and CN.TenChuyenNganh = N'" + tenlop + "'"
                         +" and TK.id_DonVi = " + r1[0].ToString()
                         + " group by TK.id_ChuyenNganh";
            DataTable dtb = db.getDS(sql);
            DataRow r = dtb.Rows[0];
            return r;
        }
        public DataRow TenLopTruong(string tenlop,string maCB)
        {

            string query1 = "select id_DonVi from TaiKhoan where id_TaiKhoan = '" + maCB + "'";
            DataRow r1 = db.getDS(query1).Rows[0];
            string sql = "select TK.HoTen, id_TaiKhoan"
                         + " from ChuyenNganh CN, TaiKhoan TK"
                         + " where CN.id_ChuyenNganh = TK.id_ChuyenNganh"
                         + " and CN.TenChuyenNganh = N'" + tenlop + "'"
                            + " and TK.id_ChucVu = 2"
                            +" and TK.id_DonVi = "+r1[0].ToString();
            DataTable dtb = db.getDS(sql);
            DataRow r = dtb.Rows[0];
            return r;
        }
        public DataTable load_dtgv(string tenlop, string maCB)
        {
            string query1 = "select id_DonVi from TaiKhoan where id_TaiKhoan = '" + maCB + "'";
            DataRow r1 = db.getDS(query1).Rows[0];
            string sql = "select TK.id_TaiKhoan, TK.HoTen, TK.NgaySinh, CV.TenChucVu, CB.TenCapBac, L.TenDangKy, DK.LyDo,DK.ThoiGianDi, DK.ThoiGianVe,DK.TrangThai"
                        + " from DangKy DK, DSDangKy DS, LoaiDangKy L, TaiKhoan TK, ChucVu CV, CapBac CB, DonVi DV, ChuyenNganh CN"
                        + " where DK.id_DSDangKy = DS.id_DSDangKy"
                        + " and DK.id_TaiKhoan = TK.id_TaiKhoan"
                        + " and DK.id_LoaiDangKy = L.id_LoaiDangKy"
                        + " and TK.id_ChucVu = CV.id_ChucVu"
                        + " and TK.id_CapBac = CB.id_CapBac"
                        + " and TK.id_DonVi = DV.id_DonVi"
                        + " and TK.id_ChuyenNganh = CN.id_ChuyenNganh"
                
                        + " and L.id_LoaiDangKy  > 2"
                        + " and CN.TenChuyenNganh = N'" + tenlop + "'"
                        + " and DS.LopDuyet = 1"
                        + " and DK.TTLop = 1"
                        + " and DK.TrangThai = 0"                   
                        +" and TK.id_DonVi = " +r1[0].ToString();

                        //+ "order by L.id_LoaiDangKy";

            DataTable dtb = db.getDS(sql);
            return dtb;
        }
        
    }
    
}
