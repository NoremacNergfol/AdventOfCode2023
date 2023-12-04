namespace AdventOfCode2023.Day04
{
	public class ScratchCard
	{
		public int Id { get; set; }
		public HashSet<int> WinningNumbers { get; set; }
		public int[] Numbers { get; set; }
		public List<NumberMatch> Matches { get; set; }
		public int Points { get; set; }
	}
}
