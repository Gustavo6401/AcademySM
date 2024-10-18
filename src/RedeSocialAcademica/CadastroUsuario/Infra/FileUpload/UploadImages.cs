namespace CadastroUsuario.Infra.FileUpload
{
    public class UploadImages
    {
        /// <summary> 
        /// This method will Upload your image to your local server. This method is made to be used only in 
        /// the development server.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<string> UploadFiles(IFormFile file)
        {
            if(file == null || file.Length == 0)
            {
                throw new ArgumentException("Arquivo de Imagem Inválido.");
            }

            // Adds to the name of the file DateTime.Now
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", $"{file.Name}{DateTime.Now}");

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return "Arquivo Cadastrado Com Sucesso!";
        }
    }
}
