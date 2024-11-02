﻿namespace WASP_Assembler
{
    partial class WASPAssemblerIDE
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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            ProjectTreeView = new TreeView();
            CurrentProjectLbl = new Label();
            splitContainer2 = new SplitContainer();
            AssemblyCodeUi = new WASP_huninat.WinForms.CustomControls.RtbWithLineNumbers.UI();
            AssemblyCodeLbl = new Label();
            MicroCodeUi = new WASP_huninat.WinForms.CustomControls.RtbWithLineNumbers.UI();
            MicroCodeLbl = new Label();
            toolStrip1 = new ToolStrip();
            Selected_Assembler = new ToolStripDropDownButton();
            StartAssembleButto = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.FromArgb(28, 173, 240);
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 35);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.Transparent;
            splitContainer1.Panel1.Controls.Add(ProjectTreeView);
            splitContainer1.Panel1.Controls.Add(CurrentProjectLbl);
            splitContainer1.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Panel2.RightToLeft = RightToLeft.No;
            splitContainer1.Size = new Size(900, 342);
            splitContainer1.SplitterDistance = 200;
            splitContainer1.TabIndex = 2;
            // 
            // ProjectTreeView
            // 
            ProjectTreeView.BackColor = Color.FromArgb(64, 64, 64);
            ProjectTreeView.BorderStyle = BorderStyle.None;
            ProjectTreeView.Dock = DockStyle.Bottom;
            ProjectTreeView.ForeColor = Color.White;
            ProjectTreeView.FullRowSelect = true;
            ProjectTreeView.Indent = 20;
            ProjectTreeView.ItemHeight = 20;
            ProjectTreeView.LineColor = Color.FromArgb(28, 173, 240);
            ProjectTreeView.Location = new Point(0, 34);
            ProjectTreeView.Name = "ProjectTreeView";
            ProjectTreeView.Size = new Size(200, 308);
            ProjectTreeView.TabIndex = 0;
            ProjectTreeView.NodeMouseClick += ProjectTreeView_NodeMouseClick;
            ProjectTreeView.NodeMouseDoubleClick += ProjectTreeView_NodeMouseDoubleClick;
            ProjectTreeView.Leave += ProjectTreeView_Leave;
            ProjectTreeView.MouseClick += ProjectTreeView_MouseClick;
            // 
            // CurrentProjectLbl
            // 
            CurrentProjectLbl.BackColor = Color.FromArgb(64, 64, 64);
            CurrentProjectLbl.Dock = DockStyle.Top;
            CurrentProjectLbl.Font = new Font("Segoe UI", 9F);
            CurrentProjectLbl.ForeColor = Color.White;
            CurrentProjectLbl.Location = new Point(0, 0);
            CurrentProjectLbl.Margin = new Padding(3);
            CurrentProjectLbl.Name = "CurrentProjectLbl";
            CurrentProjectLbl.Size = new Size(200, 30);
            CurrentProjectLbl.TabIndex = 0;
            CurrentProjectLbl.Text = "Current Project:";
            CurrentProjectLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.BackColor = Color.Transparent;
            splitContainer2.Panel1.Controls.Add(AssemblyCodeUi);
            splitContainer2.Panel1.Controls.Add(AssemblyCodeLbl);
            splitContainer2.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.BackColor = Color.Transparent;
            splitContainer2.Panel2.Controls.Add(MicroCodeUi);
            splitContainer2.Panel2.Controls.Add(MicroCodeLbl);
            splitContainer2.Panel2.RightToLeft = RightToLeft.No;
            splitContainer2.Size = new Size(696, 342);
            splitContainer2.SplitterDistance = 350;
            splitContainer2.TabIndex = 0;
            // 
            // AssemblyCodeUi
            // 
            AssemblyCodeUi.BackColor = Color.FromArgb(64, 64, 64);
            AssemblyCodeUi.Dock = DockStyle.Bottom;
            AssemblyCodeUi.ForeColor = Color.White;
            AssemblyCodeUi.Location = new Point(0, 34);
            AssemblyCodeUi.Name = "AssemblyCodeUi";
            AssemblyCodeUi.Size = new Size(350, 308);
            AssemblyCodeUi.SplitColor = Color.Silver;
            AssemblyCodeUi.TabIndex = 10;
            // 
            // AssemblyCodeLbl
            // 
            AssemblyCodeLbl.BackColor = Color.FromArgb(64, 64, 64);
            AssemblyCodeLbl.Dock = DockStyle.Top;
            AssemblyCodeLbl.ForeColor = Color.White;
            AssemblyCodeLbl.Location = new Point(0, 0);
            AssemblyCodeLbl.Margin = new Padding(0);
            AssemblyCodeLbl.Name = "AssemblyCodeLbl";
            AssemblyCodeLbl.Size = new Size(350, 30);
            AssemblyCodeLbl.TabIndex = 1;
            AssemblyCodeLbl.Text = "Assembly code";
            AssemblyCodeLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MicroCodeUi
            // 
            MicroCodeUi.BackColor = Color.FromArgb(64, 64, 64);
            MicroCodeUi.Dock = DockStyle.Bottom;
            MicroCodeUi.ForeColor = Color.White;
            MicroCodeUi.Location = new Point(0, 34);
            MicroCodeUi.Name = "MicroCodeUi";
            MicroCodeUi.Size = new Size(342, 308);
            MicroCodeUi.SplitColor = Color.Silver;
            MicroCodeUi.TabIndex = 11;
            // 
            // MicroCodeLbl
            // 
            MicroCodeLbl.BackColor = Color.FromArgb(64, 64, 64);
            MicroCodeLbl.Dock = DockStyle.Top;
            MicroCodeLbl.ForeColor = Color.White;
            MicroCodeLbl.Location = new Point(0, 0);
            MicroCodeLbl.Margin = new Padding(3);
            MicroCodeLbl.Name = "MicroCodeLbl";
            MicroCodeLbl.Size = new Size(342, 30);
            MicroCodeLbl.TabIndex = 2;
            MicroCodeLbl.Text = "Micro code";
            MicroCodeLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.BackColor = Color.FromArgb(64, 64, 64);
            toolStrip1.GripMargin = new Padding(0);
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { Selected_Assembler, StartAssembleButto, toolStripButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0);
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(900, 35);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // Selected_Assembler
            // 
            Selected_Assembler.BackColor = Color.Transparent;
            Selected_Assembler.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Selected_Assembler.ForeColor = Color.White;
            Selected_Assembler.ImageTransparentColor = Color.Magenta;
            Selected_Assembler.Name = "Selected_Assembler";
            Selected_Assembler.Size = new Size(156, 32);
            Selected_Assembler.Text = "Selected Assembler:";
            Selected_Assembler.DropDownItemClicked += Selected_Assembler_DropDownItemClicked;
            // 
            // StartAssembleButto
            // 
            StartAssembleButto.BackColor = Color.Transparent;
            StartAssembleButto.ForeColor = Color.White;
            StartAssembleButto.Image = Properties.Resources.Green_Triangle;
            StartAssembleButto.ImageTransparentColor = Color.Magenta;
            StartAssembleButto.Name = "StartAssembleButto";
            StartAssembleButto.Size = new Size(97, 32);
            StartAssembleButto.Text = "Assemble";
            StartAssembleButto.Click += StartAssembleButto_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.ForeColor = Color.White;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(123, 32);
            toolStripButton1.Text = "Save Current File";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // WASPAssemblerIDE
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(900, 377);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            MinimumSize = new Size(360, 150);
            Name = "WASPAssemblerIDE";
            RightToLeft = RightToLeft.No;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "WASP Assembler IDE";
            Load += Form1_Load;
            SizeChanged += Form1_SizeChanged;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ToolStrip toolStrip1;
        private Label AssemblyCodeLbl;
        private TreeView ProjectTreeView;
        private ToolStripDropDownButton Selected_Assembler;
        private ToolStripButton StartAssembleButto;
        private WASP_huninat.WinForms.CustomControls.RtbWithLineNumbers.UI AssemblyCodeUi;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private WASP_huninat.WinForms.CustomControls.RtbWithLineNumbers.UI MicroCodeUi;
        private Label MicroCodeLbl;
        private ToolStripButton toolStripButton1;
        private Label CurrentProjectLbl;
        private ErrorProvider errorProvider1;
    }
}