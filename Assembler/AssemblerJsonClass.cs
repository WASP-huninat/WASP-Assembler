namespace Logic
{
    internal class AssemblerJsonClass
    {

        public class Rootobject
        {
            public string Instruction_Bits { get; set; }
            public string Most_Significant_Bit { get; set; }
            public Label_Convert_To Label_Convert_To { get; set; }
            public Assembly_Instructions[] Assembly_Instructions { get; set; }
        }

        public class Label_Convert_To
        {
            public int Address_Bits { get; set; }
            public string[] Additional_Instructions { get; set; }
        }

        public class Assembly_Instructions
        {
            public string Assembly_Mnemotic { get; set; }
            public string[] Parameter_Order { get; set; }
            public string[] Binary { get; set; }
        }

    }
}
