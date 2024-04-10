namespace PrecastFactorySystem.Core.Contracts
{
    using PrecastFactorySystem.Core.Models.Order;

    public interface IExportService
	{
		void ExportToPdf(OrderViewModel data, string fileName);
	}
}
