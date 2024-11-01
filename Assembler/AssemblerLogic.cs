using Newtonsoft.Json;

namespace Logic
{
    public class AssemblerLogic
    {
        private AssemblerJsonClass.Assembly_Instructions _assembly;
        private AssemblerJsonClass.Rootobject? _isaClass = null;
        private List<string> _splittedAssembly = new List<string>();
        private int _operantId;
        private int[] _countOfSpecificChars = new int[]
            {
                //Values: X Y Z I A
                0, 0 ,0, 0, 0,
                //Values: user defined
                0, 0, 0, 0, 0, 0, 0, 0, 0
            };

        // Converts Json ISA Files to Class
        public void JsonToClassConverter(string PathOfISA)
        {
            _isaClass = JsonConvert.DeserializeObject<AssemblerJsonClass.Rootobject>(File.ReadAllText(PathOfISA));
        }

        public string ConvertAssemblyToMicrocode(string[] AssemblyInput)
        {
            string OutputString = "";
            // Cheks if an assembler file is selected
            if (_isaClass == null)
            {
                return "No ISA Selected";
            }

            // Step over every line in the _assembly code
            for (int i = 0; i < AssemblyInput.Length; i++)
            {
                _splittedAssembly = AssemblyInput[i].Split(' ', '\t').ToList();
                // Step over every line in the .json file
                int j = 0;
                for (; j < _isaClass.Assembly_Instructions.Length; j++)
                {
                    // Ignoring empty lines and Comments
                    if (AssemblyInput[i] == "" || AssemblyInput[i].StartsWith("//"))
                    {
                        OutputString += Environment.NewLine;
                        j = _isaClass.Assembly_Instructions.Length + 1;
                    }

                    // chek if the _assembly operation is in the .json file
                    else if (_splittedAssembly[0].ToString().ToUpper() == _isaClass.Assembly_Instructions[j].Assembly_Mnemotic.ToUpper())
                    {
                        if (OutputString.Length > 0)
                        {
                            OutputString += Environment.NewLine;
                        }

                        _assembly = _isaClass.Assembly_Instructions[j];
                        OutputString += OperantToMicrocode();
                        j = _isaClass.Assembly_Instructions.Length + 1;
                    }
                }

                // output if no _assembly operation was found
                if (j != _isaClass.Assembly_Instructions.Length + 2)
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
            if (_assembly.Parameter_Order.Length > _splittedAssembly.Count - 1)
            {
                return "Not enough operators for this instruction";
            }
            else if (_assembly.Parameter_Order.Length < _splittedAssembly.Count - 1)
            {
                return "Too many operators for this instruction";
            }

            List<string> operant = new List<string>();
            for (int i = 1; i < _splittedAssembly.Count; i++)
            {
                if (_splittedAssembly[i].StartsWith('#'))
                {
                    _splittedAssembly[i] = ConvertDecimalToBinary(_splittedAssembly[i].Replace("#", ""), int.Parse(_assembly.Parameter_Order[i - 1][1..]));
                }
                operant.Add(_splittedAssembly[i]);
            }

            for (int i = 0; i < _countOfSpecificChars.Length; i++)
            {
                _countOfSpecificChars[i] = 0;
            }
            string output = "";

            // Step over every element in the bit array off the .json file
            for (int i = 0; i < _assembly.Binary.Length; i++)
            {
                int assemblyAsInt = 0;
                try { assemblyAsInt = Convert.ToInt32(_assembly.Binary[i]); }
                catch { }

                output += _assembly.Binary[i].ToUpper() switch
                {
                    "X" => PasteValuesForBinaryElement(operant, 0, 'X'),
                    "Y" => PasteValuesForBinaryElement(operant, 1, 'Y'),
                    "Z" => PasteValuesForBinaryElement(operant, 2, 'Z'),
                    "I" => PasteValuesForBinaryElement(operant, 3, 'I'),
                    "A" => PasteValuesForBinaryElement(operant, 4, 'A'),
                    string when assemblyAsInt > 1 => PasteValuesForBinaryElement(operant, assemblyAsInt + 4, Convert.ToChar(_assembly.Binary[i])),
                    _ => _assembly.Binary[i]
                };
            }
            return output;
        }

        private char PasteValuesForBinaryElement(List<string> operant, int CountOfSpecificCharElementNumber, char charToChek)
        {
            for (int k = 0; k < _assembly.Parameter_Order.Length; k++)
            {
                if (_assembly.Parameter_Order[k].ToUpper().StartsWith(charToChek))
                {
                    _operantId = k;
                }
            }

            if (_assembly.Parameter_Order[_operantId].Length == 1)
            {
                _assembly.Parameter_Order[_operantId] = _assembly.Parameter_Order[_operantId] + "1";
            }

            char output;
            switch (operant)
            {
                case List<string> when operant[_operantId].Length == 0:
                    output = '-';
                    break;
                case List<string> when operant[_operantId].Length == Convert.ToInt32(_assembly.Parameter_Order[_operantId][1..]):
                    {
                        try
                        {
                            output = operant[_operantId][_countOfSpecificChars[CountOfSpecificCharElementNumber]];
                            _countOfSpecificChars[CountOfSpecificCharElementNumber]++;
                        }
                        catch (Exception)
                        {
                            output = '/';
                        }
                    };
                    break;
                case List<string> when operant[_operantId].Length < Convert.ToInt32(_assembly.Parameter_Order[_operantId][1..]):
                    output = '<';
                    break;
                case List<string> when operant[_operantId].Length > Convert.ToInt32(_assembly.Parameter_Order[_operantId][1..]):
                    output = '>';
                    break;
                default:
                    output = '#';
                    break;
            };
            return output;
        }

        private string ConvertDecimalToBinary(string decimalNumber, int bitCount)
        {
            string output = "";
            int x = Convert.ToInt32(decimalNumber);

            //  match with base 2 Numbers
            //  starting at 2 until end of integer limit
            for (int i = bitCount - 1; i > 0; i--)
            {
                int bitvalue = (int)Math.Pow(2, i);

                if (bitvalue <= x)
                {
                    x -= bitvalue;
                    output += 1;
                }
                else
                {
                    output += 0;
                }
            }

            //  Chck if the Least Significant Bit is on
            if (x == 1)
            {
                x -= 1;
                output += 1;
            }
            else if (x == 0)
            {
                output += 0;
            }

            //  if the Value is bigger than the maximum bit add 00 at the end so that an error is shown
            if (_isaClass.Most_Significant_Bit == "left" && x > 0)
            {
                output += "00";
            }

            //  if the Value is smaller than the minimum bit add null at the end so that an error is shown
            if (_isaClass.Most_Significant_Bit == "right")
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