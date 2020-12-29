using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyRaVao.DAL;
using System.Data;
namespace QuanLyRaVao
{
    class XacNhanRaNgoai_BLL
    {
        DBAccess db = new DBAccess();

        public DataRow infoCanBo(string maCB)
        {
            string sql = "select TK.HoTen, CB.TenCapBac, CV.TenChucVu"
                         + " from DSDangKy DS, TaiKhoan TK, DonVi DV, CapBac CB, ChucVu CV"
                         + " where DS.id_CanBo = TK.id_TaiKhoan"
                         + " and DV.id_DonVi = TK.id_DonVi"
                         + " and CB.id_CapBac = TK.id_CapBac"
                         + " and CV.id_ChucVu = TK.id_ChucVu and id_TaiKhoan = '" + maCB + "'";
            DataTable dtb = db.getDS(sql);
            DataRow r = dtb.Rows[0];
            return r;
        }
        public DataTable ComboboxLop(string maCB)
        {
            string query1 = "select id_DonVi from TaiKhoan where id_TaiKhoan = '" + maCB + "'";
            DataRow r = db.getDS(query1).Rows[0];
            string sql = "select * from ChuyenNganh CN where id_DonVi = " + r[0].ToString();

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
                         + " and TK.id_DonVi = " + r1[0].ToString()
                         + " group by TK.id_ChuyenNganh";
            DataTable dtb = db.getDS(sql);
            DataRow r = dtb.Rows[0];
            return r;
        }
        public DataRow TenLopTruong(string tenlop, string maCB)
        {

            string query1 = "select id_DonVi from TaiKhoan where id_TaiKhoan = '" + maCB + "'";
            DataRow r1 = db.getDS(query1).Rows[0];
            string sql = "select TK.HoTen, id_TaiKhoan"
                         + " from ChuyenNganh CN, TaiKhoan TK"
                         + " where CN.id_ChuyenNganh = TK.id_ChuyenNganh"
                         + " and CN.TenChuyenNganh = N'" + tenlop + "'"
                            + " and TK.id_ChucVu = 2"
                            + " and TK.id_DonVi = " + r1[0].ToString();
            DataTable dtb = db.getDS(sql);
            DataRow r = dtb.Rows[0];
            return r;
        }
        public DataRow Load_datetime()
        {
            string sql = "select DS.ThoiGianDuyet from DSDangKy DS";
            DataTable dtb = db.getDS(sql);
            DataRow r = dtb.Rows[0];
            return r;
        }
        
        public DataTable Load_dtgv(string dt, string maCB)
        {
            string query1 = "select id_DonVi from TaiKhoan where id_TaiKhoan = '" + maCB + "'";
            DataRow r1 = db.getDS(query1).Rows[0];
            // string dtsub = dt.Substring(0, dt.Length - 3);
            string sql = "select TK.id_TaiKhoan, TK.HoTen, DK.ThoiGianDi, DK.ThoiGianVe,VE.cDuyetDi, VE.cDuyetVe, VE.vbDuyetDi, VE.vbDuyetVe"
                        + " from DSDangKy DS, DangKy DK, VeRANgoai VE, TaiKhoan TK"
                        + " where DS.id_DSDangKy = DK.id_DSDangKy"
                        + " and DK.id_DangKy = VE.id_DangKy"
                        + " and DK.id_TaiKhoan = TK.id_TaiKhoan"
                        + " and DS.ThoiGianDuyet = '" + Convert.ToDateTime(dt) + "'"
                        + " and DK.id_LoaiDangKy > 2"
                        + " and DS.cDuyet = 1"
                        + " and TK.id_DonVi = " + r1[0].ToString();
            DataTable dtb = db.getDS(sql);
            return dtb;
        }
        

    }
}
