﻿namespace Catalogs
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgvObject = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDel = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvObject)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel2.Controls.Add(this.dgvObject);
			this.panel2.Location = new System.Drawing.Point(0, 2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(790, 414);
			this.panel2.TabIndex = 7;
			// 
			// dgvObject
			// 
			this.dgvObject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvObject.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvObject.Location = new System.Drawing.Point(0, 0);
			this.dgvObject.Name = "dgvObject";
			this.dgvObject.Size = new System.Drawing.Size(790, 414);
			this.dgvObject.TabIndex = 0;
			this.dgvObject.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObject_CellEndEdit);
			this.dgvObject.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvObject_CellValidating);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.btnAdd);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnDel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 416);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(790, 34);
			this.panel1.TabIndex = 8;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(3, 4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 22);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Добавить";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(165, 4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 22);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Сохранить";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDel
			// 
			this.btnDel.Location = new System.Drawing.Point(84, 4);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(75, 22);
			this.btnDel.TabIndex = 3;
			this.btnDel.Text = "Удалить";
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			// 
			// ProviderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(790, 450);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Name = "ProviderForm";
			this.Text = "Поставщики";
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvObject)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dgvObject;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnDel;
	}
}