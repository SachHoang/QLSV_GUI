using QLSV_DAL.Model1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSV_BLL;
using QLSV_DAL.Model1;

namespace QLSV_GUI
{
    public partial class frmDSSV : Form
    {
        private readonly SinhVienService sinhVien1 = new SinhVienService();
        private readonly LopService lop = new LopService();
        public frmDSSV()
        {
            InitializeComponent();
        }

        private void frmDSSV_Load(object sender, EventArgs e)
        {
            try
            {
                var SV = sinhVien1.GetAll();
                var Lops = lop.GetAll();
                FillLop(Lops);
                BindGrid(SV);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillLop(List<Lop> lops)
        {
            lops.Insert(0, new Lop());
            this.cboLop.DataSource = lops;
            this.cboLop.DisplayMember = "TenLop";
            this.cboLop.ValueMember = "MaLop";
        }

        private void BindGrid(List<SinhVien1> sv1)
        { 
            dgvSV.Rows.Clear();
            foreach (var sv in sv1)
            {
                int index = dgvSV.Rows.Add();
                dgvSV.Rows[index].Cells[0].Value = sv.MaSV;
                dgvSV.Rows[index].Cells[1].Value = sv.TenSV;
                
                dgvSV.Rows[index].Cells[2].Value = sv.NgaySinh + "";
                if (sv.Lop != null)
                {
                    dgvSV.Rows[index].Cells[3].Value = sv.Lop.TenLop;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dgvSV.Rows.Add(txtMSSV.Text, txtHoTen.Text, Convert.ToDateTime(dtNgaySinh.Text), cboLop.Text);

            SinhVien1 s = new SinhVien1();
            s.MaSV = txtMSSV.Text;
            s.TenSV = txtHoTen.Text;
            s.MaLop = cboLop.SelectedValue.ToString();
            s.NgaySinh = DateTime.Parse(dtNgaySinh.Text);           
            sinhVien1.Add(s);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn thoát!", "Thông Báo!",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn lưu!", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                SinhVien1 s1 = new SinhVien1();
                sinhVien1.Save(s1);
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSV.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);



                if (result == DialogResult.Yes)
                {

                    dgvSV.Rows.RemoveAt(dgvSV.SelectedRows[0].Index);


                    string sanpham = txtMSSV.Text;

                    if (sanpham != null)
                    {

                        sinhVien1.delete(sanpham);
                    }
                }
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
        private void dgvSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow row = dgvSV.Rows[e.RowIndex];
            string MaSV = txtMSSV.Text;

            txtMSSV.Text = row.Cells[0].Value.ToString();
            txtHoTen.Text = row.Cells[1].Value.ToString();
            dtNgaySinh.Text = row.Cells[2].Value.ToString();
            cboLop.Text = row.Cells[3].Value.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }
    }
}
