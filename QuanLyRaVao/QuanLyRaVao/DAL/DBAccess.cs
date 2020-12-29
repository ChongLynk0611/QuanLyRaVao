using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace QuanLyRaVao.DAL
{
    class DBAccess
    {
        SqlConnection con;
        SqlDataAdapter dap;
        SqlCommand cmd;

        public DBAccess()
        {
            connectDB();
        }

        //Kết nối
        public void connectDB()
        {
            string strCon = @"Data Source=DESKTOP-UR6D0PD\SQLEXPRESS;Initial Catalog=QuanLyRaVao;Integrated Security=True";
            con = new SqlConnection(strCon);
            try
            {
                con.Open();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                con.Dispose();
            }
        }

        //Thực hiện câu lệnh sql trả về bảng dữ liệu
        public DataTable getDS(string sql)
        {
            DataTable tbl = new DataTable();
            dap = new SqlDataAdapter(sql, con);
            dap.Fill(tbl);
            return tbl;
        }

        //Thực thi lệnh sql chèn, xóa, sửa
        public bool ExecuteNonQueryPara(string sql, string[] parameters, object[] value)
        {
            int num = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd = new SqlCommand(sql, con);
                SqlParameter p;
                for (int i = 0; i < parameters.Length; i++)
                {
                    p = new SqlParameter(parameters[i], value[i]);
                    cmd.Parameters.Add(p);
                }
                num = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            if (num > 0)
                return true;
            else
                return false;
        }

        public bool ExecuteQuery(string sql)
        {
            int num = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd = new SqlCommand(sql, con);
                num = (int)cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            if (num > 0)
                return true;
            else
                return false;
        }

        //Kiểm tra sự tồn tại
        public bool checkExist(string tblName, string field, string value)
        {
            string sql = "Select Count (*) From " + tblName + " where " + field + "=N'" + value + "'";
            cmd = new SqlCommand(sql, con);
            int num = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                num = (int)cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            if (num > 0)
                return true;
            else
                return false;
        }

        public int excuteScalar(string query)
        {
            
            cmd = new SqlCommand(query, con);
            int num = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                num = (int)cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return num;
        }

        
    }
}
