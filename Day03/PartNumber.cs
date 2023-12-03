namespace AdventOfCode2023.Day03
{
	public class PartNumber : IEquatable<PartNumber?>
	{
		public int Id { get; set; }
		public bool Consumed { get; set; }
		public List<Point> Points { get; set; }
		public Guid UniqueId = Guid.NewGuid();

		public override string? ToString()
		{
			return Id.ToString();
		}

		public override bool Equals(object? obj)
		{
			return Equals(obj as PartNumber);
		}

		public bool Equals(PartNumber? other)
		{
			return other is not null &&
				   UniqueId.Equals(other.UniqueId);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(UniqueId);
		}

		public static bool operator ==(PartNumber? left, PartNumber? right)
		{
			return EqualityComparer<PartNumber>.Default.Equals(left, right);
		}

		public static bool operator !=(PartNumber? left, PartNumber? right)
		{
			return !(left == right);
		}
	}
}