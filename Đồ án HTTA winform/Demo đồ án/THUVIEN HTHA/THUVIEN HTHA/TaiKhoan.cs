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
    public partial class TaiKhoan : Form
    {
        ThuVienDB taikhoancontext = new ThuVienDB();
        public TaiKhoan()
        {
            InitializeComponent();
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            try
            {

                List<DANGNHAP> listdangnhaps = taikhoancontext.DANGNHAPs.ToList();


                BindGrid(listdangnhaps);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<DANGNHAP> listdangnhaps)
        {
            dgvTaiKhoan.Rows.Clear();
            foreach (var item in listdangnhaps)
            {
                int index = dgvTaiKhoan.Rows.Add();
                dgvTaiKhoan.Rows[index].Cells[0].Value = item.ID;
                dgvTaiKhoan.Rows[index].Cells[1].Value = item.USERNAME;
                dgvTaiKhoan.Rows[index].Cells[2].Value = item.PASSWORD;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtDangNhap.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK);
            }
            DANGNHAP taikhoandb = taikhoancontext.DANGNHAPs.FirstOrDefault(p => p.USERNAME == txtDangNhap.Text);


            DANGNHAP f = new DANGNHAP();
            if (taikhoandb != null)
            {
                
                f.USERNAME = txtDangNhap.Text;
                f.PASSWORD = txtMatKhau.Text;

                taikhoancontext.DANGNHAPs.Add(f);
                taikhoancontext.SaveChanges();
                List<DANGNHAP> listdangnhaps = taikhoancontext.DANGNHAPs.ToList();
                BindGrid(listdangnhaps);
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                taikhoandb.USERNAME = txtDangNhap.Text;
                taikhoandb.PASSWORD = txtMatKhau.Text;
                taikhoancontext.SaveChanges();
                List<DANGNHAP> listdangnhaps = taikhoancontext.DANGNHAPs.ToList();
                BindGrid(listdangnhaps);
                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DANGNHAP TKDB = taikhoancontext.DANGNHAPs.FirstOrDefault(p => p.USERNAME == txtDangNhap.Text);
            if (TKDB != null)
            {
                if (MessageBox.Show("Bạn có muốn xóa ?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    taikhoancontext.DANGNHAPs.Remove(TKDB);
                    taikhoancontext.SaveChanges();
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo!", MessageBoxButtons.OK);
                    List<DANGNHAP> listdangnhaps = taikhoancontext.DANGNHAPs.ToList();
                    BindGrid(listdangnhaps);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy khoa cần xóa!", "Thông báo!", MessageBoxButtons.OK);
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int.Parse(.Text) = dgvTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDangNhap.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMatKhau.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtDangNhap.Focus();
        }

        /*  private object checkTAIKHOAN(string text)
          {
              List<DANGNHAP> listdangnhaps = taikhoancontext.DANGNHAPs.ToList();
              foreach (var taikhoan in listdangnhaps)
              {
                  if (txtID.Equals(taikhoan.ID))
                  {
                      return taikhoan.ID;
                  }
              }
              return null;
          }
        */
    }
}
