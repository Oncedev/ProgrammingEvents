using System;
using System.IO;
using ProgrammingEvents.Core;

namespace ProgrammingEvents
{
	public class FileAccessor : IFileAccessor
	{
		public FileAccessor ()
		{
		}

		public void SaveEvents(string content) {
			var documents =
				Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			var filename = Path.Combine (documents, "EventList.json");
			File.WriteAllText(filename, content);
		}

		public void GetEvents() {

		}
	}
}

