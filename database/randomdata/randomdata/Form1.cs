using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace randomdata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string MD5(string mk)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(mk);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string queryString = "";
            string[] ho = { "Phạm", "Trần", "Nguyễn", "Thái", "Trịnh", "Nguyễn", "Dương", "Lê", "Huỳnh", "Đinh" };
            string[] dem = { "Bá", "Trọng", "Đình", "Văn", "Thị" };
            string[] ten = { "Linh", "Tuyên", "Anh", "Thắng", "Tá", "Kiên", "Hà", "Tú", "Quỳnh", "Thùy" };
            int index = 0;
            string[] HoTen = new string[600];
            for(int i = 0; i<10; i++)
            {
                for(int j =0; j < 5; j++)
                {
                    for(int k =0; k < 10; k++)
                    {
                        string HT = ho[i] + " " + dem[j] + " " + ten[k];
                        HoTen[index] = HT;
                        index++;
                    }
                }
            }
            Random rd = new Random();
            
            for ( int i =1; i<=100; i++)
            {
                string maHV = "";
                if (i < 50)
                {
                    maHV= "18QS";
                }
                else
                {
                    maHV = "17QS";
                }
                 
                if (i < 10)
                {
                    maHV = maHV + "0" + "0" + i.ToString();
                }
                else if(10 <= i && i < 100)
                {
                    maHV = maHV + "0" + i.ToString();
                }
                else
                {
                    maHV = maHV + i.ToString();
                }
                string mk = MD5("123");

                string thang = "";
                int a = rd.Next(1, 12);
                if (a < 10)
                {
                    thang = "0" + a.ToString();
                }
                else
                {
                    thang = a.ToString();
                }
                string ngay = "";
                int b = rd.Next(1, 28);
                if (b < 10)
                {
                    ngay = "0" + b.ToString();
                }
                else
                {
                    ngay = b.ToString();

                }
                string NgaySinh = rd.Next(1995, 2202).ToString() + thang + ngay;
                int id_CapBac = rd.Next(1, 6);
                int id_ChucVu = 1;
                int id_DonVi = rd.Next(1, 3);
                int id_ChuyenNganh = rd.Next(1, 3);
                string HTen = HoTen[i];
                queryString += "( '" + maHV + "','" + mk + "',N'" + HTen + "'," + "'" + NgaySinh + "'," + id_CapBac + "," + id_ChucVu + "," + id_DonVi + "," + id_ChuyenNganh + "),";
                


            }

            ketQua_txt.Text = queryString;


        }


        private void button2_Click(object sender, EventArgs e)
        {
            string queryString = "";
            for(int i =1;i <=300; i++)
            {

            }
        }
    }
}
