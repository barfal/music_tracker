using MusicTracker.Controllers;
using MusicTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace MusicTracker.ViewModels
{
	public class GigFormViewModel
	{
		public int Id { get; set; }

		[Required]
		public string Place { get; set; }

		[Required]
		[FutureDateValidation]
		public string Date { get; set; }

		[Required]
		public string Time { get; set; }

		[Required]
		public byte Genre { get; set; }

		public IEnumerable<Genre> Genres { get; set; }

		public string Heading { get; set; }

		public string Action
		{
			get
			{
				Expression<Func<GigController, ActionResult>> update =
					(q => q.Update(this));

				Expression<Func<GigController, ActionResult>> create =
					(q => q.Create(this));

				var action = (Id != 0) ? update : create;

				return (action.Body as MethodCallExpression).Method.Name;
			}
		}

		public DateTime GetDateTime()
		{
			// must be method not prop, because ASP.NET uses reflection mechanism to construct ViewModel
			return DateTime.Parse($"{Date} {Time}");
		}
	}
}