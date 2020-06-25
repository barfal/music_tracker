using System;

namespace MusicTracker.Dtos
{
	public class GigDto
	{
		public int Id { get; set; }
		public bool IsCanceled { get; set; }
		public UserDto Artist { get; set; }
		public DateTime DateTime { get; set; }
		public string GigPlace { get; set; }
		public GenreDto GenreDto { get; set; }

	}
}