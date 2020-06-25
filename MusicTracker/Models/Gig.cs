using MusicTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MusicTracker.Models
{
	public class Gig
	{
		public int Id { get; set; }

		public bool IsCanceled { get; private set; }

		public ApplicationUser Artist { get; set; }

		[Required]
		public string ArtistId { get; set; }

		public DateTime DateTime { get; set; }

		[Required]
		[StringLength(255)]
		public string GigPlace { get; set; }

		public Genre Genre { get; set; }

		[Required]
		public byte GenreId { get; set; }

		public ICollection<Participation> Participators { get; private set; }

		public Gig()
		{
			Participators = new Collection<Participation>();
		}

		public void Cancel()
		{
			IsCanceled = true;
			var notification = Notification.GigNotifyCanceledFactory(this);
			foreach (var participator in Participators.Select(p => p.ParticipatingUser))
			{
				participator.Notify(notification);
			}
		}

		public void Modify(GigFormViewModel viewModel)
		{
			var notification = Notification.GigNotifyUpdatedFactory(this, DateTime, GigPlace);

			// new values
			GigPlace = viewModel.Place;
			DateTime = viewModel.GetDateTime();
			GenreId = viewModel.Genre;
			IsCanceled = false;

			foreach (var participator in Participators.Select(p => p.ParticipatingUser))
			{
				participator.Notify(notification);
			}
		}


	}
}