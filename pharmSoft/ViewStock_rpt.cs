﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
namespace pharmSoft
{
    public partial class ViewStock_rpt : Form
    {
        public ViewStock_rpt()
        {
            InitializeComponent();
        }

        private void ViewStock_rpt_Load(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"\\HOMEPC1\Users\ADMIN\Documents\Visual Studio 2013\Projects\pharmSoft\pharmSoft\stock_rpt.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
