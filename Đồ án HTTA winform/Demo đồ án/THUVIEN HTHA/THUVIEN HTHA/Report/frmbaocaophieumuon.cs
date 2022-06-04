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
    public partial class frmbaocaophieumuon : Form
    {
        public frmbaocaophieumuon()
        {
            InitializeComponent();
        }

        private void frmbaocaophieumuon_Load(object sender, EventArgs e)
        {
            rptphieumuon rpt = new rptphieumuon();
            crystalReportViewer5.ReportSource = rpt;
        }
    }
}
