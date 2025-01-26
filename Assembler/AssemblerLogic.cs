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
            if (_isaClass.Label_Convert_To == null)
            {
                return "Selected ISA has no\nLabel_Convert_To\nSee the Latest Information for the Content of the ISA.json File\nhttps://github.com/WASP-huninat/WASP-Assembler/wiki/User's-manual";
            }

            string OutputString = "";

            List<Labels> labels = new List<Labels>();

            int currentRow = 0;

            for (int i = 0; i < AssemblyInput.Length; i++)
            {
                if (AssemblyInput[i] != "" && !AssemblyInput[i].StartsWith("//"))
                {
                    if (AssemblyInput[i].StartsWith('_'))
                    {
                        labels.Add(new Labels(AssemblyInput[i], currentRow.ToString()));
                        currentRow += _isaClass.Label_Convert_To.Additional_Instructions.Count();
                    }
                    currentRow++;
                }
            }

            // Step over every line in the assembly code
            for (int i = 0; i < AssemblyInput.Length; i++)
            {
                AssemblyInput[i].Replace("/v", "");
                string[] checkForInlineComment = AssemblyInput[i].Split("//");
                string[] splittedAssembly = checkForInlineComment[0].Split([' ', '\t'], 2);
                // Ignoring empty lines and Comments
                if (splittedAssembly[0] != "" && !splittedAssembly[0].StartsWith("//") && !splittedAssembly[0].StartsWith('_'))
                {
                    int j = SearchForAssemblyMnemotic(splittedAssembly[0]);
                    if (j != -1)
                    {
                        if (OutputString.Length > 0)
                        {
                            OutputString += Environment.NewLine;
                        }
                        if (splittedAssembly.Length != 1)
                        {
                            OutputString += GenerateMicrocode(splittedAssembly[1].Split(','), _isaClass.Assembly_Instructions[j], labels);
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
                    else
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
        private string GenerateMicrocode(string[] operants, AssemblerJsonClass.Assembly_Instructions instructionName, List<Labels> labels)
        {
            string temp = "";

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
                else if (operants[i].StartsWith('_'))
                {
                    var labelRowNumber = labels.FirstOrDefault(l => l.Name == operants[i]);
                    if (labelRowNumber != null)
                    {
                        int addressBits = _isaClass.Label_Convert_To.Address_Bits;

                        string rowNumberAsBinary = ConvertDecimalToBinary(labelRowNumber.RowNumber, addressBits);
                        if (_isaClass.Label_Convert_To.Additional_Instructions.Count() != 0)
                        {
                            for (int j = 0; j < _isaClass.Label_Convert_To.Additional_Instructions.Count(); j++)
                            {
                                string currentAdditionalInstruction = _isaClass.Label_Convert_To.Additional_Instructions[j];
                                int k = SearchForAssemblyMnemotic(currentAdditionalInstruction);

                                if (k != -1)
                                {
                                    int splitIndex = int.Parse(_isaClass.Assembly_Instructions[k].Parameter_Order[0][1..]);

                                    string[] op = { rowNumberAsBinary[..splitIndex] };

                                    temp = GenerateMicrocode(op,
                                        _isaClass.Assembly_Instructions[k],
                                        labels) + "\n";

                                    operants[i] = rowNumberAsBinary[splitIndex..];
                                }
                                else
                                {
                                    return $"Additional_Instruction   {currentAdditionalInstruction.ToUpper()}   not found";
                                }
                            }
                        }
                        else
                        {
                            operants[i] = rowNumberAsBinary;
                        }
                    }
                    else
                    {
                        temp = $"Label {operants[0]} not Found\n";
                    }
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
            return temp + string.Join("", binaryOutput);
        }

        private int SearchForAssemblyMnemotic(string MnemoticToSearch)
        {
            int i = 0;
            for (; i < _isaClass.Assembly_Instructions.Length; i++)
            {
                if (_isaClass.Assembly_Instructions[i].Assembly_Mnemotic.ToUpper() == MnemoticToSearch.ToUpper())
                {
                    return i++;
                }
            }
            return -1;
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