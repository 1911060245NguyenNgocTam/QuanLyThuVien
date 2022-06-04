using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THUVIEN_HTHA.Report
{
    public partial class frmBaoCaoSach : Form
    {
        public frmBaoCaoSach()
        {
            InitializeComponent();
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void frmBaoCaoSach_Load(object sender, EventArgs e)
        {
            rptSach rpt = new rptSach();
            crystalReportViewer2.ReportSource = rpt;
        }
    }
}
