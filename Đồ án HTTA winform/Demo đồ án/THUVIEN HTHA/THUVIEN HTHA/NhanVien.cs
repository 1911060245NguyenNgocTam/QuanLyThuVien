using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THUVIEN_HTHA.Models;
namespace THUVIEN_HTHA
{
    public partial class frmNhanVien : Form
    {
        ThuVienDB context = new ThuVienDB();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        
       /* private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtHoTen.Text == "" || txtDiaChi.Text == "" || rdoNam.Text == "" || rdoNu.Text == "" || txtChucVu.Text == "" || txtID.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //Student studentDB = studentContext.Students.SingleOrDefault(p => p.StudentID == txtID.Text);
            //Student stu = new Student();
            try
            { 

                if (checkNHANVIEN(txtMaNV.Text) != null)
                {
                    MessageBox.Show("MSSV đã tồn tại!", "Thông báo!", MessageBoxButtons.OK);
                }
                else
                {
                    //int temp = checkFaculty(cbxFaculty.Text);
                    NHANVIEN nv = new NHANVIEN() { MANHANVIEN = txtMaNV.Text, HOTENNHANVIEN = txtHoTen.Text, SDTNHANVIEN = txtSDT.Text, DIACHI = txtDiaChi.Text, PHAI = rdoNam.Text, };
                    context.NHANVIENs.Add(nv);
                    context.SaveChanges();
                    List<NHANVIEN> listNHANVIENs = context.NHANVIENs.ToList();
                    loadGridView(listNHANVIENs);
                }
            }
            catch (Exception)
            {
                if (txtMaNV.TextLength != 10)
                {
                    MessageBox.Show("Mã số sinh viên phải có 10 ký tự!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
       */
        private object checkNHANVIEN(string MANHANVIEN)
        {
            List<NHANVIEN> listNHANVIENs = context.NHANVIENs.ToList();
            foreach (var NHANVIEN in listNHANVIENs)
            {
                if (txtMaNV.Equals(NHANVIEN.MANHANVIEN))
                {
                    return NHANVIEN.MANHANVIEN;
                }
            }
            return null;
        }



        
        private void NhanVien_Load(object sender, EventArgs e)
        {
            try
            {
               
                List<NHANVIEN> listNHANVIENs = context.NHANVIENs.ToList();

                loadform(listNHANVIENs);
                loadGridView(listNHANVIENs);
                loadDGV(listNHANVIENs);
                frmNhanVien f = new frmNhanVien();
            }
            
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
           
        }

        private void loadDGV(List<NHANVIEN> listNHANVIENs)
        {
            List<NHANVIEN> listNHANVIEN = context.NHANVIENs.ToList();
            BindGrid(listNHANVIEN);
        }

        private void loadform(List<NHANVIEN> listNHANVIENs)
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            cboPhai.Focus();
            txtChucVu.Clear();
            txtID.Clear();
        }

