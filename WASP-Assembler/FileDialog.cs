using Logic;

namespace WASP_Assembler
{
    public partial class FileDialog : Form
    {
        public string? projectsPath;
        public Settings? settings;
        public WASPAssemblerIDE? parentForm;
        public TreeNode? CurrentNode;

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

        /// <summary>
        /// Sets the Visible Elements of this Form
        /// </summary>
        /// <param name="dialogtype">Spesifies the type of the Form</param>
        public void VisibleElements(Dialogtypes dialogtype)
        {
            NewFolderLbl.Visible = true;
            NewFileLbl.Visible = true;
            DeletLbl.Visible = true;
            RenameLbl.Visible = true;

            switch (dialogtype)
            {
                case Dialogtypes.Create:
                    DeletLbl.Visible = false;
                    RenameLbl.Visible = false;
                    this.Height = NewFileLbl.Height + NewFolderLbl.Height + 2;
                    break;
                case Dialogtypes.DeleteAndEdit:
                    NewFolderLbl.Visible = false;
                    NewFileLbl.Visible = false;
                    this.Height = DeletLbl.Height + RenameLbl.Height + 2;
                    break;
                default:
                    this.Height = NewFileLbl.Height + NewFolderLbl.Height + DeletLbl.Height + RenameLbl.Height + 2;
                    break;
            }

        }

        private void NewFileLbl_Click(object sender, EventArgs e)
        {
            if (parentForm != null && projectsPath!= null)
            {
                int newFileCount = 0;

                foreach (var item in Directory.EnumerateFiles(projectsPath))
                {
                    if (Path.GetFileName(item).StartsWith("New File"))
                    {
                        newFileCount++;
                    }
                }
                File.WriteAllText(Path.Combine(projectsPath, $"New File{newFileCount}.asm".Replace("0", "")), "");
                this.Hide();
                parentForm.FillTreeView();
                parentForm.Focus();
            }
        }

        private void NewFolderLbl_Click(object sender, EventArgs e)
        {
            if (parentForm != null && projectsPath != null)
            {
                int newFileCount = 0;

                foreach (var item in Directory.EnumerateDirectories(projectsPath))
                {
                    if (Path.GetFileName(item).StartsWith("New Folde"))
                    {
                        newFileCount++;
                    }
                }
                Directory.CreateDirectory(Path.Combine(projectsPath, $"New Folder{newFileCount}").Replace("0", ""));
                this.Hide();
                parentForm.FillTreeView();
            }
        }

        private void DeletLbl_Click(object sender, EventArgs e)
        {
            if (parentForm != null && projectsPath != null)
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
                parentForm.FillTreeView();
            }
        }

        private void RenameLbl_Click(object sender, EventArgs e)
        {
            if (CurrentNode != null)
            {
                CurrentNode.BeginEdit();
                this.Hide();
            }
        }

        private void Lbl_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label lbl && settings != null)
            {
                lbl.BackColor = settings.UiColors[2];
            }
        }

        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label lbl && settings != null)
            {
                lbl.BackColor = settings.UiColors[0];
            }
        }
    }
}
