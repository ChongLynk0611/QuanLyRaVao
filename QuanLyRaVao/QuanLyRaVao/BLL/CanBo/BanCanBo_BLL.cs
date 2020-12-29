using QuanLyRaVao.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao.BLL
{
    class BanCanBo_BLL
    {
        DBAccess db = new DBAccess();
        public DataRow infoCanBo()
        {
            string sql = "select TK.id_TaiKhoan TK.HoTen, CB.TenCapBac, CV.TenChucVu"
                         + " from DSDangKy DS, TaiKhoan TK, DonVi DV, CapBac CB, ChucVu CV"
                         + " where DS.id_CanBo = TK.id_TaiKhoan"
                         + " and DV.id_DonVi = TK.id_DonVi"
                         + " and CB.id_CapBac = TK.id_CapBac"
                         + " and CV.id_ChucVu = TK.id_ChucVu"
                         + " and CV.id_ChucVu = 7";
            DataTable dtb = db.getDS(sql);
            DataRow r = dtb.Rows[0];
            return r;
        }
        public DataTable load_comboDV()
        {
            string sql = "select *from DonVi";
            DataTable dtb = db.getDS(sql);
            return dtb;
        }
        public DataTable load_comboCN(string idDV)
        {
            string sql = "select *from ChuyenNganh CN where CN.id_DonVi = '"+idDV+"'";
            DataTable dtb = db.getDS(sql);
            return dtb;
        }
        public DataTable load_text(string tenDV)
        {
            string sql = "select TK.id_TaiKhoan, TK.HoTen from TaiKhoan TK, DonVi DV where TK.id_DonVi = DV.id_DonVi and DV.tenDV=N'" + tenDV + "'";
            DataTable dtb = db.getDS(sql);
            return dtb;
        }

        public DataTable ThemDV(string tenDV)
        {
            
                string sql = "insert into DonVi values (N'" + tenDV + "')";
                DataTable dtb = db.getDS(sql);
            return dtb;

        }
        public DataTable ThemCN(string tenCN, string idDV)
        {

            string sql = "insert into ChuyenNganh values (N'" + tenCN + "','"+idDV+"')";
            DataTable dtb = db.getDS(sql);
            return dtb;

        }
        public DataTable Xoa(string tenDV)
        {
            string sql = "delete from DonVi where TenDonVi = N'"+tenDV+"'";
            DataTable dtb = db.getDS(sql);
            return dtb;
        }
        public DataTable XacNhan(string tenCBQL, string maCBQL)
        {
            string sql = "update TaiKhoan set XacNhan = 1 where id_TaiKhoan = '" + maCBQL + "' and HoTen = N'" + tenCBQL + "'";
            DataTable dtb = db.getDS(sql);
            return dtb;
        }    
    }
}
