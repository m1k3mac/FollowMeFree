using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void MainControl_Load(object sender, EventArgs e)
        {
            var query = _dbContext.PrintJobs.OrderByDescending(p => p.DateTimePrinted).Take(500).ToList();
            printJobBindingSource.DataSource = query;
        }
    }
}
