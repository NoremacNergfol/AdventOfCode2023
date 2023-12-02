using AdventOfCode2023.Common;

namespace AdventOfCode2023.Day02
{
	public class CubeGameService
	{
		private readonly FilesService _filesService;

		public CubeGameService(FilesService filesService)
		{
			_filesService = filesService;
		}

		public CubeGameInstance GetCubeGameInstance(string line)
		{
			var idAndSets = line.Split(": ");

			var id = int.Parse(idAndSets[0].Split(" ")[1]);
			var sets = idAndSets[1].Split("; ").Select(set =>
			{
				var cubeCounts = set.Split(", ");

				int red = 0;
				int green = 0;
				int blue = 0;

				foreach (var cubeCount in cubeCounts)
				{
					var value = int.Parse(cubeCount.Split(" ")[0]);
					if (cubeCount.EndsWith("red"))
					{
						red = value;
					}
					else if (cubeCount.EndsWith("green"))
					{
						green = value;
					}
					else if (cubeCount.EndsWith("blue"))
					{
						blue = value;
					}
				}

				return new CubeGameSet
				{
					BlueCubes = blue,
					GreenCubes = green,
					RedCubes = red,
				};
			}).ToList();

			int minRed = 0;
			int minGreen = 0;
			int minBlue = 0;

			foreach (var set in sets)
			{
				minBlue = Math.Max(minBlue, set.BlueCubes);
				minGreen = Math.Max(minGreen, set.GreenCubes);
				minRed = Math.Max(minRed, set.RedCubes);
			}

			return new CubeGameInstance
			{
				Id = id,
				Sets = sets,
				MinimumCubeGameBagForPossibility = new CubeGameBag
				{
					BlueCubes = minBlue,
					GreenCubes = minGreen,
					RedCubes = minRed
				},
				Power = minBlue * minGreen * minRed,
			};
		}

		public void SetPossibilities(CubeGameBag cubeGameBag, List<CubeGameInstance> instances)
		{
			foreach (var instance in instances)
			{
				instance.IsPossible = !instance.Sets.Any(s => s.RedCubes > cubeGameBag.RedCubes || s.GreenCubes > cubeGameBag.GreenCubes || s.BlueCubes > cubeGameBag.BlueCubes);
			}
		}

		public List<CubeGameInstance> GetCubeGameInstances(string inputPath)
		{
			var lines = _filesService.ReadAllLines(inputPath);

			var instances = lines.Select(GetCubeGameInstance).ToList();

			SetPossibilities(
				new CubeGameBag
				{
					BlueCubes = 14,
					GreenCubes = 13,
					RedCubes = 12,
				},
				instances);

			return instances;
		}
	}
}
