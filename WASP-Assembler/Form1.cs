using Logic;

namespace WASP_Assembler
{
    public partial class WASPAssemblerIDE : Form
    {
        private readonly AssemblerLogic _assemblerLogic = new AssemblerLogic();
        private readonly string _tempFilePath = Path.Combine(Path.GetTempPath(), "WASP-Assembler");
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
            ProjectTreeView.Nodes.Add(new TreeNode("📁 Projects", AddNodes(Path.Combine(_tempFilePath, "Projects"))));
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
            }

            _settings.UiColors = [Color.FromArgb(64, 64, 64), Color.White, Color.Gray];
            _fileDialog.settings = _settings;
            _fileDialog.parentForm = this;

            SetCustomUiHeight();
            // Create File Structure
            Directory.CreateDirectory(Path.Combine(Path.Combine(_tempFilePath, "Projects")));
            File.WriteAllText(Path.Combine(_tempFilePath, "Example.json"), @"
{
	""Instruction_Bits"": ""16"",
	""Most_Significant_Bit"": ""left"",
	""Assembly_Instructions"": [
		{
			""Assembly_Mnemotic"": ""NOP"",
			""Parameter_Order"": [],
			//			1	2   3   4	5   6   7  8   9	10	11	12	13	14	15	16
			""Binary"": [""0"",""0"",""0"",""0"",""0"",""0"",""0"",""0"",""0"",""0"",""0"",""0"",""0"",""0"",""0"",""0""]
		},
		{
			""Assembly_Mnemotic"": ""JMP"",
			""Parameter_Order"": [""A5""],
			//			1	2	3	4	5	6	7	8	9	10	11	12	13	14	15	16
			""Binary"": [""0"",""0"",""0"",""0"",""0"",""1"",""0"",""0"",""0"",""0"",""0"",""A"",""A"",""A"",""A"",""A""]
		},		{
			""Assembly_Mnemotic"": ""ADD"",
			""Parameter_Order"": [""Z3"",""Y3"",""X3""],
			//			1	2	3	4	5	6	7	8	9	10	11	12	13	14	15	16
			""Binary"": [""0"",""0"",""0"",""0"",""1"",""1"",""1"",""Z"",""Z"",""Z"",""X"",""X"",""X"",""Y"",""Y"",""Y""]
		},
		{
			""Assembly_Mnemotic"": """",
			""Parameter_Order"": [],
			//			1	2	3	4	5	6	7	8	9	10	11	12	13	14	15	16
			""Binary"": ["""","""","""","""","""","""","""","""","""","""","""","""","""","""","""",""""]
		}
	]
}");
            // Adds all assembly definition files to the Selected_Assembler Dropdown
            foreach (var isaFile in Directory.EnumerateFiles(_tempFilePath))
            {
                SelectedAssemblerDdBtn.DropDownItems.Add(isaFile.Replace($"{_tempFilePath}\\", ""));
            }

            FillTreeView();
        }

        private void Selected_Assembler_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string selectedAssembler = e.ClickedItem.ToString();
            SelectedAssemblerDdBtn.Text = $"Selected Assembler: {selectedAssembler.Replace(".json", "")}";
            _assemblerLogic.JsonToClassConverter(Path.Combine(_tempFilePath, selectedAssembler));
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
            string nodePath = Path.Combine(_tempFilePath, RemoveUnicodeIcons(e.Node.FullPath));
            if (File.GetAttributes(nodePath) != FileAttributes.Directory)
            {
                AssemblyCodeUi.Text = File.ReadAllText(nodePath);

                ChangeCurrentSelectedNode(_settings.UiColors[2], e.Node);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Path.Combine(_tempFilePath, RemoveUnicodeIcons(_lastChangedNode.FullPath)), AssemblyCodeUi.Text);
        }

        private void ProjectTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ProjectTreeView.LabelEdit = true;

                Point mousePoint = new Point(e.X + this.Location.X + 10, e.Y + this.Location.Y + 40);

                string fullNodePath = Path.Combine(_tempFilePath, RemoveUnicodeIcons(e.Node.FullPath));
                if (e.Node.Parent == null)
                {
                    _fileDialog.VisibleElements(FileDialog.Dialogtypes.Create);
                    mousePoint.Y += _fileDialog.Height;
                }
                else if (File.GetAttributes(fullNodePath) == FileAttributes.Directory)
                {
                    _fileDialog.VisibleElements(FileDialog.Dialogtypes.Both);
                    mousePoint.Y += _fileDialog.Height - 60;
                }
                else
                {
                    _fileDialog.VisibleElements(FileDialog.Dialogtypes.DeleteAndEdit);
                    mousePoint.Y += _fileDialog.Height;
                }

                _fileDialog.Location = mousePoint;

                ProjectTreeView.SelectedNode = e.Node;

                _fileDialog.CurrentNode = e.Node;
                _fileDialog.projectsPath = fullNodePath;
                _fileDialog.Show();
                _fileDialog.Focus();
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

        private void ProjectTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node == _fileDialog.CurrentNode)
            {
                var t = Path.Combine(_tempFilePath, RemoveUnicodeIcons(e.Node.FullPath));
                var s = Path.Combine(_tempFilePath, RemoveUnicodeIcons(e.Node.Parent.FullPath), e.Label + Path.GetExtension(e.Node.FullPath));

                try
                {
                    if (Path.GetExtension(e.Node.FullPath) != null)
                    {
                        File.Move(t, s);
                    }
                    else
                    {
                        Directory.Move(t, s);
                    }
                }
                catch (Exception)
                {
                    errorProvider1.SetError(ProjectTreeView, "Test");
                    MessageBox.Show("File name already exists");
                }

                FillTreeView();
                ProjectTreeView.LabelEdit = false;
            }
        }

        private string RemoveUnicodeIcons(string stringToBeRenamed)
        {
            return stringToBeRenamed.Replace("📁 ", "").Replace("🗎 ", "");
        }
    }
}