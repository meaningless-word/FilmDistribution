namespace Office
{
	partial class CreateLeasingForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateLeasingForm));
			this.btnOk = new System.Windows.Forms.Button();
			this.cbxCinema = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.edtTitlePart = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.edtYearRange = new System.Windows.Forms.TextBox();
			this.btnRefreshFilms = new System.Windows.Forms.Button();
			this.cbxFilms = new System.Windows.Forms.ComboBox();
			this.ttpYearRange = new System.Windows.Forms.ToolTip(this.components);
			this.gpbPeriod = new System.Windows.Forms.GroupBox();
			this.dtpStop = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dtpStart = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.edtRentPrice = new System.Windows.Forms.TextBox();
			this.erpValidator = new System.Windows.Forms.ErrorProvider(this.components);
			this.label7 = new System.Windows.Forms.Label();
			this.edtDelayPrice = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.edtDocumentNo = new System.Windows.Forms.TextBox();
			this.gpbPeriod.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.erpValidator)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(76, 3);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 13;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// cbxCinema
			// 
			this.cbxCinema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxCinema.FormattingEnabled = true;
			this.cbxCinema.Location = new System.Drawing.Point(12, 66);
			this.cbxCinema.Name = "cbxCinema";
			this.cbxCinema.Size = new System.Drawing.Size(280, 21);
			this.cbxCinema.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "кинотеатр";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 101);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "фильм с фрагментом названия";
			// 
			// edtTitlePart
			// 
			this.edtTitlePart.Location = new System.Drawing.Point(183, 98);
			this.edtTitlePart.Name = "edtTitlePart";
			this.edtTitlePart.Size = new System.Drawing.Size(109, 20);
			this.edtTitlePart.TabIndex = 4;
			this.edtTitlePart.Enter += new System.EventHandler(this.edtTitlePart_Enter);
			this.edtTitlePart.Leave += new System.EventHandler(this.edtTitlePart_Leave);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 125);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(105, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "или годом выпуска";
			// 
			// edtYearRange
			// 
			this.edtYearRange.Location = new System.Drawing.Point(120, 122);
			this.edtYearRange.Name = "edtYearRange";
			this.edtYearRange.Size = new System.Drawing.Size(113, 20);
			this.edtYearRange.TabIndex = 6;
			this.edtYearRange.Enter += new System.EventHandler(this.edtYearRange_Enter);
			this.edtYearRange.Leave += new System.EventHandler(this.edtYearRange_Leave);
			// 
			// btnRefreshFilms
			// 
			this.btnRefreshFilms.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefreshFilms.BackgroundImage")));
			this.btnRefreshFilms.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnRefreshFilms.Location = new System.Drawing.Point(239, 120);
			this.btnRefreshFilms.Name = "btnRefreshFilms";
			this.btnRefreshFilms.Size = new System.Drawing.Size(23, 23);
			this.btnRefreshFilms.TabIndex = 7;
			this.btnRefreshFilms.UseVisualStyleBackColor = true;
			this.btnRefreshFilms.Click += new System.EventHandler(this.btnRefreshFilms_Click);
			// 
			// cbxFilms
			// 
			this.cbxFilms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxFilms.FormattingEnabled = true;
			this.cbxFilms.ItemHeight = 13;
			this.cbxFilms.Location = new System.Drawing.Point(12, 146);
			this.cbxFilms.Name = "cbxFilms";
			this.cbxFilms.Size = new System.Drawing.Size(280, 21);
			this.cbxFilms.TabIndex = 8;
			this.cbxFilms.SelectedIndexChanged += new System.EventHandler(this.cbxFilms_SelectedIndexChanged);
			// 
			// ttpYearRange
			// 
			this.ttpYearRange.ShowAlways = true;
			// 
			// gpbPeriod
			// 
			this.gpbPeriod.Controls.Add(this.dtpStop);
			this.gpbPeriod.Controls.Add(this.label5);
			this.gpbPeriod.Controls.Add(this.label4);
			this.gpbPeriod.Controls.Add(this.dtpStart);
			this.gpbPeriod.Location = new System.Drawing.Point(12, 179);
			this.gpbPeriod.Name = "gpbPeriod";
			this.gpbPeriod.Size = new System.Drawing.Size(280, 56);
			this.gpbPeriod.TabIndex = 9;
			this.gpbPeriod.TabStop = false;
			this.gpbPeriod.Text = "период проката";
			// 
			// dtpStop
			// 
			this.dtpStop.CustomFormat = "dd.MM.yyyy";
			this.dtpStop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStop.Location = new System.Drawing.Point(162, 19);
			this.dtpStop.Name = "dtpStop";
			this.dtpStop.Size = new System.Drawing.Size(94, 20);
			this.dtpStop.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(137, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(19, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "по";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(13, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "с";
			// 
			// dtpStart
			// 
			this.dtpStart.CustomFormat = "dd.MM.yyyy";
			this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStart.Location = new System.Drawing.Point(37, 19);
			this.dtpStart.Name = "dtpStart";
			this.dtpStart.Size = new System.Drawing.Size(94, 20);
			this.dtpStart.TabIndex = 0;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(15, 247);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(102, 13);
			this.label6.TabIndex = 17;
			this.label6.Text = "стоимость аренды";
			// 
			// edtRentPrice
			// 
			this.edtRentPrice.Location = new System.Drawing.Point(123, 244);
			this.edtRentPrice.Name = "edtRentPrice";
			this.edtRentPrice.Size = new System.Drawing.Size(100, 20);
			this.edtRentPrice.TabIndex = 11;
			this.edtRentPrice.Validating += new System.ComponentModel.CancelEventHandler(this.edtRentPrice_Validating);
			this.edtRentPrice.Validated += new System.EventHandler(this.edtRentPrice_Validated);
			// 
			// erpValidator
			// 
			this.erpValidator.BlinkRate = 0;
			this.erpValidator.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.erpValidator.ContainerControl = this;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(15, 279);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(138, 13);
			this.label7.TabIndex = 21;
			this.label7.Text = "стоимость дня просрочки";
			// 
			// edtDelayPrice
			// 
			this.edtDelayPrice.Location = new System.Drawing.Point(159, 276);
			this.edtDelayPrice.Name = "edtDelayPrice";
			this.edtDelayPrice.Size = new System.Drawing.Size(100, 20);
			this.edtDelayPrice.TabIndex = 12;
			this.edtDelayPrice.Validating += new System.ComponentModel.CancelEventHandler(this.edtDelayPrice_Validating);
			this.edtDelayPrice.Validated += new System.EventHandler(this.edtDelayPrice_Validated);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnOk);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 302);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(309, 33);
			this.panel1.TabIndex = 23;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(157, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "Отмена";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(9, 18);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(96, 13);
			this.label8.TabIndex = 24;
			this.label8.Text = "номер документа";
			// 
			// edtDocumentNo
			// 
			this.edtDocumentNo.Location = new System.Drawing.Point(111, 15);
			this.edtDocumentNo.Name = "edtDocumentNo";
			this.edtDocumentNo.Size = new System.Drawing.Size(181, 20);
			this.edtDocumentNo.TabIndex = 0;
			// 
			// CreateLeasingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(309, 335);
			this.Controls.Add(this.edtDocumentNo);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.edtDelayPrice);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.edtRentPrice);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.gpbPeriod);
			this.Controls.Add(this.cbxFilms);
			this.Controls.Add(this.btnRefreshFilms);
			this.Controls.Add(this.edtYearRange);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.edtTitlePart);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbxCinema);
			this.Name = "CreateLeasingForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Новый договор аренды";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateLeasingForm_FormClosing);
			this.gpbPeriod.ResumeLayout(false);
			this.gpbPeriod.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.erpValidator)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.ComboBox cbxCinema;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox edtTitlePart;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox edtYearRange;
		private System.Windows.Forms.Button btnRefreshFilms;
		private System.Windows.Forms.ComboBox cbxFilms;
		private System.Windows.Forms.ToolTip ttpYearRange;
		private System.Windows.Forms.GroupBox gpbPeriod;
		private System.Windows.Forms.DateTimePicker dtpStart;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dtpStop;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox edtRentPrice;
		private System.Windows.Forms.ErrorProvider erpValidator;
		private System.Windows.Forms.TextBox edtDelayPrice;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox edtDocumentNo;
		private System.Windows.Forms.Label label8;
	}
}