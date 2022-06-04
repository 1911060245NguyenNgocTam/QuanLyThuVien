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
    public partial class NhaXuatBan : Form
    {
        ThuVienDB context = new ThuVienDB();
        public NhaXuatBan()
        {
            InitializeComponent();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkNHAXUATBAN(txtMaNXB.Text) != null)
            {
                MessageBox.Show("Không tìm thấy nhà xuất bản cần xóa!", "Thông báo!", MessageBoxButtons.OK);
            }
            else
            {
                NHAXUATBAN deleteNXBDB = context.NHAXUATBANs.FirstOrDefault(p => p.MANHAXUATBAN == txtMaNXB.Text);
                if (deleteNXBDB != null)
                {
                    if (MessageBox.Show("Bạn có muốn xóa ?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        context.NHAXUATBANs.Remove(deleteNXBDB);
                        context.SaveChanges();
                        MessageBox.Show("Xóa nhà xuất bản thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        List<NHAXUATBAN> listNHAXUATBANs = context.NHAXUATBANs.ToList();
                        BindGrid(listNHAXUATBANs);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã nhà xuất bản cần xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void NhaXuatBan_Load(object sender, EventArgs e)
        {
            try
            {

                List<NHAXUATBAN> listNHAXUATBANs = context.NHAXUATBANs.ToList();


                BindGrid(listNHAXUATBANs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<NHAXUATBAN> listNHAXUATBANs)
        {
            dgvNXB.Rows.Clear();
            foreach (var item in listNHAXUATBANs)
            {
                int index = dgvNXB.Rows.Add();
                dgvNXB.Rows[index].Cells[0].Value = item.MANHAXUATBAN;
                dgvNXB.Rows[index].Cells[1].Value = item.TENNHAXUATBAN;
                dgvNXB.Rows[index].Cells[3].Value = item.DIACHI;
                dgvNXB.Rows[index].Cells[2].Value = item.SODTNHAXUATBAN;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNXB.Text == "" || txtDiaChi.Text == "" || txtTenNXB.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                if (checkNHAXUATBAN(txtMaNXB.Text) != null)
                {
                    MessageBox.Show("Mã NXB đã tồn tại!", "Thông báo!", MessageBoxButtons.OK);
                }
                else
                {
                    NHAXUATBAN stu = new NHAXUATBAN() { MANHAXUATBAN = txtMaNXB.Text, TENNHAXUATBAN = txtTenNXB.Text, DIACHI = txtDiaChi.Text, SODTNHAXUATBAN = txtSDT.Text };
                    context.NHAXUATBANs.Add(stu);
                    context.SaveChanges();
                    List<NHAXUATBAN> listNHAXUATBANs = context.NHAXUATBANs.ToList();
                    BindGrid(listNHAXUATBANs);
                }
                MessageBox.Show("Thêm nhà xuất bản thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
               /* if (txtMaNXB.TextLength != 3)
                {
                    MessageBox.Show("Mã NXB giả phải có 3 kí tự trở lên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               */
            }

        }

        private object checkNHAXUATBAN(string text)
        {
            List<NHAXUATBAN> listNHAXUATBANs = context.NHAXUATBANs.ToList();
            foreach (var NHAXUATBANs in listNHAXUATBANs)
            {
                if (txtMaNXB.Equals(NHAXUATBANs.MANHAXUATBAN))
                {
                    return NHAXUATBANs.MANHAXUATBAN;
                }
            }
            return null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNXB.Text == "" || txtDiaChi.Text == "" || txtTenNXB.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (checkNHAXUATBAN(txtMaNXB.Text) == null)
                {
                    MessageBox.Show("Không tìm thấy nhà xuất bản!", "Thông báo!", MessageBoxButtons.OK);
                }
                else
                {
                    NHAXUATBAN updateDG = context.NHAXUATBANs.FirstOrDefault(p => p.MANHAXUATBAN == txtMaNXB.Text);

                    if (updateDG != null)
                    {
                        updateDG.TENNHAXUATBAN = txtTenNXB.Text;
                        updateDG.DIACHI = txtDiaChi.Text;
                        updateDG.SODTNHAXUATBAN = txtSDT.Text;
                        context.SaveChanges();
                    }
                    List<NHAXUATBAN> listNHAXUATBANs = context.NHAXUATBANs.ToList();
                    BindGrid(listNHAXUATBANs);
                }
                MessageBox.Show("Sửa nhà xuất bản thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            txtMaNXB.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtTenNXB.Text = "";
            txtMaNXB.Focus();
        }

        private void dgvNXB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNXB.Enabled = false;
            txtMaNXB.Text = dgvNXB.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenNXB.Text = dgvNXB.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvNXB.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSDT.Text = dgvNXB.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
