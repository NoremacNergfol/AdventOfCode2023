using AdventOfCode2023.Common;

namespace AdventOfCode2023.Day04
{
	public class ScratchCardsService
	{
		private readonly FilesService _filesService;

		public ScratchCardsService(FilesService filesService)
		{
			_filesService = filesService;
		}

		public List<ScratchCard> ParseScratchCards(string inputPath)
		{
			var lines = _filesService.ReadAllLines(inputPath);

			var scratchCards = lines
				.Select(l =>
				{
					var idAndAllNumbers = l.Split(": ");

					var id = int.Parse(idAndAllNumbers[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);

					var allNumbers = idAndAllNumbers[1].Split(" | ");

					var winningNumbers = allNumbers[0]
						.Split(" ", StringSplitOptions.RemoveEmptyEntries)
						.Select(int.Parse)
						.ToHashSet();

					var numbers = allNumbers[1]
						.Split(" ", StringSplitOptions.RemoveEmptyEntries)
						.Select(int.Parse)
						.ToArray();

					var matches = new List<NumberMatch>();
					var points = 0;
					foreach (var number in numbers)
					{
						if (winningNumbers.Contains(number))
						{
							if (matches.Count == 0)
							{
								points++;
							}
							else
							{
								points *= 2;
							}

							matches.Add(new NumberMatch
							{
								Number = number
							});
						}
					}

					return new ScratchCard
					{
						Id = id,
						Numbers = numbers,
						WinningNumbers = winningNumbers,
						Matches = matches,
						Points = points
					};
				})
				.ToList();

			return scratchCards;
		}
	}
}
