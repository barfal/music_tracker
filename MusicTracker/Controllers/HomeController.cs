using Microsoft.AspNet.Identity;
using MusicTracker.Models;
using MusicTracker.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MusicTracker.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _context;

		public HomeController()
		{
			_context = new ApplicationDbContext();
		}

		public ActionResult ArtistsWhoIamFollowing()
		{
			var userId = User.Identity.GetUserId();
			var artists = _context.Follows
				.Where(f => f.FollowerId == userId)
				.Select(p => p.Followee)
				.ToList();

			ArtistViewModel viewModel = new ArtistViewModel
			{
				Artists = artists,
			};

			return View(viewModel);
		}

		public ActionResult Index(string query = null)
		{
			var futureGigs = _context.Gigs
				.Include(g => g.Artist)
				.Include(g => g.Genre)
				.Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);

			if (!String.IsNullOrWhiteSpace(query))
			{
				futureGigs = futureGigs
					.Where(g =>
						g.Artist.Name.Contains(query) ||
						g.Genre.Name.Contains(query) ||
						g.GigPlace.Contains(query));
			}

			var viewModel = new GigsViewModel
			{
				FutureGigs = futureGigs,
				ShowActions = User.Identity.IsAuthenticated,
				Heading = "Music Gigs",
				SearchTerm = query,
			};

			return View("Gigs", viewModel);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}