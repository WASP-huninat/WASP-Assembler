namespace WASP_Assembler
{
    partial class FileDialog
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
            RenameLbl = new Label();
            NewFileLbl = new Label();
            DeletLbl = new Label();
            NewFolderLbl = new Label();
            SuspendLayout();
            // 
            // RenameLbl
            // 
            RenameLbl.BackColor = Color.FromArgb(64, 64, 64);
            RenameLbl.Cursor = Cursors.Hand;
            RenameLbl.Dock = DockStyle.Top;
            RenameLbl.ForeColor = Color.White;
            RenameLbl.Location = new Point(1, 91);
            RenameLbl.Name = "RenameLbl";
            RenameLbl.Size = new Size(178, 30);
            RenameLbl.TabIndex = 5;
            RenameLbl.Text = "   Rename";
            RenameLbl.TextAlign = ContentAlignment.MiddleLeft;
            RenameLbl.Click += RenameLbl_Click;
            RenameLbl.MouseEnter += Lbl_MouseEnter;
            RenameLbl.MouseLeave += Lbl_MouseLeave;
            // 
            // NewFileLbl
            // 
            NewFileLbl.BackColor = Color.FromArgb(64, 64, 64);
            NewFileLbl.Cursor = Cursors.Hand;
            NewFileLbl.Dock = DockStyle.Top;
            NewFileLbl.ForeColor = Color.White;
            NewFileLbl.ImageAlign = ContentAlignment.MiddleLeft;
            NewFileLbl.Location = new Point(1, 31);
            NewFileLbl.Margin = new Padding(0);
            NewFileLbl.Name = "NewFileLbl";
            NewFileLbl.Size = new Size(178, 30);
            NewFileLbl.TabIndex = 2;
            NewFileLbl.Text = "🗎 NewFile";
            NewFileLbl.TextAlign = ContentAlignment.MiddleLeft;
            NewFileLbl.Click += NewFileLbl_Click;
            NewFileLbl.MouseEnter += Lbl_MouseEnter;
            NewFileLbl.MouseLeave += Lbl_MouseLeave;
            // 
            // DeletLbl
            // 
            DeletLbl.BackColor = Color.FromArgb(64, 64, 64);
            DeletLbl.Cursor = Cursors.Hand;
            DeletLbl.Dock = DockStyle.Top;
            DeletLbl.ForeColor = Color.White;
            DeletLbl.Location = new Point(1, 61);
            DeletLbl.Margin = new Padding(0);
            DeletLbl.Name = "DeletLbl";
            DeletLbl.Size = new Size(178, 30);
            DeletLbl.TabIndex = 4;
            DeletLbl.Text = "X Delete";
            DeletLbl.TextAlign = ContentAlignment.MiddleLeft;
            DeletLbl.Click += DeletLbl_Click;
            DeletLbl.MouseEnter += Lbl_MouseEnter;
            DeletLbl.MouseLeave += Lbl_MouseLeave;
            // 
            // NewFolderLbl
            // 
            NewFolderLbl.BackColor = Color.FromArgb(64, 64, 64);
            NewFolderLbl.Cursor = Cursors.Hand;
            NewFolderLbl.Dock = DockStyle.Top;
            NewFolderLbl.ForeColor = Color.White;
            NewFolderLbl.Location = new Point(1, 1);
            NewFolderLbl.Name = "NewFolderLbl";
            NewFolderLbl.Size = new Size(178, 30);
            NewFolderLbl.TabIndex = 3;
            NewFolderLbl.Text = "📁 NewFolder";
            NewFolderLbl.TextAlign = ContentAlignment.MiddleLeft;
            NewFolderLbl.Click += NewFolderLbl_Click;
            NewFolderLbl.MouseEnter += Lbl_MouseEnter;
            NewFolderLbl.MouseLeave += Lbl_MouseLeave;
            // 
            // FileDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(180, 353);
            Controls.Add(RenameLbl);
            Controls.Add(DeletLbl);
            Controls.Add(NewFileLbl);
            Controls.Add(NewFolderLbl);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FileDialog";
            Padding = new Padding(1);
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.Manual;
            Text = "FileOptions";
            ResumeLayout(false);
        }

        #endregion

        private Label RenameLbl;
        private Label NewFileLbl;
        private Label DeletLbl;
        private Label NewFolderLbl;
    }
}