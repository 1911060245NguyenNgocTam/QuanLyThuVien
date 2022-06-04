using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THUVIEN_HTHA.Report;
namespace THUVIEN_HTHA
{
    public partial class ThuVien : Form
    {
        public ThuVien()
        {
            InitializeComponent();
        }

        private void ThuVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thoát chương trình?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void đỘCGIẢToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDocGia f = new frmDocGia();
           // this.Hide();
            f.ShowDialog();
          //  this.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Bạn chắc chắn muốn thoát chương trình ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            Close();
            
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
           // this.Hide();
            f.ShowDialog();
           // this.Show();
        }

        private void ThuVien_Load(object sender, EventArgs e)
        {
        }

        private void tÀIKHOẢNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaiKhoan f = new TaiKhoan ();
            // this.Hide();
            f.ShowDialog();
            //  this.Show();
        }

        private void quảnLýToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sach f = new Sach();
            // this.Hide();
            f.ShowDialog();
            //  this.Show();
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TacGia f = new TacGia();
            // this.Hide();
            f.ShowDialog();
            //  this.Show();
        }

        private void thểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           TheLoai f = new TheLoai();
            // this.Hide();
            f.ShowDialog();
            //  this.Show();
        }

        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhaXuatBan f = new NhaXuatBan();
            // this.Hide();
            f.ShowDialog();
            //  this.Show();
        }

        private void phiếuPhạtToolStripMenuItem_Click(object sender, EventArgs e)
        {
           PhieuPhat f = new PhieuPhat();
            // this.Hide();
            f.ShowDialog();
            //  this.Show();
        }

        private void phiếuMượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuMuonSach f = new PhieuMuonSach();
            // this.Hide();
            f.ShowDialog();
            //  this.Show();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, System.IO.Path.Combine(Application.StartupPath, @"C:\Users\HP\Desktop\Thông Tin HTTA\Thông Tin HTTA.chm"));
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Formbaocaodocgia f = new Formbaocaodocgia();
            // this.Hide();
            f.ShowDialog();
            //  this.Show();
        }

        private void nhàXuấtBảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmbaocaophieumuon f = new frmbaocaophieumuon();
            // this.Hide();
            f.ShowDialog();
            //  this.Show();
        }

        private void tHÔNGKÊToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void phiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void qUẢNLÝSÁCHToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoSach f = new frmBaoCaoSach();
            // this.Hide();
            f.ShowDialog();
            //  this.Show();
        }

        private void thểLoạiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frmbaocaophieuphat f = new Frmbaocaophieuphat();
            // this.Hide();
            f.ShowDialog();
            //  this.Show();
        }

        private void cáchSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, System.IO.Path.Combine(Application.StartupPath, @"C:\Users\HP\Desktop\HuongDan\HuongDan.chm"));
        }
    }
}
