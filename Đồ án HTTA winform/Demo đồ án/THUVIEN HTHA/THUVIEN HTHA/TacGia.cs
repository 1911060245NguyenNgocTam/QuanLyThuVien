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
    public partial class TacGia : Form
    {
        ThuVienDB context = new ThuVienDB();
        public TacGia()
        {
            InitializeComponent();
        }

        private void TacGia_Load(object sender, EventArgs e)
        {
            try
            {
                List<TACGIA> listTACGIAs = context.TACGIAs.ToList();
                BindGrid(listTACGIAs);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<TACGIA> listTACGIAs)
        {
            dgvTacGia.Rows.Clear();
            foreach (var item in listTACGIAs)
            {
                int index = dgvTacGia.Rows.Add();
                dgvTacGia.Rows[index].Cells[0].Value = item.MATACGIA;
                dgvTacGia.Rows[index].Cells[1].Value = item.TENTACGIA;
            }
            
        }

        private object checkTACGIA(string text)
        {
            List<TACGIA> listTACGIAs = context.TACGIAs.ToList();
            foreach (var TACGIAs in listTACGIAs)
            {
                if (txtMaTacGia.Equals(TACGIAs.MATACGIA))
                {
                    return TACGIAs.MATACGIA;
                }
            }
            return null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaTacGia.Text == "" || txtHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                if (checkTACGIA(txtMaTacGia.Text) != null)
                {
                    MessageBox.Show("Mã tác giả đã tồn tại!", "Thông báo!", MessageBoxButtons.OK);
                }
                else
                {
                    TACGIA stu = new TACGIA() { MATACGIA = txtMaTacGia.Text, TENTACGIA = txtHoTen.Text, };
                    context.TACGIAs.Add(stu);
                    context.SaveChanges();
                    List<TACGIA> listTACGIAs = context.TACGIAs.ToList();
                    BindGrid(listTACGIAs);
                }
                MessageBox.Show("Thêm tác giả thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                /*if (txtMaDocGia.TextLength != 3)
                {
                    MessageBox.Show("Mã độc giả phải có 3 kí tự trở lên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }*/
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkTACGIA(txtMaTacGia.Text) != null)
            {
                MessageBox.Show("Không tìm thấy tác giả cần xóa!", "Thông báo!", MessageBoxButtons.OK);
            }
            else
            {
                TACGIA deletetacgiaDB = context.TACGIAs.FirstOrDefault(p => p.MATACGIA == txtMaTacGia.Text);
                if (deletetacgiaDB != null)
                {
                    if (MessageBox.Show("Bạn có muốn xóa ?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        context.TACGIAs.Remove(deletetacgiaDB);
                        context.SaveChanges();
                        MessageBox.Show("Xóa tác giả thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        List<TACGIA> listTACGIAs = context.TACGIAs.ToList();
                        BindGrid(listTACGIAs);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã tác giả cần xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaTacGia.Text == "" || txtHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (checkTACGIA(txtMaTacGia.Text) == null)
                {
                    MessageBox.Show("Không tìm thấy tác giả!", "Thông báo!", MessageBoxButtons.OK);
                }
                else
                {
                    TACGIA updateDG = context.TACGIAs.FirstOrDefault(p => p.MATACGIA == txtMaTacGia.Text);

                    if (updateDG != null)
                    {
                        updateDG.TENTACGIA = txtHoTen.Text;
                        context.SaveChanges();
                    }
                    List<TACGIA> listTACGIAs = context.TACGIAs.ToList();
                    BindGrid(listTACGIAs);
                }
            }
        }

        private void dgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTacGia.Text = dgvTacGia.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTen.Text = dgvTacGia.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtMaTacGia.Text = "";
            txtMaTacGia.Focus();
        }
    }
}
