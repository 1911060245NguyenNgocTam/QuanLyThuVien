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
    public partial class frmDocGia : Form
    {
        ThuVienDB context = new ThuVienDB();
        public frmDocGia()
        {
            InitializeComponent();
        }

        private void frmDocGia_Load(object sender, EventArgs e)
        {
            {
                try
                {

                    List<DOCGIA> listdocgias = context.DOCGIAs.ToList();


                    BindGrid(listdocgias);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private void BindGrid(List<DOCGIA> listdocgias)
        {
            dgvDocGia.Rows.Clear();
            foreach (var item in listdocgias)
            {
                int index = dgvDocGia.Rows.Add();
                dgvDocGia.Rows[index].Cells[0].Value = item.MADOCGIA;
                dgvDocGia.Rows[index].Cells[1].Value = item.HOTENDOCGIA;
                dgvDocGia.Rows[index].Cells[2].Value = item.SDTDOCGIA;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaDocGia.Text == "" || txtHoTen.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                if (checkDOCGIA(txtMaDocGia.Text) != null)
                {
                    MessageBox.Show("Mã độc giả đã tồn tại!", "Thông báo!", MessageBoxButtons.OK);
                }
                else
                {
                    DOCGIA stu = new DOCGIA() { MADOCGIA = txtMaDocGia.Text, HOTENDOCGIA = txtHoTen.Text, SDTDOCGIA = txtSDT.Text };
                    context.DOCGIAs.Add(stu);
                    context.SaveChanges();
                    List<DOCGIA> listdocgias = context.DOCGIAs.ToList();
                    BindGrid(listdocgias);
                }
                MessageBox.Show("Thêm độc giả thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                /*if (txtMaDocGia.TextLength != 3)
                {
                    MessageBox.Show("Mã độc giả phải có 3 kí tự trở lên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }*/
            }
        }

        private object checkDOCGIA(string text)
        {
            List<DOCGIA> listdocgias = context.DOCGIAs.ToList();
            foreach (var docgia in listdocgias)
            {
                if (txtMaDocGia.Equals(docgia.MADOCGIA))
                {
                    return docgia.MADOCGIA;
                }
            }
            return null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkDOCGIA(txtMaDocGia.Text) != null)
            {
                MessageBox.Show("Không tìm thấy độc giả cần xóa!", "Thông báo!", MessageBoxButtons.OK);
            }
            else
            {
                DOCGIA deletedocgiaDB = context.DOCGIAs.FirstOrDefault(p => p.MADOCGIA == txtMaDocGia.Text);
                if (deletedocgiaDB != null)
                {
                    if (MessageBox.Show("Bạn có muốn xóa ?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        context.DOCGIAs.Remove(deletedocgiaDB);
                        context.SaveChanges();
                        MessageBox.Show("Xóa độc giả thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        List<DOCGIA> listdocgias = context.DOCGIAs.ToList();
                        BindGrid(listdocgias);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã độc giả cần xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDocGia.Text == "" || txtHoTen.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK);
            }
            else
            {
                if (checkDOCGIA(txtMaDocGia.Text) != null)
                {
                    MessageBox.Show("Không tìm thấy độc giả!", "Thông báo!", MessageBoxButtons.OK);
                }
                else
                {
                    DOCGIA updateDG = context.DOCGIAs.FirstOrDefault(p => p.MADOCGIA == txtMaDocGia.Text);

                    if (updateDG != null)
                    {
                        updateDG.HOTENDOCGIA = txtHoTen.Text;
                        updateDG.SDTDOCGIA = txtSDT.Text;
                        context.SaveChanges();
                        MessageBox.Show("Sửa độc giả thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    List<DOCGIA> listdocgias = context.DOCGIAs.ToList();
                    BindGrid(listdocgias);
                }
            }
        }

        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDocGia.Enabled = false;
            txtMaDocGia.Text = dgvDocGia.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTen.Text = dgvDocGia.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSDT.Text = dgvDocGia.Rows[e.RowIndex].Cells[2].Value.ToString();
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtMaDocGia.Text = "";
            txtSDT.Text = "";
            txtMaDocGia.Focus();
        }
    }
}
