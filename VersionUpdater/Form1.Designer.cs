namespace VersionUpdater
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRevisionNumber = new System.Windows.Forms.Button();
            this.buttonLayoutNumber = new System.Windows.Forms.Button();
            this.buttonJuniorNumber = new System.Windows.Forms.Button();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxRevisionNumber = new System.Windows.Forms.TextBox();
            this.textBoxLayoutNumber = new System.Windows.Forms.TextBox();
            this.textBoxJuniorNumber = new System.Windows.Forms.TextBox();
            this.buttonSeniorNumber = new System.Windows.Forms.Button();
            this.textBoxSeniorNumber = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView
            // 
            this.gridView.AutoGenerateColumns = false;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.pathDataGridViewTextBoxColumn,
            this.currentDataGridViewTextBoxColumn});
            this.gridView.DataSource = this.projectBindingSource1;
            this.gridView.Location = new System.Drawing.Point(12, 37);
            this.gridView.Name = "gridView";
            this.gridView.Size = new System.Drawing.Size(547, 401);
            this.gridView.TabIndex = 0;
            this.gridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonRevisionNumber);
            this.groupBox1.Controls.Add(this.buttonLayoutNumber);
            this.groupBox1.Controls.Add(this.buttonJuniorNumber);
            this.groupBox1.Controls.Add(this.labelProjectName);
            this.groupBox1.Controls.Add(this.buttonUpdate);
            this.groupBox1.Controls.Add(this.textBoxRevisionNumber);
            this.groupBox1.Controls.Add(this.textBoxLayoutNumber);
            this.groupBox1.Controls.Add(this.textBoxJuniorNumber);
            this.groupBox1.Controls.Add(this.buttonSeniorNumber);
            this.groupBox1.Controls.Add(this.textBoxSeniorNumber);
            this.groupBox1.Location = new System.Drawing.Point(588, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 158);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // buttonRevisionNumber
            // 
            this.buttonRevisionNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRevisionNumber.Location = new System.Drawing.Point(291, 68);
            this.buttonRevisionNumber.Name = "buttonRevisionNumber";
            this.buttonRevisionNumber.Size = new System.Drawing.Size(28, 23);
            this.buttonRevisionNumber.TabIndex = 12;
            this.buttonRevisionNumber.Text = "^";
            this.buttonRevisionNumber.UseVisualStyleBackColor = true;
            this.buttonRevisionNumber.Click += new System.EventHandler(this.buttonRevisionNumber_Click);
            // 
            // buttonLayoutNumber
            // 
            this.buttonLayoutNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLayoutNumber.Location = new System.Drawing.Point(212, 67);
            this.buttonLayoutNumber.Name = "buttonLayoutNumber";
            this.buttonLayoutNumber.Size = new System.Drawing.Size(28, 23);
            this.buttonLayoutNumber.TabIndex = 11;
            this.buttonLayoutNumber.Text = "^";
            this.buttonLayoutNumber.UseVisualStyleBackColor = true;
            this.buttonLayoutNumber.Click += new System.EventHandler(this.buttonLayoutNumber_Click);
            // 
            // buttonJuniorNumber
            // 
            this.buttonJuniorNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonJuniorNumber.Location = new System.Drawing.Point(133, 66);
            this.buttonJuniorNumber.Name = "buttonJuniorNumber";
            this.buttonJuniorNumber.Size = new System.Drawing.Size(28, 23);
            this.buttonJuniorNumber.TabIndex = 10;
            this.buttonJuniorNumber.Text = "^";
            this.buttonJuniorNumber.UseVisualStyleBackColor = true;
            this.buttonJuniorNumber.Click += new System.EventHandler(this.buttonJuniorNumber_Click);
            // 
            // labelProjectName
            // 
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Location = new System.Drawing.Point(13, 25);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(68, 13);
            this.labelProjectName.TabIndex = 9;
            this.labelProjectName.Text = "ProjectName";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(6, 95);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(310, 37);
            this.buttonUpdate.TabIndex = 8;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // textBoxRevisionNumber
            // 
            this.textBoxRevisionNumber.Location = new System.Drawing.Point(246, 69);
            this.textBoxRevisionNumber.Name = "textBoxRevisionNumber";
            this.textBoxRevisionNumber.Size = new System.Drawing.Size(39, 20);
            this.textBoxRevisionNumber.TabIndex = 6;
            // 
            // textBoxLayoutNumber
            // 
            this.textBoxLayoutNumber.Location = new System.Drawing.Point(167, 68);
            this.textBoxLayoutNumber.Name = "textBoxLayoutNumber";
            this.textBoxLayoutNumber.Size = new System.Drawing.Size(39, 20);
            this.textBoxLayoutNumber.TabIndex = 4;
            // 
            // textBoxJuniorNumber
            // 
            this.textBoxJuniorNumber.Location = new System.Drawing.Point(88, 67);
            this.textBoxJuniorNumber.Name = "textBoxJuniorNumber";
            this.textBoxJuniorNumber.Size = new System.Drawing.Size(39, 20);
            this.textBoxJuniorNumber.TabIndex = 2;
            // 
            // buttonSeniorNumber
            // 
            this.buttonSeniorNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSeniorNumber.Location = new System.Drawing.Point(54, 64);
            this.buttonSeniorNumber.Name = "buttonSeniorNumber";
            this.buttonSeniorNumber.Size = new System.Drawing.Size(28, 23);
            this.buttonSeniorNumber.TabIndex = 1;
            this.buttonSeniorNumber.Text = "^";
            this.buttonSeniorNumber.UseVisualStyleBackColor = true;
            this.buttonSeniorNumber.Click += new System.EventHandler(this.buttonSeniorNumber_Click);
            // 
            // textBoxSeniorNumber
            // 
            this.textBoxSeniorNumber.Location = new System.Drawing.Point(9, 66);
            this.textBoxSeniorNumber.Name = "textBoxSeniorNumber";
            this.textBoxSeniorNumber.Size = new System.Drawing.Size(39, 20);
            this.textBoxSeniorNumber.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(989, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // projectBindingSource1
            // 
            this.projectBindingSource1.DataSource = typeof(VersionUpdater.Project);
            // 
            // projectBindingSource
            // 
            this.projectBindingSource.DataSource = typeof(VersionUpdater.Project);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            this.pathDataGridViewTextBoxColumn.Width = 300;
            // 
            // currentDataGridViewTextBoxColumn
            // 
            this.currentDataGridViewTextBoxColumn.DataPropertyName = "Current";
            this.currentDataGridViewTextBoxColumn.HeaderText = "Current";
            this.currentDataGridViewTextBoxColumn.Name = "currentDataGridViewTextBoxColumn";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "VersionUpdater";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.BindingSource projectBindingSource;
        private System.Windows.Forms.BindingSource projectBindingSource1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonRevisionNumber;
        private System.Windows.Forms.Button buttonLayoutNumber;
        private System.Windows.Forms.Button buttonJuniorNumber;
        private System.Windows.Forms.Label labelProjectName;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox textBoxRevisionNumber;
        private System.Windows.Forms.TextBox textBoxLayoutNumber;
        private System.Windows.Forms.TextBox textBoxJuniorNumber;
        private System.Windows.Forms.Button buttonSeniorNumber;
        private System.Windows.Forms.TextBox textBoxSeniorNumber;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentDataGridViewTextBoxColumn;
    }
}

