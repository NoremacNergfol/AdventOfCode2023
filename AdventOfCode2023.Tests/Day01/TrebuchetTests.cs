using AdventOfCode2023.Common;
using AdventOfCode2023.Day01;

namespace AdventOfCode2023.Tests.Day01
{
	public class TrebuchetTests
	{
		[Theory]
		[InlineData("1abc2", 12)]
		[InlineData("pqr3stu8vwx", 38)]
		[InlineData("a1b2c3d4e5f", 15)]
		[InlineData("treb7uchet", 77)]
		public void TrebuchetCalibration_SampleInputs_Part1(string line, int expected)
		{
			var sut = new TrebuchetService(null);

			var actual = sut.ParseCalibrationValue(line);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("Day01/Input/SamplePart1.txt", 142)]
		[InlineData("Day01/Input/Part1.txt", 54927)]
		public void TrebuchetCalibration_Part1(string inputPath, int expected)
		{
			var sut = new TrebuchetService(new FilesService());

			var values = sut.GetTrebuchetCalibrationValues(inputPath);

			var actual = values.Sum();

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("two1nine", 29)]
		[InlineData("eightwothree", 83)]
		[InlineData("abcone2threexyz", 13)]
		[InlineData("xtwone3four", 24)]
		[InlineData("4nineeightseven2", 42)]
		[InlineData("zoneight234", 14)]
		[InlineData("7pqrstsixteen", 76)]
		[InlineData("onetwo", 12)]
		[InlineData("onethree", 13)]
		[InlineData("nine", 99)]
		[InlineData("nine9nine", 99)]
		[InlineData("nine9eight", 98)]
		[InlineData("nrhdxfsqvxcbcghf35eightthreeseven5", 35)]
		public void TrebuchetCalibration_SampleInputs_Part2(string line, int expected)
		{
			var sut = new TrebuchetServiceV2(null);

			var actual = sut.ParseCalibrationValue(line);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("Day01/Input/SamplePart2.txt", 281)]
		[InlineData("Day01/Input/Part1.txt", 54581)]
		public void TrebuchetCalibration_Part2(string inputPath, int expected)
		{
			var sut = new TrebuchetServiceV2(new FilesService());

			var values = sut.GetTrebuchetCalibrationValues(inputPath);

			var actual = values.Sum();

			Assert.Equal(expected, actual);
		}
	}
}
