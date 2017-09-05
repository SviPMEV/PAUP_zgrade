using iTextSharp.text;
using iTextSharp.text.pdf;
using PAUP_zgrade.Models;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using static iTextSharp.text.Font;

namespace PAUP_zgrade.Reports
{
    public class ObavijestiReport
    {
        public byte[] Podaci { get; private set; }

        public ObavijestiReport(List<obavijesti> obavijesti)
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

            p = new Paragraph("OBAVIJEST", naslov);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingBefore = 30;
            p.SpacingAfter = 30;
            pdfDokument.Add(p);

            foreach (obavijesti f in obavijesti)
            {
                p = new Paragraph(f.temaObavijest.ToString(), naslov);
                p.SpacingAfter = 2;
                pdfDokument.Add(p);
                p = new Paragraph(f.datumObavijest.ToString("yyyy-MM-dd"));
                p.SpacingAfter = 5;                
                pdfDokument.Add(p);                
                p = new Paragraph(f.tekstObavijest.ToString(), tekst);
                pdfDokument.Add(p);
            }

            p = new Paragraph("Čakovec, " + System.DateTime.Now.ToString("dd.MM.yyyy"), header);
            p.Alignment = Element.ALIGN_RIGHT;
            p.SpacingBefore = 30;
            pdfDokument.Add(p);

            pdfDokument.Close();
            Podaci = memStream.ToArray();
        }
    }
}