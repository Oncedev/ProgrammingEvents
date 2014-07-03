using System;
using System.Globalization;

namespace ProgrammingEvents.Core
{
	public class Event
	{
		public string Title {
			get;
			set;
		}

		public string Description {
			get;
			set;
		}

		public DateTime StartDate {
			get;
			set;
		}

		public DateTime EndDate {
			get;
			set;
		}

		public string Address {
			get;
			set;
		}

		public string Site {
			get;
			set;
		}

		public double Latitude {
			get;
			set;
		}

		public double Longitude {
			get;
			set;
		}

		public string DetailLabelText {
			get {
				var shortDate = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
				var date = StartDate == EndDate ? StartDate.ToString(shortDate) : StartDate.ToString(shortDate) + " - " + EndDate.ToString(shortDate);
				return date + " at " + Address;
			}
		}

		public Event ()
		{
		}			
	}
}

