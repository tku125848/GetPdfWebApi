using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetPdfWebApi.Controllers
{
    public class PdfController : Controller
    {
        /// <summary>
        /// GET: Pdf
        /// Returns a PDF file from the ~/Content/pdf/ directory.
        /// </summary>
        /// <param name="id">The filename of the PDF file to retrieve.</param>
        /// <returns>A FileResult containing the PDF file, or HttpNotFound if the file does not exist.</returns>
        // 原路由 [Route("pdf/index/{id}")]
        // 可改路由 [Route("pdf/{id}.pdf")]
        public ActionResult Index(string id)
        {
            // Map the virtual path to a physical file path
            var filePath = Server.MapPath("~/Content/pdf/" + id + ".pdf");

            // Check if the file exists
            if (System.IO.File.Exists(filePath))
            {
                // Return the file as a PDF with the correct content type and filename
                return File(filePath, "application/pdf", id + ".pdf");
            }
            else
            {
                // Return a 404 Not Found response if the file does not exist
                return HttpNotFound();
            }
        }
        
        public ActionResult IndexMs(string id)
        {
            // Map the virtual path to a physical file path
            var filePath = Server.MapPath("~/Content/pdf/" + id + ".pdf");

            // Check if the file exists
            if (System.IO.File.Exists(filePath))
            {
                // Read the file into a MemoryStream
                var memoryStream = new MemoryStream();
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    fileStream.CopyTo(memoryStream);
                }
                memoryStream.Position = 0;

                // Return the file as a PDF with the correct content type and filename
                return new FileStreamResult(memoryStream, "application/pdf") { FileDownloadName = id + ".pdf" };
            }
            else
            {
                // Return a 404 Not Found response if the file does not exist
                return HttpNotFound();
            }
        }
        // [Route("pdf/{id}.pdf")]
        public ActionResult IndexBytes(string id)
        {
            // Map the virtual path to a physical file path
            var filePath = Server.MapPath("~/Content/pdf/" + id + ".pdf");

            // Check if the file exists
            if (System.IO.File.Exists(filePath))
            {
                // Read the file into a byte array
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

                // Return the file as a PDF with the correct content type and filename
                return File(fileBytes, "application/pdf", id + ".pdf");
            }
            else
            {
                // Return a 404 Not Found response if the file does not exist
                return HttpNotFound();
            }
        }
    }
}