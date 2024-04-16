namespace PrecastFactorySystem.Core.Services
{
	using iText.Kernel.Pdf;
	using iText.Layout;
	using iText.Layout.Borders;
	using iText.Layout.Element;
	using iText.Layout.Properties;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Order;

	public class ExportService : IExportService
	{
		public byte[] ExportOrderToPdf(OrderViewModel data, string fileName)
		{
			MemoryStream stream = new MemoryStream();
			PdfWriter writer = new PdfWriter(stream);
			PdfDocument pdf = new PdfDocument(writer);
			Document document = new Document(pdf);

			document.Add(new Paragraph("Order ID: " + data.OrderNum)).SetFontSize(14);
			document.Add(new Paragraph("Precast: " + data.Precast)).SetFontSize(11);
			document.Add(new Paragraph("Project: " + data.Project)).SetFontSize(11);
			document.Add(new Paragraph("Count: " + data.Count)).SetFontSize(11);
			document.Add(new Paragraph("Order Date: " + data.OrderDate)).SetFontSize(11);

			document.Add(new Paragraph(new Text("\n")));


			Table table = new Table(4, false)
				.UseAllAvailableWidth()
				.SetBorder(Border.NO_BORDER);
			table.AddCell("Position").SetBold();
			table.AddCell("Count").SetBold();
			table.AddCell("ReinforceType").SetBold();
			table.AddCell("Length").SetBold();

			foreach (var reinforce in data.Reinforce)
			{
				table.AddCell(reinforce.Position);
				table.AddCell(reinforce.Count.ToString());
				table.AddCell(reinforce.ReinforceType);
				table.AddCell(reinforce.Length.ToString("f2"));
			}

			document.Add(table);
			document.Add(new Paragraph(new Text("\n")));

			document.Add(new Paragraph("Deliver Date: " + data.DeliverDate)).SetFontSize(11);
			document.Add(new Paragraph("Department: " + data.Department)).SetFontSize(11);

			int n = pdf.GetNumberOfPages();
			for (int i = 1; i <= n; i++)
			{
				document.ShowTextAligned(new Paragraph(String
				   .Format("page" + i + " of " + n)),
					559, 806, i, TextAlignment.RIGHT,
					VerticalAlignment.BOTTOM, 0);
			}


			document.Close();
			byte[] bytes = stream.ToArray();
			return bytes;
		}
	}
}
