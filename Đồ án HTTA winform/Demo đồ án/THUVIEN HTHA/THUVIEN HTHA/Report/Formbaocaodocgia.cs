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
    public partial class Formbaocaodocgia : Form
    {
        public Formbaocaodocgia()
        {
            InitializeComponent();
        }

        private void Formbaocaodocgia_Load(object sender, EventArgs e)
        {
            rptdocgia rpt = new rptdocgia();
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
