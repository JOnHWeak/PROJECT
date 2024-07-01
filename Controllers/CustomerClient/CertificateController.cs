using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using SWPApp.Models;

namespace SWPApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        [HttpGet("pdf")]
        public IActionResult GetCertificatePdf(int certificateId)
        {
            // Fetch the certificate from the database (mock data for demonstration)
            var certificate = new Certificate
            {
                CertificateId = certificateId,
                ResultId = 123,
                IssueDate = DateTime.Now,
                Result = new Result { /* populate the Result object as needed */ }
            };

            // Create a memory stream to hold the PDF data
            using (var memoryStream = new MemoryStream())
            {
                // Initialize PDF writer and document
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                // Add content to the PDF
                document.Add(new Paragraph("Certificate Details"));
                document.Add(new Paragraph($"Certificate ID: {certificate.CertificateId}"));
                document.Add(new Paragraph($"Result ID: {certificate.ResultId}"));
                document.Add(new Paragraph($"Issue Date: {certificate.IssueDate.ToShortDateString()}"));
                // Add more fields as needed from the Result object

                document.Close();
                writer.Close();

                // Return the PDF as a file result
                var fileBytes = memoryStream.ToArray();
                return File(fileBytes, "application/pdf", "Certificate.pdf");
            }
        }
    }
}