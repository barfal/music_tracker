using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MusicTracker.ViewModels
{
	public class FutureDateValidation : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			string dateFormat = "dd MMM yyyy";

			DateTime dateTime;
			var isValid = DateTime.TryParseExact(Convert.ToString(value),
				dateFormat,
				CultureInfo.CurrentCulture,
				DateTimeStyles.None,
				out dateTime);

			return (isValid && dateTime > DateTime.Now);
		}

	}
}