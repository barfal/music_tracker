using System.Collections.Generic;
using MusicTracker.Models;

namespace MusicTracker.ViewModels
{
	public class ArtistViewModel
	{
		public IEnumerable<ApplicationUser> Artists { get; set; }
	}
}