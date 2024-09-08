namespace Assembler
{
    internal class AssemblerJsonClass
    {
        public class Rootobject
        {
            public string Instruction_Bits { get; set; }
            public string MSB { get; set; }
            public string Adress_Bus_Bit { get; set; }
            public string Data_Bus_Bits { get; set; }
            public string Register_Count { get; set; }
            public string Number_Of_Operants { get; set; }
            public string Accumulator_Based { get; set; }
            public string Max_Operations_Per_Line { get; set; }
            public Assembly_Instuctions[] Assembly_Instuctions { get; set; }
        }

        public class Assembly_Instuctions
        {
            public string Assembly_Mnemotic { get; set; }
            public string[] Parameter_Order { get; set; }
            public string[] Binary { get; set; }
        }

    }
}
