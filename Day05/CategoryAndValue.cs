namespace AdventOfCode2023.Day05
{
	public class CategoryAndValue
	{
		public string Category { get; set; }
		public long Value { get; set; }

		public override string? ToString()
		{
			return $"{Category} {Value}";
		}
		public Stack<CategoryAndValue> Stack { get; set; }
	}
}
