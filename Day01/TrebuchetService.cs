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
			// keep track of the first and last numbers
			// and set them to placeholder values
			int firstNumber = -1;
			int lastNumber = -1;

			foreach (char character in line)
			{
				// process the character when it is a when it is a number (0 - 9)
				if (character >= '0' && character <= '9')
				{
					// subtract the current character from '0' to get it's integer value
					int value = character - '0';

					// assign the value to the first number or last number
					if (firstNumber == -1)
					{
						firstNumber = value;
					}
					else
					{
						lastNumber = value;
					}
				}
			}

			if (lastNumber == -1)
			{
				// when there is no last number, use the first number twice
				return firstNumber * 10 + firstNumber;
			}
			else
			{
				return firstNumber * 10 + lastNumber;
			}
		}
	}
}
