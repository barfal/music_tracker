using Microsoft.AspNet.Identity;
using MusicTracker.Models;
using MusicTracker.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MusicTracker.Controllers
{

	public class GigController : Controller
	{
		private readonly ApplicationDbContext _context;

		public GigController()
		{
			_context = new ApplicationDbContext();
		}

		[Authorize]
		public ActionResult Mine()
		{
			var userId = User.Identity.GetUserId();
			var gigs = _context.Gigs
				.Where(g => g.ArtistId == userId &&
							g.DateTime > DateTime.Now &&
							!g.IsCanceled)
				.Include(g => g.Genre)
				.ToList();

			return View(gigs);
		}

		[Authorize]
		public ActionResult Participating()
		{
			var userId = User.Identity.GetUserId();
			var gigs = _context.Participations
				.Where(p => p.ParticipatingUserId == userId)
				.Select(p => p.Gig)
				.Include(p => p.Artist)
				.Include(p => p.Genre)
				.ToList();

			var viewModel = new GigsViewModel
			{
				ShowActions = User.Identity.IsAuthenticated,
				FutureGigs = gigs,
				Heading = "Gigs I'm going",
			};

			return View("Gigs", viewModel);
		}

		[Authorize]
		public ActionResult Create()
		{
			var viewModel = new GigFormViewModel
			{
				Genres = _context.Genres.ToList(),
				Heading = "Add a Gig",
			};
			return View("GigForm", viewModel);
		}

		[Authorize]
		public ActionResult Edit(int id)
		{
			var userId = User.Identity.GetUserId();
			var gigToEdit = _context.Gigs.Single(g => g.Id == id && g.ArtistId == userId);
			var viewModel = new GigFormViewModel
			{
				Id = gigToEdit.Id,
				Genres = _context.Genres.ToList(),
				Date = gigToEdit.DateTime.ToString("dd MMM yyyy"),
				Time = gigToEdit.DateTime.ToString("HH:mm"),
				Genre = gigToEdit.GenreId,
				Place = gigToEdit.GigPlace,
				Heading = "Edit a Gig",
			};

			return View("GigForm", viewModel);
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(GigFormViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				viewModel.Genres = _context.Genres.ToList();
				return View("GigForm", viewModel);
			}
			var gig = new Gig
			{
				ArtistId = User.Identity.GetUserId(),
				DateTime = viewModel.GetDateTime(),
				GenreId = viewModel.Genre,
				GigPlace = viewModel.Place
			};
			_context.Gigs.Add(gig);
			_context.SaveChanges();

			return RedirectToAction("Mine", "Gig");
		}

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult Update(GigFormViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				viewModel.Genres = _context.Genres.ToList();
				return View("GigForm", viewModel);
			}
			var userId = User.Identity.GetUserId();
			var gig = _context.Gigs
				.Include(g => g.Participators.Select(p => p.ParticipatingUser))
				.Single(g => g.Id == viewModel.Id && g.ArtistId == userId);

			gig.Modify(viewModel);

			_context.SaveChanges();

			return RedirectToAction("Mine", "Gig");
		}


		[HttpPost]
		public ActionResult Search(GigsViewModel viewModel)
		{
			return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
		}
	}
}