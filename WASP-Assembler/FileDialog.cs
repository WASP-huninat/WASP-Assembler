using Logic;

namespace WASP_Assembler
{
    public partial class FileDialog : Form
    {
        public string projectsPath;
        public Settings settings;
        public WASPAssemblerIDE treeView;

        public enum Dialogtypes
        {
            Create,
            DeleteAndEdit,
            Both
        };

        public FileDialog()
        {
            InitializeComponent();
        }

        public void SetVisibleElements(Dialogtypes dialogtype)
        {
            RenameLbl.Visible = false;
            switch (dialogtype)
            {
                case Dialogtypes.Create:
                    NewFolderLbl.Visible = true;
                    NewFileLbl.Visible = true;
                    DeletLbl.Visible = false;
                    //RenameLbl.Visible = true;
                    this.Height = NewFileLbl.Height + NewFolderLbl.Height/* + RenameLbl.Height*/ + 2;
                    break;
                case Dialogtypes.DeleteAndEdit:
                    NewFolderLbl.Visible = false;
                    NewFileLbl.Visible = false;
                    DeletLbl.Visible = true;
                    //RenameLbl.Visible = true;
                    this.Height = DeletLbl.Height/* + RenameLbl.Height*/ + 2;
                    break;
                default:
                    NewFolderLbl.Visible = true;
                    NewFileLbl.Visible = true;
                    DeletLbl.Visible = true;
                    //RenameLbl.Visible = true;
                    this.Height = NewFileLbl.Height + NewFolderLbl.Height + DeletLbl.Height/* + RenameLbl.Height*/ + 2;
                    break;
            }

        }

        private void NewFileLbl_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Path.Combine(projectsPath, "New File.asm"), "");
            this.Hide();
            treeView.FillTreeView();
        }

        private void NewFolderLbl_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Path.Combine(projectsPath, "New Folder"));
            this.Hide();
            treeView.FillTreeView();
        }

        private void DeletLbl_Click(object sender, EventArgs e)
        {
            if (File.GetAttributes(projectsPath) == FileAttributes.Directory)
            {
                Directory.Delete(projectsPath, true);                
            }
            else
            {
                File.Delete(projectsPath);
            }
            this.Hide();
            treeView.FillTreeView();
        }

        private void Lbl_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.BackColor = settings.UiColors[2];
            }
        }

        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.BackColor = settings.UiColors[0];
            }
        }
    }
}
