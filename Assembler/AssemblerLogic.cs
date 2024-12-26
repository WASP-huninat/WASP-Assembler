using Newtonsoft.Json;

namespace Logic
{
    public class AssemblerLogic
    {
        internal AssemblerJsonClass.Rootobject? _isaClass;

        // Converts Json ISA Files to Class
        public void JsonToClassConverter(string PathOfISA)
        {
            _isaClass = JsonConvert.DeserializeObject<AssemblerJsonClass.Rootobject>(File.ReadAllText(PathOfISA));
        }

        public string ConvertAssemblyToMicrocode(string[] AssemblyInput)
        {
            // Cheks if an assembler file is selected
            if (_isaClass == null)
            {
                return "No ISA Selected";
            }
            string OutputString = "";

            // Step over every line in the assembly code
            for (int i = 0; i < AssemblyInput.Length; i++)
            {
                AssemblyInput[i].Replace("/v", "");
                string[] splittedAssembly = AssemblyInput[i].Split([' ', '\t'], 2);
                // Ignoring empty lines and Comments
                if (splittedAssembly[0] != "" && !splittedAssembly[0].StartsWith("//"))
                {
                    int j = 0;
                    // Search the instruction inside the Selected Assembly .json
                    for (; j < _isaClass.Assembly_Instructions.Length; j++)
                    {
                        if (splittedAssembly[0].ToUpper() == _isaClass.Assembly_Instructions[j].Assembly_Mnemotic.ToUpper())
                        {
                            if (i > 0)
                            {
                                OutputString += Environment.NewLine;
                            }
                            if (splittedAssembly.Length != 1)
                            {
                                OutputString += GenerateMicrocode(splittedAssembly[1].Split(','), _isaClass.Assembly_Instructions[j]);
                            }
                            else if (splittedAssembly.Length == _isaClass.Assembly_Instructions[j].Parameter_Order.Length)
                            {
                                OutputString += "Not enough operators for this instruction";
                            }
                            else
                            {
                                string temp = "";
                                foreach (var bit in _isaClass.Assembly_Instructions[j].Binary)
                                {
                                    temp += bit;
                                }

                                OutputString += temp;
                            }
                            j = _isaClass.Assembly_Instructions.Length + 1;
                        }
                    }
                    if (j != _isaClass.Assembly_Instructions.Length + 2)
                    {
                        if (OutputString.Length > 0)
                        {
                            OutputString += Environment.NewLine;
                        }
                        OutputString += "Instruction not found";
                    }
                }
            }
            return OutputString;
        }

        //  This will convert every operant to its Binary Value
        private string GenerateMicrocode(string[] operants, AssemblerJsonClass.Assembly_Instructions instructionName)
        {
            if (instructionName.Parameter_Order.Length > operants.Length)
            {
                return "Not enough operators for this instruction";
            }
            else if (instructionName.Parameter_Order.Length < operants.Length)
            {
                return "Too many operators for this instruction";
            }

            // First steps trougth every operant and then edit the list where no Binary value is present
            string[] binaryOutput = (string[])instructionName.Binary.Clone();
            for (int i = 0; i < operants.Length; i++)
            {
                int parameterBitCount = int.Parse(instructionName.Parameter_Order[i][1..]);
                operants[i] = operants[i].Trim();
                if (operants[i].StartsWith('#'))
                {
                    operants[i] = ConvertDecimalToBinary(operants[i].Replace("#", ""), parameterBitCount);
                }

                // Check Length of the parameters with the desired length
                if (operants[i].Length < parameterBitCount)
                {
                    return $"Operant {i + 1} < {parameterBitCount} bit";
                }
                if (operants[i].Length > parameterBitCount)
                {
                    return $"Operant {i + 1} > {parameterBitCount} bit";
                }

                int operantCount = 0;
                for (int j = 0; j < instructionName.Binary.Length; j++)
                {
                    if (instructionName.Binary[j].ToUpper() == instructionName.Parameter_Order[i][0].ToString().ToUpper())
                    {
                        binaryOutput[j] = operants[i][operantCount].ToString();
                        operantCount++;
                    }
                }
            }
            return string.Join("", binaryOutput);
        }

        private string ConvertDecimalToBinary(string decimalNumber, int bitCount)
        {
            string output = "";
            int x = Convert.ToInt32(decimalNumber);
            int Signed = 0;

            //convert negativ number to tows compliment
            if (x < 0)
            {
                x = -x;
                x--;
                Signed = 1;
            }

            //  match with base 2 Numbers
            //  starting at 2 until end of integer limit
            for (int i = bitCount - 1; i > 0; i--)
            {
                int bitvalue = (int)Math.Pow(2, i);

                if (bitvalue <= x)
                {
                    x -= bitvalue;
                    output += 1 ^ Signed;
                }
                else
                {
                    output += 0 ^ Signed;
                }
            }

            //  Chck if the Least Significant Bit is on
            if (x == 1)
            {
                x -= 1;
                output += 1 ^ Signed;
            }
            else if (x == 0)
            {
                output += 0 ^ Signed;
            }

            //  if the Value is bigger than the maximum bit add 00 at the end so that an error is shown
            if (_isaClass?.Most_Significant_Bit == "left" && x > 0)
            {
                output += "00";
            }

            //  if the Value is smaller than the minimum bit add null at the end so that an error is shown
            if (_isaClass?.Most_Significant_Bit == "right")
            {
                if (x > 1)
                {
                    output += "";
                }

                //  Inverts the bin string to set the MSB on the right side
                output = new string(output.Reverse().ToArray());
            }
            return output;
        }
    }
}