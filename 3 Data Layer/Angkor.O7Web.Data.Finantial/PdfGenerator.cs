using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Angkor.O7Web.Common.Finantial.Entity;
using Angkor.O7Web.Data.Finantial.DataMapper;



namespace Angkor.O7Web.Data.Finantial
{


    class PdfGenerator
    {
        public class RoundRectangle : IPdfPCellEvent
        {
            public void CellLayout(
              PdfPCell cell, Rectangle rect, PdfContentByte[] canvas
            )
            {
                PdfContentByte cb = canvas[PdfPTable.LINECANVAS];
                cb.RoundRectangle(
                  rect.Left,
                  rect.Bottom,
                  rect.Width,
                  rect.Height,
                  4 // change to adjust how "round" corner is displayed
                );
                cb.SetLineWidth(1f);
                cb.SetCMYKColorStrokeF(0f, 0f, 0f, 1f);
                cb.Stroke();
            }
        }
        public class RoundRectangleForm : IPdfPCellEvent
        {
            public void CellLayout(
              PdfPCell cell, Rectangle rect, PdfContentByte[] canvas
            )
            {
                PdfContentByte cb = canvas[PdfPTable.LINECANVAS];
                cb.RoundRectangle(
                  rect.Left,
                  rect.Bottom,
                  rect.Width,
                  rect.Height,
                  4 // change to adjust how "round" corner is displayed
                );
                cb.SetLineWidth(1f);
                cb.SetCMYKColorStrokeF(0f, 0f, 0f, 1f);
                cb.Stroke();
            }
        }
        class RoundedBorder : IPdfPCellEvent
        {
            public void CellLayout(PdfPCell cell, Rectangle rect, PdfContentByte[] canvas)
            {
                PdfContentByte cb = canvas[PdfPTable.BACKGROUNDCANVAS];
                cb.RoundRectangle(
                  rect.Left + 1.5f,
                  rect.Bottom + 1.5f,
                  rect.Width - 3,
                  rect.Height - 3, 4
                );
                cb.Stroke();
            }
        }
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        public static Stream DownloadData(string url)
        {
            WebRequest req = WebRequest.Create(url);
            WebResponse response = req.GetResponse();
            Stream stream = response.GetResponseStream();
            return stream;
        }

        public static Dictionary<string, string> convertToDictonary(DetailInvoicePDF concept)
        {
            return new Dictionary<string, string>()
            {
                {"desc",concept.descripcion },
                {"price", concept.valor_unitario},
                {"qua",concept.cantidad },
                {"tax", concept.impuesto },
                {"amount",concept.importe }
            };
        }

