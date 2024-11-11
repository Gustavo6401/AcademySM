# Segundo Projeto - Cadastro de Usuário

Esse não é o segundo projeto utilizado em produção, mas é um projeto igualmente importantíssimo. O objetivo é ser um projeto que mantém e fornece o Cookie e os dados de autenticação. Além disso, o projeto conta com 4 classes Model importantes, sendo elas:

- ApplicationUser;
- EducationalBackground;
- UserLockout;
- ProfilePic.

Para Melhor entendimento, mostrarei o diagrama de classes.

![Diagrama de Classes](<../imgs/5.1 - Diagrama de Classes - CadastroUsuario.png>)

Essa é a estrutura principal do projeto.

## Como esse projeto foi pensado?

Esse projeto foi projetado justamente para separar as responsabilidades da aba Grupos e do cadastro de usuário em si. Por causa disso, decidi que o melhor era justamente escrever duas APIs. Fora que uma boa parte desse SaaS foi pensado no meu aprendizado na programação. E essa parte tem a função de cadastrar o usuário e tem todas as funções relacionadas com o cadastro, tais como autenticação, validação de dados e login. Futuramente, incluiremos novas features, tais como a possibilidade de você incluir links relacionados à sua conta e os dados de utilização do projeto (que por sinal, não sei se serão colocados aqui ou diretamente na API de Grupos.)

## Quais são as Principais Tecnologias?

- **.Net e C#** - Com certeza o .Net seria a principal tecnologia, afinal, de todas, é a que eu tenho mais afinidade. Em nenhum momento me passou pela cabeça utilizar conhecimentos "periféricos", como o Java e o Node JS. Eu queria me aprofundar e testar a capacidade de uma linguagem que já aprendo há alguns anos.
- **Entity Framework Core** - Utilizei vários ORMs no Java, nenhum com a profundidade que eu já utilizei o Entity Framework Core, logo, eu soube que eu não podia deixá-lo de fora do projeto.
- **Microsoft SQL Server** - Sendo direto, em produção eu utilizo o **SQL Server Express**, creio que desde 2020 eu utilizo o SQL Server para todas as minhas aplicações, aqui não poderia ser diferente após algumas dificuldades técnicas com o MySql.
- **MongoDB** - Uso o Mongo DB para dados secundários. Principalmente para isolamento de ambientes ou para tabelas que se ficassem num SQL Server, que com certeza ficariam soltas. A tabela de Salts é um grande exemplo de tabela que não poderia ficar isolada de forma alguma. Além disso, eu salvo os Tokens no banco de dados pensando numa arquitetura antiga. 

## Instalação e Configuração

