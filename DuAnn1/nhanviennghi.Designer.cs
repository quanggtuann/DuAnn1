namespace DuAnn1
{
    partial class nhanviennghi
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
            dgvnhanviennghi = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvnhanviennghi).BeginInit();
            SuspendLayout();
            // 
            // dgvnhanviennghi
            // 
            dgvnhanviennghi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvnhanviennghi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvnhanviennghi.Dock = DockStyle.Fill;
            dgvnhanviennghi.Location = new Point(0, 0);
            dgvnhanviennghi.Name = "dgvnhanviennghi";
            dgvnhanviennghi.RowHeadersWidth = 51;
            dgvnhanviennghi.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvnhanviennghi.RowTemplate.Height = 29;
            dgvnhanviennghi.Size = new Size(851, 320);
            dgvnhanviennghi.TabIndex = 0;
            dgvnhanviennghi.CellClick += dgvnhanviennghi_CellClick;
            dgvnhanviennghi.CellContentClick += dgvnhanviennghi_CellContentClick;
            // 
            // nhanviennghi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(851, 320);
            Controls.Add(dgvnhanviennghi);
            Name = "nhanviennghi";
            Text = "nhanviennghi";
            Load += nhanviennghi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvnhanviennghi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvnhanviennghi;
    }
}