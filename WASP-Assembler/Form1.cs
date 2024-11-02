using Logic;

namespace WASP_Assembler
{
    public partial class WASPAssemblerIDE : Form
    {
        private readonly AssemblerLogic _assemblerLogic = new AssemblerLogic();
        private string? _selectedAssembler;
        private readonly string _tempFilePath = Path.Combine(Path.GetTempPath(), "WASP-Assembler");
        private readonly string _tempProjectFilePath = Path.Combine(Path.GetTempPath(), "WASP-Assembler", "Projects");
        private readonly FileDialog _fileDialog = new FileDialog();
        private TreeNode? _lastChangedNode;
        private readonly Settings _settings = new Settings();
        private readonly string _filePath;

        public WASPAssemblerIDE(string filePath = null)
        {
            InitializeComponent();
            _filePath = filePath;
        }
        public void FillTreeView()
        {
            ProjectTreeView.Nodes.Clear();
            ProjectTreeView.Nodes.Add(new TreeNode("📁 Projects", AddNodes(_tempProjectFilePath)));
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
            if (!string.IsNullOrEmpty(_filePath) && File.Exists(_filePath))
            {
                AssemblyCodeUi.Text = File.ReadAllText(_filePath);
                CurrentProjectLbl.Text = "Current Project: " + Path.GetFileName(_filePath);
            }

            _settings.UiColors = [Color.FromArgb(64, 64, 64), Color.White, Color.Gray];
            _fileDialog.settings = _settings;
            _fileDialog.treeView = this;

            SetCustomUiHeight();
            // Create File Structure
            Directory.CreateDirectory(_tempProjectFilePath);
            File.WriteAllText(Path.Combine(_tempFilePath, "Example.json"), "{\r\n\t\"Instruction_Bits\": \"16\",\r\n\t\"Most_Significant_Bit\": \"left\",\r\n\t\"Assembly_Instructions\": [\r\n\t\t{\r\n\t\t\t\"Assembly_Mnemotic\": \"NOP\",\r\n\t\t\t\"Parameter_Order\": [],\r\n\t\t\t//\t\t\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\t11\t12\t13\t14\t15\t16\r\n\t\t\t\"Binary\": [\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\"]\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"Assembly_Mnemotic\": \"JMP\",\r\n\t\t\t\"Parameter_Order\": [\"A5\"],\r\n\t\t\t//\t\t\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\t11\t12\t13\t14\t15\t16\r\n\t\t\t\"Binary\": [\"0\",\"0\",\"0\",\"0\",\"0\",\"1\",\"0\",\"0\",\"0\",\"0\",\"0\",\"A\",\"A\",\"A\",\"A\",\"A\"]\r\n\t\t},\t\t{\r\n\t\t\t\"Assembly_Mnemotic\": \"ADD\",\r\n\t\t\t\"Parameter_Order\": [\"Z3\",\"Y3\",\"X3\"],\r\n\t\t\t//\t\t\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\t11\t12\t13\t14\t15\t16\r\n\t\t\t\"Binary\": [\"0\",\"0\",\"0\",\"0\",\"1\",\"1\",\"1\",\"Z\",\"Z\",\"Z\",\"X\",\"X\",\"X\",\"Y\",\"Y\",\"Y\"]\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"Assembly_Mnemotic\": \"\",\r\n\t\t\t\"Parameter_Order\": [],\r\n\t\t\t//\t\t\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\t11\t12\t13\t14\t15\t16\r\n\t\t\t\"Binary\": [\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\"]\r\n\t\t}\r\n\t]\r\n}");

            // Adds all assembly definition files to the Selected_Assembler Dropdown
            foreach (var isaFile in Directory.EnumerateFiles(_tempFilePath))
            {
                Selected_Assembler.DropDownItems.Add(isaFile.Replace($"{_tempFilePath}\\", ""));
            }

            FillTreeView();
        }

