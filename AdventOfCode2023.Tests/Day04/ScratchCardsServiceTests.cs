using AdventOfCode2023.Day04;

namespace AdventOfCode2023.Tests.Day04
{
	public class ScratchCardsServiceTests
	{
		[Theory]
		[InlineData("Day04/Input/SamplePart1.txt", 13)]
		[InlineData("Day04/Input/Part1.txt", 32609)]
		public void GetScratchCards_Part1(string inputPath, int expected)
		{
			var sut = new ScratchCardsService(new Common.FilesService());

			var scratchCards = sut.ParseScratchCards(inputPath);

			var actual = scratchCards.Select(s => s.Points).Sum();

			Assert.Equal(expected, actual);
		}
	}
}
