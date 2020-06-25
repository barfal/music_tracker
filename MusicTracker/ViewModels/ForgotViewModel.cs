using System.ComponentModel.DataAnnotations;

namespace MusicTracker.ViewModels
{
	public class ForgotViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}