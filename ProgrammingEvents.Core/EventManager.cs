using System;
using System.Net.Http;
using System.IO;

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

		public void GetData() {

			try {
				var response = _client.GetAsync("willmendesneto/keepr/master/bower.json").Result;
				var content = response.Content.ReadAsStringAsync().Result;

				_fileAccessor.SaveEvents(content);
			} catch (Exception ex) {

			}
		}
	}
}

