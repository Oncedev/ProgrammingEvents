using System;
using System.IO;
using ProgrammingEvents.Core;
using System.Collections.Generic;

namespace ProgrammingEvents
{
	public class FileAccessor : IFileAccessor
	{
		string _filePath;

		public FileAccessor ()
		{
			var documents =
				Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			_filePath = Path.Combine (documents, "EventList.json");


		}

		public void SaveContent(string content) {

			File.WriteAllText(_filePath, content);
		}

		public string GetContent () {

			var content = File.ReadAllText (_filePath);
			return content;
		}
	}
}

