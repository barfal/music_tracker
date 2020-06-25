using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using MusicTracker.Dtos;
using MusicTracker.Models;

namespace MusicTracker.Controllers.Api
{
	[Authorize]
	public class ParticipationController : ApiController
	{
		private readonly ApplicationDbContext _context;

		public ParticipationController()
		{
			_context = new ApplicationDbContext();
		}


		[HttpPost]
		public IHttpActionResult Participate(ParticipationDto dto)
		{
			var userId = User.Identity.GetUserId();
			var exists = _context.Participations.Any(p => p.ParticipatingUserId == userId && p.GigId == dto.GigId);

			if (exists)
				return BadRequest("The participation already exists.");

			var participation = new Participation
			{
				GigId = dto.GigId,
				ParticipatingUserId = userId,
			};

			_context.Participations.Add(participation);
			_context.SaveChanges();

			return Ok();
		}

	}
}
