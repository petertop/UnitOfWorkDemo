namespace UnitOfWorkDemo
{
    partial class frmMain
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
            this.button1 = new System.Windows.Forms.Button();
            this.cmdWorkWithRepository = new System.Windows.Forms.Button();
            this.cmdHelloHhib = new System.Windows.Forms.Button();
            this.cmdWorkWithHHibRepo = new System.Windows.Forms.Button();
            this.dgPearsons = new System.Windows.Forms.DataGridView();
            this.lblStatistics = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgPearsons)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Message";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdWorkWithRepository
            // 
            this.cmdWorkWithRepository.Location = new System.Drawing.Point(13, 66);
            this.cmdWorkWithRepository.Name = "cmdWorkWithRepository";
            this.cmdWorkWithRepository.Size = new System.Drawing.Size(139, 23);
            this.cmdWorkWithRepository.TabIndex = 1;
            this.cmdWorkWithRepository.Text = "Work With Repository";
            this.cmdWorkWithRepository.UseVisualStyleBackColor = true;
            this.cmdWorkWithRepository.Click += new System.EventHandler(this.cmdWorkWithRepository_Click);
            // 
            // cmdHelloHhib
            // 
            this.cmdHelloHhib.Location = new System.Drawing.Point(13, 95);
            this.cmdHelloHhib.Name = "cmdHelloHhib";
            this.cmdHelloHhib.Size = new System.Drawing.Size(102, 23);
            this.cmdHelloHhib.TabIndex = 2;
            this.cmdHelloHhib.Text = "Hello Hibernate!";
            this.cmdHelloHhib.UseVisualStyleBackColor = true;
            this.cmdHelloHhib.Click += new System.EventHandler(this.cmdHelloHib_Click);
            // 
            // cmdWorkWithHHibRepo
            // 
            this.cmdWorkWithHHibRepo.Location = new System.Drawing.Point(158, 66);
            this.cmdWorkWithHHibRepo.Name = "cmdWorkWithHHibRepo";
            this.cmdWorkWithHHibRepo.Size = new System.Drawing.Size(139, 23);
            this.cmdWorkWithHHibRepo.TabIndex = 3;
            this.cmdWorkWithHHibRepo.Text = "Work With NHib Repo";
            this.cmdWorkWithHHibRepo.UseVisualStyleBackColor = true;
            this.cmdWorkWithHHibRepo.Click += new System.EventHandler(this.cmdWorkWithHHibRepo_Click);
            // 
            // dgPearsons
            // 
            this.dgPearsons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPearsons.Location = new System.Drawing.Point(13, 124);
            this.dgPearsons.Name = "dgPearsons";
            this.dgPearsons.Size = new System.Drawing.Size(422, 183);
            this.dgPearsons.TabIndex = 4;
            // 
            // lblStatistics
            // 
            this.lblStatistics.AutoSize = true;
            this.lblStatistics.Location = new System.Drawing.Point(8, 9);
            this.lblStatistics.Name = "lblStatistics";
            this.lblStatistics.Size = new System.Drawing.Size(59, 13);
            this.lblStatistics.TabIndex = 5;
            this.lblStatistics.Text = "lblStatistics";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 319);
            this.Controls.Add(this.lblStatistics);
            this.Controls.Add(this.dgPearsons);
            this.Controls.Add(this.cmdWorkWithHHibRepo);
            this.Controls.Add(this.cmdHelloHhib);
            this.Controls.Add(this.cmdWorkWithRepository);
            this.Controls.Add(this.button1);
            this.Name = "frmMain";
            this.Text = "UnitOfWork IoC and... demos!";
            ((System.ComponentModel.ISupportInitialize)(this.dgPearsons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdWorkWithRepository;
        private System.Windows.Forms.Button cmdHelloHhib;
        private System.Windows.Forms.Button cmdWorkWithHHibRepo;
        private System.Windows.Forms.DataGridView dgPearsons;
        private System.Windows.Forms.Label lblStatistics;
    }
}

