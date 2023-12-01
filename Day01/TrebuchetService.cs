using AdventOfCode2023.Common;

namespace AdventOfCode2023.Day01
{
	public class TrebuchetService
	{
		private readonly FilesService _filesService;

		public TrebuchetService(FilesService filesService)
		{
			_filesService = filesService;
		}

		public int[] GetTrebuchetCalibrationValues(string inputPath)
		{
			var lines = _filesService.ReadAllLines(inputPath);

			var calibrationValues = lines
				.Select(ParseCalibrationValue)
				.ToArray();

			return calibrationValues;
		}

		public int[] GetTrebuchetCalibrationValuesV2(string inputPath)
		{
			var lines = _filesService.ReadAllLines(inputPath);

			var calibrationValues = lines
				.Select(ParseCalibrationValueV2)
				.ToArray();

			return calibrationValues;
		}

		public int ParseCalibrationValue(string line)
		{
			int number1 = -1;
			int number2 = -1;

			foreach (char character in line)
			{
				if (character >= '0' && character <= '9')
				{
					var value = character - '0';

					if (number1 != -1)
					{
						number2 = value;
					}
					else
					{
						number1 = value;
					}
				}
			}

			if (number2 != -1)
			{
				return number1 * 10 + number2;
			}
			else
			{
				return number1 * 10 + number1;
			}
		}

		public static readonly Dictionary<string, int> SpelledOutNumbers = new Dictionary<string, int>
		{
			{ "one", 1 },
			{ "two", 2 },
			{ "three", 3 },
			{ "four", 4 },
			{ "five", 5 },
			{ "six", 6 },
			{ "seven", 7 },
			{ "eight", 8 },
			{ "nine", 9 }
		};

		public int ParseCalibrationValueV2(string line)
		{
			int number1 = -1;
			int number2 = -1;

			for (int i = 0; i < line.Length; i++)
			{
				char character = line[i];

				int value = -1;
				if (character >= '0' && character <= '9')
				{
					value = character - '0';
				}
				else
				{
					var currentString = line[..(i + 1)];

					foreach (var kvp in SpelledOutNumbers)
					{
						if (currentString.EndsWith(kvp.Key))
						{
							value = kvp.Value;
							break;
						}
					}
				}

				if (value == -1)
				{
					continue;
				}

				if (number1 != -1)
				{
					number2 = value;
				}
				else
				{
					number1 = value;
				}
			}

			if (number2 != -1)
			{
				return number1 * 10 + number2;
			}
			else
			{
				return number1 * 10 + number1;
			}
		}
	}
}
