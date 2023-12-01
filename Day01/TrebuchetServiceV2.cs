using AdventOfCode2023.Common;
using System.Text;

namespace AdventOfCode2023.Day01
{
	public class TrebuchetServiceV2
	{
		private readonly FilesService _filesService;

		public TrebuchetServiceV2(FilesService filesService)
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

		public int ParseCalibrationValue(string line)
		{
			var number1 = -1;
			var number2 = -1;
			var stringBuilder = new StringBuilder(5);

			for (int i = 0; i < line.Length; i++)
			{
				char character = line[i];

				if (stringBuilder.Length >= 5)
				{
					stringBuilder.Remove(0, 1);
				}
				stringBuilder.Append(character);

				int value = -1;
				if (character >= '0' && character <= '9')
				{
					value = character - '0';
					stringBuilder.Clear();
				}
				else if (stringBuilder.Length >= 3)
				{
					foreach (var kvp in SpelledOutNumbers)
					{
						if (kvp.Key.Length > stringBuilder.Length)
						{
							continue;
						}

						bool isMatch = true;
						for (int j = kvp.Key.Length - 1; j >= 0; j--)
						{
							int invertedIndex = kvp.Key.Length - 1 - j;
							if (kvp.Key[j] != stringBuilder[stringBuilder.Length - 1 - invertedIndex])
							{
								isMatch = false;
								break;
							}
						}

						if (isMatch)
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
