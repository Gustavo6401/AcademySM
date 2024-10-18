using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Index(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Arquivo de Imagem Inválido.");
            }

            string timeStamp = $"{DateTime.Now.ToString("u").Replace(':', '-')}";
            string fileName = $"{file.FileName.Replace(' ', '_')}";

            string fileFullName = $"{timeStamp}-{fileName}";

            // Adds to the name of the file DateTime.Now
            var path = Path.Combine(Environment.CurrentDirectory, "wwwroot\\images", fileFullName);

            string? directory = Path.GetDirectoryName(path);

            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory!);
            }

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(fileFullName);
        }
    }
}
