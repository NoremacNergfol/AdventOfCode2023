namespace AdventOfCode2023.Day03
{
	public class EngineSchematic
	{
		public Dictionary<Point, char> Numbers { get; set; }
		public Dictionary<Point, char> Symbols { get; set; }
		public char[,] Grid { get; set; }
		public Dictionary<Point, PartNumber> PartNumbers { get; set; }
	}
}
