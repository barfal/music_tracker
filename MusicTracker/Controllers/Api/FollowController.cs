using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using MusicTracker.Dtos;
using MusicTracker.Models;

namespace MusicTracker.Controllers.Api
{
	[Authorize]
	public class FollowController : ApiController
	{
		private readonly ApplicationDbContext _context;

		public FollowController()
		{
			_context = new ApplicationDbContext();
		}

		[HttpPost]
		public IHttpActionResult Following(FollowDto dto)
		{
			var userId = User.Identity.GetUserId();
			var exists = _context.Follows.Any(f => f.FollowerId == userId && f.FolloweeId == dto.FolloweeId);

			if (exists)
				return BadRequest("Following already exists.");

			var following = new Follow
			{
				FollowerId = userId,
				FolloweeId = dto.FolloweeId,
			};

			_context.Follows.Add(following);
			_context.SaveChanges();

			return Ok();
		}
	}
}
