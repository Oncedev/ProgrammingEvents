using System;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProgrammingEvents.Core
{
	public class EventManager
	{
		private HttpClient _client;
		private IFileAccessor _fileAccessor;

		public EventManager (IFileAccessor fileAccessor)
		{
			_client = new HttpClient();
			_client.BaseAddress = new Uri("https://raw.githubusercontent.com/");

			_fileAccessor = fileAccessor;
		}

		public void UpdateData() {

			try {
				var response = _client.GetAsync("pauloortins/ProgrammingEvents/master/EventList.json").Result;
				var content = response.Content.ReadAsStringAsync().Result;

				_fileAccessor.SaveContent(content);
			} catch (Exception ex) {

			}
		}

		public List<Event> GetData() {
			var content = _fileAccessor.GetContent ();
			var events = JsonConvert.DeserializeObject<List<Event>> (content);
			return events;
		}
	}
}

