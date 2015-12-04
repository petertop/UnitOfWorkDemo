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
            this.cmdNHibLight = new System.Windows.Forms.Button();
            this.chkRaiseError = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgOrders = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdUseGenericRepo = new System.Windows.Forms.Button();
            this.chkShowMessages = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgPearsons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrders)).BeginInit();
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
            this.cmdHelloHhib.Location = new System.Drawing.Point(121, 37);
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
            this.dgPearsons.Location = new System.Drawing.Point(11, 142);
            this.dgPearsons.Name = "dgPearsons";
            this.dgPearsons.Size = new System.Drawing.Size(679, 183);
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
            // cmdNHibLight
            // 
            this.cmdNHibLight.Location = new System.Drawing.Point(13, 95);
            this.cmdNHibLight.Name = "cmdNHibLight";
            this.cmdNHibLight.Size = new System.Drawing.Size(139, 23);
            this.cmdNHibLight.TabIndex = 6;
            this.cmdNHibLight.Text = "NHib Light";
            this.cmdNHibLight.UseVisualStyleBackColor = true;
            this.cmdNHibLight.Click += new System.EventHandler(this.cmdNHibLight_Click);
            // 
            // chkRaiseError
            // 
            this.chkRaiseError.AutoSize = true;
            this.chkRaiseError.Location = new System.Drawing.Point(158, 100);
            this.chkRaiseError.Name = "chkRaiseError";
            this.chkRaiseError.Size = new System.Drawing.Size(72, 17);
            this.chkRaiseError.TabIndex = 7;
            this.chkRaiseError.Text = "raise error";
            this.chkRaiseError.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Pearsons:";
            // 
            // dgOrders
            // 
            this.dgOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrders.Location = new System.Drawing.Point(11, 371);
            this.dgOrders.Name = "dgOrders";
            this.dgOrders.Size = new System.Drawing.Size(679, 202);
            this.dgOrders.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Orders:";
            // 
            // cmdUseGenericRepo
            // 
            this.cmdUseGenericRepo.Location = new System.Drawing.Point(230, 37);
            this.cmdUseGenericRepo.Name = "cmdUseGenericRepo";
            this.cmdUseGenericRepo.Size = new System.Drawing.Size(106, 23);
            this.cmdUseGenericRepo.TabIndex = 11;
            this.cmdUseGenericRepo.Text = "UseGeneric";
            this.cmdUseGenericRepo.UseVisualStyleBackColor = true;
            this.cmdUseGenericRepo.Click += new System.EventHandler(this.cmdUseGenericRepo_Click);
            // 
            // chkShowMessages
            // 
            this.chkShowMessages.AutoSize = true;
            this.chkShowMessages.Location = new System.Drawing.Point(237, 100);
            this.chkShowMessages.Name = "chkShowMessages";
            this.chkShowMessages.Size = new System.Drawing.Size(101, 17);
            this.chkShowMessages.TabIndex = 12;
            this.chkShowMessages.Text = "show messages";
            this.chkShowMessages.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 601);
            this.Controls.Add(this.chkShowMessages);
            this.Controls.Add(this.cmdUseGenericRepo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgOrders);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkRaiseError);
            this.Controls.Add(this.cmdNHibLight);
            this.Controls.Add(this.lblStatistics);
            this.Controls.Add(this.dgPearsons);
            this.Controls.Add(this.cmdWorkWithHHibRepo);
            this.Controls.Add(this.cmdHelloHhib);
            this.Controls.Add(this.cmdWorkWithRepository);
            this.Controls.Add(this.button1);
            this.Name = "frmMain";
            this.Text = "UnitOfWork IoC and... demos!";
            ((System.ComponentModel.ISupportInitialize)(this.dgPearsons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrders)).EndInit();
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
        private System.Windows.Forms.Button cmdNHibLight;
        private System.Windows.Forms.CheckBox chkRaiseError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgOrders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdUseGenericRepo;
        private System.Windows.Forms.CheckBox chkShowMessages;
    }
}

