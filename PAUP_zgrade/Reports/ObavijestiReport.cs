using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PAUP_zgrade.Models;
using System.IO;
using System.Web.Hosting;


namespace PAUP_zgrade.Reports
{
    public class ObavijestiReport
    {
        public byte[] Podaci { get; private set; }


        public ObavijestiReport(obavijesti obavijest)
        {
            Document pdfDokumentObavijesti = new Document(PageSize.A4, 50, 50, 20, 50);

            MemoryStream memStream = new MemoryStream();
            PdfWriter.GetInstance(pdfDokumentObavijesti, memStream).CloseStream = false;

            pdfDokumentObavijesti.Open();

            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false /*embedded*/);

            Font header = new Font(font, 12, Font.NORMAL, BaseColor.DARK_GRAY);
            Font naslov = new Font(font, 14, Font.BOLDITALIC, BaseColor.BLACK);
            Font tekst = new Font(font, 10, Font.NORMAL, BaseColor.BLACK);

            Paragraph p = new Paragraph("Obavijest", header);
            pdfDokumentObavijesti.Add(p);

            p = new Paragraph(obavijest.temaObavijest, header);
            pdfDokumentObavijesti.Add(p);
            p = new Paragraph(obavijest.datumObavijest.ToString(), naslov);
            pdfDokumentObavijesti.Add(p);
            p = new Paragraph(obavijest.tekstObavijest, tekst);
            pdfDokumentObavijesti.Add(p);

            pdfDokumentObavijesti.Close();
            Podaci = memStream.ToArray();
        }
    }
}