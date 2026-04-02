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
using DevExpress.XtraCharts;

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

            LoadCharts();
        }

        private void barButtonItem_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var query = _dbContext.PrintJobs.Include(i => i.Department).OrderByDescending(p => p.DateTimePrinted).Take(500).ToList();
            printJobBindingSource.DataSource = query;
            gridView1.BestFitColumns();

            LoadCharts();
        }

        private void LoadCharts()
        {
            LoadPrintJobsByDepartmentChart();
            LoadPrintJobsOverTimeChart();
        }

        private void LoadPrintJobsByDepartmentChart()
        {
            chartControlByDepartment.Series.Clear();
            chartControlByDepartment.Titles.Clear();

            var departmentData = _dbContext.PrintJobs
                .Include(p => p.Department)
                .GroupBy(p => p.Department != null ? p.Department.DepartmentName : "Unassigned")
                .Select(g => new { Department = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(10)
                .ToList();

            var series = new Series("Print Jobs", ViewType.Bar);
            foreach (var item in departmentData)
            {
                series.Points.Add(new SeriesPoint(item.Department, item.Count));
            }

            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((BarSeriesView)series.View).ColorEach = true;

            chartControlByDepartment.Series.Add(series);

            var title = new ChartTitle();
            title.Text = "Print Jobs by Department";
            title.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            chartControlByDepartment.Titles.Add(title);

            chartControlByDepartment.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            var diagram = chartControlByDepartment.Diagram as XYDiagram;
            if (diagram != null)
            {
                diagram.AxisX.Label.Angle = -45;
                diagram.AxisX.Label.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
            }
        }

        private void LoadPrintJobsOverTimeChart()
        {
            chartControlOverTime.Series.Clear();
            chartControlOverTime.Titles.Clear();

            var timeData = _dbContext.PrintJobs
                .GroupBy(p => new { p.DateTimePrinted.Year, p.DateTimePrinted.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Count = g.Count()
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToList()
                .Select(x => new
                {
                    Date = new DateTime(x.Year, x.Month, 1),
                    x.Count
                })
                .ToList();

            var series = new Series("Total Print Jobs", ViewType.Line);
            foreach (var item in timeData)
            {
                series.Points.Add(new SeriesPoint(item.Date, item.Count));
            }

            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((LineSeriesView)series.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;

            chartControlOverTime.Series.Add(series);

            var title = new ChartTitle();
            title.Text = "Total Print Jobs Over Time";
            title.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            chartControlOverTime.Titles.Add(title);

            chartControlOverTime.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            var diagram = chartControlOverTime.Diagram as XYDiagram;
            if (diagram != null)
            {
                diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month;
                diagram.AxisX.Label.Angle = -45;
                diagram.AxisX.Label.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisX.Label.TextPattern = "{A:MMM yyyy}";
            }
        }
    }
}
