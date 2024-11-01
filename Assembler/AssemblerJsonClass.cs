namespace Logic
{
    internal class AssemblerJsonClass
    {
        public class Rootobject
        {
            public string Instruction_Bits { get; set; }
            public string Most_Significant_Bit { get; set; }
            public Assembly_Instructions[] Assembly_Instructions { get; set; }
        }

        public class Assembly_Instructions
        {
            public string Assembly_Mnemotic { get; set; }
            public string[] Parameter_Order { get; set; }
            public string[] Binary { get; set; }
        }

    }
}
