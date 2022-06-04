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
    public partial class PhieuMuonSach : Form
    {

        public PhieuMuonSach()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtMaMuonSach.Text == "" || txtMaDocGia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                if (checkphieumuon(txtMaMuonSach.Text) != null)
                {
                    MessageBox.Show("Mã phiếu mượn đã tồn tại!", "Thông báo!", MessageBoxButtons.OK);
                }
                else
                {
                    PHIEUMUONSACH pm = new PHIEUMUONSACH();
                    pm.MAMUONSACH = txtMaMuonSach.Text;
                    pm.MADOCGIA = txtMaDocGia.Text;
                    pm.MANHANVIEN = txtMaNV.Text;
                    pm.NGAYCAP = dtpNgayCap.Value;
                    pm.NGAYMUON = dtpNgayMuon.Value;
                    context.PHIEUMUONSACHes.Add(pm);
                    context.SaveChanges();
                    List<PHIEUMUONSACH> listphieumuons = context.PHIEUMUONSACHes.ToList();
                    BindGrid(listphieumuons);
                }
            }
            catch (Exception)
            {
            }
        }
        ThuVienDB context = new ThuVienDB();
        private void PhieuMuonSach_Load(object sender, EventArgs e)
        {
            try
            {
                List<PHIEUMUONSACH> listPHIEUMUONSACH = context.PHIEUMUONSACHes.ToList(); //Lấy Sách
                DateTime date1 = dtpNgayCap.Value.Date;
                DateTime date2 = dtpNgayMuon.Value.Date;
                BindGrid(listPHIEUMUONSACH);

                dtpNgayCap.Format = DateTimePickerFormat.Custom;
                dtpNgayMuon.Format = DateTimePickerFormat.Custom;
                //dtpNgayMuon.Value = DateTime.Today;
                dtpNgayCap.Format = DateTimePickerFormat.Custom;
                dtpNgayMuon.Format = DateTimePickerFormat.Custom;
                //dtpNgayTra.Value = DateTime.Today;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<PHIEUMUONSACH> listPHIEUMUONSACH)
        {
            dgvPhieuMuon.Rows.Clear();
            foreach (var item in listPHIEUMUONSACH)
            {
                int index = dgvPhieuMuon.Rows.Add();
                dgvPhieuMuon.Rows[index].Cells[0].Value = item.MAMUONSACH;
                dgvPhieuMuon.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvPhieuMuon.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvPhieuMuon.Rows[index].Cells[1].Value = item.NGAYCAP;
                dgvPhieuMuon.Rows[index].Cells[2].Value = item.NGAYMUON;
                dgvPhieuMuon.Rows[index].Cells[3].Value = item.MADOCGIA;
                dgvPhieuMuon.Rows[index].Cells[4].Value = item.MANHANVIEN;
            }
        }
        private void loadGridView(List<PHIEUMUONSACH> listPHIEUMUONSACH)
        {
            dgvPhieuMuon.Rows.Clear();
            foreach (var item in listPHIEUMUONSACH)
            {
                int index = dgvPhieuMuon.Rows.Add();
                dgvPhieuMuon.Rows[index].Cells[0].Value = item.MAMUONSACH;
                dgvPhieuMuon.Rows[index].Cells[1].Value = item.NGAYCAP;
                dgvPhieuMuon.Rows[index].Cells[2].Value = item.NGAYMUON;
                dgvPhieuMuon.Rows[index].Cells[3].Value = item.MADOCGIA;
                dgvPhieuMuon.Rows[index].Cells[4].Value = item.MANHANVIEN;
            }
        }
        private void loadform(List<PHIEUMUONSACH> listPHIEUMUONSACH)
        {
            txtMaNV.Clear();
            txtMaDocGia.Clear();
            txtMaMuonSach.Clear();
            dtpNgayCap.Enabled = false;
            dtpNgayMuon.Enabled = false;
            txtMaNV.Focus();

        }
        private void loadDGV(List<PHIEUMUONSACH> listPHIEUMUONSACH)
        {
            List<PHIEUMUONSACH> listPHIEUMUONSACHs = context.PHIEUMUONSACHes.ToList();
            BindGrid(listPHIEUMUONSACH);
        }
        private string checkphieumuon(string MAMUONSACH)
        {
            List<PHIEUMUONSACH> listphieumuons = context.PHIEUMUONSACHes.ToList();
            foreach (var phieumuon in listphieumuons)
            {
                if (MAMUONSACH.Equals(phieumuon.MAMUONSACH))
                {
                    return phieumuon.MAMUONSACH;
                }
            }
            return null;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtMaMuonSach.Text = "";
            txtMaDocGia.Text = "";
            txtMaDocGia.Focus();
        }

        private void dgvPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // txtMaMuonSach.Enabled = false;
            txtMaMuonSach.Text = dgvPhieuMuon.Rows[e.RowIndex].Cells[4].Value.ToString();
            dtpNgayCap.Text = dgvPhieuMuon.Rows[e.RowIndex].Cells[1].Value.ToString();
            dtpNgayMuon.Text = dgvPhieuMuon.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtMaDocGia.Text = dgvPhieuMuon.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtMaNV.Text = dgvPhieuMuon.Rows[e.RowIndex].Cells[0].Value.ToString();
          
        }
    }
}
