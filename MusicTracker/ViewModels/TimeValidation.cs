using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MusicTracker.ViewModels
{
	public class TimeValidation : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			string timeFormat = "HH:mm";

			DateTime dateTime;
			var isValid = DateTime.TryParseExact(Convert.ToString(value),
				timeFormat,
				CultureInfo.CurrentCulture,
				DateTimeStyles.None,
				out dateTime);

			return (isValid);
		}

	}
}