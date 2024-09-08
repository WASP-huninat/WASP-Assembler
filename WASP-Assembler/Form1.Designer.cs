namespace WASP_Assembler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            treeView1 = new TreeView();
            ui1 = new WASP_huninat.WinForms.CustomControls.RtbWithLineNumbers.UI();
            ui2 = new WASP_huninat.WinForms.CustomControls.RtbWithLineNumbers.UI();
            toolStrip1 = new ToolStrip();
            Selected_Assembler = new ToolStripDropDownButton();
            StartAssembleButto = new ToolStripButton();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tableLayoutPanel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.DarkGray;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 2, 0);
            tableLayoutPanel1.Controls.Add(treeView1, 0, 1);
            tableLayoutPanel1.Controls.Add(ui1, 1, 1);
            tableLayoutPanel1.Controls.Add(ui2, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 27);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.Size = new Size(971, 456);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DimGray;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(3, 3);
            label1.Margin = new Padding(3);
            label1.Name = "label1";
            label1.Size = new Size(285, 20);
            label1.TabIndex = 0;
            label1.Text = "Project";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.DimGray;
            label2.Dock = DockStyle.Fill;
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(294, 3);
            label2.Margin = new Padding(3);
            label2.Name = "label2";
            label2.Size = new Size(333, 20);
            label2.TabIndex = 1;
            label2.Text = "Assembly code";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.DimGray;
            label3.Dock = DockStyle.Fill;
            label3.ForeColor = Color.Gainsboro;
            label3.Location = new Point(633, 3);
            label3.Margin = new Padding(3);
            label3.Name = "label3";
            label3.Size = new Size(335, 20);
            label3.TabIndex = 2;
            label3.Text = "Machine code";
            // 
            // treeView1
            // 
            treeView1.BackColor = Color.DimGray;
            treeView1.Dock = DockStyle.Fill;
            treeView1.ForeColor = Color.Gainsboro;
            treeView1.LineColor = Color.Gainsboro;
            treeView1.Location = new Point(3, 29);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(285, 224);
            treeView1.TabIndex = 3;
            // 
            // ui1
            // 
            ui1.BackColor = Color.DimGray;
            ui1.Dock = DockStyle.Fill;
            ui1.Location = new Point(294, 29);
            ui1.Name = "ui1";
            ui1.Size = new Size(333, 224);
            ui1.TabIndex = 10;
            // 
            // ui2
            // 
            ui2.BackColor = Color.DimGray;
            ui2.Dock = DockStyle.Fill;
            ui2.Location = new Point(633, 29);
            ui2.Name = "ui2";
            ui2.Size = new Size(335, 224);
            ui2.TabIndex = 11;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.DimGray;
            toolStrip1.GripMargin = new Padding(0);
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { Selected_Assembler, StartAssembleButto });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0);
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(971, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // Selected_Assembler
            // 
            Selected_Assembler.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Selected_Assembler.ForeColor = Color.Gainsboro;
            Selected_Assembler.ImageTransparentColor = Color.Magenta;
            Selected_Assembler.Name = "Selected_Assembler";
            Selected_Assembler.Size = new Size(156, 24);
            Selected_Assembler.Text = "Selected Assembler:";
            Selected_Assembler.DropDownItemClicked += Selected_Assembler_DropDownItemClicked;
            // 
            // StartAssembleButto
            // 
            StartAssembleButto.DisplayStyle = ToolStripItemDisplayStyle.Text;
            StartAssembleButto.ForeColor = Color.Gainsboro;
            StartAssembleButto.ImageTransparentColor = Color.Magenta;
            StartAssembleButto.Name = "StartAssembleButto";
            StartAssembleButto.Size = new Size(77, 24);
            StartAssembleButto.Text = "Assemble";
            StartAssembleButto.Click += StartAssembleButto_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(971, 483);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "WASP Assembler IDE";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ToolStrip toolStrip1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TreeView treeView1;
        private ToolStripDropDownButton Selected_Assembler;
        private ToolStripButton StartAssembleButto;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private WASP_huninat.WinForms.CustomControls.RtbWithLineNumbers.UI ui1;
        private WASP_huninat.WinForms.CustomControls.RtbWithLineNumbers.UI ui2;
    }
}