        public static Stream generar(HeadInvoicePDF head, List<DetailInvoicePDF> details, string pathFile)
        {
            String PDFTitle = head.company;
            String PDFClientName = head.clientName;
            String PDFAddress = head.clientAddress;
            String PDFClientDocument = head.clientId;
            string PDFClientPhone = head.clientPhone;
            string PDFClientEmail = head.clientEmail;

            List<Dictionary<string, string>> prods = new List<Dictionary<string, string>>();
            foreach (DetailInvoicePDF detail in details)
            {
                prods.Add(convertToDictonary(detail));
            }


            //double taxAmount = 0.18;
            string subTotal = head.subtotal;
            string taxOfAmount = head.taxes;
            string total = head.total;
            string companyDoc = head.companyRuc;
            string documentType = head.document;
            string serieNumber = head.serie;
            string docNumber = head.nroext;
            string perc = head.perception;
            string dateDoc = head.documentDate;
            string url = head.url;
            string path = "D:/ResumenFactura_" + head.document + head.serie + "-" + head.nroext + ".pdf";
            MemoryStream ms = new MemoryStream();
            Rectangle rec2 = new Rectangle(PageSize.A4);
            Document doc = new Document(rec2);
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            writer.CloseStream = false;
            iTextSharp.text.Image myImage = iTextSharp.text.Image.GetInstance(url);
            doc.Open();
            var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
            var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            var boldTableFont = FontFactory.GetFont("Arial", 8, Font.BOLD);
            var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
            var bodyFont = FontFactory.GetFont("Arial", 8, Font.NORMAL);
            var bodyHeaderFont = FontFactory.GetFont("Arial", 6, Font.NORMAL);

            //doc.Add(new Paragraph(PDFTitle, titleFont));
            PdfPTable headerTable = new PdfPTable(2);
            headerTable.DefaultCell.Border = PdfPCell.NO_BORDER;
            headerTable.DefaultCell.CellEvent = new RoundRectangleForm();
            headerTable.TotalWidth = 520f;
            headerTable.LockedWidth = true;
            headerTable.SetWidths(new float[] { 2f, 1f });
            //Left Header Table
            PdfPTable nestedHeaderLeftTable = new PdfPTable(2);
            nestedHeaderLeftTable.DefaultCell.Border = PdfPCell.NO_BORDER;
            nestedHeaderLeftTable.SetWidths(new float[] { 1f, 3f });
            nestedHeaderLeftTable.AddCell(myImage);
            PdfPTable headerSubTitle = new PdfPTable(1);
            headerSubTitle.DefaultCell.Border = PdfPCell.NO_BORDER;
            PdfPCell headerTitle = new PdfPCell()
            {
                Border = PdfPCell.NO_BORDER,
                PaddingBottom = 4,
                Phrase = new Phrase(PDFTitle, titleFont)
            };
            headerSubTitle.AddCell(headerTitle);
            headerSubTitle.AddCell(new Phrase(head.headerLeftLine1, bodyHeaderFont));
            headerSubTitle.AddCell(new Phrase(head.headerLeftLine2, bodyHeaderFont));
            headerSubTitle.AddCell(new Phrase(head.headerLeftLine3, bodyHeaderFont));
            headerSubTitle.AddCell(new Phrase(head.headerLeftLine4, bodyHeaderFont));
            headerSubTitle.AddCell(new Phrase(head.headerLeftLine5, bodyHeaderFont));
            PdfPCell nestedCell = new PdfPCell(headerSubTitle);
            nestedCell.Padding = 0f;
            nestedCell.Border = PdfPCell.NO_BORDER;
            nestedHeaderLeftTable.AddCell(nestedCell);
            PdfPCell nesthou = new PdfPCell(nestedHeaderLeftTable);
            nesthou.Border = PdfPCell.NO_BORDER;
            nesthou.HorizontalAlignment = 1;
            headerTable.AddCell(nesthou);

            //Right Header Table
            PdfPTable nestedHeaderTable = new PdfPTable(1);
            nestedHeaderTable.DefaultCell.Border = PdfPCell.NO_BORDER;
            PdfPCell headerRUC = new PdfPCell()
            {
                Border = PdfPCell.NO_BORDER,
                PaddingLeft = 20f,
                Phrase = new Phrase("R.U.C. " + companyDoc, subTitleFont)
            };
            float scaleFontSize = 9.7f;
            PdfPCell headerDocType = new PdfPCell()
            {
                Border = PdfPCell.NO_BORDER,
                PaddingLeft = (Math.Abs(170 - documentType.Length * scaleFontSize)) / 2,
                Phrase = new Phrase(documentType, subTitleFont)
            };
            PdfPCell headerSerie = new PdfPCell()
            {
                Border = PdfPCell.NO_BORDER,
                PaddingLeft = 25f,
                Phrase = new Phrase(serieNumber + " - N° " + docNumber, subTitleFont)
            };
            nestedHeaderTable.AddCell(headerRUC);
            nestedHeaderTable.AddCell(headerDocType);
            nestedHeaderTable.AddCell(headerSerie);
            PdfPCell nesthousing = new PdfPCell(nestedHeaderTable);
            nesthousing.PaddingTop = 15f;
            nesthousing.PaddingBottom = 15f;
            nesthousing.HorizontalAlignment = 1;
            nesthousing.Border = PdfPCell.NO_BORDER;
            nesthousing.CellEvent = new RoundRectangleForm();
            headerTable.AddCell(nesthousing);
            doc.Add(headerTable);
            var orderInfoTable = new PdfPTable(4);
            orderInfoTable.HorizontalAlignment = 0;
            orderInfoTable.SpacingBefore = 10;
            orderInfoTable.DefaultCell.Border = 0;
            orderInfoTable.SetWidths(new int[] { 2, 5, 2, 7 });
            orderInfoTable.SpacingBefore = 20;


            orderInfoTable.AddCell(new Phrase("NOMBRE:", boldTableFont));
            orderInfoTable.AddCell(new Phrase(PDFClientName, bodyFont));
            orderInfoTable.AddCell(new Phrase("DIRECCIÓN:", boldTableFont));
            orderInfoTable.AddCell(new Phrase(PDFAddress, bodyFont));
            orderInfoTable.AddCell(new Phrase("RUC:", boldTableFont));
            orderInfoTable.AddCell(new Phrase(PDFClientDocument, bodyFont));
            orderInfoTable.AddCell(new Phrase("TELÉFONO:", boldTableFont));
            orderInfoTable.AddCell(new Phrase(PDFClientPhone, bodyFont));
            orderInfoTable.AddCell(new Phrase("FECHA:", boldTableFont));
            orderInfoTable.AddCell(new Phrase(dateDoc, bodyFont));
            orderInfoTable.AddCell(" ");
            orderInfoTable.AddCell(" ");

            doc.Add(orderInfoTable);
            //Preparing the table header
            PdfPTable table = new PdfPTable(1);
            table.DefaultCell.Border = PdfPCell.NO_BORDER;
            table.DefaultCell.CellEvent = new RoundRectangleForm();
            //actual width of table in points
            table.TotalWidth = 500f;
            //fix the absolute width of the table
            table.LockedWidth = true;
            table.HorizontalAlignment = 0;
            table.SpacingAfter = 15f;
            PdfPTable nestedTable = new PdfPTable(5);
            nestedTable.DefaultCell.Border = PdfPCell.NO_BORDER;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widths = new float[] { 3f, 1f, 1f, 1f, 1f };
            nestedTable.SetWidths(widths);
            nestedTable.HorizontalAlignment = 0;
            var descPhrase = new Phrase();
            descPhrase.Add(new Chunk("DESCRIPCIÓN", boldTableFont));
            var quanPhrase = new Phrase();
            quanPhrase.Add(new Chunk("CANTIDAD", boldTableFont));
            var pricePhrase = new Phrase();
            pricePhrase.Add(new Chunk("VAL UNIT", boldTableFont));
            var taxPhrase = new Phrase();
            taxPhrase.Add(new Chunk("IMPUESTO", boldTableFont));
            var amountPhrase = new Phrase();
            amountPhrase.Add(new Chunk("IMPORTE", boldTableFont));
            //leave a gap before and after the table
            PdfPCell descCell = new PdfPCell()
            {
                Border = PdfPCell.BOTTOM_BORDER,
                Padding = 4,
                Phrase = new Phrase(descPhrase)
            };
            PdfPCell impCell = new PdfPCell()
            {
                Border = PdfPCell.BOTTOM_BORDER,
                Padding = 4,
                Phrase = new Phrase(amountPhrase)
            };
            PdfPCell quanCell = new PdfPCell()
            {
                Border = PdfPCell.BOTTOM_BORDER,
                Padding = 4,
                Phrase = new Phrase(quanPhrase)
            };
            PdfPCell priceCell = new PdfPCell()
            {
                Border = PdfPCell.BOTTOM_BORDER,
                Padding = 4,
                Phrase = new Phrase(pricePhrase)
            };
            PdfPCell headerTaxCell = new PdfPCell()
            {
                Border = PdfPCell.BOTTOM_BORDER,
                Padding = 4,
                Phrase = new Phrase(taxPhrase)
            };
            nestedTable.AddCell(descCell);
            nestedTable.AddCell(quanCell);
            nestedTable.AddCell(priceCell);
            nestedTable.AddCell(headerTaxCell);
            nestedTable.AddCell(impCell);
            //Adding products
            for (int i = 0; i < 25; i++)
            {
                Phrase descP, priceP, quanP, taxP, amountP;
                if (i < prods.Count)
                {
                    descP = new Phrase(prods[i]["desc"], bodyFont);
                    priceP = new Phrase(prods[i]["price"], bodyFont);
                    quanP = new Phrase(prods[i]["qua"], bodyFont);
                    taxP = new Phrase(prods[i]["tax"], bodyFont);
                    amountP = new Phrase(prods[i]["amount"], bodyFont);
                }
                else
                {
                    descP = new Phrase(" ");
                    priceP = new Phrase(" ");
                    quanP = new Phrase(" ");
                    taxP = new Phrase(" ");
                    amountP = new Phrase(" ");
                }
                PdfPCell descPro = new PdfPCell()
                {
                    Border = PdfPCell.NO_BORDER,
                    Padding = 4,
                    Phrase = descP
                };
                PdfPCell pricePro = new PdfPCell()
                {
                    Border = PdfPCell.NO_BORDER,
                    Padding = 4,
                    Phrase = priceP
                };
                PdfPCell quanPro = new PdfPCell()
                {
                    Border = PdfPCell.NO_BORDER,
                    PaddingTop = 4,
                    PaddingBottom = 4,
                    PaddingLeft = 20f,
                    Phrase = quanP
                };
                PdfPCell taxPro = new PdfPCell()
                {
                    Border = PdfPCell.NO_BORDER,
                    PaddingTop = 4,
                    PaddingBottom = 4,
                    PaddingLeft = 17f,
                    Phrase = taxP
                };
                PdfPCell amountPro = new PdfPCell()
                {
                    Border = PdfPCell.NO_BORDER,
                    Padding = 4,
                    Phrase = amountP
                };

                nestedTable.AddCell(descPro);
                nestedTable.AddCell(quanPro);
                nestedTable.AddCell(pricePro);
                nestedTable.AddCell(taxPro);
                nestedTable.AddCell(amountPro);
            }

            PdfPCell subTotalCell = new PdfPCell()
            {
                Border = PdfPCell.NO_BORDER,
                Padding = 4,
                Phrase = new Phrase("Sub Total", boldTableFont)
            };
            PdfPCell subTotalValueCell = new PdfPCell()
            {
                Border = PdfPCell.NO_BORDER,
                Padding = 4,
                Phrase = new Phrase(subTotal, bodyFont)
            };
            PdfPCell tributosCell = new PdfPCell()
            {
                Border = PdfPCell.NO_BORDER,
                Padding = 4,
                Phrase = new Phrase("Impuestos:", boldTableFont)
            };


            PdfPCell taxCell = new PdfPCell()
            {
                Border = PdfPCell.NO_BORDER,
                Padding = 4,
                Phrase = new Phrase(taxOfAmount, bodyFont)
            };
            PdfPCell percCell = new PdfPCell()
            {
                Border = PdfPCell.NO_BORDER,
                Padding = 4,
                Phrase = new Phrase("Percepción", boldTableFont)
            };
            PdfPCell percValueCell = new PdfPCell()
            {
                Border = PdfPCell.NO_BORDER,
                Padding = 4,
                Phrase = new Phrase(perc, bodyFont)
            };
            nestedTable.AddCell(" ");
            nestedTable.AddCell(" ");
            nestedTable.AddCell(" ");
            nestedTable.AddCell(subTotalCell);
            nestedTable.AddCell(subTotalValueCell);
            nestedTable.AddCell(" ");
            nestedTable.AddCell(" ");
            nestedTable.AddCell(" ");
            nestedTable.AddCell(tributosCell);
            nestedTable.AddCell(taxCell);
            nestedTable.AddCell(" ");
            nestedTable.AddCell(" ");
            nestedTable.AddCell(" ");
            nestedTable.AddCell(percCell);
            nestedTable.AddCell(percValueCell);
            table.AddCell(nestedTable);
            doc.Add(table);

            //total = subTotal + taxOfAmount;
            PdfPTable totalTable = new PdfPTable(1);
            totalTable.DefaultCell.Border = PdfPCell.NO_BORDER;
            //actual width of table in points
            totalTable.TotalWidth = 500f;
            //fix the absolute width of the table
            totalTable.LockedWidth = true;
            totalTable.HorizontalAlignment = 0;
            PdfPTable nestedTotalTable = new PdfPTable(4);
            nestedTotalTable.DefaultCell.Border = PdfPCell.NO_BORDER;
            //relative col widths in proportions - 1/3 and 2/3
            float[] totalWidths = new float[] { 4f, 1f, 1f, 1f };
            nestedTotalTable.SetWidths(totalWidths);
            nestedTotalTable.HorizontalAlignment = 0;
            PdfPCell sonCell = new PdfPCell()
            {
                Border = PdfPCell.NO_BORDER,
                CellEvent = new RoundRectangleForm(),
                Padding = 4,
                Phrase = new Phrase("SON: " + head.totalDescription, boldTableFont)
            };
            PdfPCell totalCell = new PdfPCell()
            {
                Border = PdfPCell.NO_BORDER,
                Padding = 4,
                Phrase = new Phrase("TOTAL:", boldTableFont)
            };
            PdfPCell totalAmountCell = new PdfPCell()
            {
                Border = PdfPCell.NO_BORDER,
                CellEvent = new RoundRectangleForm(),
                Padding = 4,
                Phrase = new Phrase(total, bodyFont)
            };
            nestedTotalTable.AddCell(sonCell);
            nestedTotalTable.AddCell(" ");
            nestedTotalTable.AddCell(totalCell);
            nestedTotalTable.AddCell(totalAmountCell);
            totalTable.AddCell(nestedTotalTable);
            doc.Add(totalTable);
            doc.Add(new Paragraph(head.Observacion, bodyFont));
            doc.Close();
            ms.Flush(); //Always catches me out
            ms.Position = 0; //Not sure if this is required

            return ms;

            //////////////////////////////////////////////////////////////////////////////////////////////////////////


        }
    }
}
