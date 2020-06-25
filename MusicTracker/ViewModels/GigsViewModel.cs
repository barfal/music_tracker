using MusicTracker.Models;
using System.Collections.Generic;

namespace MusicTracker.ViewModels
{
	public class GigsViewModel
	{
		public IEnumerable<Gig> FutureGigs { get; set; }
		public bool ShowActions { get; set; }
		public string Heading { get; set; }
		public string SearchTerm { get; set; }
	}
}