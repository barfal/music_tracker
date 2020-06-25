using System;
using System.ComponentModel.DataAnnotations;

namespace MusicTracker.Models
{
	public class Notification
	{
		public int Id { get; private set; }
		public DateTime DateTime { get; private set; }
		public NotificationType Type { get; private set; }
		public DateTime? OldDateTime { get; private set; }
		public string OldGigPlace { get; private set; }

		[Required]
		public Gig Gig { get; private set; }

		protected Notification()
		{

		}

		private Notification(Gig gig, NotificationType type)
		{
			Gig = gig ?? throw new ArgumentNullException(nameof(gig));
			Type = type;
			DateTime = DateTime.Now;
		}

		public static Notification GigNotifyCreatedFactory(Gig gig)
		{
			return new Notification(gig, NotificationType.GIG_CREATED);
		}

		public static Notification GigNotifyUpdatedFactory(Gig newGig, DateTime oldDateTime, string oldGigPlace)
		{
			var notification = new Notification(newGig, NotificationType.GIG_UPDATED)
			{
				OldDateTime = oldDateTime,
				OldGigPlace = oldGigPlace
			};
			return notification;
		}

		public static Notification GigNotifyCanceledFactory(Gig gig)
		{
			return new Notification(gig, NotificationType.GIG_CANCELED);
		}


	}
}