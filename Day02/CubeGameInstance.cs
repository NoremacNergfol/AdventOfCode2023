﻿namespace AdventOfCode2023.Day02
{
	public class CubeGameInstance
	{
		public int Id { get; set; }
		public List<CubeGameSet> Sets { get; set; }
		public bool IsPossible { get; set; }
		public CubeGameBag MinimumCubeGameBagForPossibility { get; set; }
		public int Power { get; set; }
	}
}
