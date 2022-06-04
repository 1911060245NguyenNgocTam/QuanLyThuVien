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
    public partial class TheLoai : Form
    {
        ThuVienDB context = new ThuVienDB();
        public TheLoai()
        {
            InitializeComponent();
        }

        private void TheLoai_Load(object sender, EventArgs e)
        {
            try
            {
                List<THELOAI> listTHELOAIs = context.THELOAIs.ToList();
                BindGrid(listTHELOAIs);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<THELOAI> listTHELOAIs)
        {
            dgvTheLoai.Rows.Clear();
            foreach (var item in listTHELOAIs)
            {
                int index = dgvTheLoai.Rows.Add();
                dgvTheLoai.Rows[index].Cells[0].Value = item.MATHELOAI;
                dgvTheLoai.Rows[index].Cells[1].Value = item.TENTHELOAI;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaTheLoai.Text == "" || txtTenTheLoaiSach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                if (checkTHELOAI(txtMaTheLoai.Text) != null)
                {
                    MessageBox.Show("Mã thể loại đã tồn tại!", "Thông báo!", MessageBoxButtons.OK);
                }
                else
                {
                    THELOAI stu = new THELOAI() { MATHELOAI = txtMaTheLoai.Text, TENTHELOAI = txtTenTheLoaiSach.Text, };
                    context.THELOAIs.Add(stu);
                    context.SaveChanges();
                    List<THELOAI> listTHELOAIs = context.THELOAIs.ToList();
                    BindGrid(listTHELOAIs);
                }
                MessageBox.Show("Thêm thể loại thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
               /* if (txtMaTheLoai.TextLength != 3)
                {
                    MessageBox.Show("Mã thể loại phải có 3 kí tự trở lên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } */
            }
        }

        private object checkTHELOAI(string text)
        {
            List<THELOAI> listTHELOAIs = context.THELOAIs.ToList();
            foreach (var THELOAIs in listTHELOAIs)
            {
                if (txtMaTheLoai.Equals(THELOAIs.MATHELOAI))
                {
                    return THELOAIs.MATHELOAI;
                }
            }
            return null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaTheLoai.Text == "" || txtTenTheLoaiSach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (checkTHELOAI(txtMaTheLoai.Text) != null)
                {
                    MessageBox.Show("Không tìm thấy Thể Loại!", "Thông báo!", MessageBoxButtons.OK);
                }
                else
                {
                    THELOAI updateTL = context.THELOAIs.FirstOrDefault(p => p.MATHELOAI == txtMaTheLoai.Text);

                    if (updateTL != null)
                    {
                        updateTL.TENTHELOAI = txtTenTheLoaiSach.Text;
                        context.SaveChanges();
                       

                    }
                    MessageBox.Show("Sửa thể loại thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    List<THELOAI> listTHELOAIs = context.THELOAIs.ToList();
                    BindGrid(listTHELOAIs);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkTHELOAI(txtMaTheLoai.Text) != null)
            {
                MessageBox.Show("Không tìm thấy thể loại cần xóa!", "Thông báo!", MessageBoxButtons.OK);
            }
            else
            {
                THELOAI deletetheloaiDB = context.THELOAIs.FirstOrDefault(p => p.MATHELOAI == txtMaTheLoai.Text);
                if (deletetheloaiDB != null)
                {
                    if (MessageBox.Show("Bạn có muốn xóa ?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        context.THELOAIs.Remove(deletetheloaiDB);
                        context.SaveChanges();
                        MessageBox.Show("Xóa thể loại thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        List<THELOAI> listTHELOAIs = context.THELOAIs.ToList();
                        BindGrid(listTHELOAIs);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã thể loại cần xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTheLoai.Text = dgvTheLoai.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenTheLoaiSach.Text = dgvTheLoai.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaTheLoai.Text = "";
            txtTenTheLoaiSach.Text = "";
            txtMaTheLoai.Focus();
        }
    }
}
