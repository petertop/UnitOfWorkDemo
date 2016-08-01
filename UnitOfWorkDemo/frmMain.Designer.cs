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
            this.cmdMessage = new System.Windows.Forms.Button();
            this.cmdWorkWithRepository = new System.Windows.Forms.Button();
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
            this.label3 = new System.Windows.Forms.Label();
            this.dgLogs = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPearsonCounts = new System.Windows.Forms.Label();
            this.lblOrdersCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLogCount = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgPearsons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLogs)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdMessage
            // 
            this.cmdMessage.Location = new System.Drawing.Point(203, 95);
            this.cmdMessage.Name = "cmdMessage";
            this.cmdMessage.Size = new System.Drawing.Size(152, 23);
            this.cmdMessage.TabIndex = 0;
            this.cmdMessage.Text = "IoC demo Service call";
            this.cmdMessage.UseVisualStyleBackColor = true;
            this.cmdMessage.Click += new System.EventHandler(this.cmdMessage_Click);
            // 
            // cmdWorkWithRepository
            // 
            this.cmdWorkWithRepository.Location = new System.Drawing.Point(11, 66);
            this.cmdWorkWithRepository.Name = "cmdWorkWithRepository";
            this.cmdWorkWithRepository.Size = new System.Drawing.Size(184, 23);
            this.cmdWorkWithRepository.TabIndex = 1;
            this.cmdWorkWithRepository.Text = "Work With Concrete Repository";
            this.cmdWorkWithRepository.UseVisualStyleBackColor = true;
            this.cmdWorkWithRepository.Click += new System.EventHandler(this.cmdWorkWithRepository_Click);
            // 
            // cmdWorkWithHHibRepo
            // 
            this.cmdWorkWithHHibRepo.Location = new System.Drawing.Point(203, 66);
            this.cmdWorkWithHHibRepo.Name = "cmdWorkWithHHibRepo";
            this.cmdWorkWithHHibRepo.Size = new System.Drawing.Size(152, 23);
            this.cmdWorkWithHHibRepo.TabIndex = 3;
            this.cmdWorkWithHHibRepo.Text = "Work With Light Repo";
            this.cmdWorkWithHHibRepo.UseVisualStyleBackColor = true;
            this.cmdWorkWithHHibRepo.Click += new System.EventHandler(this.cmdWorkWithHHibRepo_Click);
            // 
            // dgPearsons
            // 
            this.dgPearsons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPearsons.Location = new System.Drawing.Point(11, 142);
            this.dgPearsons.Name = "dgPearsons";
            this.dgPearsons.Size = new System.Drawing.Size(679, 142);
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
            this.cmdNHibLight.Location = new System.Drawing.Point(11, 36);
            this.cmdNHibLight.Name = "cmdNHibLight";
            this.cmdNHibLight.Size = new System.Drawing.Size(184, 23);
            this.cmdNHibLight.TabIndex = 6;
            this.cmdNHibLight.Text = "NHib Light";
            this.cmdNHibLight.UseVisualStyleBackColor = true;
            this.cmdNHibLight.Click += new System.EventHandler(this.cmdNHibLight_Click);
            // 
            // chkRaiseError
            // 
            this.chkRaiseError.AutoSize = true;
            this.chkRaiseError.Location = new System.Drawing.Point(14, 96);
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
            this.dgOrders.Location = new System.Drawing.Point(11, 311);
            this.dgOrders.Name = "dgOrders";
            this.dgOrders.Size = new System.Drawing.Size(679, 134);
            this.dgOrders.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Orders:";
            // 
            // cmdUseGenericRepo
            // 
            this.cmdUseGenericRepo.Location = new System.Drawing.Point(203, 37);
            this.cmdUseGenericRepo.Name = "cmdUseGenericRepo";
            this.cmdUseGenericRepo.Size = new System.Drawing.Size(152, 23);
            this.cmdUseGenericRepo.TabIndex = 11;
            this.cmdUseGenericRepo.Text = "UseGeneric";
            this.cmdUseGenericRepo.UseVisualStyleBackColor = true;
            this.cmdUseGenericRepo.Click += new System.EventHandler(this.cmdUseGenericRepo_Click);
            // 
            // chkShowMessages
            // 
            this.chkShowMessages.AutoSize = true;
            this.chkShowMessages.Location = new System.Drawing.Point(96, 96);
            this.chkShowMessages.Name = "chkShowMessages";
            this.chkShowMessages.Size = new System.Drawing.Size(101, 17);
            this.chkShowMessages.TabIndex = 12;
            this.chkShowMessages.Text = "show messages";
            this.chkShowMessages.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 452);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Logs:";
            // 
            // dgLogs
            // 
            this.dgLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLogs.Location = new System.Drawing.Point(11, 469);
            this.dgLogs.Name = "dgLogs";
            this.dgLogs.Size = new System.Drawing.Size(679, 140);
            this.dgLogs.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.lblLogCount);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblOrdersCount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblPearsonCounts);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(475, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pearsons:";
            // 
            // lblPearsonCounts
            // 
            this.lblPearsonCounts.AutoSize = true;
            this.lblPearsonCounts.ForeColor = System.Drawing.Color.Blue;
            this.lblPearsonCounts.Location = new System.Drawing.Point(77, 20);
            this.lblPearsonCounts.Name = "lblPearsonCounts";
            this.lblPearsonCounts.Size = new System.Drawing.Size(86, 13);
            this.lblPearsonCounts.TabIndex = 1;
            this.lblPearsonCounts.Text = "PearsonCount";
            // 
            // lblOrdersCount
            // 
            this.lblOrdersCount.AutoSize = true;
            this.lblOrdersCount.ForeColor = System.Drawing.Color.Blue;
            this.lblOrdersCount.Location = new System.Drawing.Point(77, 40);
            this.lblOrdersCount.Name = "lblOrdersCount";
            this.lblOrdersCount.Size = new System.Drawing.Size(77, 13);
            this.lblOrdersCount.TabIndex = 3;
            this.lblOrdersCount.Text = "OrdersCount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Orders:";
            // 
            // lblLogCount
            // 
            this.lblLogCount.AutoSize = true;
            this.lblLogCount.ForeColor = System.Drawing.Color.Blue;
            this.lblLogCount.Location = new System.Drawing.Point(77, 60);
            this.lblLogCount.Name = "lblLogCount";
            this.lblLogCount.Size = new System.Drawing.Size(86, 13);
            this.lblLogCount.TabIndex = 5;
            this.lblLogCount.Text = "PearsonCount";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Logs:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(6, 77);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(34, 13);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Time";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 621);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgLogs);
            this.Controls.Add(this.label3);
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
            this.Controls.Add(this.cmdWorkWithRepository);
            this.Controls.Add(this.cmdMessage);
            this.Name = "frmMain";
            this.Text = "UnitOfWork IoC and... demos!";
            ((System.ComponentModel.ISupportInitialize)(this.dgPearsons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLogs)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdMessage;
        private System.Windows.Forms.Button cmdWorkWithRepository;
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgLogs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLogCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblOrdersCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPearsonCounts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTime;
    }
}

