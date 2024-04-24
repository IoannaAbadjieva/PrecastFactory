namespace PrecastFactorySystem.Core.Contracts
{
    using PrecastFactorySystem.Core.Models.Order;

    public interface IExportService
	{
		byte[] ExportOrderToPdf(OrderViewModel data);
	}
}
