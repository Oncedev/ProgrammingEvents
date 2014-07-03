using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingEvents.Core
{
	public static class EventListExtensions
	{
		public static List<Event> GetPastEvents(this List<Event> events)
		{
			return events.Where (x => x.StartDate.Date < DateTime.Today).OrderBy (x => x.StartDate).ToList ();
		}

		public static List<Event> GetUpcomingEvents(this List<Event> events)
		{
			return events.Where (x => x.StartDate.Date >= DateTime.Today).OrderBy (x => x.StartDate).ToList ();
		}
	}
}

