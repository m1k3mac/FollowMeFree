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
    public partial class LogViewerControl : DevExpress.XtraEditors.XtraUserControl
    {
        private FMFDataEntities _dbContext;

        public LogViewerControl()
        {
            InitializeComponent();
        }

        private void LogViewerControl_Load(object sender, EventArgs e)
        {
            _dbContext = new FMFDataEntities();
            var query = _dbContext.Logs.OrderByDescending(l => l.Timestamp).ToList();
            logBindingSource.DataSource = query;
        }
    }
}
