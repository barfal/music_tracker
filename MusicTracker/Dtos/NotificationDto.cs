using System;
using MusicTracker.Models;

namespace MusicTracker.Dtos
{
	public class NotificationDto
	{
		public DateTime DateTime { get; set; }
		public NotificationType Type { get; set; }
		public DateTime? OldDateTime { get; set; }
		public string OldGigPlace { get; set; }
		public GigDto GigDto { get; set; }
	}
}