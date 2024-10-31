using Assembler;
namespace WASP_Assembler
{
    public partial class WASPAssemblerIDE : Form
    {
        readonly IAssemblerLogic _IAssemblerLogic = new AssemblerLogic();
        private string? selectedAssembler;
        private readonly string tempFilePath = Path.Combine(Path.GetTempPath(), "WASP-Assembler");
        private readonly string tempProjectFilePath = Path.Combine(Path.GetTempPath(), "WASP-Assembler", "Projects");
        private TreeNode lastChangedNode;

        public WASPAssemblerIDE()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetCustomUiHeight();
            // Create File Structure
            Directory.CreateDirectory(tempProjectFilePath);
            File.WriteAllText(Path.Combine(tempFilePath, "Example.json"), "{\r\n\t\"Instruction_Bits\": \"16\",\r\n\t\"Most_Significant_Bit\": \"left\",\r\n\t\"Assembly_Instructions\": [\r\n\t\t{\r\n\t\t\t\"Assembly_Mnemotic\": \"NOP\",\r\n\t\t\t\"Parameter_Order\": [],\r\n\t\t\t//\t\t\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\t11\t12\t13\t14\t15\t16\r\n\t\t\t\"Binary\": [\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\",\"0\"]\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"Assembly_Mnemotic\": \"JMP\",\r\n\t\t\t\"Parameter_Order\": [\"A5\"],\r\n\t\t\t//\t\t\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\t11\t12\t13\t14\t15\t16\r\n\t\t\t\"Binary\": [\"0\",\"0\",\"0\",\"0\",\"0\",\"1\",\"0\",\"0\",\"0\",\"0\",\"0\",\"A\",\"A\",\"A\",\"A\",\"A\"]\r\n\t\t},\t\t{\r\n\t\t\t\"Assembly_Mnemotic\": \"ADD\",\r\n\t\t\t\"Parameter_Order\": [\"Z3\",\"Y3\",\"X3\"],\r\n\t\t\t//\t\t\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\t11\t12\t13\t14\t15\t16\r\n\t\t\t\"Binary\": [\"0\",\"0\",\"0\",\"0\",\"1\",\"1\",\"1\",\"Z\",\"Z\",\"Z\",\"X\",\"X\",\"X\",\"Y\",\"Y\",\"Y\"]\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"Assembly_Mnemotic\": \"\",\r\n\t\t\t\"Parameter_Order\": [],\r\n\t\t\t//\t\t\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\t11\t12\t13\t14\t15\t16\r\n\t\t\t\"Binary\": [\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\"]\r\n\t\t}\r\n\t]\r\n}");

            // Adds all assembly definition files to the Selected_Assembler Dropdown
            foreach (var isaFile in Directory.EnumerateFiles(tempFilePath))
            {
                Selected_Assembler.DropDownItems.Add(isaFile.Replace($"{tempFilePath}\\", "")).BackColor = Color.FromArgb(50, 0, 0);
            }

            // Adds all Projects To the TreeView
            foreach (string item in Directory.EnumerateFileSystemEntries(tempProjectFilePath))
            {
                string Name = Path.GetFileName(item);
                if (File.GetAttributes(item) == FileAttributes.Directory)
                {
                    // Get all files in one folder and adds to ChildNode list
                    List<TreeNode> ChildNodes = new List<TreeNode>();
                    foreach (var item1 in Directory.EnumerateFiles(item))
                    {
                        ChildNodes.Add(new TreeNode($"🖹{Path.GetFileName(item1)}"));
                    }
                    // Add File Nods to the correct Parent Node
                    ProjectTreeView.Nodes.Add(new TreeNode($"📁{Name}", ChildNodes.ToArray()));
                }
                else
                {
                    ProjectTreeView.Nodes.Add($"🖹{Name}");
                }
            }
        }

        private void Selected_Assembler_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            selectedAssembler = e.ClickedItem.ToString();
            Selected_Assembler.Text = $"Selected Assembler: {selectedAssembler.Replace(".json", "")}";
            _IAssemblerLogic.JsonToClassConverter(Path.Combine(tempFilePath, selectedAssembler));
        }

        private void StartAssembleButto_Click(object sender, EventArgs e)
        {
            MachineCodeUi.Text = _IAssemblerLogic.ConvertAssemblyToMicrocode(AssemblyCodeUi.Logic.TextRtb.Lines);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            SetCustomUiHeight();
        }

        private void SetCustomUiHeight()
        {
            int temp = splitContainer2.Panel1.Height - AssemblyCodeLbl.Height - 4;
            ProjectTreeView.Height = temp;
            AssemblyCodeUi.Height = temp;
            MachineCodeUi.Height = temp;
        }

        private void ProjectTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.ToString().EndsWith(".txt"))
            {
                string nodePath = Path.Combine(tempProjectFilePath, e.Node.FullPath.Replace("📁", "").Replace("🖹", ""));
                AssemblyCodeUi.Text = File.ReadAllText(nodePath);
                    CurrentProjectLbl.Text = "Current Project: " + e.Node.Text.Replace("🖹", "");

                if (lastChangedNode != null)
                {
                    lastChangedNode.BackColor = Color.FromArgb(64, 64, 64);
                    lastChangedNode.ForeColor = Color.White;
                }
                lastChangedNode = e.Node;
                lastChangedNode.BackColor = Color.FromArgb(128, 128, 128);
                lastChangedNode.ForeColor = Color.White;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string[] path = CurrentProjectLbl.Text.Split(": ");
            File.WriteAllText(Path.Combine(tempProjectFilePath, path[0].ToString(), path[1].ToString()), AssemblyCodeUi.Text);
        }
    }
}