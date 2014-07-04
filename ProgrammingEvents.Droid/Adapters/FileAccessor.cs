using System;
using System.IO;
using System.Text;
using ProgrammingEvents.Core;
using Android.Content;
using Java.IO;

namespace ProgrammingEvents.Droid
{
	public class FileAccessor : IFileAccessor
	{
		Context _ctxt;

		public FileAccessor (Context c)
		{
			_ctxt = c;
		}

		public void SaveContent(string content)
		{
			var output = _ctxt.OpenFileOutput ("EventList.json", FileCreationMode.Private);
			var contentBytes = content.ToByteArray ();
			output.Write (content.ToByteArray(), 0, contentBytes.Length);
			output.Close ();
		}

		public string GetContent()
		{
			using (var reader = new StreamReader (_ctxt.OpenFileInput ("EventList.json"), Encoding.Unicode)) {
				return reader.ReadToEnd ();
			}
		}
	}
}

