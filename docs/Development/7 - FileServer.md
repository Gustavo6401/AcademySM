# Quarto - Projeto - File Server

O objetivo dessa API é receber e enviar os arquivos no servidor de produção, como sabem, o Vite é uma tecnologia que depende especialmente das URLs dos arquivos para renderizá-los em alguma biblioteca como o React JS. Por conta disso, possibilitamos a renderização de imagens e o download de imagens.

Em teoria, as imagens que recebemos deveriam ser compactadas, mas não nos atentamos direito a isso.

Futuramente, pensamos em utilizar o Amazon S3 para salvarmos essas imagens e compartilhá-las por meio do CloudFront.

## Qual a tecnologia do Projeto?

Esse projeto foi desenvolvido também utilizando o Microsoft .NET e o C#, assim como os outros projetos, essa é a minha linguagem favorita e que eu tenho o maior domínio, especialmente por isso, decidi utilizá-la no projeto. 

## Processo de Instalação

O processo de instalação desse projeto é mais simples que o processo de instalação da API de Cadastro de Usuário e da API de Grupos, pois esse projeto não faz nenhuma interação com bancos de dados e é completamente independente e desacoplado dos outros dois. E a partir daqui, provavelmente você já sabe e já instalou a Visual Studio 2022. O processo de instalação é o seguinte:

#### 1. Abra o arquivo .sln

![Abrir o Arquivo .sln](<../imgs/4-3 - Abrindo o Arquivo na Visual Studio.png>)

![Abrir o Arquivo .sln Pt. 2](<../imgs/4-4 - Abrindo a Visual Studio Pt. 2.png>)

A partir daqui, como citado anteriormente, você não terá que se preocupar com bancos de dados ou outras tecnologias.

#### 2. Clique com o Botão Esquerdo em Cima da Solução

![Botão Esquerdo Solução](<../imgs/4.5 - Clicando com o Botão Direito Por Cima da Solução.png>)

#### 3. Clique em "Configurar Projetos de Inicialização"

![Clicando em Configurar Projetos](<../imgs/4.6 - Configurar Projetos de Inicialização.png>)

#### 4. Selecione os Projetos **academysm-client**, **CadastroUsuario**, **Groups** e **FileServer** para inicializar

![Selecionar Projetos](<../imgs/4.6 - Configurar Projetos de Inicialização.png>)

#### 5. Clique em OK

![Clique em OK](<../imgs/4.7 - Selecionar Projetos para Inicializar.png>)

#### 6. Inicie as Aplicações com o Botão Iniciar

![Clique em Iniciar](<../imgs/4.9 - Clique em Iniciar.png>)

## Explicação do Código

### 1 - Upload de Arquivo

``` csharp
[HttpPost]
public async Task<ActionResult<string>> Index(IFormFile file)
{
    if (file == null || file.Length == 0)
    {
        return BadRequest("Arquivo de Imagem Inválido.");
    }

    // Faço mudanças para tornar tudo mais legível.
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
```

Se você for notar, você vai perceber que essa rota serve para fazer o Upload de qualquer tipo de arquivo, desde arquivos de blocos de notas até mesmo imagens e vídeos, além de que o arquivo é salvo dentro do próprio servidor. Penso inclusive em criar filtros de tamanho e de tipo de arquivo, afim de evitar possíveis problemas relacionados à sobrecarga do servidor. De modo geral, utilizamos as APIs nativas do ASP.Net Core e do C# para a persistência de arquivos. 

### 2 - Exibição de arquivos

``` csharp
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

    // Linha responsável pela leitura.
    var image = System.IO.File.OpenRead(filePath);

    return File(image, "image/jpeg");
}
```

Já essa rota de API apenas retorna arquivos de imagem/jpeg, a minha ideia é bem simples: apenas retornar imagens, penso em futuramente, retornar imagens em tipo webp.

## Agradecimento

Muito obrigado pela atenção! Começaremos a escrever agora o nosso Whitepaper da Academy SM Explicando melhor a documentação como um todo, muito obrigado pela atenção e bom desenvolvimento! 

*O ser humano é naturalmente polímata!*