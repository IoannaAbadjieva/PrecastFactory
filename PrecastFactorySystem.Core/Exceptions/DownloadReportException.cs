namespace PrecastFactorySystem.Core.Exceptions
{
	using System;

	public class DownloadReportException : Exception
	{
		public DownloadReportException(string message)
			: base(message)
		{
		}
	}
}
