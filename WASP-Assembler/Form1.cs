using Assembler;

namespace WASP_Assembler
{
    public partial class Form1 : Form
    {
        IAssemblerLogic _IAssemblerLogic = new AssemblerLogic();
        private string? selectedAssembler = null;

        public Form1()
        {
            InitializeComponent();

            ui1.SetHeight((int)(ui1.Parent.Height - 6 - tableLayoutPanel1.RowStyles[0].Height - tableLayoutPanel1.RowStyles[2].Height));
            ui2.SetHeight((int)(ui2.Parent.Height - 6 - tableLayoutPanel1.RowStyles[0].Height - tableLayoutPanel1.RowStyles[2].Height));


            foreach (var isaFile in Directory.EnumerateFiles("D:\\temp\\"))
            {
                Selected_Assembler.DropDownItems.Add(isaFile.Replace("D:\\temp\\", ""));
            }
        }

        private void Selected_Assembler_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            selectedAssembler = e.ClickedItem.ToString().Replace(".json0", "");
            Selected_Assembler.Text = $"Selected Assembler: {selectedAssembler}";
            _IAssemblerLogic.JsonToClassConverter($"D:\\temp\\{selectedAssembler}");
        }

        private void StartAssembleButto_Click(object sender, EventArgs e)
        {
            ui2.Text = _IAssemblerLogic.ConvertAssemblyToMicrocode(ui1.Logic.TextRtb.Lines);
        }
    }
}