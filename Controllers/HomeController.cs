using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace YourAppNamespace.Controllers
{
    public class FileController : Controller
    {
      
        [HttpGet]
        [Route("File/DownloadFile")]
        public IActionResult DownloadFile()
        {
            return View();
        }

       
        [HttpPost]
        [Route("File/DownloadFile")]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
        
            string content = $"Name: {firstName}\nSurname: {lastName}";

       
            var fileBytes = Encoding.UTF8.GetBytes(content);
            var result = File(fileBytes, "text/plain", $"{fileName}.txt");

            return result;
        }
    }
}
