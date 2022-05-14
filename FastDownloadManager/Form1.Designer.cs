
namespace FastDownloadManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblFastDownloadManager = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.tblDownload = new System.Windows.Forms.DataGridView();
            this.Play = new System.Windows.Forms.DataGridViewImageColumn();
            this.Urlname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timeleft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lasttry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Process1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Process2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Process3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Process4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stop = new System.Windows.Forms.DataGridViewImageColumn();
            this.Resume = new System.Windows.Forms.DataGridViewImageColumn();
            this.Cancel = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblURL = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnGetLink = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnPauseAll = new System.Windows.Forms.PictureBox();
            this.btnResumeAll = new System.Windows.Forms.PictureBox();
            this.btnCancelAll = new System.Windows.Forms.PictureBox();
            this.txtPauseAll = new System.Windows.Forms.Label();
            this.txtResumeAll = new System.Windows.Forms.Label();
            this.txtCancelAll = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPauseAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnResumeAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelAll)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.pictureBox1_Click_1);
            this.btnClose.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.lblFastDownloadManager);
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox4
            // 
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // lblFastDownloadManager
            // 
            resources.ApplyResources(this.lblFastDownloadManager, "lblFastDownloadManager");
            this.lblFastDownloadManager.Name = "lblFastDownloadManager";
            this.lblFastDownloadManager.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnMinimize
            // 
            resources.ApplyResources(this.btnMinimize, "btnMinimize");
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.pictureBox3_Click);
            this.btnMinimize.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            this.btnMinimize.MouseHover += new System.EventHandler(this.pictureBox3_MouseHover);
            // 
            // tblDownload
            // 
            this.tblDownload.AllowUserToAddRows = false;
            this.tblDownload.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.tblDownload.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tblDownload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblDownload.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Play,
            this.Urlname,
            this.Filename,
            this.Status,
            this.Total,
            this.Speed,
            this.Timeleft,
            this.Lasttry,
            this.Process1,
            this.Process2,
            this.Process3,
            this.Process4,
            this.Stop,
            this.Resume,
            this.Cancel,
            this.Delete});
            this.tblDownload.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tblDownload.GridColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.tblDownload, "tblDownload");
            this.tblDownload.Name = "tblDownload";
            this.tblDownload.ReadOnly = true;
            this.tblDownload.RowTemplate.Height = 29;
            this.tblDownload.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Play
            // 
            resources.ApplyResources(this.Play, "Play");
            this.Play.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Play.Name = "Play";
            this.Play.ReadOnly = true;
            this.Play.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Play.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Urlname
            // 
            resources.ApplyResources(this.Urlname, "Urlname");
            this.Urlname.Name = "Urlname";
            this.Urlname.ReadOnly = true;
            // 
            // Filename
            // 
            resources.ApplyResources(this.Filename, "Filename");
            this.Filename.Name = "Filename";
            this.Filename.ReadOnly = true;
            // 
            // Status
            // 
            resources.ApplyResources(this.Status, "Status");
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Total
            // 
            resources.ApplyResources(this.Total, "Total");
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Speed
            // 
            resources.ApplyResources(this.Speed, "Speed");
            this.Speed.Name = "Speed";
            this.Speed.ReadOnly = true;
            // 
            // Timeleft
            // 
            resources.ApplyResources(this.Timeleft, "Timeleft");
            this.Timeleft.Name = "Timeleft";
            this.Timeleft.ReadOnly = true;
            // 
            // Lasttry
            // 
            resources.ApplyResources(this.Lasttry, "Lasttry");
            this.Lasttry.Name = "Lasttry";
            this.Lasttry.ReadOnly = true;
            // 
            // Process1
            // 
            resources.ApplyResources(this.Process1, "Process1");
            this.Process1.Name = "Process1";
            this.Process1.ReadOnly = true;
            // 
            // Process2
            // 
            resources.ApplyResources(this.Process2, "Process2");
            this.Process2.Name = "Process2";
            this.Process2.ReadOnly = true;
            // 
            // Process3
            // 
            resources.ApplyResources(this.Process3, "Process3");
            this.Process3.Name = "Process3";
            this.Process3.ReadOnly = true;
            // 
            // Process4
            // 
            resources.ApplyResources(this.Process4, "Process4");
            this.Process4.Name = "Process4";
            this.Process4.ReadOnly = true;
            // 
            // Stop
            // 
            resources.ApplyResources(this.Stop, "Stop");
            this.Stop.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Stop.Name = "Stop";
            this.Stop.ReadOnly = true;
            this.Stop.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Stop.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Resume
            // 
            resources.ApplyResources(this.Resume, "Resume");
            this.Resume.Image = ((System.Drawing.Image)(resources.GetObject("Resume.Image")));
            this.Resume.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Resume.Name = "Resume";
            this.Resume.ReadOnly = true;
            this.Resume.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Resume.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Cancel
            // 
            resources.ApplyResources(this.Cancel, "Cancel");
            this.Cancel.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Cancel.Name = "Cancel";
            this.Cancel.ReadOnly = true;
            this.Cancel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cancel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Delete
            // 
            resources.ApplyResources(this.Delete, "Delete");
            this.Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lblURL
            // 
            resources.ApplyResources(this.lblURL, "lblURL");
            this.lblURL.Name = "lblURL";
            this.lblURL.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtURL
            // 
            resources.ApplyResources(this.txtURL, "txtURL");
            this.txtURL.Name = "txtURL";
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // btnGetLink
            // 
            this.btnGetLink.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.btnGetLink, "btnGetLink");
            this.btnGetLink.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGetLink.Name = "btnGetLink";
            this.btnGetLink.UseVisualStyleBackColor = false;
            this.btnGetLink.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPath
            // 
            resources.ApplyResources(this.txtPath, "txtPath");
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox2_MouseClick);
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            this.txtPath.MouseHover += new System.EventHandler(this.textBox2_MouseHover);
            // 
            // lblPath
            // 
            resources.ApplyResources(this.lblPath, "lblPath");
            this.lblPath.Name = "lblPath";
            this.lblPath.Click += new System.EventHandler(this.label3_Click);
            this.lblPath.MouseLeave += new System.EventHandler(this.label3_MouseLeave);
            this.lblPath.MouseHover += new System.EventHandler(this.label3_MouseHover);
            // 
            // btnPauseAll
            // 
            resources.ApplyResources(this.btnPauseAll, "btnPauseAll");
            this.btnPauseAll.Name = "btnPauseAll";
            this.btnPauseAll.TabStop = false;
            this.btnPauseAll.Click += new System.EventHandler(this.btnPauseAll_Click);
            this.btnPauseAll.MouseLeave += new System.EventHandler(this.btnPauseAll_MouseLeave);
            this.btnPauseAll.MouseHover += new System.EventHandler(this.btnPauseAll_MouseHover);
            // 
            // btnResumeAll
            // 
            resources.ApplyResources(this.btnResumeAll, "btnResumeAll");
            this.btnResumeAll.Name = "btnResumeAll";
            this.btnResumeAll.TabStop = false;
            this.btnResumeAll.Click += new System.EventHandler(this.btnResumeAll_Click);
            this.btnResumeAll.MouseLeave += new System.EventHandler(this.btnResumeAll_MouseLeave);
            this.btnResumeAll.MouseHover += new System.EventHandler(this.btnResumeAll_MouseHover);
            // 
            // btnCancelAll
            // 
            resources.ApplyResources(this.btnCancelAll, "btnCancelAll");
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.TabStop = false;
            this.btnCancelAll.Click += new System.EventHandler(this.btnCancelAll_Click);
            this.btnCancelAll.MouseLeave += new System.EventHandler(this.btnCancelAll_MouseLeave);
            this.btnCancelAll.MouseHover += new System.EventHandler(this.btnCancelAll_MouseHover);
            // 
            // txtPauseAll
            // 
            resources.ApplyResources(this.txtPauseAll, "txtPauseAll");
            this.txtPauseAll.Name = "txtPauseAll";
            // 
            // txtResumeAll
            // 
            resources.ApplyResources(this.txtResumeAll, "txtResumeAll");
            this.txtResumeAll.Name = "txtResumeAll";
            this.txtResumeAll.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtCancelAll
            // 
            resources.ApplyResources(this.txtCancelAll, "txtCancelAll");
            this.txtCancelAll.Name = "txtCancelAll";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.txtCancelAll);
            this.Controls.Add(this.txtResumeAll);
            this.Controls.Add(this.txtPauseAll);
            this.Controls.Add(this.btnCancelAll);
            this.Controls.Add(this.btnResumeAll);
            this.Controls.Add(this.btnPauseAll);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnGetLink);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.tblDownload);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPauseAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnResumeAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelAll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnMinimize;
        private System.Windows.Forms.Label lblFastDownloadManager;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.DataGridView tblDownload;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnGetLink;
        private System.Windows.Forms.DataGridViewImageColumn Play;
        private System.Windows.Forms.DataGridViewTextBoxColumn Urlname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Speed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timeleft;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lasttry;
        private System.Windows.Forms.DataGridViewTextBoxColumn Process1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Process2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Process3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Process4;
        private System.Windows.Forms.DataGridViewImageColumn Stop;
        private System.Windows.Forms.DataGridViewImageColumn Resume;
        private System.Windows.Forms.DataGridViewImageColumn Cancel;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox btnPauseAll;
        private System.Windows.Forms.PictureBox btnResumeAll;
        private System.Windows.Forms.PictureBox btnCancelAll;
        private System.Windows.Forms.Label txtPauseAll;
        private System.Windows.Forms.Label txtResumeAll;
        private System.Windows.Forms.Label txtCancelAll;
    }
}

