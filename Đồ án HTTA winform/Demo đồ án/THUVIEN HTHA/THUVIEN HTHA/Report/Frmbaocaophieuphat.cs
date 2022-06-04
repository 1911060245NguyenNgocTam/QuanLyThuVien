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
    public partial class Frmbaocaophieuphat : Form
    {
        public Frmbaocaophieuphat()
        {
            InitializeComponent();
        }

        private void Frmbaocaophieuphat_Load(object sender, EventArgs e)
        {
            rptphieuphat rpt = new rptphieuphat();
            crystalReportViewer6.ReportSource = rpt;
        }
    }
}
