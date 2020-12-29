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
    class ThemLoiVP_BLL
    {
        DBAccess db = new DBAccess();
        public bool addVP(ViPham_DTO VP)
        {
            string[] param = { "@id_HocVien", "@id_NguoiGhi", "@ThoiGian", "@ChiTietLoi"};
            object[] values = { VP.Id_hocVien , VP.Id_nguoiGhi, VP.ThoiGian, VP.ChiTietLoi };
            string query = "insert into ViPham values(@id_HocVien,@id_NguoiGhi,@ThoiGian,@ChiTietLoi)";
            return db.ExecuteNonQueryPara(query, param, values);
        }
    }
}
