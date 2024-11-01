using Logic;

namespace WASP_Assembler
{
    public partial class FileDialog : Form
    {
        public string projectsPath;
        public Settings settings;
        public WASPAssemblerIDE form;

        public enum Dialogtypes
        {
            Create,
            Delete,
            Both
        };

        public FileDialog()
        {
            InitializeComponent();
        }

        public void SetVisibleElements(Dialogtypes dialogtype)
        {
            switch (dialogtype)
            {
                case Dialogtypes.Create:
                    NewFileLbl.Visible = true;
                    NewFolderLbl.Visible = true;
                    DeletLbl.Visible = false;
                    this.Height = NewFileLbl.Height + NewFolderLbl.Height;
                    break;
                case Dialogtypes.Delete:
                    NewFileLbl.Visible = false;
                    NewFolderLbl.Visible = false;
                    DeletLbl.Visible = true;
                    this.Height = DeletLbl.Height;
                    break;
                default:
                    NewFileLbl.Visible = true;
                    NewFolderLbl.Visible = true;
                    DeletLbl.Visible = true;
                    this.Height = NewFileLbl.Height + NewFolderLbl.Height + DeletLbl.Height;
                    break;
            }

        }

        private void NewFileLbl_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Path.Combine(projectsPath, "New File.txt"), "");
            this.Hide();
            form.FillTreeView();
        }

        private void NewFolderLbl_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Path.Combine(projectsPath, "New Folder"));
            this.Hide();
            form.FillTreeView();
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
            form.FillTreeView();
        }

        private void Lbl_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.BackColor = settings.uiColors[2];
            }
        }

        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.BackColor = settings.uiColors[0];
            }
        }
    }
}
