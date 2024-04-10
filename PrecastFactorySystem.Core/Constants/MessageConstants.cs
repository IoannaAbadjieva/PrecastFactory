namespace PrecastFactorySystem.Core.Constants
{
	public class MessageConstants
	{
		public const string DeleteProjectErrorMessage = "You can not delete this projectt, it has precast either produced or in production.";

		public const string DeletePrecastErrorMessage = "You can not delete this precast, it is either produced or in production.";

		public const string DeleteDelivererErrorMessage = "You can not delete this deliverer, he has orders in production.";

		public const string InvalidPrecastCountErrorMessage = "You can not change precast count to less than {0}.";

		public const string InvalidOrderCountErrorMessage = "You can not order more than {0} precast.";

		public const string InvalidProduceCountErrorMessage = "You can not mark as produced more than {0} precast.";

	}
}
