namespace ECLViewer
{
    partial class Form
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabPageSpectrum = new System.Windows.Forms.TabPage();
            this.plotViewSpectrum = new OxyPlot.WindowsForms.PlotView();
            this.labelCLer = new System.Windows.Forms.Label();
            this.textBoxCLer = new System.Windows.Forms.TextBox();
            this.labelTolerance = new System.Windows.Forms.Label();
            this.textBoxTolerance = new System.Windows.Forms.TextBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabPageResult = new System.Windows.Forms.TabPage();
            this.labelLoading = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelFDR = new System.Windows.Forms.Label();
            this.comboBoxFDR = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxSpectra = new System.Windows.Forms.TextBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.buttonSpectra = new System.Windows.Forms.Button();
            this.buttonResult = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.tabPageSpectrum.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPageResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1121, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(113, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabPageSpectrum
            // 
            this.tabPageSpectrum.Controls.Add(this.plotViewSpectrum);
            this.tabPageSpectrum.Controls.Add(this.labelCLer);
            this.tabPageSpectrum.Controls.Add(this.textBoxCLer);
            this.tabPageSpectrum.Controls.Add(this.labelTolerance);
            this.tabPageSpectrum.Controls.Add(this.textBoxTolerance);
            this.tabPageSpectrum.Controls.Add(this.buttonUpdate);
            this.tabPageSpectrum.Controls.Add(this.panel2);
            this.tabPageSpectrum.Location = new System.Drawing.Point(4, 22);
            this.tabPageSpectrum.Name = "tabPageSpectrum";
            this.tabPageSpectrum.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpectrum.Size = new System.Drawing.Size(1113, 555);
            this.tabPageSpectrum.TabIndex = 1;
            this.tabPageSpectrum.Text = "Spectrum";
            this.tabPageSpectrum.UseVisualStyleBackColor = true;
            // 
            // plotViewSpectrum
            // 
            this.plotViewSpectrum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotViewSpectrum.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plotViewSpectrum.Location = new System.Drawing.Point(8, 6);
            this.plotViewSpectrum.Name = "plotViewSpectrum";
            this.plotViewSpectrum.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewSpectrum.Size = new System.Drawing.Size(852, 541);
            this.plotViewSpectrum.TabIndex = 14;
            this.plotViewSpectrum.Text = "plotView1";
            this.plotViewSpectrum.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewSpectrum.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewSpectrum.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // labelCLer
            // 
            this.labelCLer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCLer.AutoSize = true;
            this.labelCLer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCLer.Location = new System.Drawing.Point(885, 194);
            this.labelCLer.Name = "labelCLer";
            this.labelCLer.Size = new System.Drawing.Size(114, 13);
            this.labelCLer.TabIndex = 13;
            this.labelCLer.Text = "Cross-Linker Mass:";
            // 
            // textBoxCLer
            // 
            this.textBoxCLer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCLer.Location = new System.Drawing.Point(1003, 187);
            this.textBoxCLer.Name = "textBoxCLer";
            this.textBoxCLer.Size = new System.Drawing.Size(60, 20);
            this.textBoxCLer.TabIndex = 12;
            this.textBoxCLer.Text = "138.0681";
            // 
            // labelTolerance
            // 
            this.labelTolerance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTolerance.AutoSize = true;
            this.labelTolerance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTolerance.Location = new System.Drawing.Point(883, 155);
            this.labelTolerance.Name = "labelTolerance";
            this.labelTolerance.Size = new System.Drawing.Size(114, 13);
            this.labelTolerance.TabIndex = 11;
            this.labelTolerance.Text = "MS/MS Tolerance:";
            // 
            // textBoxTolerance
            // 
            this.textBoxTolerance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTolerance.Location = new System.Drawing.Point(1003, 148);
            this.textBoxTolerance.Name = "textBoxTolerance";
            this.textBoxTolerance.Size = new System.Drawing.Size(60, 20);
            this.textBoxTolerance.TabIndex = 10;
            this.textBoxTolerance.Text = "0.02";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.AutoSize = true;
            this.buttonUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonUpdate.Location = new System.Drawing.Point(1038, 231);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(52, 23);
            this.buttonUpdate.TabIndex = 9;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.checkBox7);
            this.panel2.Controls.Add(this.checkBox6);
            this.panel2.Controls.Add(this.checkBox5);
            this.panel2.Controls.Add(this.checkBox4);
            this.panel2.Controls.Add(this.checkBox3);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Location = new System.Drawing.Point(883, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(207, 98);
            this.panel2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(2, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "ion charge:";
            // 
            // checkBox7
            // 
            this.checkBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(143, 24);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(54, 17);
            this.checkBox7.TabIndex = 6;
            this.checkBox7.Text = "+5 (xl)";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(83, 70);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(54, 17);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = "+4 (xl)";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(83, 47);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(54, 17);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "+3 (xl)";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(83, 24);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(54, 17);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "+2 (xl)";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(5, 70);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(72, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "+3 (linear)";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(5, 47);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "+2 (linear)";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(5, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "+1 (linear)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tabPageResult
            // 
            this.tabPageResult.Controls.Add(this.labelLoading);
            this.tabPageResult.Controls.Add(this.progressBar1);
            this.tabPageResult.Controls.Add(this.labelFDR);
            this.tabPageResult.Controls.Add(this.comboBoxFDR);
            this.tabPageResult.Controls.Add(this.dataGridView1);
            this.tabPageResult.Controls.Add(this.buttonOK);
            this.tabPageResult.Controls.Add(this.textBoxSpectra);
            this.tabPageResult.Controls.Add(this.textBoxResult);
            this.tabPageResult.Controls.Add(this.buttonSpectra);
            this.tabPageResult.Controls.Add(this.buttonResult);
            this.tabPageResult.Location = new System.Drawing.Point(4, 22);
            this.tabPageResult.Name = "tabPageResult";
            this.tabPageResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageResult.Size = new System.Drawing.Size(1113, 555);
            this.tabPageResult.TabIndex = 0;
            this.tabPageResult.Text = "Result";
            this.tabPageResult.UseVisualStyleBackColor = true;
            // 
            // labelLoading
            // 
            this.labelLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLoading.AutoSize = true;
            this.labelLoading.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLoading.Location = new System.Drawing.Point(220, 245);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(118, 29);
            this.labelLoading.TabIndex = 9;
            this.labelLoading.Text = "Loading...";
            this.labelLoading.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(216, 294);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(683, 37);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Visible = false;
            // 
            // labelFDR
            // 
            this.labelFDR.AutoSize = true;
            this.labelFDR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFDR.Location = new System.Drawing.Point(745, 45);
            this.labelFDR.Name = "labelFDR";
            this.labelFDR.Size = new System.Drawing.Size(77, 13);
            this.labelFDR.TabIndex = 7;
            this.labelFDR.Text = "FDR cut-off:";
            // 
            // comboBoxFDR
            // 
            this.comboBoxFDR.FormattingEnabled = true;
            this.comboBoxFDR.Items.AddRange(new object[] {
            "0.01",
            "0.05",
            "1.00"});
            this.comboBoxFDR.Location = new System.Drawing.Point(828, 42);
            this.comboBoxFDR.Name = "comboBoxFDR";
            this.comboBoxFDR.Size = new System.Drawing.Size(71, 21);
            this.comboBoxFDR.TabIndex = 6;
            this.comboBoxFDR.Text = "1.00";
            this.comboBoxFDR.SelectedIndexChanged += new System.EventHandler(this.comboBoxFDR_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1099, 452);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // buttonOK
            // 
            this.buttonOK.AutoSize = true;
            this.buttonOK.Location = new System.Drawing.Point(607, 27);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(62, 49);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxSpectra
            // 
            this.textBoxSpectra.Location = new System.Drawing.Point(32, 53);
            this.textBoxSpectra.Name = "textBoxSpectra";
            this.textBoxSpectra.Size = new System.Drawing.Size(412, 20);
            this.textBoxSpectra.TabIndex = 3;
            this.textBoxSpectra.TextChanged += new System.EventHandler(this.textBoxSpectra_TextChanged);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(32, 27);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(412, 20);
            this.textBoxResult.TabIndex = 0;
            this.textBoxResult.TextChanged += new System.EventHandler(this.textBoxResult_TextChanged);
            // 
            // buttonSpectra
            // 
            this.buttonSpectra.AutoSize = true;
            this.buttonSpectra.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSpectra.Location = new System.Drawing.Point(450, 53);
            this.buttonSpectra.Name = "buttonSpectra";
            this.buttonSpectra.Size = new System.Drawing.Size(70, 23);
            this.buttonSpectra.TabIndex = 2;
            this.buttonSpectra.Text = "Spectra file";
            this.buttonSpectra.UseVisualStyleBackColor = true;
            this.buttonSpectra.Click += new System.EventHandler(this.buttonSpectra_Click);
            // 
            // buttonResult
            // 
            this.buttonResult.AutoSize = true;
            this.buttonResult.Location = new System.Drawing.Point(450, 25);
            this.buttonResult.Name = "buttonResult";
            this.buttonResult.Size = new System.Drawing.Size(70, 23);
            this.buttonResult.TabIndex = 1;
            this.buttonResult.Text = "Result file";
            this.buttonResult.UseVisualStyleBackColor = true;
            this.buttonResult.Click += new System.EventHandler(this.buttonResult_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageResult);
            this.tabControl1.Controls.Add(this.tabPageSpectrum);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1121, 581);
            this.tabControl1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form
            // 
            this.AcceptButton = this.buttonUpdate;
            this.ClientSize = new System.Drawing.Size(1121, 605);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Name = "Form";
            this.Text = "ECLViewer 2.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPageSpectrum.ResumeLayout(false);
            this.tabPageSpectrum.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPageResult.ResumeLayout(false);
            this.tabPageResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPageSpectrum;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabPage tabPageResult;
        private System.Windows.Forms.Label labelFDR;
        private System.Windows.Forms.ComboBox comboBoxFDR;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxSpectra;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button buttonSpectra;
        private System.Windows.Forms.Button buttonResult;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label labelTolerance;
        private System.Windows.Forms.TextBox textBoxTolerance;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelCLer;
        private System.Windows.Forms.TextBox textBoxCLer;
        private OxyPlot.WindowsForms.PlotView plotViewSpectrum;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelLoading;
    }
}