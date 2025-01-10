// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace ScratchProject;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.DataGridView DataGridView1;
    private System.Windows.Forms.DataGridViewTextBoxColumn id;
    private System.Windows.Forms.DataGridViewCheckBoxColumn CB;
    private System.Windows.Forms.DataGridViewTextBoxColumn NameText;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.DataGridView1 = new System.Windows.Forms.DataGridView();
        this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.CB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        this.NameText = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
        this.SuspendLayout();
        // 
        // DataGridView1
        // 
        this.DataGridView1.AllowUserToAddRows = false;
        this.DataGridView1.AllowUserToDeleteRows = false;
        this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
          this.id,
          this.CB,
          this.NameText});
        this.DataGridView1.Location = new System.Drawing.Point(12, 12);
        this.DataGridView1.Name = "DataGridView1";
        this.DataGridView1.ReadOnly = true;
        this.DataGridView1.RowHeadersWidth = 62;
        this.DataGridView1.Size = new System.Drawing.Size(548, 426);
        this.DataGridView1.TabIndex = 0;
        this.DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
        // 
        // id
        // 
        this.id.HeaderText = "id";
        this.id.MinimumWidth = 8;
        this.id.Name = "id";
        this.id.ReadOnly = true;
        this.id.Width = 150;
        // 
        // CB
        // 
        this.CB.HeaderText = "CB";
        this.CB.MinimumWidth = 8;
        this.CB.Name = "CB";
        this.CB.ReadOnly = true;
        this.CB.Width = 150;
        // 
        // NameText
        // 
        this.NameText.HeaderText = "Text";
        this.NameText.MinimumWidth = 8;
        this.NameText.Name = "NameText";
        this.NameText.ReadOnly = true;
        this.NameText.Width = 150;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(10.0F, 25.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(581, 450);
        this.Controls.Add(this.DataGridView1);
        this.Name = "Form1";
        ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
        this.ResumeLayout(false);
    }
}
