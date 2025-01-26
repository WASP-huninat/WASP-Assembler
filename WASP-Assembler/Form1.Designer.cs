namespace WASP_Assembler
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
            tableLayoutPanel1 = new TableLayoutPanel();
            SaveCurrentFileBtn = new Button();
            ProjectTreeView = new TreeView();
            CurrentProjectLbl = new Label();
            splitContainer2 = new SplitContainer();
            AssemblyCodeUi = new WASP_huninat.WinForms.CustomControls.RTB.WithLineNumbers();
            AssemblyCodeLbl = new Label();
            MicroCodeUi = new WASP_huninat.WinForms.CustomControls.RTB.WithLineNumbers();
            MicroCodeLbl = new Label();
            toolStrip1 = new ToolStrip();
            SelectedAssemblerDdBtn = new ToolStripDropDownButton();
            AssembleBtn = new ToolStripButton();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            splitContainer1.Location = new Point(0, 27);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.Transparent;
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            splitContainer1.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Panel2.RightToLeft = RightToLeft.No;
            splitContainer1.Size = new Size(900, 350);
            splitContainer1.SplitterDistance = 200;
            splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(SaveCurrentFileBtn, 0, 2);
            tableLayoutPanel1.Controls.Add(ProjectTreeView, 0, 1);
            tableLayoutPanel1.Controls.Add(CurrentProjectLbl, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel1.Size = new Size(200, 350);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // SaveCurrentFileBtn
            // 
            SaveCurrentFileBtn.BackColor = Color.FromArgb(64, 64, 64);
            SaveCurrentFileBtn.Dock = DockStyle.Bottom;
            SaveCurrentFileBtn.FlatAppearance.BorderSize = 0;
            SaveCurrentFileBtn.FlatStyle = FlatStyle.Flat;
            SaveCurrentFileBtn.ForeColor = Color.White;
            SaveCurrentFileBtn.Location = new Point(0, 320);
            SaveCurrentFileBtn.Margin = new Padding(0);
            SaveCurrentFileBtn.Name = "SaveCurrentFileBtn";
            SaveCurrentFileBtn.Size = new Size(200, 30);
            SaveCurrentFileBtn.TabIndex = 1;
            SaveCurrentFileBtn.Text = "Save Current File";
            SaveCurrentFileBtn.UseVisualStyleBackColor = false;
            SaveCurrentFileBtn.Click += SaveCurrentFileBtn_Click;
            // 
            // ProjectTreeView
            // 
            ProjectTreeView.AllowDrop = true;
            ProjectTreeView.BackColor = Color.FromArgb(64, 64, 64);
            ProjectTreeView.BorderStyle = BorderStyle.None;
            ProjectTreeView.Dock = DockStyle.Fill;
            ProjectTreeView.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProjectTreeView.ForeColor = Color.White;
            ProjectTreeView.FullRowSelect = true;
            ProjectTreeView.Indent = 20;
            ProjectTreeView.ItemHeight = 20;
            ProjectTreeView.LineColor = Color.FromArgb(28, 173, 240);
            ProjectTreeView.Location = new Point(0, 33);
            ProjectTreeView.Margin = new Padding(0);
            ProjectTreeView.Name = "ProjectTreeView";
            ProjectTreeView.Size = new Size(200, 284);
            ProjectTreeView.TabIndex = 0;
            ProjectTreeView.AfterLabelEdit += ProjectTreeView_AfterLabelEdit;
            ProjectTreeView.NodeMouseClick += ProjectTreeView_NodeMouseClick;
            ProjectTreeView.NodeMouseDoubleClick += ProjectTreeView_NodeMouseDoubleClick;
            ProjectTreeView.DragDrop += ProjectTreeView_DragDrop;
            ProjectTreeView.DragEnter += ProjectTreeView_DragEnter;
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
            CurrentProjectLbl.Margin = new Padding(0);
            CurrentProjectLbl.Name = "CurrentProjectLbl";
            CurrentProjectLbl.Size = new Size(200, 30);
            CurrentProjectLbl.TabIndex = 0;
            CurrentProjectLbl.Text = "Current Project";
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
            splitContainer2.Size = new Size(696, 350);
            splitContainer2.SplitterDistance = 350;
            splitContainer2.TabIndex = 0;
            // 
            // AssemblyCodeUi
            // 
            AssemblyCodeUi.BackColor = Color.FromArgb(64, 64, 64);
            AssemblyCodeUi.Dock = DockStyle.Bottom;
            AssemblyCodeUi.Font = new Font("Segoe UI", 9F);
            AssemblyCodeUi.ForeColor = Color.White;
            AssemblyCodeUi.Location = new Point(0, 33);
            AssemblyCodeUi.Name = "AssemblyCodeUi";
            AssemblyCodeUi.Size = new Size(350, 317);
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
            MicroCodeUi.Location = new Point(0, 33);
            MicroCodeUi.Name = "MicroCodeUi";
            MicroCodeUi.Size = new Size(342, 317);
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
            toolStrip1.BackColor = Color.FromArgb(64, 64, 64);
            toolStrip1.GripMargin = new Padding(0);
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { SelectedAssemblerDdBtn, AssembleBtn });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0);
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(900, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // SelectedAssemblerDdBtn
            // 
            SelectedAssemblerDdBtn.BackColor = Color.Transparent;
            SelectedAssemblerDdBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SelectedAssemblerDdBtn.ForeColor = Color.White;
            SelectedAssemblerDdBtn.ImageTransparentColor = Color.Magenta;
            SelectedAssemblerDdBtn.Name = "SelectedAssemblerDdBtn";
            SelectedAssemblerDdBtn.Size = new Size(156, 24);
            SelectedAssemblerDdBtn.Text = "Selected Assembler:";
            SelectedAssemblerDdBtn.DropDownItemClicked += Selected_Assembler_DropDownItemClicked;
            // 
            // AssembleBtn
            // 
            AssembleBtn.BackColor = Color.Transparent;
            AssembleBtn.ForeColor = Color.White;
            AssembleBtn.Image = Properties.Resources.Green_Triangle;
            AssembleBtn.ImageTransparentColor = Color.Magenta;
            AssembleBtn.Name = "AssembleBtn";
            AssembleBtn.RightToLeft = RightToLeft.No;
            AssembleBtn.Size = new Size(97, 24);
            AssembleBtn.Text = "Assemble";
            AssembleBtn.Click += StartAssembleButto_Click;
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
            tableLayoutPanel1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private Label AssemblyCodeLbl;
        private TreeView ProjectTreeView;
        private ToolStripDropDownButton SelectedAssemblerDdBtn;
        private ToolStripButton AssembleBtn;
        private WASP_huninat.WinForms.CustomControls.RTB.WithLineNumbers AssemblyCodeUi;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private WASP_huninat.WinForms.CustomControls.RTB.WithLineNumbers MicroCodeUi;
        private Label MicroCodeLbl;
        private Label CurrentProjectLbl;
        private Button SaveCurrentFileBtn;
        private TableLayoutPanel tableLayoutPanel1;
        public ErrorProvider errorProvider1;
    }
}