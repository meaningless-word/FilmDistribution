namespace Catalogs
{
	partial class CinemaForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CinemaForm));
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dgvObject = new System.Windows.Forms.DataGridView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.bnCinemas = new System.Windows.Forms.BindingNavigator(this.components);
			this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlPropertyHolder = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.edtOfficeNo = new System.Windows.Forms.TextBox();
			this.cbxCity = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbxElement = new System.Windows.Forms.ComboBox();
			this.edtBuildingNo = new System.Windows.Forms.TextBox();
			this.cbxStreet = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnDelAccount = new System.Windows.Forms.Button();
			this.btnAddAccount = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lstAccounts = new System.Windows.Forms.ListBox();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvObject)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bnCinemas)).BeginInit();
			this.bnCinemas.SuspendLayout();
			this.pnlPropertyHolder.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.panel1);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(765, 449);
			this.panel2.TabIndex = 8;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dgvObject);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(761, 414);
			this.panel1.TabIndex = 1;
			// 
			// dgvObject
			// 
			this.dgvObject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvObject.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvObject.Location = new System.Drawing.Point(0, 0);
			this.dgvObject.Name = "dgvObject";
			this.dgvObject.Size = new System.Drawing.Size(761, 414);
			this.dgvObject.TabIndex = 0;
			this.dgvObject.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObject_CellEndEdit);
			this.dgvObject.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvObject_CellValidating);
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.bnCinemas);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 414);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(761, 31);
			this.panel3.TabIndex = 2;
			// 
			// bnCinemas
			// 
			this.bnCinemas.AddNewItem = this.bindingNavigatorAddNewItem;
			this.bnCinemas.CountItem = this.bindingNavigatorCountItem;
			this.bnCinemas.DeleteItem = this.bindingNavigatorDeleteItem;
			this.bnCinemas.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bnCinemas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
			this.bnCinemas.Location = new System.Drawing.Point(0, 2);
			this.bnCinemas.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.bnCinemas.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.bnCinemas.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.bnCinemas.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.bnCinemas.Name = "bnCinemas";
			this.bnCinemas.PositionItem = this.bindingNavigatorPositionItem;
			this.bnCinemas.Size = new System.Drawing.Size(757, 25);
			this.bnCinemas.TabIndex = 0;
			this.bnCinemas.Text = "bindingNavigator1";
			// 
			// bindingNavigatorAddNewItem
			// 
			this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
			this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
			this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorAddNewItem.Text = "Добавить";
			// 
			// bindingNavigatorCountItem
			// 
			this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
			this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 22);
			this.bindingNavigatorCountItem.Text = "для {0}";
			this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
			// 
			// bindingNavigatorDeleteItem
			// 
			this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
			this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
			this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorDeleteItem.Text = "Удалить";
			// 
			// bindingNavigatorMoveFirstItem
			// 
			this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
			this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
			this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
			// 
			// bindingNavigatorMovePreviousItem
			// 
			this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
			this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
			this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
			// 
			// bindingNavigatorSeparator
			// 
			this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
			this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorPositionItem
			// 
			this.bindingNavigatorPositionItem.AccessibleName = "Положение";
			this.bindingNavigatorPositionItem.AutoSize = false;
			this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
			this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
			this.bindingNavigatorPositionItem.Text = "0";
			this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
			// 
			// bindingNavigatorSeparator1
			// 
			this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
			this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorMoveNextItem
			// 
			this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
			this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
			this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
			// 
			// bindingNavigatorMoveLastItem
			// 
			this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
			this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
			this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
			// 
			// bindingNavigatorSeparator2
			// 
			this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
			this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// pnlPropertyHolder
			// 
			this.pnlPropertyHolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlPropertyHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlPropertyHolder.Controls.Add(this.groupBox1);
			this.pnlPropertyHolder.Controls.Add(this.btnDelAccount);
			this.pnlPropertyHolder.Controls.Add(this.btnAddAccount);
			this.pnlPropertyHolder.Controls.Add(this.label1);
			this.pnlPropertyHolder.Controls.Add(this.lstAccounts);
			this.pnlPropertyHolder.Controls.Add(this.btnSave);
			this.pnlPropertyHolder.Location = new System.Drawing.Point(766, 0);
			this.pnlPropertyHolder.Name = "pnlPropertyHolder";
			this.pnlPropertyHolder.Size = new System.Drawing.Size(329, 449);
			this.pnlPropertyHolder.TabIndex = 9;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(243, 418);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 22);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Сохранить";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.edtOfficeNo);
			this.groupBox1.Controls.Add(this.cbxCity);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cbxElement);
			this.groupBox1.Controls.Add(this.edtBuildingNo);
			this.groupBox1.Controls.Add(this.cbxStreet);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(6, 104);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(311, 178);
			this.groupBox1.TabIndex = 39;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "адрес";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 13);
			this.label3.TabIndex = 33;
			this.label3.Text = "населенный пункт";
			// 
			// edtOfficeNo
			// 
			this.edtOfficeNo.Location = new System.Drawing.Point(95, 143);
			this.edtOfficeNo.Name = "edtOfficeNo";
			this.edtOfficeNo.Size = new System.Drawing.Size(57, 20);
			this.edtOfficeNo.TabIndex = 32;
			// 
			// cbxCity
			// 
			this.cbxCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxCity.FormattingEnabled = true;
			this.cbxCity.Location = new System.Drawing.Point(9, 32);
			this.cbxCity.Name = "cbxCity";
			this.cbxCity.Size = new System.Drawing.Size(222, 21);
			this.cbxCity.TabIndex = 26;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(36, 146);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 31;
			this.label2.Text = "№ офиса";
			// 
			// cbxElement
			// 
			this.cbxElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxElement.FormattingEnabled = true;
			this.cbxElement.Location = new System.Drawing.Point(9, 59);
			this.cbxElement.Name = "cbxElement";
			this.cbxElement.Size = new System.Drawing.Size(85, 21);
			this.cbxElement.TabIndex = 27;
			// 
			// edtBuildingNo
			// 
			this.edtBuildingNo.Location = new System.Drawing.Point(95, 117);
			this.edtBuildingNo.Name = "edtBuildingNo";
			this.edtBuildingNo.Size = new System.Drawing.Size(57, 20);
			this.edtBuildingNo.TabIndex = 30;
			// 
			// cbxStreet
			// 
			this.cbxStreet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxStreet.FormattingEnabled = true;
			this.cbxStreet.Location = new System.Drawing.Point(72, 86);
			this.cbxStreet.Name = "cbxStreet";
			this.cbxStreet.Size = new System.Drawing.Size(233, 21);
			this.cbxStreet.TabIndex = 28;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(79, 13);
			this.label4.TabIndex = 29;
			this.label4.Text = "дом/строение";
			// 
			// btnDelAccount
			// 
			this.btnDelAccount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelAccount.BackgroundImage")));
			this.btnDelAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnDelAccount.Location = new System.Drawing.Point(295, 51);
			this.btnDelAccount.Name = "btnDelAccount";
			this.btnDelAccount.Size = new System.Drawing.Size(23, 23);
			this.btnDelAccount.TabIndex = 38;
			this.btnDelAccount.UseVisualStyleBackColor = true;
			this.btnDelAccount.Click += new System.EventHandler(this.btnDelAccount_Click);
			// 
			// btnAddAccount
			// 
			this.btnAddAccount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddAccount.BackgroundImage")));
			this.btnAddAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnAddAccount.Location = new System.Drawing.Point(295, 22);
			this.btnAddAccount.Name = "btnAddAccount";
			this.btnAddAccount.Size = new System.Drawing.Size(23, 23);
			this.btnAddAccount.TabIndex = 37;
			this.btnAddAccount.UseVisualStyleBackColor = true;
			this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 13);
			this.label1.TabIndex = 36;
			this.label1.Text = "расчетные счета";
			// 
			// lstAccounts
			// 
			this.lstAccounts.FormattingEnabled = true;
			this.lstAccounts.Location = new System.Drawing.Point(3, 22);
			this.lstAccounts.Name = "lstAccounts";
			this.lstAccounts.Size = new System.Drawing.Size(286, 56);
			this.lstAccounts.TabIndex = 35;
			// 
			// CinemaForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1096, 450);
			this.Controls.Add(this.pnlPropertyHolder);
			this.Controls.Add(this.panel2);
			this.Name = "CinemaForm";
			this.Text = "Кинотеатры";
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvObject)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bnCinemas)).EndInit();
			this.bnCinemas.ResumeLayout(false);
			this.bnCinemas.PerformLayout();
			this.pnlPropertyHolder.ResumeLayout(false);
			this.pnlPropertyHolder.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dgvObject;
		private System.Windows.Forms.Panel pnlPropertyHolder;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.BindingNavigator bnCinemas;
		private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
		private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
		private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox edtOfficeNo;
		private System.Windows.Forms.ComboBox cbxCity;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbxElement;
		private System.Windows.Forms.TextBox edtBuildingNo;
		private System.Windows.Forms.ComboBox cbxStreet;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnDelAccount;
		private System.Windows.Forms.Button btnAddAccount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lstAccounts;
	}
}