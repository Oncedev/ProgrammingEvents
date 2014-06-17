using System;
using System.Collections.Generic;

namespace ProgrammingEvents.Core
{
	public interface IFileAccessor
	{
		void SaveContent(string content);

		string GetContent ();
	}		
}

