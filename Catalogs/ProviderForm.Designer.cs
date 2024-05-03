namespace Catalogs
{
	partial class ProviderForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProviderForm));
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dgvObject = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.bnProviders = new System.Windows.Forms.BindingNavigator(this.components);
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
			this.btnSave = new System.Windows.Forms.Button();
			this.pnlPropertyHolder = new System.Windows.Forms.Panel();
			this.btnDelAccount = new System.Windows.Forms.Button();
			this.btnAddAccount = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lstAccounts = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.edtOfficeNo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.edtBuildingNo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbxStreet = new System.Windows.Forms.ComboBox();
			this.cbxElement = new System.Windows.Forms.ComboBox();
			this.cbxCity = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvObject)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bnProviders)).BeginInit();
			this.bnProviders.SuspendLayout();
			this.pnlPropertyHolder.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.panel1);
			this.panel2.Location = new System.Drawing.Point(0, 2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(371, 452);
			this.panel2.TabIndex = 7;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dgvObject);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(367, 414);
			this.panel3.TabIndex = 9;
			// 
			// dgvObject
			// 
			this.dgvObject.AllowUserToAddRows = false;
			this.dgvObject.AllowUserToDeleteRows = false;
			this.dgvObject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvObject.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvObject.Location = new System.Drawing.Point(0, 0);
			this.dgvObject.Name = "dgvObject";
			this.dgvObject.Size = new System.Drawing.Size(367, 414);
			this.dgvObject.TabIndex = 0;
			this.dgvObject.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObject_CellEndEdit);
			this.dgvObject.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvObject_CellValidating);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.bnProviders);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 414);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(367, 34);
			this.panel1.TabIndex = 8;
			// 
			// bnProviders
			// 
			this.bnProviders.AddNewItem = this.bindingNavigatorAddNewItem;
			this.bnProviders.CountItem = this.bindingNavigatorCountItem;
			this.bnProviders.DeleteItem = this.bindingNavigatorDeleteItem;
			this.bnProviders.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bnProviders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
			this.bnProviders.Location = new System.Drawing.Point(0, 5);
			this.bnProviders.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.bnProviders.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.bnProviders.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.bnProviders.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.bnProviders.Name = "bnProviders";
			this.bnProviders.PositionItem = this.bindingNavigatorPositionItem;
			this.bnProviders.Size = new System.Drawing.Size(363, 25);
			this.bnProviders.TabIndex = 0;
			this.bnProviders.Text = "bindingNavigator1";
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
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(244, 423);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 22);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Сохранить";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// pnlPropertyHolder
			// 
			this.pnlPropertyHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlPropertyHolder.Controls.Add(this.groupBox1);
			this.pnlPropertyHolder.Controls.Add(this.btnDelAccount);
			this.pnlPropertyHolder.Controls.Add(this.btnAddAccount);
			this.pnlPropertyHolder.Controls.Add(this.label1);
			this.pnlPropertyHolder.Controls.Add(this.lstAccounts);
			this.pnlPropertyHolder.Controls.Add(this.btnSave);
			this.pnlPropertyHolder.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlPropertyHolder.Location = new System.Drawing.Point(371, 0);
			this.pnlPropertyHolder.Name = "pnlPropertyHolder";
			this.pnlPropertyHolder.Size = new System.Drawing.Size(327, 454);
			this.pnlPropertyHolder.TabIndex = 8;
			// 
			// btnDelAccount
			// 
			this.btnDelAccount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelAccount.BackgroundImage")));
			this.btnDelAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnDelAccount.Location = new System.Drawing.Point(297, 55);
			this.btnDelAccount.Name = "btnDelAccount";
			this.btnDelAccount.Size = new System.Drawing.Size(23, 23);
			this.btnDelAccount.TabIndex = 25;
			this.btnDelAccount.UseVisualStyleBackColor = true;
			this.btnDelAccount.Click += new System.EventHandler(this.btnDelAccount_Click);
			// 
			// btnAddAccount
			// 
			this.btnAddAccount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddAccount.BackgroundImage")));
			this.btnAddAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnAddAccount.Location = new System.Drawing.Point(297, 26);
			this.btnAddAccount.Name = "btnAddAccount";
			this.btnAddAccount.Size = new System.Drawing.Size(23, 23);
			this.btnAddAccount.TabIndex = 24;
			this.btnAddAccount.UseVisualStyleBackColor = true;
			this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "расчетные счета";
			// 
			// lstAccounts
			// 
			this.lstAccounts.FormattingEnabled = true;
			this.lstAccounts.Location = new System.Drawing.Point(5, 26);
			this.lstAccounts.Name = "lstAccounts";
			this.lstAccounts.Size = new System.Drawing.Size(286, 56);
			this.lstAccounts.TabIndex = 3;
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(36, 146);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 31;
			this.label2.Text = "№ офиса";
			// 
			// edtBuildingNo
			// 
			this.edtBuildingNo.Location = new System.Drawing.Point(95, 117);
			this.edtBuildingNo.Name = "edtBuildingNo";
			this.edtBuildingNo.Size = new System.Drawing.Size(57, 20);
			this.edtBuildingNo.TabIndex = 30;
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
			// cbxStreet
			// 
			this.cbxStreet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxStreet.FormattingEnabled = true;
			this.cbxStreet.Location = new System.Drawing.Point(72, 86);
			this.cbxStreet.Name = "cbxStreet";
			this.cbxStreet.Size = new System.Drawing.Size(233, 21);
			this.cbxStreet.TabIndex = 28;
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
			// cbxCity
			// 
			this.cbxCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxCity.FormattingEnabled = true;
			this.cbxCity.Location = new System.Drawing.Point(9, 32);
			this.cbxCity.Name = "cbxCity";
			this.cbxCity.Size = new System.Drawing.Size(222, 21);
			this.cbxCity.TabIndex = 26;
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
			this.groupBox1.Location = new System.Drawing.Point(8, 108);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(311, 178);
			this.groupBox1.TabIndex = 34;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "адрес";
			// 
			// ProviderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(698, 454);
			this.Controls.Add(this.pnlPropertyHolder);
			this.Controls.Add(this.panel2);
			this.Name = "ProviderForm";
			this.Text = "Поставщики";
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvObject)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bnProviders)).EndInit();
			this.bnProviders.ResumeLayout(false);
			this.bnProviders.PerformLayout();
			this.pnlPropertyHolder.ResumeLayout(false);
			this.pnlPropertyHolder.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dgvObject;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Panel pnlPropertyHolder;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.BindingNavigator bnProviders;
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
		private System.Windows.Forms.ListBox lstAccounts;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnDelAccount;
		private System.Windows.Forms.Button btnAddAccount;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox edtOfficeNo;
		private System.Windows.Forms.ComboBox cbxCity;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbxElement;
		private System.Windows.Forms.TextBox edtBuildingNo;
		private System.Windows.Forms.ComboBox cbxStreet;
		private System.Windows.Forms.Label label4;
	}
}