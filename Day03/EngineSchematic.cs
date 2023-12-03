namespace AdventOfCode2023.Day03
{
	public class EngineSchematic
	{
		public Dictionary<Point, char> Numbers { get; set; }
		public Dictionary<Point, char> Symbols { get; set; }
		public char[,] Grid { get; set; }
		public Dictionary<Point, PartNumber> PossiblePartNumbers { get; set; }
		public Dictionary<Point, Gear> PossibleGears { get; set; }
		public List<Gear> Gears { get; set; }
		public List<PartNumber> PartNumbers { get; set; }
	}
}
