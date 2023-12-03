namespace AdventOfCode2023.Day03
{
	public class Gear
	{
		public Point Point { get; set; }
		public int Ratio { get; set; }
		public int AdjacentNumbers { get; set; }
		public HashSet<PartNumber> PartNumbers { get; set; } = new HashSet<PartNumber>();
	}
}