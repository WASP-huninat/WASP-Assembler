namespace Assembler
{
    public interface IAssemblerLogic
    {
        public void JsonToClassConverter(string PathOfISA);
        public string ConvertAssemblyToMicrocode(string[] AssemblyInut);
    }
}
