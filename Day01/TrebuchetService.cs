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
	}
}
