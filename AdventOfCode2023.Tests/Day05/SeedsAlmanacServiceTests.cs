using AdventOfCode2023.Day05;

namespace AdventOfCode2023.Tests.Day05
{
	public class SeedsAlmanacServiceTests
	{
		[Theory]
		[InlineData("Day05/Input/SamplePart1.txt", 35)]
		[InlineData("Day05/Input/Part1.txt", 324724204)]
		public void GetScratchCards_Part1(string inputPath, int expected)
		{
			var sut = new SeedsAlmanacService(new Common.FilesService());

			var alamanac = sut.ParseAlmanac(inputPath);

			var locations = sut.GetLocationNumbers(alamanac);

			var actual = locations.Select(l => l.Value).Min();

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("Day05/Input/SamplePart1.txt", 46)]
		[InlineData("Day05/Input/Part1.txt", 0)]
		public void GetScratchCards_Part2(string inputPath, int expected)
		{
			var sut = new SeedsAlmanacService(new Common.FilesService());

			var alamanac = sut.ParseAlmanac(inputPath);

			sut.SetSeedsAsRange(alamanac);

			var locations = sut.GetLocationNumbers(alamanac);

			var actual = locations.Select(l => l.Value).Min();

			Assert.Equal(expected, actual);
		}
	}
}
