//using PdfSharpCore;
//using PdfSharpCore.Pdf;
//using TheArtOfDev.HtmlRenderer.PdfSharp;
//using System.IO;
//using SWPApp.Models;

//namespace SWPApp
//{
//    public class PdfGenerator
//    {
//        public void GeneratePdf(Certificate certificate, string outputPath)
//        {
//            var certificateService = new CertificateService();
//            string htmlContent = certificateService.GenerateHtmlContent(certificate);

//            PdfDocument pdf = PdfGenerator.GeneratePdf(htmlContent, PageSize.A4);
//            using (var stream = new FileStream(outputPath, FileMode.Create))
//            {
//                pdf.Save(stream);
//            }
//        }
//    }
//}
