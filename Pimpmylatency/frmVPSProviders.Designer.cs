namespace pimpmylatency
{
    partial class frmVPSProviders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Divelements.SandGrid.Rendering.Office2007Renderer office2007Renderer2 = new Divelements.SandGrid.Rendering.Office2007Renderer();
            this.latency_grid = new Divelements.SandGrid.SandGrid();
            this.colName = new Divelements.SandGrid.Specialized.GridHyperlinkColumn();
            this.colLocation = new Divelements.SandGrid.GridColumn();
            this.colIntLatency = new Divelements.SandGrid.Specialized.GridIntegerColumn();
            this.colLatency = new Divelements.SandGrid.Specialized.GridProgressBarColumn();
            this.colLastPing = new Divelements.SandGrid.GridColumn();
            this.track_bar = new DevExpress.XtraEditors.TrackBarControl();
            this.lbl_trackbar = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // latency_grid
            // 
            this.latency_grid.AllowMultipleSelection = false;
            this.latency_grid.AllowRowResize = true;
            this.latency_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.latency_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.latency_grid.Columns.AddRange(new Divelements.SandGrid.GridColumn[] {
            this.colName,
            this.colLocation,
            this.colIntLatency,
            this.colLatency,
            this.colLastPing});
            this.latency_grid.GridLines = Divelements.SandGrid.GridLinesDisplayType.Both;
            this.latency_grid.HideSelection = true;
            this.latency_grid.ImageTextSeparation = 1;
            this.latency_grid.Location = new System.Drawing.Point(0, 0);
            this.latency_grid.Name = "latency_grid";
            this.latency_grid.NullRepresentation = "";
            this.latency_grid.PrimaryColumn = this.colIntLatency;
            office2007Renderer2.ColorScheme = Divelements.SandGrid.Rendering.Office2007ColorScheme.Silver;
            this.latency_grid.Renderer = office2007Renderer2;
            this.latency_grid.RowDragBehavior = Divelements.SandGrid.RowDragBehavior.None;
            this.latency_grid.RowHighlightType = Divelements.SandGrid.RowHighlightType.None;
            this.latency_grid.ShadeAlternateRows = true;
            this.latency_grid.Size = new System.Drawing.Size(516, 242);
            this.latency_grid.StretchPrimaryGrid = false;
            this.latency_grid.TabIndex = 1;
            this.latency_grid.ColumnHeaderClick += new Divelements.SandGrid.GridColumnEventHandler(this.latency_grid_ColumnHeaderClick);
            // 
            // colName
            // 
            this.colName.AllowReorder = false;
            this.colName.AutoSize = Divelements.SandGrid.ColumnAutoSizeMode.Contents;
            this.colName.AutoSizeIncludeHeader = true;
            this.colName.AutoSortType = Divelements.SandGrid.ColumnAutoSortType.None;
            this.colName.HeaderText = "Name";
            this.colName.Width = 36;
            // 
            // colLocation
            // 
            this.colLocation.AllowReorder = false;
            this.colLocation.AutoSize = Divelements.SandGrid.ColumnAutoSizeMode.Spring;
            this.colLocation.AutoSizeIncludeHeader = true;
            this.colLocation.AutoSortType = Divelements.SandGrid.ColumnAutoSortType.None;
            this.colLocation.HeaderText = "Location";
            this.colLocation.Width = 110;
            // 
            // colIntLatency
            // 
            this.colIntLatency.AllowEditing = false;
            this.colIntLatency.AllowReorder = false;
            this.colIntLatency.AutoSize = Divelements.SandGrid.ColumnAutoSizeMode.Contents;
            this.colIntLatency.AutoSizeIncludeHeader = true;
            this.colIntLatency.AutoSortType = Divelements.SandGrid.ColumnAutoSortType.None;
            this.colIntLatency.HeaderText = "Avg. Latency";
            this.colIntLatency.Width = 71;
            // 
            // colLatency
            // 
            this.colLatency.AllowEditing = false;
            this.colLatency.AllowReorder = false;
            this.colLatency.AutoSize = Divelements.SandGrid.ColumnAutoSizeMode.Spring;
            this.colLatency.AutoSortType = Divelements.SandGrid.ColumnAutoSortType.None;
            this.colLatency.Clickable = false;
            this.colLatency.HeaderText = "Avg. Latency";
            this.colLatency.Width = 247;
            // 
            // colLastPing
            // 
            this.colLastPing.AllowEditing = false;
            this.colLastPing.AllowReorder = false;
            this.colLastPing.AutoSize = Divelements.SandGrid.ColumnAutoSizeMode.Contents;
            this.colLastPing.AutoSizeIncludeHeader = true;
            this.colLastPing.AutoSortType = Divelements.SandGrid.ColumnAutoSortType.None;
            this.colLastPing.HeaderText = "Last Ping";
            this.colLastPing.Width = 52;
            // 
            // track_bar
            // 
            this.track_bar.EditValue = 3;
            this.track_bar.Location = new System.Drawing.Point(318, 248);
            this.track_bar.Name = "track_bar";
            this.track_bar.Properties.AutoSize = false;
            this.track_bar.Properties.LookAndFeel.SkinName = "Black";
            this.track_bar.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.track_bar.Properties.Minimum = 1;
            this.track_bar.Size = new System.Drawing.Size(185, 45);
            this.track_bar.TabIndex = 4;
            this.track_bar.Value = 3;
            this.track_bar.ValueChanged += new System.EventHandler(this.track_bar_ValueChanged);
            // 
            // lbl_trackbar
            // 
            this.lbl_trackbar.Location = new System.Drawing.Point(155, 263);
            this.lbl_trackbar.Name = "lbl_trackbar";
            this.lbl_trackbar.Size = new System.Drawing.Size(116, 13);
            this.lbl_trackbar.TabIndex = 5;
            this.lbl_trackbar.Text = "Ping Interval: 3 seconds";
            // 
            // frmVPSProviders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 304);
            this.Controls.Add(this.lbl_trackbar);
            this.Controls.Add(this.track_bar);
            this.Controls.Add(this.latency_grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmVPSProviders";
            this.Text = "VPS Providers Latency Checker";
            this.Load += new System.EventHandler(this.frmVPSProviders_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVPSProviders_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.track_bar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Divelements.SandGrid.SandGrid latency_grid;
        private Divelements.SandGrid.GridColumn colLocation;
        private Divelements.SandGrid.Specialized.GridProgressBarColumn colLatency;
        private Divelements.SandGrid.Specialized.GridIntegerColumn colIntLatency;
        private Divelements.SandGrid.GridColumn colLastPing;
        private Divelements.SandGrid.Specialized.GridHyperlinkColumn colName;
        private DevExpress.XtraEditors.TrackBarControl track_bar;
        private DevExpress.XtraEditors.LabelControl lbl_trackbar;


    }
}