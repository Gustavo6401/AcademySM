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