        private void Selected_Assembler_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _selectedAssembler = e.ClickedItem.ToString();
            Selected_Assembler.Text = $"Selected Assembler: {_selectedAssembler.Replace(".json", "")}";
            _assemblerLogic.JsonToClassConverter(Path.Combine(_tempFilePath, _selectedAssembler));
        }

        private void StartAssembleButto_Click(object sender, EventArgs e)
        {
            MicroCodeUi.Text = _assemblerLogic.ConvertAssemblyToMicrocode(AssemblyCodeUi.Logic.TextRtb.Lines);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            SetCustomUiHeight();
        }

        private void ProjectTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (File.GetAttributes(Path.Combine(_tempFilePath, e.Node.FullPath.Replace("📁 ", "").Replace("🗎 ", ""))) != FileAttributes.Directory)
            {
                string nodePath = Path.Combine(_tempFilePath, e.Node.FullPath.Replace("📁 ", "").Replace("🗎 ", ""));
                AssemblyCodeUi.Text = File.ReadAllText(nodePath);
                CurrentProjectLbl.Text = "Current Project: " + e.Node.Text.Replace("🗎 ", "");

                ChangeCurrentSelectedNode(_settings.UiColors[2], e.Node);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string[] path = CurrentProjectLbl.Text.Split(": ");
            if (path.Length < 2)
            {
                return;
            }
            File.WriteAllText(Path.Combine(_tempFilePath, _lastChangedNode.FullPath.Replace("📁 ", "").Replace("🗎 ", "")), AssemblyCodeUi.Text);
        }

        private void ProjectTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int baseX = e.X + this.Location.X + 10;
                int baseY = e.Y + this.Location.Y;
                string fullNodePath = Path.Combine(_tempFilePath, e.Node.FullPath.Replace("📁 ", "").Replace("🗎 ", ""));
                if (e.Node.Parent == null)
                {
                    ProjectTreeView.SelectedNode = e.Node;
                    _fileDialog.SetVisibleElements(FileDialog.Dialogtypes.Create);
                    _fileDialog.Location = new Point(baseX, baseY + _fileDialog.Height + 15);
                }
                else if (File.GetAttributes(fullNodePath) == FileAttributes.Directory)
                {
                    ProjectTreeView.SelectedNode = e.Node;
                    _fileDialog.SetVisibleElements(FileDialog.Dialogtypes.Both);
                    _fileDialog.Location = new Point(baseX, baseY + _fileDialog.Height - 15);
                }
                else
                {
                    ProjectTreeView.SelectedNode = e.Node;
                    _fileDialog.SetVisibleElements(FileDialog.Dialogtypes.DeleteAndEdit);
                    _fileDialog.Location = new Point(baseX, baseY + _fileDialog.Height + 45);
                }
                _fileDialog.projectsPath = fullNodePath;

                _fileDialog.Show();
            }
            else
            {
                _fileDialog.Hide();
            }
        }

        private void ProjectTreeView_Leave(object sender, EventArgs e)
        {
            _fileDialog.Hide();
        }

        private void SetCustomUiHeight()
        {
            int temp = splitContainer2.Panel1.Height - AssemblyCodeLbl.Height - 4;
            ProjectTreeView.Height = temp;
            AssemblyCodeUi.Height = temp;
            MicroCodeUi.Height = temp;
        }

        private void ChangeCurrentSelectedNode(Color newColorOfElement, TreeNode nodeToChange)
        {
            if (_lastChangedNode != null)
            {
                _lastChangedNode.BackColor = _settings.UiColors[0];
                _lastChangedNode.ForeColor = _settings.UiColors[1];
            }
            _lastChangedNode = nodeToChange;
            _lastChangedNode.BackColor = _settings.UiColors[2];
            _lastChangedNode.ForeColor = _settings.UiColors[1];
        }

        private void ProjectTreeView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _fileDialog.Hide();
            }
        }
    }
}