using AdventOfCode2023.Common;

namespace AdventOfCode2023.Day05
{
	public class SeedsAlmanacService
	{
		private readonly FilesService _filesService;

		public SeedsAlmanacService(FilesService filesService)
		{
			_filesService = filesService;
		}

		public Almanac ParseAlmanac(string inputPath)
		{
			var lines = _filesService.ReadAllLines(inputPath);

			var seeds = lines[0]
				.Split(": ")[1]
				.Split(" ")
				.Select(s =>
				{
					return new CategoryAndValue
					{
						Category = "seed",
						Value = long.Parse(s)
					};
				})
				.ToList();

			var conversions = new List<AlmanacConversion>();
			AlmanacConversion currentConversion = null;

			for (int i = 2; i < lines.Length; i++)
			{
				var line = lines[i];

				if (line.EndsWith("map:"))
				{
					var categories = line.Split("-");

					currentConversion = new AlmanacConversion
					{
						SourceCategory = categories[0],
						DestinationCategory = categories[2].Split(" ")[0],
						ConversionRanges = new List<ConversionRange>()
					};
				}
				else if (currentConversion != null && line.Length == 0)
				{
					conversions.Add(currentConversion);
				}
				else if (currentConversion != null)
				{
					var ranges = line
						.Split(" ")
						.Select(long.Parse)
						.ToArray();

					currentConversion.ConversionRanges.Add(new ConversionRange
					{
						DestinationRangeStart = ranges[0],
						SourceRangeStart = ranges[1],
						RangeLength = ranges[2]
					});
				}
			}

			conversions.Add(currentConversion);

			return new Almanac
			{
				Seeds = seeds,
				AlamanacConversions = conversions.ToDictionary(kvp => kvp.SourceCategory, conversions => conversions)
			};
		}

		public void SetSeedsAsRange(Almanac almanac)
		{
			var values = almanac.Seeds.Select(s => s.Value).ToList();

			var newSeeds = new List<CategoryAndValue>();

			for (var start = values[0]; start < values[0] + values[1]; start++)
			{
				newSeeds.Add(new CategoryAndValue
				{
					Category = "seed",
					Value = start
				});
			}

			for (var start = values[2]; start < values[2] + values[3]; start++)
			{
				newSeeds.Add(new CategoryAndValue
				{
					Category = "seed",
					Value = start
				});
			}

			almanac.Seeds = newSeeds;
		}

		public List<CategoryAndValue> GetLocationNumbers(Almanac almanac)
		{
			var locations = new List<CategoryAndValue>();

			foreach (var seed in almanac.Seeds)
			{
				var location = new CategoryAndValue
				{
					Category = "location",
					Stack = new Stack<CategoryAndValue>(),
					Value = -1
				};
				location.Stack.Push(seed);

				var currentCategory = seed;
				while (true)
				{
					if (!almanac.AlamanacConversions.TryGetValue(currentCategory.Category, out var conversion))
					{
						break;
					}

					var newCategory = conversion.DestinationCategory;
					var newValue = currentCategory.Value;

					var currentValue = currentCategory.Value;

					foreach (var range in conversion.ConversionRanges)
					{
						var diff = currentValue - range.SourceRangeStart;
						if (diff >= 0 && diff <= range.RangeLength - 1)
						{
							newValue = range.DestinationRangeStart + diff;
							break;
						}
					}

					currentCategory = new CategoryAndValue
					{
						Category = newCategory,
						Value = newValue,
					};

					if (currentCategory.Category == "location")
					{
						location.Value = currentCategory.Value;
						break;
					}

					location.Stack.Push(currentCategory);
				}

				locations.Add(location);
			}

			return locations;
		}
	}
}
