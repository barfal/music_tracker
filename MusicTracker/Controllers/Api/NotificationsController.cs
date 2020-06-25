using Microsoft.AspNet.Identity;
using MusicTracker.Dtos;
using MusicTracker.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace MusicTracker.Controllers.Api
{
	[Authorize]
	public class NotificationsController : ApiController
	{
		private readonly ApplicationDbContext _context;

		public NotificationsController()
		{
			_context = new ApplicationDbContext();
		}

		public IEnumerable<NotificationDto> GetNewNotifications()
		{
			var userId = User.Identity.GetUserId();
			var notifications = _context.UserNotifications
				.Where(un => un.UserId == userId && !un.IsRead)
				.Select(un => un.Notification)
				.Include(n => n.Gig.Artist)
				.ToList();

			// Map: Notification -> NotificationDto
			return notifications.Select(n => new NotificationDto()
			{
				DateTime = n.DateTime,
				GigDto = new GigDto()
				{
					Artist = new UserDto()
					{
						Id = n.Gig.ArtistId,
						Name = n.Gig.Artist.Name,
					},
					DateTime = n.Gig.DateTime,
					Id = n.Gig.Id,
					IsCanceled = n.Gig.IsCanceled,
					GigPlace = n.Gig.GigPlace,
				},
				OldGigPlace = n.OldGigPlace,
				OldDateTime = n.OldDateTime,
				Type = n.Type,
			});

		}
	}
}
