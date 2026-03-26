using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FollowMeFree
{
    public partial class MainControl : DevExpress.XtraEditors.XtraUserControl
    {
        private FMFDataEntities _dbContext = new FMFDataEntities();
        public MainControl()
        {
            InitializeComponent();
            gridView1.BestFitColumns();
        }

        private void MainControl_Load(object sender, EventArgs e)
        {
            var query = _dbContext.PrintJobs.Include(i => i.Department).OrderByDescending(p => p.DateTimePrinted).Take(500).ToList();
            printJobBindingSource.DataSource = query;
            gridView1.BestFitColumns();
        }

        private void barButtonItem_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var query = _dbContext.PrintJobs.Include(i => i.Department).OrderByDescending(p => p.DateTimePrinted).Take(500).ToList();
            printJobBindingSource.DataSource = query;
            gridView1.BestFitColumns();
        }
    }
}