Para Instalar corretamente esse projeto, como avisado antes, é necessário que você já tenha instalado componentes como a Visual Studio e a versão mais atual do .NET SDK. A Visual Studio pode ser baixada por [AQUI](https://visualstudio.microsoft.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false) e o .NET SDK pode ser baixado por [AQUI](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.403-windows-x64-installer)

Siga-me para o passo a passo para a instalação da Visual Studio Community:

### E agora, como Instalar a Visual Studio Community? 🤔

#### 1. Entre no Instalador do Visual Studio após concluir o Download da IDE:

![Abrindo o Instalador](<../imgs/5.2 - Abrindo o Instalador da Visual Studio.png>)

#### 2. Clique no Visual Studio Community em "Instalar"

#### 3. Em cargas de Trabalho, escolha ASP.NET e Desenvolvimento Web e Desenvolvimento em Node JS

![Cargas de Trabalho](<../imgs/5.3 - Cargas de Trabalho.png>)

#### 4. Aguarde o Processo de Instalação

### Mas e agora, de que forma eu posso Inicializar a Aplicação?

É mais ou menos o mesmo processo de abertura da aplicação [academysm-client](<4 - academysm-client.md>).

#### 1. Abra o arquivo .sln

![Abrir o Arquivo .sln](<../imgs/4-3 - Abrindo o Arquivo na Visual Studio.png>)

![Abrir o Arquivo .sln Pt. 2](<../imgs/4-4 - Abrindo a Visual Studio Pt. 2.png>)

Primeiro de tudo, vale lembrar que a instalação do banco de dados é essencial.

#### 2. Clique em Exibir >>> Outras Janelas >>> Console do Gerenciador de Pacotes

![Console do Gerenciador de Pacotes](<../imgs/5.4 - Console do Gerenciador de Pactoes.png>)

Você verá a Seguinte Janela:

![Janela do Gerenciador de Pacotes](<../imgs/5.5 - Janela.png>)

#### 3. Clique com o Botão Esquerdo em Cima da Solução

![Botão Esquerdo Solução](<../imgs/4.5 - Clicando com o Botão Direito Por Cima da Solução.png>)

#### 4. Clique em "Configurar Projetos de Inicialização"

![Clicando em Configurar Projetos](<../imgs/4.6 - Configurar Projetos de Inicialização.png>)

#### 5. Selecione os Projetos **academysm-client**, **CadastroUsuario**, **Groups** e **FileServer** para inicializar

![Selecionar Projetos](<../imgs/4.6 - Configurar Projetos de Inicialização.png>)

#### 6. Clique em OK

![Clique em OK](<../imgs/4.7 - Selecionar Projetos para Inicializar.png>)

#### 7. Selecione **CadastroUsuario** como o projeto padrão no console do gerenciador de pacotes.

![Cadastro Usuário](<../imgs/5.6 - CadastroUsuario.png>)

#### 8. Digite o comando `Update-Database` após ter instalado as dependências do SQL Server no console do gerenciador de pacotes.

![Update-Database](<../imgs/5.7 - Update Database.png>)

#### 9. Inicie as aplicações com o botão iniciar.

![Clique em Iniciar](<../imgs/4.9 - Clique em Iniciar.png>)

#### 10. Pronto! 

## Estrutura do Projeto

Após entrar em **RedeSocialAcademica** >> **Server** >> **CadastroUsuario** você verá a seguinte imagem:

![Cadastro de Usuário - Diretórios](<../imgs/5.8 - Cadastro de Usuário - Diretórios.png>)

A estrutura de pastas foi pensada nos princípios do Domain Driven Design, aqui, vamos falar sobre as pastas principais

### Domain

Domain ou camada de domínio, é o ponto principal da API de Cadastro de Usuário, aqui, ficam todas as Models e a maioria das regras de negócio. O objetivo é ser uma pasta sem alguma dependência externa, possuíndo assim, apenas código da própria aplicação. Essa pasta possui três subpastas principais: **Models**, **Interfaces** e **Services**

#### Interfaces

Interfaces é uma das pastas principais do projeto, o objetivo é utilizar o padrão da injeção de dependência e ditar regras de nomenclatura e retorno para todos os métodos criados dentro da Academy SM, especialmente os de validação de dados e de interação com o banco de dados. Possuíndo assim, algumas pastas, tais como **ApplicationServices**, **Cookies**, **Controllers**, **Repositories** e **Services**;

#### Models

A pasta Models igualmente é importantíssima, o objetivo dessa pasta é criar todas as classes que servirão de instância para os objetos e que fazem uso apenas de tipos primitivos ou de recursos nativos da linguagem C#. Ficou confusa a explicação? Para simplificar, vamos ao seguinte exemplo: Digamos que você tenha um banco de dados de marcas de carro, onde você tenha como principais propriedades, o Id da Marca, o Nome da Marca e o País da Marca. Criemos a classe Marca da seguinte forma: 

``` csharp
public class Marca 
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Pais { get; set; }
}
```

Pensando nisso, foi justamente por isso que criei a pasta Models. Cada uma dessas classes Models são reutilizáveis em múltiplos contextos de código, tais como na hora de fazer a criação das rotas HTTP nas Controllers, ou até mesmo na hora de fazer a interoperabilidade com o banco de dados por meio de referências externas com o Entity Framework. 

Se uma determinada classe Apenas contém dependências nativas à linguagem C#, é necessário que ao fazer seu pull request, que você crie essa classe diretamente na pasta Models. Caso contrário, pode criar diretamente na camada de infraestrutura, a exemplo do que acontece com a classe `SaltsDataDocument`, que utiliza dependências do pacote MongoDBClient, como o `ObjectId`:

``` csharp
public class SaltsDataDocument
{
    public ObjectId Id { get; set; }
    public string? Salt { get; set; }
    public string? Email { get; set; }
}
```

A pasta Models ainda é dividida em outras 4 subpastas

1. Models (Pasta principal) - Na pasta principal, coloquei os Modelos responsáveis por interagir com a camada Controllers e com a camada de Dados.
2. API - Modelos responsáveis pela busca de dados dentro de APIs externas.
3. ControllerModels - Talvez a mais interessante: Muitas vezes, eu não escrevo o Front-End para o Back-End e sim o contrário. Como assim? Muitas vezes, precisamos de dados do usuário como o E-mail, a senha justamente para fazer o cadastro dele, mas evidentemente na tela de portfólio que não exibiremos o hash da senha né? 😅. Pensando justamente nisso, criei a pasta ControllerModels, com o objetivo de fornecer para o meu front-end as informações que ele realmente precisa.
4. Enums - Enums foi uma pasta que admito ter deixado de lado por conta da complexidade de se trabalhar com eles. Mas o objetivo foi justamente guardar dados relevantes como `EducationalBackgrounds` ou formações Educacionais, que contém dados que podem ser muito bem utilizados por meio de um DropDownList, ou Status do Curso. O status do curso só tem 3 dados possíveis: Concluído, Trancado ou Cursando, correto? Pensando justamente nisso eu pensei em criar Enums. Creio que o fato dos Enums estarem deixados de lados é algo sujeito a mudanças. Digo isso porque recentemente, me aperfeiçoei no design pattern strategy, o que acredite: me faria converter esses Enums para strings com muito mais facilidade, apesar do trabalho da conversão em si.
5. MongoDBCollections - Acredito que o próprio nome já fala por si só. Modelos do MongoDB escritos com recursos da linguagem C#. O que me permite fazer isso é justamente o fato de que eu escrevi uma forma de mapear as entidades diretamente na minha classe Program, o que me permite deixar o meu domíno limpo de dependências externas.

``` csharp
BsonClassMap.RegisterClassMap<SaltsData>(salts =>
{
    salts.AutoMap();
    salts.MapIdProperty(s => s.Id)
        .SetIdGenerator(ObjectIdGenerator.Instance);
});
```

#### Services

O objetivo dessa pasta, é conter as principais regras de negócio do sistema, tais como validações de senha e validação de dados simples, como os dados de usuário e de links. Caso a validação de um determinado dado não seja satisfeita, é jogado para o cliente lá na classe controller um erro 400 BadRequest e uma exceção é gerada (que deve ser tratada diretamente no Controller).

``` csharp
public void ValidateLink(string? link)
{
    // Code generated with ChatGPT.
    if (string.IsNullOrWhiteSpace(link) ||
        !Uri.TryCreate(link, UriKind.Absolute, out Uri? uriResult) ||
        (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
    {
        throw new ArgumentException("Link Inválido.");
    }
}
```

Esse código por exemplo, tem a responsabilidade de fazer a validação do link e verificar se esse link funciona corretamente. Esse código é usado especialmente quando o usuário for fazer o cadastro de um link.

### Infra

O objetivo da Infra é integrar a API com as suas dependências externas, tais como Bancos de Dados, APIs externas ou bibliotecas de terceiros. Sendo dividida especialmente, entre 10 subpastas, sendo elas:

1. API - Tem por objetivo a comunicação entre serviços de API externos, tais como a própria API de Grupos da Academy SM.
2. Authentication - Tem por responsabilidade guardar o código dos serviços de autenticação da Academy SM.
3. BCryptServices - Responsável pela comunicação com os serviços do BCrypt.
4. Context - Carrega a classe `UserDbContext` do EntityFrameworkCore, responsável por gerar o código da pasta Migrations, responsável por criar e gerenciar as bases de dados da Academy SM.
5. Cookies - Configuração e compartilhamento de Cookies da API de Cadastro de Usuário.
6. EnumConverters - Responsável por converter Enums.
7. FileUpload (Descontinuado) - Servia como Upload de imagem antes da API de Servidor de Imagens.
8. RabbitMQ - Comunicação com os serviços do RabbitMQ.
9. Repositories - Camada de comunicação com os bancos de dados do MongoDB e do SQL Server.
10. Tokens - Criação e administração de Tokens de acesso.

``` csharp
public override async Task CreateAsync(ApplicationUser entity)
{
    _context.ApplicationUser.Add(entity);

    await _context.SaveChangesAsync();
}
```

Utilizei como Exemplo, a classe `UserRepository`, da camada de Infraestrutura, na pasta Repositories.SqlServer.

![Infra](<../imgs/5.9 - Cadastro de Usuário - Infra.png>)

### Presentation

A camada de apresentação é responsável pela orquestração de serviços entre Domínio e Infraestrutura e pela comunicação direta com o cliente. Ela tem duas subpastas, sendo elas:

1. **ApplicationServices** - Responsável pela orquestração entre domínio e infraestrutura. Aqui eu mantive as regras de negócio que dependem diretamente da camada de infraestrutura, como validações de bloqueio de usuário que dependem de buscas ao banco de dados para funcionarem corretamente.
2. **Controllers** - Responsável pela comunicação HTTP entre o servidor e o cliente.

## Principais Funcionalidades

A API de Cadastro de Usuário é importante por uma série de motivos, dentre eles:

1. **Gerenciar as Bases de Dados de Autenticação e de Cadastro de Usuário** - Responsável pela administração e pelas mudanças nas bases de dados relacionadas ao cadastro de usuário, dentre elas o serviço de manutenção dos Tokens, das Salts e de dados mais sensíveis do usuário, como os dados de contato. Essa é a principal funcionalidade das pastas Infra e Migrations.
2. **Gerenciar os Cookies de Autenticação** - Essa API é responsável por criar e compartilhar com suas aplicações intermediárias os Cookies de autenticação. 
3. **Validação de Dados Sensíveis** - As senhas e o cadastro de usuário são devidamente validados e no caso do lançamento errôneo de um determinado dado, é lançado um erro `400 BadRequest`. Além disso, vale destacar a regra de senhas, que exige que as senhas tenham no mínimo 8 caracteres de comprimento e que o usuário cadastre letras maiúsculas, minúsculas, números e caracteres especiais.
4. **Realizar as Chamadas HTTP** - As chamadas HTTP relacionadas ao cadastro de usuário são feitas diretamente à essa API, mais especificamente na pasta Controllers.

## Explicação do Código:

Alguns trechos críticos do código podem ser explicados diretamente aqui na documentação.

### 1 - Presentation.ApplicationServices.UserApplicationServices.Login()

``` csharp
public async Task<LoginReturn> Login(Login login)
{
    // Recupera a Salt.
    SaltsData salts = await _saltsRepository.GetSaltByEmail(login.Email!);

    // Reconstrói a senha baseada na senha informada pelo usuário e a salt.
    login.Password = PasswordHashing.HashPassword(login.Password!, salts.Salt!);

    // Checks wether the user and password are correct.
    // Verifica se o E-Mail e se o hash da senha estão corretos.
    LoginInformations loginInformations = await _userRepository.Login(login.Email!, login.Password!);

    // Busca o usuário no banco de dados, utilizamos esse recurso se o usuário estiver bloqueado, além de usarmos o ID dele.
    ApplicationUser user = await _userRepository.GetByEmail(login.Email!);

    // Adiciona um erro à conta do usuário
    if (loginInformations == null)
    {
        // Se o usuário já tiver 10 erros na conta, ele estará bloqueado.
        if (user.PasswordErrors >= 10)
        {
            // Salva o bloqueio no banco de dados.
            UserLockout lockout = await _userLockoutRepository.GetLastUserLockoutByUserId(user!.Id);

            /* Verifica o tempo correto de bloqueio.
            * 1º Erro - 5 minutos de bloqueio
            * 2º Erro - 10 minutos de bloqueio
            * 3º Erro - 15 minutos de bloqueio
            * 4º Erro - 30 minutos de bloqueio.
            * 5º Erro - 60 minutos de bloqueio.
            */
            int blockTime = _userLockoutServices.TimeBlock(lockout);

            // en Creates an lockout when user.PasswordErros >= 10;
            // pt-br Bloqueia o usuário quando user.PasswordErrors >= 10;
            lockout = new UserLockout
            {
                LockoutDate = DateTime.Now + TimeSpan.FromMinutes(blockTime),
                QtdMinutes = blockTime,
                UserId = user!.Id
            };

            // Salva o Bloqueio no Banco de dados.
            await _userLockoutRepository.CreateAsync(lockout);

            // Gera uma exceção interrompendo o fluxo de código.
            throw new ArgumentException($"Usuário Bloqueado durante {blockTime} minutos");
        }

        // Caso o usuário tenha menos que 9 erros, apenas um erro é adicionado à conta dele.
        user.PasswordErrors++;
        // Salva as informações no banco de dados.
        await _userRepository.UpdateAsync(user);

        // Gera uma exceção interrompendo o fluxo de código.
        throw new ArgumentException("E-Mail ou Senha Incorretos!");
    }

    // FLUXO NORMAL

    // Busca todos os grupos onde ele está cadastrado, informação relevante na hora de fazer login.
    // Busca na API de Grupos.
    List<GroupsUsers> groupsUsers = await _groupsUserAPI.GetAllGroupsUsers(loginInformations.Id);

    // Gera o Token baseado nos dados do usuário e nos grupos que ele participa.
    string token = MainTokenService.GenerateToken(user, groupsUsers);

    // en Save the Main Token in an HTTPOnlyCookie.
    // en _cookieConfiguration.DeleteHttpOnlyCookie("MainToken");
    // pt-br Salva o Token principal num CookieHTTPOnly.
    await _cookieAuthServices.LoginAsync(user.Id, token, groupsUsers);

    // en Save the Main Token in MongoDB.
    // pt-br Cria uma classe com o Main Token
    TokenData data = new TokenData
    {
        DataCriacaoToken = DateTime.Now,
        Token = token,
        UsuarioId = Convert.ToString(loginInformations.Id)
    };

    // Salva o MainToken no MongoDB.
    await _tokenRepository.Create(data);

    // Os dados na classe LoginReturn são extremamente relevantes, o usuário utilizará todos no Front-End.
    LoginReturn loginReturn = new LoginReturn
    {
        Id = loginInformations!.Id,
        UserFullName = loginInformations.FullName,
        UserProfilePicPath = loginInformations!.ProfilePicPathName,
        ReturnMessage = "Usuário Logado com Sucesso!"
    };

    return loginReturn;
}
```

Essa funcionalidade tem diversos objetivos em questão: 

1. Buscar a Salt relacionada com o E-Mail do usuário - As salts são guardadas num banco de dados do MongoDB, servindo de tempero para as senhas do usuário.
2. Reconstruir o Hash Bcrypt. 
3. Verificar se o Bcrypt foi inserido no banco de dados.
4. Caso o usuário estiver errado, Verifica se esse já é o 10º erro.
5. Se for o 10º Erro, bloqueia ele.
6. Caso não seja o 10º erro, apenas adiciona um erro à conta.
7. Joga uma exceção caso o usuário tenha errado a senha, seja avisando que ele foi bloqueado ou que o usuário apenas errou a senha.
8. Gera o Token e os Cookies de Autenticação.
9. Retorna informações que serão enviadas para o localStorage no projeto [academysm-client](<4 - academysm-client.md>), como o Id, o Nome completo, o nome do arquivo da foto de perfil e uma mensagem avisando que o login foi efetuado.

Para o futuro, uma modificação importante é zerar o número de erros, o motivo? Bom, a minha meta com o sistema de bloqueio era evitar ataques de força bruta, porém, o que acontece é que se o usuário errar a senha 10 vezes **em dias diferentes**, ele será bloqueado mesmo assim. Para modificar isso, creio que o ideal seria guardar a data do último erro. Pode ser em uma collection do próprio MongoDB. Essa arquitetura foi pensada justamente em evitar invasões.

### 2 - Domain.Models.ControllerModels.LoginReturn

``` csharp
public class LoginReturn
{
    public Guid Id { get; set; }
    public string? UserFullName { get; set; }
    public string? UserProfilePicPath { get; set; }
    public string? ReturnMessage { get; set; }
}
```

Cada trecho de código foi minuciosamente pensado.

1. **Id** - O Id deve ser retornado especialmente porque o usuário precisará depois para acessar o próprio portfólio, além disso, o Id é mantido no localStorage com o objetivo de fazer determinadas verificações, como a exibição de certos componentes React no Front-End.
2. **UserFullName e UserProfilePicPath** - O nome completo do usuário foi pensado para ser utilizado especialmente quando as funcionalidades de rede social estiverem funcionando corretamente, na imagem abaixo, poderemos ver que a cada interação em determinadas redes sociais, tais como o Quora e o Facebook, você poderá ver o seu nome de usuário após uma interação, como o envio de um artigo. 
3. **ReturnMessage** - Mensagem de retorno após o login.

![Ciclo é Coisa de Maromba 😅](<../imgs/5.10 - Ciclo é Coisa de Maromba.png>)

Ciclo é coisa de maromba!

### 3 - Presentation.ApplicationServices.UserApplicationServices.CreateAsync()

``` csharp
public async Task<UserCreateReturn> CreateAsync(ApplicationUser user)
{
    // en Checks wether user's e-mail already exists.
    // pt-br Verifica se o E-Mail do usuário já existe.
    ApplicationUser nullData = await _userRepository.GetByEmail(user.EMail!);

    // Se o e-mail já existir na base da dados, jogo uma exceção.
    if(nullData != null)
    {
        throw new ArgumentException("E-Mail já Existente no Banco de Dados");
    }

    // Crio uma Salt com 15 de fator de trabalho. O recomendado nos tempos de hoje é entre 10 e 12, porém, o meu objetivo é que os hackers TENHAM MEDO DE TENTAR ATAQUES DE FORÇA BRUTA. Por isso, eu coloquei 15 de fator de trabalho.
    string salt = PasswordHashing.GenerateSalt(15);

    // en Validate user's data.
    // pt-br Utiliza os serviços de domínio para validar os dados de usuário.
    _userServices.ValidateUserOnCreate(user);

    // en Generates a new Guid.
    // pt-br Gera um Guid.
    Guid id = Guid.NewGuid();

    // en Hashes Password Using BCrypt
    // pt-br "Hesha" a senha usando BCrypt
    user.Password = PasswordHashing.HashPassword(user.Password!, salt);
    // en Inserts new Id into user.Id:
    // Guarda o Id no objeto user.
    user.Id = id;

    // Cria o usuário no banco de dados.
    await _userRepository.CreateAsync(user);
    // en When the user is being created, it doesn't have any groups.
    // pt-br Quando o usuário está sendo criado, ele não tem nenhum grupo, por isso achei melhor instanciar essa classe.
    List<GroupsUsers> groupsUsers = new List<GroupsUsers>();

    // Gera nosso Token JWT.
    string token = MainTokenService.GenerateToken(user, groupsUsers);

    // en Save the Main Token in MongoDB.
    // pt-br. Salva o Token no MongoDB.
    TokenData data = new TokenData
    {
        DataCriacaoToken = DateTime.Now,
        Token = token,
        UsuarioId = Convert.ToString(user.Id)
    };

    await _tokenRepository.Create(data);

    // Deleta Tokens antigos.
    _cookieConfiguration.DeleteHttpOnlyCookie("Token");
    // Se o usuário estiver logado em alguma outra conta, esse serviço faz Logoff.
    await _cookieAuthServices.LogoutAsync();
    // Agora Loga com a senha nova.
    await _cookieAuthServices.LoginAsync(user.Id, token, groupsUsers);

    // Salva a salt no banco de dados.
    SaltsData salts = new SaltsData
    {
        Email = user.EMail,
        Salt = salt
    };

    // Salva a Salt no MongoDB.
    await _saltsRepository.Create(salts);

    // Envia uma mensagem para o usuário junto com o Id dele.
    return new UserCreateReturn
    {
        Message = "Usuário Cadastrado com Sucesso!",
        UserId = id
    };
}
```