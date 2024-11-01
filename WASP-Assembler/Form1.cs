using Logic;

namespace WASP_Assembler
{
    public partial class WASPAssemblerIDE : Form
    {
        readonly AssemblerLogic _AssemblerLogic = new AssemblerLogic();
        private string? selectedAssembler;
        private readonly string tempFilePath = Path.Combine(Path.GetTempPath(), "WASP-Assembler");
        private readonly string tempProjectFilePath = Path.Combine(Path.GetTempPath(), "WASP-Assembler", "Projects");
        private readonly FileDialog fileDialog = new FileDialog();
        private TreeNode lastChangedNode;
        private readonly Settings settings = new Settings();

        public WASPAssemblerIDE()
        {
            InitializeComponent();
        }
        public void FillTreeView()
        {
            ProjectTreeView.Nodes.Clear();
            ProjectTreeView.Nodes.Add(new TreeNode("📁 Projects", AddNodes(tempProjectFilePath)));
            ProjectTreeView.Nodes[0].Expand();
        }

        private static TreeNode[] AddNodes(string filePath)
        {
            List<TreeNode> childNodes = new List<TreeNode>();

            foreach (string item in Directory.EnumerateDirectories(filePath))
            {
                childNodes.Add(new TreeNode($"📁 {Path.GetFileName(item)}", AddNodes(item)));
            }
            foreach (string item in Directory.EnumerateFiles(filePath))
            {
                childNodes.Add(new TreeNode($"🗎 {Path.GetFileName(item)}"));
            }

            return childNodes.ToArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //  BackColor
            //  ForeColor
            //  HighlightColor
            settings.uiColors = [Color.FromArgb(64, 64, 64), Color.White, Color.Gray];
            fileDialog.settings = settings;
            fileDialog.form = this;

            SetCustomUiHeight();
            // Create File Structure
            Directory.CreateDirectory(tempProjectFilePath);
            File.WriteAllText(Path.Combine(tempFilePath, "Example.json"), "{\r\n\t\"Instruction_Bits\": \"16\",\r\n\t\"Most_Significant_Bit\": \"left\",\r\n\t\"Assembly_Instructions\": [\r\n\t\t{\r\n\t\t\t\"Assembly_Mnemotic\": \"NOP\",\r\n\t\t\t\"Parameter_Order\": [],\r\n\t\t\t//\t\t\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\t11\t12\t13\t14\t15\t16\r\n\t\t\t\"Binary\": [\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\"]\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"Assembly_Mnemotic\": \"JMP\",\r\n\t\t\t\"Parameter_Order\": [\"A5\"],\r\n\t\t\t//\t\t\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\t11\t12\t13\t14\t15\t16\r\n\t\t\t\"Binary\": [\"0\",\"0\",\"0\",\"0\",\"0\",\"1\",\"0\",\"0\",\"0\",\"0\",\"0\",\"A\",\"A\",\"A\",\"A\",\"A\"]\r\n\t\t},\t\t{\r\n\t\t\t\"Assembly_Mnemotic\": \"ADD\",\r\n\t\t\t\"Parameter_Order\": [\"Z3\",\"Y3\",\"X3\"],\r\n\t\t\t//\t\t\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\t11\t12\t13\t14\t15\t16\r\n\t\t\t\"Binary\": [\"0\",\"0\",\"0\",\"0\",\"1\",\"1\",\"1\",\"Z\",\"Z\",\"Z\",\"X\",\"X\",\"X\",\"Y\",\"Y\",\"Y\"]\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"Assembly_Mnemotic\": \"\",\r\n\t\t\t\"Parameter_Order\": [],\r\n\t\t\t//\t\t\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\t11\t12\t13\t14\t15\t16\r\n\t\t\t\"Binary\": [\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\"]\r\n\t\t}\r\n\t]\r\n}");

            // Adds all assembly definition files to the Selected_Assembler Dropdown
            foreach (var isaFile in Directory.EnumerateFiles(tempFilePath))
            {
                Selected_Assembler.DropDownItems.Add(isaFile.Replace($"{tempFilePath}\\", ""));
            }

            FillTreeView();
        }

        private void Selected_Assembler_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            selectedAssembler = e.ClickedItem.ToString();
            Selected_Assembler.Text = $"Selected Assembler: {selectedAssembler.Replace(".json", "")}";
            _AssemblerLogic.JsonToClassConverter(Path.Combine(tempFilePath, selectedAssembler));
        }

        private void StartAssembleButto_Click(object sender, EventArgs e)
        {
            MachineCodeUi.Text = _AssemblerLogic.ConvertAssemblyToMicrocode(AssemblyCodeUi.Logic.TextRtb.Lines);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            SetCustomUiHeight();
        }

        private void ProjectTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (File.GetAttributes(Path.Combine(tempFilePath, e.Node.FullPath.Replace("📁 ", "").Replace("🗎 ", ""))) != FileAttributes.Directory)
            {
                string nodePath = Path.Combine(tempFilePath, e.Node.FullPath.Replace("📁 ", "").Replace("🗎 ", ""));
                AssemblyCodeUi.Text = File.ReadAllText(nodePath);
                CurrentProjectLbl.Text = "Current Project: " + e.Node.Text.Replace("🗎 ", "");

                ChangeCurrentSelectedNode(settings.uiColors[2], e.Node);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string[] path = CurrentProjectLbl.Text.Split(": ");
            if (path.Length < 2)
            {
                return;
            }
            File.WriteAllText(Path.Combine(tempProjectFilePath, path[0].ToString(), path[1].ToString()), AssemblyCodeUi.Text);
        }

        private void ProjectTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                string fullNodePath = Path.Combine(tempFilePath, e.Node.FullPath.Replace("📁 ", "").Replace("🗎 ", ""));
                if (File.GetAttributes(fullNodePath) == FileAttributes.Directory)
                {
                    ChangeCurrentSelectedNode(settings.uiColors[2], e.Node);
                    fileDialog.SetVisibleElements(FileDialog.Dialogtypes.Both);
                    fileDialog.Location = new Point(e.X + this.Location.X, e.Y + this.Location.Y);
                }
                else
                {
                    fileDialog.SetVisibleElements(FileDialog.Dialogtypes.Delete);
                    fileDialog.Location = new Point(e.X + this.Location.X, e.Y + this.Location.Y + 60);
                }
                fileDialog.projectsPath = fullNodePath;

                fileDialog.Show();
            }
            else
            {
                fileDialog.Hide();
            }
        }

        private void ProjectTreeView_Leave(object sender, EventArgs e)
        {
            fileDialog.Hide();
        }

        private void SetCustomUiHeight()
        {
            int temp = splitContainer2.Panel1.Height - AssemblyCodeLbl.Height - 4;
            ProjectTreeView.Height = temp;
            AssemblyCodeUi.Height = temp;
            MachineCodeUi.Height = temp;
        }

        private void ChangeCurrentSelectedNode(Color newColorOfElement, TreeNode nodeToChange)
        {
            if (lastChangedNode != null)
            {
                lastChangedNode.BackColor = settings.uiColors[0];
                lastChangedNode.ForeColor = settings.uiColors[1];
            }
            lastChangedNode = nodeToChange;
            lastChangedNode.BackColor = settings.uiColors[2];
            lastChangedNode.ForeColor = settings.uiColors[1];
        }

        private void ProjectTreeView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                fileDialog.Hide();
            }
        }
    }
}