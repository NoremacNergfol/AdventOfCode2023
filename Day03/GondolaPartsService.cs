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
		public List<PartNumber> GetPartNumbers(string inputPath)
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

						if (schematic.PartNumbers.TryGetValue(pointToCheck, out PartNumber partNumber))
						{
							if (!partNumber.Consumed)
							{
								partNumber.Consumed = true;
								partNumbers.Add(partNumber.Id);
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

			return final;
		}

		private EngineSchematic BuildEngineSchematic(string[] lines)
		{
			var grid = new char[lines.Length, lines[0].Length];

			var numbers = new Dictionary<Point, char>();
			var partNumbers = new Dictionary<Point, PartNumber>();
			var symbols = new Dictionary<Point, char>();

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
				PartNumbers = partNumbers
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
