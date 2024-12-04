using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly string _imagePath;
        public ImagesController(IWebHostEnvironment env)
        {
            _imagePath = Path.Combine(env.WebRootPath, "images");
        }

        [HttpGet]
        public IActionResult GetImage(string imageName)
        {
            var filePath = Path.Combine(_imagePath, imageName);

            if(!System.IO.File.Exists(filePath))
            {
                return NotFound("Imagem Não Encontrada!");
            }

            var image = System.IO.File.OpenRead(filePath);

            return File(image, "image/jpeg");
        }
    }
}
