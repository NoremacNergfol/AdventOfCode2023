namespace AdventOfCode2023.Day05
{
	public class ConversionRange
	{
		public long DestinationRangeStart { get; set; }
		public long SourceRangeStart { get; set; }
		public long RangeLength { get; set; }

		public override string? ToString()
		{
			return $"Source range is {SourceRangeStart} to {SourceRangeStart + RangeLength - 1}. Destination range is {DestinationRangeStart} to {DestinationRangeStart + RangeLength - 1}.";
		}
	}
}
