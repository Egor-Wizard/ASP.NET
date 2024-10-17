using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace YourAppNamespace.Controllers
{
    public class FileController : Controller
    {
        // Метод для відображення форми
        [HttpGet]
        [Route("File/DownloadFile")]
        public IActionResult DownloadFile()
        {
            return View();
        }

        // Метод для обробки форми та створення текстового файлу
        [HttpPost]
        [Route("File/DownloadFile")]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            // Створення контенту для файлу
            string content = $"Name: {firstName}\nSurname: {lastName}";

            // Генерація файлу
            var fileBytes = Encoding.UTF8.GetBytes(content);
            var result = File(fileBytes, "text/plain", $"{fileName}.txt");

            return result;
        }
    }
}
