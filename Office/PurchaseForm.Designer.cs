﻿namespace Office
{
	partial class PurchaseForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnSet = new System.Windows.Forms.Button();
			this.cbxField = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.edtWord = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.dgvFilms = new System.Windows.Forms.DataGridView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.bnFilms = new System.Windows.Forms.BindingNavigator(this.components);
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
			this.edtCost = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cbxProvider = new System.Windows.Forms.ComboBox();
			this.btnRefreshProvider = new System.Windows.Forms.Button();
			this.btnRefreshCategory = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.edtProduct = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.edtDirector = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.edtScreenwriter = new System.Windows.Forms.TextBox();
			this.cbxCategory = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.edtYearOfRelease = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.edtTitle = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvFilms)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bnFilms)).BeginInit();
			this.bnFilms.SuspendLayout();
			this.pnlPropertyHolder.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.btnClear);
			this.panel1.Controls.Add(this.btnSet);
			this.panel1.Controls.Add(this.cbxField);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.edtWord);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(741, 28);
			this.panel1.TabIndex = 0;
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(656, 0);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 5;
			this.btnClear.Text = "Сброс";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnSet
			// 
			this.btnSet.Location = new System.Drawing.Point(575, 1);
			this.btnSet.Name = "btnSet";
			this.btnSet.Size = new System.Drawing.Size(75, 23);
			this.btnSet.TabIndex = 4;
			this.btnSet.Text = "Установить";
			this.btnSet.UseVisualStyleBackColor = true;
			this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
			// 
			// cbxField
			// 
			this.cbxField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxField.FormattingEnabled = true;
			this.cbxField.Location = new System.Drawing.Point(419, 3);
			this.cbxField.Name = "cbxField";
			this.cbxField.Size = new System.Drawing.Size(150, 21);
			this.cbxField.TabIndex = 3;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(373, 7);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(40, 13);
			this.label10.TabIndex = 2;
			this.label10.Text = "в поле";
			// 
			// edtWord
			// 
			this.edtWord.Location = new System.Drawing.Point(127, 3);
			this.edtWord.Name = "edtWord";
			this.edtWord.Size = new System.Drawing.Size(236, 20);
			this.edtWord.TabIndex = 1;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(119, 13);
			this.label9.TabIndex = 0;
			this.label9.Text = "фильтр по вхождению";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.panel5);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Location = new System.Drawing.Point(0, 28);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(421, 422);
			this.panel2.TabIndex = 1;
			// 
			// panel5
			// 
			this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel5.Controls.Add(this.dgvFilms);
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(417, 388);
			this.panel5.TabIndex = 1;
			// 
			// dgvFilms
			// 
			this.dgvFilms.AllowUserToAddRows = false;
			this.dgvFilms.AllowUserToDeleteRows = false;
			this.dgvFilms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFilms.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvFilms.Location = new System.Drawing.Point(0, 0);
			this.dgvFilms.Name = "dgvFilms";
			this.dgvFilms.ReadOnly = true;
			this.dgvFilms.Size = new System.Drawing.Size(417, 388);
			this.dgvFilms.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.bnFilms);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 392);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(417, 26);
			this.panel3.TabIndex = 0;
			// 
			// bnFilms
			// 
			this.bnFilms.AddNewItem = this.bindingNavigatorAddNewItem;
			this.bnFilms.CountItem = this.bindingNavigatorCountItem;
			this.bnFilms.DeleteItem = this.bindingNavigatorDeleteItem;
			this.bnFilms.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bnFilms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
			this.bnFilms.Location = new System.Drawing.Point(0, -3);
			this.bnFilms.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.bnFilms.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.bnFilms.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.bnFilms.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.bnFilms.Name = "bnFilms";
			this.bnFilms.PositionItem = this.bindingNavigatorPositionItem;
			this.bnFilms.Size = new System.Drawing.Size(413, 25);
			this.bnFilms.TabIndex = 0;
			this.bnFilms.Text = "bindingNavigator1";
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
			this.pnlPropertyHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlPropertyHolder.Controls.Add(this.btnSave);
			this.pnlPropertyHolder.Controls.Add(this.edtCost);
			this.pnlPropertyHolder.Controls.Add(this.label8);
			this.pnlPropertyHolder.Controls.Add(this.cbxProvider);
			this.pnlPropertyHolder.Controls.Add(this.btnRefreshProvider);
			this.pnlPropertyHolder.Controls.Add(this.btnRefreshCategory);
			this.pnlPropertyHolder.Controls.Add(this.label7);
			this.pnlPropertyHolder.Controls.Add(this.edtProduct);
			this.pnlPropertyHolder.Controls.Add(this.label6);
			this.pnlPropertyHolder.Controls.Add(this.edtDirector);
			this.pnlPropertyHolder.Controls.Add(this.label5);
			this.pnlPropertyHolder.Controls.Add(this.label4);
			this.pnlPropertyHolder.Controls.Add(this.edtScreenwriter);
			this.pnlPropertyHolder.Controls.Add(this.cbxCategory);
			this.pnlPropertyHolder.Controls.Add(this.label3);
			this.pnlPropertyHolder.Controls.Add(this.edtYearOfRelease);
			this.pnlPropertyHolder.Controls.Add(this.label2);
			this.pnlPropertyHolder.Controls.Add(this.label1);
			this.pnlPropertyHolder.Controls.Add(this.edtTitle);
			this.pnlPropertyHolder.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlPropertyHolder.Location = new System.Drawing.Point(421, 28);
			this.pnlPropertyHolder.Name = "pnlPropertyHolder";
			this.pnlPropertyHolder.Size = new System.Drawing.Size(320, 422);
			this.pnlPropertyHolder.TabIndex = 2;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(234, 365);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 17;
			this.btnSave.Text = "Сохранить";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// edtCost
			// 
			this.edtCost.Location = new System.Drawing.Point(6, 328);
			this.edtCost.Name = "edtCost";
			this.edtCost.Size = new System.Drawing.Size(100, 20);
			this.edtCost.TabIndex = 16;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(7, 312);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(61, 13);
			this.label8.TabIndex = 15;
			this.label8.Text = "стоимость";
			// 
			// cbxProvider
			// 
			this.cbxProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxProvider.FormattingEnabled = true;
			this.cbxProvider.Location = new System.Drawing.Point(7, 288);
			this.cbxProvider.Name = "cbxProvider";
			this.cbxProvider.Size = new System.Drawing.Size(279, 21);
			this.cbxProvider.TabIndex = 14;
			// 
			// btnRefreshProvider
			// 
			this.btnRefreshProvider.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefreshProvider.BackgroundImage")));
			this.btnRefreshProvider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnRefreshProvider.Location = new System.Drawing.Point(287, 286);
			this.btnRefreshProvider.Name = "btnRefreshProvider";
			this.btnRefreshProvider.Size = new System.Drawing.Size(23, 23);
			this.btnRefreshProvider.TabIndex = 13;
			this.btnRefreshProvider.UseVisualStyleBackColor = true;
			this.btnRefreshProvider.Click += new System.EventHandler(this.btnRefreshProvider_Click);
			// 
			// btnRefreshCategory
			// 
			this.btnRefreshCategory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefreshCategory.BackgroundImage")));
			this.btnRefreshCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnRefreshCategory.Location = new System.Drawing.Point(287, 53);
			this.btnRefreshCategory.Name = "btnRefreshCategory";
			this.btnRefreshCategory.Size = new System.Drawing.Size(23, 23);
			this.btnRefreshCategory.TabIndex = 13;
			this.btnRefreshCategory.UseVisualStyleBackColor = true;
			this.btnRefreshCategory.Click += new System.EventHandler(this.btnRefreshCategory_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(5, 272);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "поставщик";
			// 
			// edtProduct
			// 
			this.edtProduct.Location = new System.Drawing.Point(7, 249);
			this.edtProduct.Name = "edtProduct";
			this.edtProduct.Size = new System.Drawing.Size(303, 20);
			this.edtProduct.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 233);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(137, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "компания производитель";
			// 
			// edtDirector
			// 
			this.edtDirector.Location = new System.Drawing.Point(6, 171);
			this.edtDirector.Multiline = true;
			this.edtDirector.Name = "edtDirector";
			this.edtDirector.Size = new System.Drawing.Size(303, 59);
			this.edtDirector.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(4, 155);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(134, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "режиссёр - постановщик";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 79);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(87, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "автор сценария";
			// 
			// edtScreenwriter
			// 
			this.edtScreenwriter.Location = new System.Drawing.Point(6, 95);
			this.edtScreenwriter.Multiline = true;
			this.edtScreenwriter.Name = "edtScreenwriter";
			this.edtScreenwriter.Size = new System.Drawing.Size(304, 57);
			this.edtScreenwriter.TabIndex = 6;
			// 
			// cbxCategory
			// 
			this.cbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxCategory.FormattingEnabled = true;
			this.cbxCategory.Location = new System.Drawing.Point(124, 55);
			this.cbxCategory.Name = "cbxCategory";
			this.cbxCategory.Size = new System.Drawing.Size(161, 21);
			this.cbxCategory.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(121, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "категория";
			// 
			// edtYearOfRelease
			// 
			this.edtYearOfRelease.Location = new System.Drawing.Point(6, 56);
			this.edtYearOfRelease.Name = "edtYearOfRelease";
			this.edtYearOfRelease.Size = new System.Drawing.Size(50, 20);
			this.edtYearOfRelease.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "год выхода на экран";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "название";
			// 
			// edtTitle
			// 
			this.edtTitle.Location = new System.Drawing.Point(6, 17);
			this.edtTitle.Name = "edtTitle";
			this.edtTitle.Size = new System.Drawing.Size(306, 20);
			this.edtTitle.TabIndex = 0;
			// 
			// PurchaseForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(741, 450);
			this.Controls.Add(this.pnlPropertyHolder);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "PurchaseForm";
			this.Text = "Отдел закупок";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvFilms)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bnFilms)).EndInit();
			this.bnFilms.ResumeLayout(false);
			this.bnFilms.PerformLayout();
			this.pnlPropertyHolder.ResumeLayout(false);
			this.pnlPropertyHolder.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel pnlPropertyHolder;
		private System.Windows.Forms.DataGridView dgvFilms;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox edtTitle;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbxCategory;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox edtYearOfRelease;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox edtScreenwriter;
		private System.Windows.Forms.TextBox edtDirector;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox edtProduct;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnRefreshCategory;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cbxProvider;
		private System.Windows.Forms.Button btnRefreshProvider;
		private System.Windows.Forms.TextBox edtCost;
		private System.Windows.Forms.BindingNavigator bnFilms;
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
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.ComboBox cbxField;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox edtWord;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnSet;
	}
}