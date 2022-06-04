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
    public partial class Sach : Form
    {
        ThuVienDB sachdb = new ThuVienDB();
        public Sach()
        {
            InitializeComponent();
        }

        private void Sach_Load(object sender, EventArgs e)
        {
            try
            {
                List<SACH> listsachs = sachdb.SACHes.ToList();
                List<NHAXUATBAN> listnhaxuatbans = sachdb.NHAXUATBANs.ToList();
                List<THELOAI> listtheloais = sachdb.THELOAIs.ToList();
                List<TACGIA> listtacgias = sachdb.TACGIAs.ToList();
                DateTime date1 = dtpNamXB.Value.Date;
                dtpNamXB.CustomFormat = " ";
                dtpNamXB.Format = DateTimePickerFormat.Custom;
                dtpNamXB.Value = DateTime.Today;
                
                loadtheloai(listtheloais);
                loadnhaxuatban(listnhaxuatbans);

                loaddgvsach(listsachs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void loaddgvsach(List<SACH> listsachs)
        {
            dgvSach.Rows.Clear();
            foreach (var item in listsachs)
            {
                int index = dgvSach.Rows.Add();
                dgvSach.Rows[index].Cells[0].Value = item.MASACH;
                dgvSach.Rows[index].Cells[1].Value = item.TENSACH;
                dgvSach.Rows[index].Cells[2].Value = item.NAMXUATBAN;
                dgvSach.Rows[index].Cells[3].Value = item.SOLUONG;
                dgvSach.Rows[index].Cells[4].Value = item.MANHAXUATBAN;
                dgvSach.Rows[index].Cells[5].Value = item.MATHELOAI;
                dgvSach.Rows[index].Cells[6].Value = item.SOTRANG;
                dgvSach.Rows[index].Cells[7].Value = item.MATACGIA;

            };
        }

        private void loadnhaxuatban(List<NHAXUATBAN> listnhaxuatbans)
        {
            cboMaNhaXB.DataSource = listnhaxuatbans;
            cboMaNhaXB.DisplayMember = "MANHAXUATBAN";
            cboMaNhaXB.ValueMember = "TENNHAXUATBAN";
        }

        private void loadtheloai(List<THELOAI> listtheloais)
        {
            cboTheLoai.DataSource = listtheloais;
            cboTheLoai.DisplayMember = "MATHELOAI";
            cboTheLoai.ValueMember = "TENTHELOAI";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
             
            if (txtMaSach.Text == "" || txtTenSach.Text == "" || dtpNamXB.Text == "" || txtSoLuong.Text == "" || cboMaNhaXB.Text == "" || cboTheLoai.Text == "" || txtSoTrang.Text == "" || txtTacGia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                if (checkSACH(txtMaSach.Text) != null)
                {
                    MessageBox.Show("Mã sách đã tồn tại!", "Thông báo!", MessageBoxButtons.OK);
                }
                else
                {
                   // int temp = loadnhaxuatban(cboMaNhaXB.Text);
                    SACH stu = new SACH()
                    {
                        
                        MASACH = txtMaSach.Text,
                        TENSACH = txtTenSach.Text,
                        NAMXUATBAN = (DateTime.Parse(dtpNamXB.Text)),
                        SOLUONG = int.Parse(txtSoLuong.Text),
                        MANHAXUATBAN = cboMaNhaXB.Text, 
                        MATHELOAI = cboTheLoai.Text,
                        
                    };
                    sachdb.SACHes.Add(stu);
                    sachdb.SaveChanges();
                    List<SACH> listSACH = sachdb.SACHes.ToList();
                    BindGrid(listSACH);
                   // loadform(listSACH);
                  //  loadDGV(listSACH);
                    
                }

            }
            catch (Exception)
            {
                /*if (txtMaNV.TextLength != 3)
                {
                    MessageBox.Show("Mã nhân viên phải có 3 kí tự trở lên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            */
            }
        }

        private void BindGrid(List<SACH> listSACHes)
        {
            dgvSach.Rows.Clear();
            foreach (var item in listSACHes)
            {
                int index = dgvSach.Rows.Add();
                dgvSach.Rows[index].Cells[0].Value = item.MASACH;
                dgvSach.Rows[index].Cells[1].Value = item.TENSACH;
                dgvSach.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvSach.Rows[index].Cells[2].Value = item.NAMXUATBAN;
                dgvSach.Rows[index].Cells[3].Value = item.SOLUONG;
                dgvSach.Rows[index].Cells[4].Value = item.MANHAXUATBAN;
                dgvSach.Rows[index].Cells[5].Value = item.MATHELOAI;
                dgvSach.Rows[index].Cells[6].Value = item.SOTRANG;
                dgvSach.Rows[index].Cells[7].Value = item.MATACGIA;
            }
        }

        private object checkSACH(string text)
        {
            List<SACH> listSACH = sachdb.SACHes.ToList();
            foreach (var SACH in listSACH)
            {
                if (txtMaSach.Equals(SACH.MASACH))
                {
                    return SACH.MASACH;
                }
            }
            return null;
        }

        private void dtpNamXB_ValueChanged(object sender, EventArgs e)
        {
            dtpNamXB.CustomFormat = "dd/MM/yyyy";
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSach.Enabled = false;
            txtMaSach.Text = dgvSach.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenSach.Text = dgvSach.Rows[e.RowIndex].Cells[1].Value.ToString();
            dtpNamXB.Text = dgvSach.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSoLuong.Text = dgvSach.Rows[e.RowIndex].Cells[3].Value.ToString();
            cboMaNhaXB.Text = dgvSach.Rows[e.RowIndex].Cells[4].Value.ToString();
            cboTheLoai.Text = dgvSach.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtSoTrang.Text = dgvSach.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtTacGia.Text = dgvSach.Rows[e.RowIndex].Cells[7].Value.ToString();
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtSoLuong.Text = "";
        }
    }
}