        private void loadGridView(List<NHANVIEN> listNHANVIENs)
        {
            dgvNhanVien.Rows.Clear();
            foreach (var item in listNHANVIENs)
            {
                int index = dgvNhanVien.Rows.Add();
                dgvNhanVien.Rows[index].Cells[0].Value = item.MANHANVIEN;
                dgvNhanVien.Rows[index].Cells[1].Value = item.HOTENNHANVIEN;
                dgvNhanVien.Rows[index].Cells[2].Value = item.SDTNHANVIEN;
                dgvNhanVien.Rows[index].Cells[3].Value = item.DIACHI;
                dgvNhanVien.Rows[index].Cells[4].Value = item.PHAI;
                dgvNhanVien.Rows[index].Cells[5].Value = item.CHUCVU;
                dgvNhanVien.Rows[index].Cells[6].Value = item.ID;

            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtHoTen.Text == "" ||txtSDT.Text == "" || txtDiaChi.Text == "" || cboPhai.Text == "" || txtChucVu.Text == "" || txtID.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                if (checkNHANVIEN(txtMaNV.Text) != null)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo!", MessageBoxButtons.OK);
                }
                else
                {
                    NHANVIEN stu = new NHANVIEN() { MANHANVIEN = txtMaNV.Text, HOTENNHANVIEN = txtHoTen.Text, SDTNHANVIEN = txtSDT.Text, DIACHI = txtDiaChi.Text, PHAI = cboPhai.Text, CHUCVU = txtChucVu.Text, ID = int.Parse(txtID.Text)
                };
                    context.NHANVIENs.Add(stu);
                    context.SaveChanges();
                    List<NHANVIEN> listNHANVIEN = context.NHANVIENs.ToList();
                    BindGrid(listNHANVIEN);
                    loadform(listNHANVIEN);
                    loadDGV(listNHANVIEN);
                }
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                /*if (txtMaNV.TextLength != 3)
                {
                    MessageBox.Show("Mã nhân viên phải có 3 kí tự trở lên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }*/
                
            }
        }
       
        private void BindGrid(List<NHANVIEN> listNHANVIEN)
        {
            dgvNhanVien.Rows.Clear();
            foreach (var item in listNHANVIEN)
            {
                int index = dgvNhanVien.Rows.Add();
                dgvNhanVien.Rows[index].Cells[0].Value = item.MANHANVIEN;
                dgvNhanVien.Rows[index].Cells[1].Value = item.HOTENNHANVIEN;
                dgvNhanVien.Rows[index].Cells[2].Value = item.SDTNHANVIEN;
                dgvNhanVien.Rows[index].Cells[3].Value = item.DIACHI;
                dgvNhanVien.Rows[index].Cells[4].Value = item.PHAI;
                dgvNhanVien.Rows[index].Cells[5].Value = item.CHUCVU;
                dgvNhanVien.Rows[index].Cells[6].Value = item.ID;
            }
        }

        private void txtMaNV_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkNHANVIEN(txtMaNV.Text) != null)
            {
                MessageBox.Show("Không tìm thấy nhân viên cần xóa!", "Thông báo!", MessageBoxButtons.OK);
            }
            else
            {
                NHANVIEN deleteNhanVienDB = context.NHANVIENs.FirstOrDefault(p => p.MANHANVIEN == txtMaNV.Text);
                if (deleteNhanVienDB != null)
                {
                    if (MessageBox.Show("Bạn có muốn xóa ?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        context.NHANVIENs.Remove(deleteNhanVienDB);
                        context.SaveChanges();
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        List<NHANVIEN> listNHANVIENs = context.NHANVIENs.ToList();
                        BindGrid(listNHANVIENs);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên cần xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtHoTen.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "" || cboPhai.Text == "" || txtChucVu.Text == "" || txtID.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK);
            }
            else
            {
                if (checkNHANVIEN(txtMaNV.Text) != null)
                {
                    MessageBox.Show("Không tìm thấy độc giả!", "Thông báo!", MessageBoxButtons.OK);
                }
                else
                {
                    NHANVIEN updateDG = context.NHANVIENs.FirstOrDefault(p => p.MANHANVIEN == txtMaNV.Text);

                    if (updateDG != null)
                    {
                        updateDG.HOTENNHANVIEN = txtHoTen.Text;
                        updateDG.SDTNHANVIEN = txtSDT.Text;
                        updateDG.DIACHI = txtDiaChi.Text;
                        updateDG.PHAI = cboPhai.Text;
                        updateDG.CHUCVU = txtChucVu.Text;
                        updateDG.ID = int.Parse(txtID.Text);
                        context.SaveChanges();
                    }
                    List<NHANVIEN> listNHANVIENs = context.NHANVIENs.ToList();
                    BindGrid(listNHANVIENs);
                }
                MessageBox.Show("Sửa nhân viên thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Enabled = false;
            txtMaNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTen.Text = dgvNhanVien.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString();
            cboPhai.Text = dgvNhanVien.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtChucVu.Text = dgvNhanVien.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtID.Text = dgvNhanVien.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        /* private int checkPhai(string text)
         {
             List<NHANVIEN> listNHANVIENs = context.NHANVIENs.ToList();
             foreach (var NHANVIEN in listNHANVIENs)
             {
                 if (cboPhai == NHANVIEN.PHAI)
                 {
                     return NHANVIEN.PHAI;
                 }
             }
             return -1;
         }
        /*
         /* private void loadNHANVIEN(List<NHANVIEN> listNHANVIENs)
          {
              txtMaNV.DataSource = listFaculties;
              cbxFaculty.DisplayMember = "FacultyName";
              cbxFaculty.ValueMember = "FacultyID";
          }
         */
    }
}
