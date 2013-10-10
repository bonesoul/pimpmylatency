using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Divelements.SandGrid;
using System.Diagnostics;

namespace pimpmylatency
{
    public partial class frmVPSProviders : Form
    {
        private string last_link_clicked;

        public frmVPSProviders()
        {
            InitializeComponent();
        }

        private void frmVPSProviders_Load(object sender, EventArgs e)
        {
            vps_providers.init();
            vps_providers.col_latency = colLatency;
            vps_providers.set_timer_interval(track_bar.Value);
            vps_providers.enable_timer();

            foreach ( vps_provider p in vps_providers.list)
            {
                GridRow r=new GridRow();
                latency_grid.Rows.Add(r);
                GridCell cell_name = colName.CreateCell();
                GridCell cell_location = new GridCell();
                GridCell cell_latency = colLatency.CreateCell();
                GridCell cell_intlatency = colIntLatency.CreateCell();
                GridCell cell_last_ping = new GridCell();

                r.Cells.Add(cell_name);
                r.Cells.Add(cell_location);
                r.Cells.Add(cell_latency);
                r.Cells.Add(cell_intlatency);
                r.Cells.Add(cell_last_ping);

                p.cell_latency = cell_latency;
                p.cell_intlatency = cell_intlatency;
                p.cell_lastping = cell_last_ping;

                cell_name.SetValue(p.name);
                r.Cells[1].Text = p.location;
                p.cell_latency.SetValue(9999);
                p.cell_lastping.Text = "";

                colName.ButtonClicked += new EventHandler<GridRowColumnEventArgs>(colName_ButtonClicked);

            }
        }

        void colName_ButtonClicked(object sender, GridRowColumnEventArgs e)
        {
            string link=e.Row.GetCellValue(e.Column).ToString();
            if (link.ToLower() != last_link_clicked)
            {
                last_link_clicked = link.ToLower();
                vps_provider p=vps_providers.get_provider(link);
                if (p != null)
                    Process.Start("http://" + p.address);
            }
        }

        private void frmVPSProviders_FormClosing(object sender, FormClosingEventArgs e)
        {
            vps_providers.disable_timer();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void latency_grid_ColumnHeaderClick(object sender, GridColumnEventArgs e)
        {
            e.GridColumn.ToggleSort();
        }

        private void track_bar_ValueChanged(object sender, EventArgs e)
        {
            lbl_trackbar.Text = "Ping Interval: " + track_bar.Value.ToString() + " seconds";
            vps_providers.set_timer_interval(track_bar.Value);
        }





    }
}
