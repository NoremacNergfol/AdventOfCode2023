﻿namespace AdventOfCode2023.Day03
{
	public class Point : IEquatable<Point?>
	{
		public int X { get; set; }
		public int Y { get; set; }

		public override bool Equals(object? obj)
		{
			return Equals(obj as Point);
		}

		public bool Equals(Point? other)
		{
			return other is not null &&
				   X == other.X &&
				   Y == other.Y;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(X, Y);
		}

		public override string? ToString()
		{
			return $"( {X}, {Y} )";
		}

		public static bool operator ==(Point? left, Point? right)
		{
			return EqualityComparer<Point>.Default.Equals(left, right);
		}

		public static bool operator !=(Point? left, Point? right)
		{
			return !(left == right);
		}
	}
}
