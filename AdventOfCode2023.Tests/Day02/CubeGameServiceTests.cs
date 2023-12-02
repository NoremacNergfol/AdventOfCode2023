using AdventOfCode2023.Day02;

namespace AdventOfCode2023.Tests.Day02
{
	public class CubeGameServiceTests
	{
		[Theory]
		[InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1)]
		public void GetCubeGameInstance_ParsesId(string input, int expected)
		{
			var sut = new CubeGameService(null);

			var actual = sut.GetCubeGameInstance(input);

			Assert.Equal(expected, actual.Id);
		}

		[Theory]
		[InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 0, 4, 0, 3)]
		[InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1, 1, 2, 6)]
		[InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 2, 0, 2, 0)]
		public void GetCubeGameInstance_ParsesSet(string input, int setIndex, int expectedRed, int expectedGreen, int expectedBlue)
		{
			var sut = new CubeGameService(null);

			var actual = sut.GetCubeGameInstance(input);

			Assert.Equal(expectedRed, actual.Sets[setIndex].RedCubes);
			Assert.Equal(expectedBlue, actual.Sets[setIndex].BlueCubes);
			Assert.Equal(expectedGreen, actual.Sets[setIndex].GreenCubes);
		}

		[Theory]
		[InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true)]
		[InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", true)]
		[InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false)]
		[InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", false)]
		[InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", true)]
		public void SetPossibilities(string input, bool expectedPossibility)
		{
			var sut = new CubeGameService(null);

			var actual = sut.GetCubeGameInstance(input);

			sut.SetPossibilities(
				new CubeGameBag
				{
					BlueCubes = 15,
					GreenCubes = 13,
					RedCubes = 12
				},
				new List<CubeGameInstance>() { actual });

			Assert.Equal(expectedPossibility, actual.IsPossible);
		}

		[Theory]
		[InlineData("Day02/Input/Part1.txt", 2237)]
		[InlineData("Day02/Input/SamplePart1.txt", 8)]
		public void GetCubeGameInstances_Part1(string inputPath, int expected)
		{
			var sut = new CubeGameService(new Common.FilesService());

			var instances = sut.GetCubeGameInstances(inputPath);

			var possibleGameIdsSum = instances.Where(i => i.IsPossible).Select(i => i.Id).Sum();

			Assert.Equal(expected, possibleGameIdsSum);
		}

		[Theory]
		[InlineData("Day02/Input/Part1.txt", 66681)]
		[InlineData("Day02/Input/SamplePart1.txt", 2286)]
		public void GetCubeGameInstances_Part2(string inputPath, int expected)
		{
			var sut = new CubeGameService(new Common.FilesService());

			var instances = sut.GetCubeGameInstances(inputPath);

			var possibleGameIdsSum = instances.Select(i => i.Power).Sum();

			Assert.Equal(expected, possibleGameIdsSum);
		}

	}
}
