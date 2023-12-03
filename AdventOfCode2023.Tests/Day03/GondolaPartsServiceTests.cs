using AdventOfCode2023.Day03;

namespace AdventOfCode2023.Tests.Day03
{
	public class GondolaPartsServiceTests
	{
		[Theory]
		[InlineData("Day03/Input/SamplePart1.txt", 4361, 58, 114)]
		[InlineData("Day03/Input/Part1.txt", 546563)]
		public void GetPartNumbers_Part1(string inputPath, int expected, params int[] invalidNumbers)
		{
			var sut = new GondolaPartsService(new Common.FilesService());

			var engineSchematic = sut.GetEngineSchematic(inputPath);

			var actual = engineSchematic.PartNumbers.Select(pn => pn.Id).Sum();

			foreach (var number in invalidNumbers)
			{
				Assert.DoesNotContain(engineSchematic.PartNumbers, pn => pn.Id.Equals(number));
			}

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("Day03/Input/SamplePart1.txt", 467835)]
		[InlineData("Day03/Input/Part1.txt", 91031374)]
		public void GetPartNumbers_Part2(string inputPath, int expected)
		{
			var sut = new GondolaPartsService(new Common.FilesService());

			var engineSchematic = sut.GetEngineSchematic(inputPath);

			var actual = engineSchematic.Gears.Select(g => g.Ratio).Sum();

			Assert.Equal(expected, actual);
		}
	}
}
