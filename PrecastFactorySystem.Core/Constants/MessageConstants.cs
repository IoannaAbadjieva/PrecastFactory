namespace PrecastFactorySystem.Core.Constants
{
	public class MessageConstants
	{
		public const string DeleteProjectErrorMessage = "You can not delete this projectt, it has precast in production";

		public const string DeletePrecastErrorMessage = "You can not delete this precast, it is in production";

		public const string DeleteDelivererErrorMessage = "You can not delete this deliverer, he has orders in production";

		public const string InvalidPrecastCountErrorMessage = "You can not change precast count to less than {0}";

	}
}
