using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicTracker.Models
{
	public class Participation
	{
		public Gig Gig { get; set; }
		public ApplicationUser ParticipatingUser { get; set; }

		[Key]
		[Column(Order = 1)]
		public int GigId { get; set; }

		[Key]
		[Column(Order = 2)]
		public string ParticipatingUserId { get; set; }


	}
}