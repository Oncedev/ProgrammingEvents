using System;

namespace ProgrammingEvents.Core
{
	public static class StringExtensions
	{
		public static byte[] ToByteArray(this string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy (str.ToCharArray (), 0, bytes, 0, bytes.Length);
			return bytes;
		}
	}
}

