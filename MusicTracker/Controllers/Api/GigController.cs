using Microsoft.AspNet.Identity;
using MusicTracker.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace MusicTracker.Controllers.Api
{
	[Authorize]
	public class GigController : ApiController
	{
		private readonly ApplicationDbContext _context;

		public GigController()
		{
			_context = new ApplicationDbContext();
		}

		[HttpDelete]
		public IHttpActionResult Cancel(int id)
		{
			var userId = User.Identity.GetUserId();
			var gig = _context.Gigs
				.Include(g => g.Participators.Select(p => p.ParticipatingUser))
				.Single(g => g.Id == id && g.ArtistId == userId);

			if (gig.IsCanceled)
				return NotFound();

			gig.Cancel();

			_context.SaveChanges();

			return Ok();
		}

	}
}
