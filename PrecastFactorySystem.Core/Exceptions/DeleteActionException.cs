namespace PrecastFactorySystem.Core.Exceptions
{
	using System;
	
	public class DeleteActionException : Exception
	{
		public DeleteActionException() { }

		public DeleteActionException(string message) : base(message)
		{

		}

	}
}
