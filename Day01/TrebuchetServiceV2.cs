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
			// keep track of the first and last numbers
			// and set them to placeholder values
			int firstNumber = -1;
			int lastNumber = -1;
			var buffer = new StringBuilder(5);

			foreach (char character in line)
			{
				int value = -1;

				if (buffer.Length >= 5)
				{
					buffer.Remove(0, 1);
				}
				buffer.Append(character);

				// process the character when it is a when it is a number (0 - 9)
				if (character >= '0' && character <= '9')
				{
					// subtract the current character from '0' to get it's integer value
					value = character - '0';
				}
				// when the buffer as enough characters see if its equal to a number
				else if (buffer.Length >= 3)
				{
					foreach (var kvp in SpelledOutNumbers)
					{
						// when the buffer is too small for the current number, skip it
						if (kvp.Key.Length > buffer.Length)
						{
							continue;
						}

						bool isMatch = true;
						// confusingly compare each character of the number against the buffer
						for (int i = kvp.Key.Length - 1; i >= 0; i--)
						{
							int invertedIndex = kvp.Key.Length - 1 - i;
							if (kvp.Key[i] != buffer[buffer.Length - 1 - invertedIndex])
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
