namespace PrecastFactorySystem.Core.Services
{
    using System.Data;

    using iTextSharp.text;
    using iTextSharp.text.pdf;

    using PrecastFactorySystem.Core.Contracts;
    using PrecastFactorySystem.Core.Models.Order;

    public class ExportService : IExportService
	{
		public void ExportToPdf(OrderViewModel data, string fileName)
		{
			DataTable dtReinforce = GetOrdersDetail(data);
			string projectDirectory = GetOrdersDirectory();
			string filepath = projectDirectory + "\\" + fileName + ".pdf";

			int pdfRowIndex = 1;
			Document document = new Document(PageSize.A4, 5f, 5f, 10f, 10f);
			FileStream fs = new FileStream(filepath, FileMode.Create);
			PdfWriter writer = PdfWriter.GetInstance(document, fs);
			document.Open();


			Font font1 = FontFactory.GetFont(FontFactory.COURIER_BOLD, 10);
			Font font2 = FontFactory.GetFont(FontFactory.COURIER, 8);

			float[] columnDefinitionSize = { 3F, 3F, 3F, 3F };
			PdfPTable table;
			PdfPCell cell;

			document.Add(new Paragraph("Order Details", new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD)));
			document.Add(new Paragraph(" "));
			document.Add(new Paragraph(new Phrase("Order N: " + data.OrderNum.ToString(), font2)));
			document.Add(new Paragraph(new Phrase("Date: " + data.OrderDate.ToString(), font2)));
			document.Add(new Paragraph(new Phrase("Precast: " + data.Precast.ToString(), font2)));
			document.Add(new Paragraph(new Phrase("Project: " + data.Project.ToString(), font2)));
			document.Add(new Paragraph(new Phrase("Count: " + data.Count.ToString(), font2)));

			document.Add(new Paragraph(" "));
			document.Add(new Paragraph("Reinforce Details", new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD)));
			document.Add(new Paragraph(" "));
			table = new PdfPTable(columnDefinitionSize)
			{
				WidthPercentage = 100
			};

			cell = new PdfPCell
			{
				BackgroundColor = new BaseColor(0xC0, 0xC0, 0xC0)
			};

			table.AddCell(new Phrase("Position", font1));
			table.AddCell(new Phrase("Count", font1));
			table.AddCell(new Phrase("ReinforceType", font1));
			table.AddCell(new Phrase("Length", font1));
			table.HeaderRows = 1;

			foreach (DataRow dataRow in dtReinforce.Rows)
			{
				table.AddCell(new Phrase(dataRow["Position"].ToString(), font2));
				table.AddCell(new Phrase(dataRow["Count"].ToString(), font2));
				table.AddCell(new Phrase(dataRow["ReinforceType"].ToString(), font2));
				table.AddCell(new Phrase(dataRow["Length"].ToString(), font2));

				pdfRowIndex++;
			}

			document.Add(table);


			document.Add(new Paragraph(new Phrase("Department: " + data.Department.ToString(), font2)));
			document.Add(new Paragraph(new Phrase("Deliver Date: " + data.DeliverDate.ToString(), font2)));

			document.Close();
			document.CloseDocument();
			document.Dispose();
			writer.Close();
			writer.Dispose();
			fs.Close();
			fs.Dispose();

		}

		private string GetOrdersDirectory()
		{
			var currentDirectory = Directory.GetCurrentDirectory();

			string dirPath = Directory.GetParent(currentDirectory) + "\\Orders";

			if (!Directory.Exists(dirPath))
			{
				Directory.CreateDirectory(dirPath);
			}

			return dirPath;
		}
		private DataTable GetOrdersDetail(OrderViewModel data)
		{

			DataTable dtReinforce = new DataTable("OrderDetails");

			dtReinforce.Columns.AddRange(new DataColumn[4] { new DataColumn("Position"),
											new DataColumn("Count"),
											new DataColumn("ReinforceType"),
											new DataColumn("Length") });
			foreach (var reinforce in data.Reinforce)
			{
				dtReinforce.Rows.Add(reinforce.Position, reinforce.Count, reinforce.ReinforceType, reinforce.Length);
			}

			return dtReinforce;
		}
	}

}
