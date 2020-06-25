﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MusicTracker.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		public ICollection<Follow> Followers { get; set; }
		public ICollection<Follow> Followees { get; set; }
		public ICollection<UserNotification> UserNotifications { get; set; }

		public ApplicationUser()
		{
			Followees = new Collection<Follow>();
			Followers = new Collection<Follow>();
			UserNotifications = new Collection<UserNotification>();
		}

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}

		public void Notify(Notification notification)
		{
			var userNotification = new UserNotification(this, notification);
			UserNotifications.Add(userNotification);
		}


	}
}