namespace AdventOfCode2023.Common
{
	public class FilesService
	{
		public string[] ReadAllLines(string path)
		{
			return File.ReadAllLines(path);
		}
	}
}
