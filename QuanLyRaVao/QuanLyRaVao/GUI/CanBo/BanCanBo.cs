using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyRaVao.BLL;
using QuanLyRaVao.DAL;


namespace QuanLyRaVao.GUI
{
    public partial class BanCanBo : DevExpress.XtraEditors.XtraUserControl
    {
        int trangThaiBTXacNhan;//0: them, 1: Xoa, 2: Xacnhanquyen
        int trangThaiThem; //0: them chuyen nganh, 1: them don vi
        DBAccess db = new DBAccess();
        BanCanBo_BLL BCB = new BanCanBo_BLL();
        public BanCanBo()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        //button them don vi
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnXacnhan.Enabled = false;
            cmbTenDV.Enabled = true;
            cmbTenCN.Enabled = true;
            btnXacNhanLuu.Enabled = true;
            trangThaiBTXacNhan = 0;
            

        }
        //xoa
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXacnhan.Enabled = false;
            cmbTenDV.Enabled = true;
            cmbTenCN.Enabled = true;
            txTenCBQL.Visible = true;
            txTenCBQL.Enabled = true;
            txMaCBQL.Visible = true;
            txMaCBQL.Enabled = true;
            btnXacNhanLuu.Enabled = true;
            trangThaiBTXacNhan = 1;
            DataTable dt = BCB.load_text(cmbTenDV.Text);
            txMaCBQL.Text = dt.Rows[0][0].ToString();
            txTenCBQL.Text = dt.Rows[0][1].ToString();

        }

        private void btnXacNhanLuu_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnXacnhan.Enabled = true;
            btnXoa.Enabled = true;
            switch (trangThaiBTXacNhan)
            {
                case 0:
                    {
                        if (trangThaiThem == 0)
                        {
                            DataTable dt = BCB.ThemCN(cmbTenCN.Text, cmbTenDV.Text);

                        }
                        if (trangThaiThem == 1)
                        {
                            DataTable dt = BCB.ThemDV(cmbTenDV.Text);
                            DataTable dt1 = BCB.ThemCN(cmbTenCN.Text, cmbTenDV.Text);

                        }
                    }
                    break;
                case 1:
                    {
                        DataTable dt = BCB.Xoa(cmbTenCN.Text);

                    }
                    break;
                case 2:
                    {
                        DataTable dt = BCB.XacNhan(txTenCBQL.Text, txMaCBQL.Text);
                    }
                    break;


            }    

        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            cmbTenDV.Enabled = true;
            cmbTenCN.Enabled = true;
            txTenCBQL.Visible = true;
            txTenCBQL.Enabled = true;
            txMaCBQL.Visible = true;
            txMaCBQL.Enabled = true;
            btnXacNhanLuu.Enabled = true;
            trangThaiBTXacNhan = 2;
            DataTable dt = BCB.load_text(cmbTenDV.Text);
            txMaCBQL.Text = dt.Rows[0][0].ToString();
            txTenCBQL.Text = dt.Rows[0][1].ToString();
        }

        private void BanCanBo_Load(object sender, EventArgs e)
        {
            cmbTenDV.DataSource = BCB.load_comboDV();
            cmbTenDV.DisplayMember = "TenDV";
            cmbTenDV.ValueMember = "id_DonVi";
        }

        private void cmbTenDV_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(trangThaiBTXacNhan == 0)
            {
                int trangThaiThemDV;//=0: không thêm đơn vị mới, 1: thêm đơn vị mới
                                  //luu vao co so du lieu
                DataTable dt = BCB.load_comboDV();

                //ktra ten don vi da ton tai chua
                int dem = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (cmbTenDV.Text != dt.Rows[i][1].ToString())
                    {
                        dem++;
                    }
                }
                if (dem == dt.Rows.Count)
                {
                    MessageBox.Show("Bạn vừa nhập thêm đơn vị mới");
                    trangThaiThemDV = 1; //them moi toan bo
                    
                }
                else
                {
                    trangThaiThemDV = 0;//khong them don vi moi
                    
                } 

                //tai du lieu len chuyen nganh
                if (trangThaiThemDV == 0)//neu don vi da ton tai
                {
                    DataTable dtCN = BCB.load_comboCN(cmbTenDV.Text);
                    cmbTenCN.DataSource = dtCN;
                    cmbTenCN.DisplayMember = "TenChuyenNganh";
                    cmbTenCN.ValueMember = "id_ChuyenNganh";
                }
            }    
            else
            {
                DataTable dtCN = BCB.load_comboCN(cmbTenDV.Text);
                cmbTenCN.DataSource = dtCN;
                cmbTenCN.DisplayMember = "TenChuyenNganh";
                cmbTenCN.ValueMember = "id_ChuyenNganh";
            }    
              
            
        }

        private void cmbTenCN_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(trangThaiBTXacNhan == 0)
            {
                DataTable dtCN = BCB.load_comboCN(cmbTenDV.Text);
                int demCN = 0;

                if (cmbTenCN.DataSource == dtCN)
                {
                    for (int i = 0; i < dtCN.Rows.Count; i++)
                    {
                        if (cmbTenDV.Text != dtCN.Rows[i][1].ToString())
                        {
                            demCN++;
                        }
                    }
                    if (demCN == dtCN.Rows.Count)//neu chuyen nganh chua ton tai
                    {
                        MessageBox.Show("Bạn vừa nhập thêm chuyên ngành mới");
                        trangThaiThem = 0;
                        //them moi toan bo
                    }
                    else
                    {
                        MessageBox.Show("Chuyên ngành đã tồn tại");//chuyen nganh da ton tai
                        cmbTenCN.Text = null;

                    }

                }    //them chuyen nganh vao don vi moi
                else
                {

                    if (cmbTenCN.Text != null)
                    {
                        MessageBox.Show("Bạn vừa nhập thêm chuyên ngành mới");
                        trangThaiThem = 1;
                    }
                }
            }    
            
        }

    }
}
