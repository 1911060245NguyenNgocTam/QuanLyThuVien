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
    public partial class PhieuPhat : Form
    {
        ThuVienDB context = new ThuVienDB();
        public PhieuPhat()
        {
            InitializeComponent();
        }

        private void PhieuPhat_Load(object sender, EventArgs e)
        {
            try
            {
                List<PHIEUPHAT> listPHIEUPHAT = context.PHIEUPHATs.ToList(); //Lấy Sách
                DateTime date1 = dtpNgayPhat.Value.Date;
                
                BindGrid(listPHIEUPHAT);

                dtpNgayPhat.Format = DateTimePickerFormat.Custom;
             //   dtpNgayMuon.Format = DateTimePickerFormat.Custom;
                dtpNgayPhat.Value = DateTime.Today;
                //dtpNgayPhat.Format = DateTimePickerFormat.Custom;
              //  dtpNgayMuon.Format = DateTimePickerFormat.Custom;
                //dtpNgayTra.Value = DateTime.Today;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<PHIEUPHAT> listPHIEUPHAT)
        {
            dgvPhieuPhat.Rows.Clear();
            foreach (var item in listPHIEUPHAT)
            {
                int index = dgvPhieuPhat.Rows.Add();
                dgvPhieuPhat.Rows[index].Cells[0].Value = item.MAPHIEUPHAT;
                dgvPhieuPhat.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
                // dgvPhieuMuon.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvPhieuPhat.Rows[index].Cells[1].Value = item.NGAYPHAT;
                dgvPhieuPhat.Rows[index].Cells[2].Value = item.LYDOPHAT;
                dgvPhieuPhat.Rows[index].Cells[3].Value = item.HINHTHUCPHAT;
                dgvPhieuPhat.Rows[index].Cells[4].Value = item.MADOCGIA;
                dgvPhieuPhat.Rows[index].Cells[5].Value = item.MANHANVIEN;
                dgvPhieuPhat.Rows[index].Cells[6].Value = item.MASACH;
                dgvPhieuPhat.Rows[index].Cells[7].Value = item.MAMUONSACH;

            }
        }

        private void dgvPhieuPhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhieuPhat.Enabled = false;
            txtMaPhieuPhat.Text = dgvPhieuPhat.Rows[e.RowIndex].Cells[0].Value.ToString();
            dtpNgayPhat.Text = dgvPhieuPhat.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLyDoPhat.Text = dgvPhieuPhat.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtHinhThucPhat.Text = dgvPhieuPhat.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtMaDocGia.Text = dgvPhieuPhat.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtMaNV.Text = dgvPhieuPhat.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtMaSach.Text = dgvPhieuPhat.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtMaMuonSach.Text = dgvPhieuPhat.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}
