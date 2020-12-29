namespace QuanLyRaVao.GUI.HocVien
{
    partial class DuyetDSRaVao_GUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_TenLop = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_QuanSo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_TenDonVi = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DSDangKyGrid = new DevExpress.XtraGrid.GridControl();
            this.viewDS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.maHV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.loaiDangKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lyDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.thoiGianDi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.thoiGianVe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.trangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.dataLoiViPham = new System.Windows.Forms.DataGridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_NgayVe = new System.Windows.Forms.Label();
            this.lb_NgayDI = new System.Windows.Forms.Label();
            this.lb_HoTen = new System.Windows.Forms.Label();
            this.txt_maHV = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DSDangKyGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLoiViPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lớp :";
            // 
            // lb_TenLop
            // 
            this.lb_TenLop.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TenLop.Location = new System.Drawing.Point(68, 12);
            this.lb_TenLop.Name = "lb_TenLop";
            this.lb_TenLop.Size = new System.Drawing.Size(584, 28);
            this.lb_TenLop.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(673, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quân số :";
            // 
            // lb_QuanSo
            // 
            this.lb_QuanSo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_QuanSo.Location = new System.Drawing.Point(775, 12);
            this.lb_QuanSo.Name = "lb_QuanSo";
            this.lb_QuanSo.Size = new System.Drawing.Size(148, 28);
            this.lb_QuanSo.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lb_TenDonVi);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lb_TenLop);
            this.panel1.Controls.Add(this.lb_QuanSo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1398, 106);
            this.panel1.TabIndex = 4;
            // 
            // lb_TenDonVi
            // 
            this.lb_TenDonVi.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TenDonVi.Location = new System.Drawing.Point(101, 53);
            this.lb_TenDonVi.Name = "lb_TenDonVi";
            this.lb_TenDonVi.Size = new System.Drawing.Size(584, 28);
            this.lb_TenDonVi.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 28);
            this.label4.TabIndex = 4;
            this.label4.Text = "Đơn vị :";
            // 
            // DSDangKyGrid
            // 
            this.DSDangKyGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.DSDangKyGrid.Location = new System.Drawing.Point(2, 25);
            this.DSDangKyGrid.MainView = this.viewDS;
            this.DSDangKyGrid.Name = "DSDangKyGrid";
            this.DSDangKyGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeEdit1,
            this.repositoryItemDateEdit1});
            this.DSDangKyGrid.Size = new System.Drawing.Size(864, 553);
            this.DSDangKyGrid.TabIndex = 5;
            this.DSDangKyGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewDS});
            // 
            // viewDS
            // 
            this.viewDS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.maHV,
            this.HoTen,
            this.loaiDangKy,
            this.lyDo,
            this.thoiGianDi,
            this.thoiGianVe,
            this.trangThai});
            this.viewDS.GridControl = this.DSDangKyGrid;
            this.viewDS.Name = "viewDS";
            this.viewDS.OptionsFind.AlwaysVisible = true;
            this.viewDS.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.viewDS_RowClick);
            this.viewDS.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id_DangKy";
            this.id.MinWidth = 25;
            this.id.Name = "id";
            this.id.OptionsColumn.ReadOnly = true;
            this.id.Visible = true;
            this.id.VisibleIndex = 0;
            this.id.Width = 94;
            // 
            // maHV
            // 
            this.maHV.Caption = "Mã học viên";
            this.maHV.FieldName = "MaHV";
            this.maHV.MinWidth = 25;
            this.maHV.Name = "maHV";
            this.maHV.OptionsColumn.ReadOnly = true;
            this.maHV.Visible = true;
            this.maHV.VisibleIndex = 1;
            this.maHV.Width = 94;
            // 
            // HoTen
            // 
            this.HoTen.Caption = "Họ và tên";
            this.HoTen.FieldName = "HoTen";
            this.HoTen.MinWidth = 25;
            this.HoTen.Name = "HoTen";
            this.HoTen.OptionsColumn.ReadOnly = true;
            this.HoTen.Visible = true;
            this.HoTen.VisibleIndex = 2;
            this.HoTen.Width = 94;
            // 
            // loaiDangKy
            // 
            this.loaiDangKy.Caption = "Loại đăng ký";
            this.loaiDangKy.FieldName = "TenDangKy";
            this.loaiDangKy.MinWidth = 25;
            this.loaiDangKy.Name = "loaiDangKy";
            this.loaiDangKy.OptionsColumn.ReadOnly = true;
            this.loaiDangKy.Visible = true;
            this.loaiDangKy.VisibleIndex = 3;
            this.loaiDangKy.Width = 94;
            // 
            // lyDo
            // 
            this.lyDo.Caption = "Lý do";
            this.lyDo.FieldName = "LyDo";
            this.lyDo.MinWidth = 25;
            this.lyDo.Name = "lyDo";
            this.lyDo.OptionsColumn.ReadOnly = true;
            this.lyDo.Visible = true;
            this.lyDo.VisibleIndex = 4;
            this.lyDo.Width = 94;
            // 
            // thoiGianDi
            // 
            this.thoiGianDi.Caption = "Thời gian đi";
            this.thoiGianDi.FieldName = "ThoiGianDi";
            this.thoiGianDi.MinWidth = 25;
            this.thoiGianDi.Name = "thoiGianDi";
            this.thoiGianDi.OptionsColumn.ReadOnly = true;
            this.thoiGianDi.Visible = true;
            this.thoiGianDi.VisibleIndex = 5;
            this.thoiGianDi.Width = 94;
            // 
            // thoiGianVe
            // 
            this.thoiGianVe.Caption = "Thời gian về";
            this.thoiGianVe.FieldName = "ThoiGianVe";
            this.thoiGianVe.MinWidth = 25;
            this.thoiGianVe.Name = "thoiGianVe";
            this.thoiGianVe.OptionsColumn.ReadOnly = true;
            this.thoiGianVe.Visible = true;
            this.thoiGianVe.VisibleIndex = 6;
            this.thoiGianVe.Width = 94;
            // 
            // trangThai
            // 
            this.trangThai.Caption = "Trạng thái";
            this.trangThai.FieldName = "TTLop";
            this.trangThai.MinWidth = 25;
            this.trangThai.Name = "trangThai";
            this.trangThai.Visible = true;
            this.trangThai.VisibleIndex = 7;
            this.trangThai.Width = 94;
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // dataLoiViPham
            // 
            this.dataLoiViPham.BackgroundColor = System.Drawing.Color.White;
            this.dataLoiViPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataLoiViPham.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataLoiViPham.Location = new System.Drawing.Point(2, 204);
            this.dataLoiViPham.Name = "dataLoiViPham";
            this.dataLoiViPham.RowHeadersWidth = 51;
            this.dataLoiViPham.RowTemplate.Height = 24;
            this.dataLoiViPham.Size = new System.Drawing.Size(526, 488);
            this.dataLoiViPham.TabIndex = 6;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panel2);
            this.groupControl1.Controls.Add(this.dataLoiViPham);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl1.Location = new System.Drawing.Point(868, 106);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(530, 694);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Thông tin xét duyệt";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lb_NgayVe);
            this.panel2.Controls.Add(this.lb_NgayDI);
            this.panel2.Controls.Add(this.lb_HoTen);
            this.panel2.Controls.Add(this.txt_maHV);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(526, 179);
            this.panel2.TabIndex = 7;
            // 
            // lb_NgayVe
            // 
            this.lb_NgayVe.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NgayVe.Location = new System.Drawing.Point(148, 117);
            this.lb_NgayVe.Name = "lb_NgayVe";
            this.lb_NgayVe.Size = new System.Drawing.Size(323, 21);
            this.lb_NgayVe.TabIndex = 9;
            // 
            // lb_NgayDI
            // 
            this.lb_NgayDI.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NgayDI.Location = new System.Drawing.Point(148, 82);
            this.lb_NgayDI.Name = "lb_NgayDI";
            this.lb_NgayDI.Size = new System.Drawing.Size(323, 21);
            this.lb_NgayDI.TabIndex = 8;
            // 
            // lb_HoTen
            // 
            this.lb_HoTen.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_HoTen.Location = new System.Drawing.Point(148, 47);
            this.lb_HoTen.Name = "lb_HoTen";
            this.lb_HoTen.Size = new System.Drawing.Size(323, 21);
            this.lb_HoTen.TabIndex = 7;
            // 
            // txt_maHV
            // 
            this.txt_maHV.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_maHV.Location = new System.Drawing.Point(148, 12);
            this.txt_maHV.Name = "txt_maHV";
            this.txt_maHV.Size = new System.Drawing.Size(323, 21);
            this.txt_maHV.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 21);
            this.label8.TabIndex = 5;
            this.label8.Text = "Ngày về :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ngày đi :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Họ và tên :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã học viên";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.simpleButton1);
            this.groupControl2.Controls.Add(this.DSDangKyGrid);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 106);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(868, 694);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "Danh sách đăng ký";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(21, 598);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(140, 46);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Xác nhận duyệt";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // DuyetDSRaVao_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panel1);
            this.Name = "DuyetDSRaVao_GUI";
            this.Size = new System.Drawing.Size(1398, 800);
            this.Load += new System.EventHandler(this.DuyetDSRaVao_GUI_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DSDangKyGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLoiViPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_TenLop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_QuanSo;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl DSDangKyGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView viewDS;
        private System.Windows.Forms.DataGridView dataLoiViPham;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label lb_TenDonVi;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn maHV;
        private DevExpress.XtraGrid.Columns.GridColumn HoTen;
        private DevExpress.XtraGrid.Columns.GridColumn loaiDangKy;
        private DevExpress.XtraGrid.Columns.GridColumn lyDo;
        private DevExpress.XtraGrid.Columns.GridColumn thoiGianDi;
        private DevExpress.XtraGrid.Columns.GridColumn thoiGianVe;
        private DevExpress.XtraGrid.Columns.GridColumn trangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lb_NgayVe;
        private System.Windows.Forms.Label lb_NgayDI;
        private System.Windows.Forms.Label lb_HoTen;
        private System.Windows.Forms.Label txt_maHV;
    }
}
