using Newtonsoft.Json;

namespace Assembler
{
    public class AssemblerLogic : IAssemblerLogic
    {
        private AssemblerJsonClass.Assembly_Instuctions assembly;
        private AssemblerJsonClass.Rootobject? ISAClass = null;
        private List<string> splittedAssembly = new List<string>();
        private int operantId;
        private int[] CountOfSpecificChars = new int[]
            {
                //Values: X Y Z I A
                0, 0 ,0, 0, 0,
                //Values: user defined
                0, 0, 0, 0, 0, 0, 0, 0, 0
            };

        // Converts Json ISA Files to Class
        void IAssemblerLogic.JsonToClassConverter(string PathOfISA)
        {
            ISAClass = JsonConvert.DeserializeObject<AssemblerJsonClass.Rootobject>(File.ReadAllText(PathOfISA));
        }

        string IAssemblerLogic.ConvertAssemblyToMicrocode(string[] AssemblyInput)
        {
            string OutputString = "";
            // Cheks if an assembler file is selected
            if (ISAClass == null)
            {
                return "No ISA Selected";
            }

            // Step over every line in the assembly code
            for (int i = 0; i < AssemblyInput.Length; i++)
            {
                splittedAssembly = AssemblyInput[i].Split(' ', '\t').ToList();
                // Step over every line in the .json file
                int j = 0;
                for (; j < ISAClass.Assembly_Instuctions.Length; j++)
                {
                    // Ignoring empty lines and Comments
                    if (AssemblyInput[i] == "" || AssemblyInput[i].StartsWith("//"))
                    {
                        OutputString += Environment.NewLine;
                        j = ISAClass.Assembly_Instuctions.Length + 1;
                    }

                    // chek if the assembly operation is in the .json file
                    else if (splittedAssembly[0].ToString().ToUpper() == ISAClass.Assembly_Instuctions[j].Assembly_Mnemotic.ToUpper())
                    {
                        if (OutputString.Length > 0)
                        {
                            OutputString += Environment.NewLine;
                        }

                        assembly = ISAClass.Assembly_Instuctions[j];
                        OutputString += OperantToMicrocode();
                        j = ISAClass.Assembly_Instuctions.Length + 1;
                    }
                }

                // output if no assembly operation was found
                if (j != ISAClass.Assembly_Instuctions.Length + 2)
                {
                    if (OutputString.Length > 0)
                    {
                        OutputString += Environment.NewLine;
                    }
                    OutputString += "Instruction not found";
                }
            }
            return OutputString;
        }

        private string OperantToMicrocode()
        {
            List<string> operant = new List<string>();
            for (int i = 1; i < splittedAssembly.Count; i++)
            {
                operant.Add(splittedAssembly[i]);
            }

            for (int i = 0; i < CountOfSpecificChars.Length; i++)
            {
                CountOfSpecificChars[i] = 0;
            }
            string output = "";

            // Step over every element in the bit array off the .json file
            for (int i = 0; i < assembly.Binary.Length; i++)
            {
                int assemblyAsInt = 0;
                try { assemblyAsInt = Convert.ToInt32(assembly.Binary[i]); }
                catch { }

                output += assembly.Binary[i].ToUpper() switch
                {
                    "X" => PasteValuesForBinaryElement(operant, 0, 'X'),
                    "Y" => PasteValuesForBinaryElement(operant, 1, 'Y'),
                    "Z" => PasteValuesForBinaryElement(operant, 2, 'Z'),
                    "I" => PasteValuesForBinaryElement(operant, 3, 'I'),
                    "A" => PasteValuesForBinaryElement(operant, 4, 'A'),
                    string when assemblyAsInt > 1 => PasteValuesForBinaryElement(operant, assemblyAsInt + 4, Convert.ToChar(assembly.Binary[i])),
                    _ => assembly.Binary[i]
                };
            }
            return output;
        }

        private char PasteValuesForBinaryElement(List<string> operant, int CountOfSpecificCharElementNumber, char charToChek)
        {
            for (int k = 0; k < assembly.Parameter_Order.Length; k++)
            {
                if (assembly.Parameter_Order[k].ToUpper().StartsWith(charToChek))
                {
                    operantId = k;
                }
            }

            if (assembly.Parameter_Order[operantId].Length == 1)
            {
                assembly.Parameter_Order[operantId] = assembly.Parameter_Order[operantId] + "1";
            }

            char output;
            switch (operant)
            {
                case List<string> when operant.Count < assembly.Parameter_Order.Length:
                    output = '#';
                    break;
                case List<string> when operant[operantId].Length == 0:
                    output = '-';
                    break;
                case List<string> when operant[operantId].Length == Convert.ToInt32(assembly.Parameter_Order[operantId][1..]):
                    {
                        output = operant[operantId][CountOfSpecificChars[CountOfSpecificCharElementNumber]];
                        CountOfSpecificChars[CountOfSpecificCharElementNumber]++;
                    };
                    break;
                case List<string> when operant[operantId].Length < Convert.ToInt32(assembly.Parameter_Order[operantId][1..]):
                    output = '<';
                    break;
                case List<string> when operant[operantId].Length > Convert.ToInt32(assembly.Parameter_Order[operantId][1..]):
                    output = '>';
                    break;
                default:
                    output = '#';
                    break;
            };
            return output;
        }

        private string ConvertDecimalToBinary(string decimalNumber)
        {
            string output = "";
            int x = Convert.ToInt32(decimalNumber);
            for (int i = 1; i < Convert.ToInt32(ISAClass.Instruction_Bits) - 1; i++)
            {
                int bitvalue = 2 ^ i;
                output += (x > bitvalue) ? 1 : 0;
            }
            return "t";
        }
    }
}