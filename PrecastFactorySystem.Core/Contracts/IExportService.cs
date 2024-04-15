namespace PrecastFactorySystem.Core.Contracts
{
    using PrecastFactorySystem.Core.Models.Order;

    public interface IExportService
	{
		void ExportOrderToPdf(OrderViewModel data, string fileName);
	}
}
