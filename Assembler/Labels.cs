namespace Logic
{
    internal class Labels
    {
        public Labels(string name, string rowNumber)
        {
            Name = name ?? string.Empty;
            RowNumber = rowNumber ?? string.Empty;
        }

        public string Name { get; }
        public string RowNumber { get; }
    }
}