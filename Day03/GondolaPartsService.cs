using AdventOfCode2023.Common;
using System.Text;

namespace AdventOfCode2023.Day03
{
	public class GondolaPartsService
	{
		private readonly FilesService _filesService;

		public GondolaPartsService(FilesService filesService)
		{
			_filesService = filesService;
		}
		public EngineSchematic GetEngineSchematic(string inputPath)
		{
			var lines = _filesService.ReadAllLines(inputPath);

			var schematic = BuildEngineSchematic(lines);

			var partNumbers = new List<int>();

			foreach (var kvp in schematic.Symbols)
			{
				for (int y = -1; y <= 1; y++)
				{
					for (int x = -1; x <= 1; x++)
					{
						var pointToCheck = new Point
						{
							X = kvp.Key.X + x,
							Y = kvp.Key.Y + y
						};

						if (schematic.PossiblePartNumbers.TryGetValue(pointToCheck, out PartNumber partNumber))
						{
							if (!partNumber.Consumed)
							{
								partNumber.Consumed = true;
								partNumbers.Add(partNumber.Id);
							}

							if (kvp.Value == '*')
							{
								var gear = schematic.Gears[kvp.Key];

								if (!gear.PartNumbers.Contains(partNumber))
								{
									gear.PartNumbers.Add(partNumber);

									gear.AdjacentNumbers++;

									if (gear.AdjacentNumbers == 1)
									{
										gear.Ratio = partNumber.Id;
									}
									else if (gear.AdjacentNumbers == 2)
									{
										gear.Ratio *= partNumber.Id;
									}
									else
									{
										gear.Ratio = 0;
									}
								}
							}
						}
					}
				}
			}

			var final = partNumbers
				.Select(n => new PartNumber
				{
					Id = n
				})
				.ToList();

			schematic.PartNumbers = final;

			schematic.Gears = schematic.Gears.Where(g => g.Value.AdjacentNumbers == 2).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

			return schematic;
		}

		private EngineSchematic BuildEngineSchematic(string[] lines)
		{
			var grid = new char[lines.Length, lines[0].Length];

			var numbers = new Dictionary<Point, char>();
			var partNumbers = new Dictionary<Point, PartNumber>();
			var symbols = new Dictionary<Point, char>();
			var gears = new Dictionary<Point, Gear>();

			var stringBuilder = new StringBuilder();
			var numbers2Points = new List<Point>();

			for (int y = 0; y < lines.Length; y++)
			{
				for (int x = 0; x < lines[y].Length; x++)
				{
					var point = new Point()
					{
						X = x,
						Y = y,
					};

					grid[x, y] = lines[y][x];

					if (grid[x, y] != '.')
					{
						if (grid[x, y] >= '0' && grid[x, y] <= '9')
						{
							numbers.Add(point, grid[x, y]);
							numbers2Points.Add(point);
							stringBuilder.Append(grid[x, y]);
						}
						else
						{
							symbols.Add(point, grid[x, y]);
							ApplyNumberToSchematic(stringBuilder, numbers2Points, partNumbers);

							if (grid[x, y] == '*')
							{
								gears.Add(point, new Gear
								{
									Point = point,
									Ratio = 0
								});
							}
						}
					}
					else
					{
						ApplyNumberToSchematic(stringBuilder, numbers2Points, partNumbers);
					}
				}
			}

			ApplyNumberToSchematic(stringBuilder, numbers2Points, partNumbers);

			return new EngineSchematic
			{
				Grid = grid,
				Numbers = numbers,
				Symbols = symbols,
				PossiblePartNumbers = partNumbers,
				Gears = gears,
			};
		}

		private void ApplyNumberToSchematic(StringBuilder stringBuilder, List<Point> points, Dictionary<Point, PartNumber> partNumbers)
		{
			if (stringBuilder.Length == 0)
			{
				return;
			}

			var integer = int.Parse(stringBuilder.ToString());

			var partNumber = new PartNumber
			{
				Id = integer,
				Points = new List<Point>()
			};

			foreach (var point in points)
			{
				partNumbers.Add(point, partNumber);
				partNumber.Points.Add(point);
			}

			stringBuilder.Clear();
			points.Clear();
		}
	}
}
