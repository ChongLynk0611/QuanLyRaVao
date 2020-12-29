using QuanLyRaVao.DAL;
using QuanLyRaVao.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRaVao.BLL.HocVien
{
    
    class DangKyRaVao_BLL
    {
        DBAccess db = new DBAccess();

        public DataTable GetLoaiDK()
        {
            string query = "select * from LoaiDangKy";
            DataTable dtb = db.getDS(query);
            return dtb;
        }

        public DataRow GetDK(int id_DangKy)
        {
            string query = "select * from GetDSDangKy where id_DangKy = " + id_DangKy.ToString();
            return db.getDS(query).Rows[0];
        }
        public int CheckDSDangKy(string maHV)
        {

            // tìm chuyên ngành và đơn vị của học viên đó
            string query1 = "select id_ChuyenNganh, id_DonVi from TaiKhoan where id_TaiKhoan = '"+maHV+"'";
            DataRow r1 = db.getDS(query1).Rows[0];
            int id_DonVi = (int)r1[1];
            int id_ChuyenNganh = (int)r1[0];
            // tìm id lớp trưởng học viên đó
            string query2 = "select id_TaiKhoan from TaiKhoan where id_ChucVu  = 2 and id_ChuyenNganh =" + id_ChuyenNganh.ToString() + " and id_DonVi =" + id_DonVi.ToString();
            DataRow r2 = db.getDS(query2).Rows[0];
            string id_LT = r2[0].ToString();
            // lấy ra id_DSDangKy của lớp học viên đăng ký 
            string query3 = "select id_DSDangKy from DSDangKy where id_LopTruong ='" + id_LT + "' and LopDuyet = 0";
            DataTable dtb = db.getDS(query3);
            if(dtb.Rows.Count > 0)
            {
                return (int)dtb.Rows[0][0];
            }
            else
            {
                return -1;
            }

        }

        // khi không có phiếu đăng ký nào đang được nộp thì trả về -1 còn có phiếu thì trả về id_DangKy
        public int CheckPhieuDK(string maHV)
        {

            
            string query = "select * from DSPhieuDK where id_TaiKhoan = '"+maHV +"'";
            DataTable dtb = db.getDS(query);
            if(dtb.Rows.Count == 0)
            {
                return -1;
            }
            else
            {
                return (int)dtb.Rows[0][0];
            }
            

        }

        // kiểm tra xem nếu phiếu đăng ký đã đăng ký và đã được duyệt qua thì sẽ trả về true, ngượ lại false
        // -1: lớp duyệt xong mà không duyệt cho học viên
        // 0 : đã duyệt đại đội mà không được duyệt ra
        // 1 chưa đăng ký ra ngoài
        // 2: đã duyệt và được ra ngoài
        //3 : lớp duyệt mà chưa đc đại đội duyệt
        public int CheckDuyet(string maHV)
        {
            // trường hợp đã duyệt qua lớp và chưa duyệt qua đại đội thì k sửa đc 
            string query = "select id_DangKy, TaiKhoan.id_TaiKhoan,TTLop  from DangKy, DSDangKy, TaiKhoan where DangKy.id_DSDangKy = DSDangKy.id_DSDangKy and TaiKhoan.id_TaiKhoan = DangKy.id_TaiKhoan and LopDuyet = 1 and cDuyet = 0 and TaiKhoan.id_TaiKhoan ='" + maHV +"'";
            DataTable dtb = db.getDS(query);
            
            if(dtb.Rows.Count > 0)
            {
                DataRow r = dtb.Rows[0];
                // đã được lớp duyệt qua mà đại đội chưa duyệt nhưng học viên không được duyệt 
                if (!(bool)dtb.Rows[0][2] )
                {
                    return -1;
                }
                // lớp duyệt đã qua nhưng chưa đc đại đội duyệt
                else
                {
                    return 3;
                }
            }
            else
            {
                // trường hợp mà lớp và đại đội đã duyệt 
                string query1 = "select * from  CheckDSDuyet where id_TaiKhoan ='" + maHV + "'";
                DataTable dtb1 = db.getDS(query1);
                //trường hợp học viên được ra ngoài
                if(dtb1.Rows.Count > 0)
                {
                    return 2;
                }
                // đã duyệt và không được ra hoặc chưa đăng ký
                else
                {
                    return -5;
                }
                
            }
            return -5;




        }

        public bool checkTao(string maHV)
        {
            string query = "select ThoiGianVe from DangKy where id_TaiKhoan ='" + maHV + "' order by ThoiGianDi";
            if(db.getDS(query).Rows.Count > 0)
            {
                DataRow r = db.getDS(query).Rows[0];
                int check = DateTime.Compare((DateTime)r[0], DateTime.Now);
                if(check == 1)
                {
                    return false;
                }
                
            }
            return true;
        }
        public bool InsertDangKy(DangKy_DTO dk)
        {

            // tìm chuyên ngành và đơn vị của học viên đó
            string query1 = "select id_ChuyenNganh, id_DonVi from TaiKhoan where id_TaiKhoan = '" + dk.Id_taiKhoan+ "'";
            DataRow r1 = db.getDS(query1).Rows[0];
            int id_DonVi = (int)r1[1];
            int id_ChuyenNganh = (int)r1[0];
            // tìm id lớp trưởng học viên đó
            string query2 = "select id_TaiKhoan from TaiKhoan where id_ChucVu  = 2 and id_ChuyenNganh =" + id_ChuyenNganh.ToString() + " and id_DonVi =" + id_DonVi.ToString();
            DataRow r2 = db.getDS(query2).Rows[0];
            string id_LT = r2[0].ToString();

            if (dk.Id_DSdangKy != -1)
            {
                string[] param = { "@id_DSDangKy", "@id_TaiKhoan", "@id_LoaiDangKy", "@LyDo", "@DiaDiem", "@ThoiGianDi", "@ThoiGianVe","@TrangThai","@TTLop"};
                object[] values = { dk.Id_DSdangKy, dk.Id_taiKhoan, dk.Id_loaiDangKy, dk.LyDo, dk.DiaDiem, dk.ThoiDangKyDi, dk.ThoiDangKyVe, dk.TrangThai ,dk.TTLop1};
                string query = "insert into DangKy values(@id_DSDangKy, @id_TaiKhoan, @id_LoaiDangKy, @LyDo, @DiaDiem, @ThoiGianDi, @ThoiGianVe,@TrangThai,@TTLop) ";
                return db.ExecuteNonQueryPara(query, param, values);
            }
            // trường hợp đã có người đăng ký trước và danh sách đã được tạo
            else
            {
                string[] param1 = { "@id_LopTruong" };
                object[] values1 = { id_LT };
                string insert1 = "insert into DSDangKy(id_LopTruong) values(@id_LopTruong)";
                db.ExecuteNonQueryPara(insert1, param1, values1);

                var id_DSDK = this.CheckDSDangKy(dk.Id_taiKhoan);
                string[] param2 = { "@id_DSDangKy", "@id_TaiKhoan", "@id_LoaiDangKy", "@LyDo", "@DiaDiem", "@ThoiGianDi", "@ThoiGianVe", "@TrangThai", "@TTLop" };
                object[] values2 = { id_DSDK, dk.Id_taiKhoan, dk.Id_loaiDangKy, dk.LyDo, dk.DiaDiem, dk.ThoiDangKyDi, dk.ThoiDangKyVe, dk.TrangThai,dk.TTLop1 };
                string insert2 = "insert into DangKy values(@id_DSDangKy, @id_TaiKhoan, @id_LoaiDangKy, @LyDo, @DiaDiem, @ThoiGianDi, @ThoiGianVe,@TrangThai,@TTLop) ";
                return db.ExecuteNonQueryPara(insert2, param2, values2);

            }
            return true;
        }



    }
}
