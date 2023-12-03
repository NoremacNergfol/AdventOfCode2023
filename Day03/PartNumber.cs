namespace AdventOfCode2023.Day03
{
	public class PartNumber
	{
		public int Id { get; set; }
		public bool Consumed { get; set; }
		public List<Point> Points { get; set; }

		public override string? ToString()
		{
			return Id.ToString();
		}
	}
}