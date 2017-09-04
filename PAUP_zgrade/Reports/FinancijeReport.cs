using iTextSharp.text;
using iTextSharp.text.pdf;
using PAUP_zgrade.Models;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace PAUP_zgrade.Reports
{
    public class FinancijeReport
    {
        public byte[] Podaci { get; private set; }

        public FinancijeReport(List<financije> financije)
        {
            Document pdfDokument = new Document(PageSize.A4, 50, 50, 20, 50);

            MemoryStream memStream = new MemoryStream();
            PdfWriter.GetInstance(pdfDokument, memStream).CloseStream = false;

            pdfDokument.Open();

            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false);
            Font header = new Font(font, 12, Font.NORMAL, BaseColor.DARK_GRAY);
            Font naslov = new Font(font, 14, Font.BOLDITALIC, BaseColor.BLACK);
            Font tekst = new Font(font, 10, Font.NORMAL, BaseColor.BLACK);

            var logo = iTextSharp.text.Image.GetInstance(HostingEnvironment.MapPath("~/Content/img/zgradaimg_1.jpg"));
            logo.Alignment = Element.ALIGN_LEFT;
            logo.ScaleAbsoluteWidth(100);
            logo.ScaleAbsoluteHeight(100);
            pdfDokument.Add(logo);

            Paragraph p = new Paragraph("Zgradar.NET", header);
            pdfDokument.Add(p);

            p = new Paragraph("POPIS FINANCIJA", naslov);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingBefore = 30;
            p.SpacingAfter = 30;
            pdfDokument.Add(p);

            PdfPTable t = new PdfPTable(5);
            t.WidthPercentage = 100;
            t.SetWidths(new float[] { 2, 2, 1, 3, 2 });

            t.AddCell(VratiCeliju("Datum", tekst, BaseColor.LIGHT_GRAY, true));
            t.AddCell(VratiCeliju("Vrijednost transakcije", tekst, BaseColor.LIGHT_GRAY, true));
            t.AddCell(VratiCeliju("Zgrada", tekst, BaseColor.LIGHT_GRAY, true));
            t.AddCell(VratiCeliju("Opis", tekst, BaseColor.LIGHT_GRAY, true));
            t.AddCell(VratiCeliju("Posao obavljen", tekst, BaseColor.LIGHT_GRAY, true));

            foreach (financije f in financije)
            {
                t.AddCell(VratiCeliju(f.datumFinancije.ToString("yyyy-MM-dd"), tekst, BaseColor.WHITE, false));
                t.AddCell(VratiCeliju(f.vrijednostFinancije.ToString(), tekst, BaseColor.WHITE, false));
                t.AddCell(VratiCeliju(f.zgradaFinancija.ToString(), tekst, BaseColor.WHITE, false));
                t.AddCell(VratiCeliju(f.opisFinancije, tekst, BaseColor.WHITE, false));
                t.AddCell(VratiCeliju((f.obavljenPosao == 1) ? "DA" : "NE", tekst, BaseColor.WHITE, false));
            }

            pdfDokument.Add(t);

            p = new Paragraph("Čakovec, " + System.DateTime.Now.ToString("dd.MM.yyyy"), header);
            p.Alignment = Element.ALIGN_RIGHT;
            p.SpacingBefore = 30;
            pdfDokument.Add(p);

            pdfDokument.Close();
            Podaci = memStream.ToArray();
        }

        private PdfPCell VratiCeliju(string labela, Font font, BaseColor boja, bool wrap)
        {
            PdfPCell c1 = new PdfPCell(new Phrase(labela, font));
            c1.BackgroundColor = boja;
            c1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            c1.Padding = 5;
            c1.NoWrap = wrap;
            return c1;
        }
    }
}