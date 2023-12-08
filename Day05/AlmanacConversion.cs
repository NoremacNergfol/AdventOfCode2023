namespace AdventOfCode2023.Day05
{
	public class AlmanacConversion
	{
		public string SourceCategory { get; set; }
		public string DestinationCategory { get; set; }
		public List<ConversionRange> ConversionRanges { get; set; }

		public override string? ToString()
		{
			return $"{SourceCategory} to {DestinationCategory}";
		}
	}
}
