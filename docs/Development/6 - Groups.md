# Terceiro Projeto - Grupos

Na minha opinião, aqui mora o *Core Domain* da Academy SM. Inicialmente, pensei num lugar onde os professores universitários poderiam postar seus artigos e assim obterem ganhos financeiros com isso, além de que aqui seria um local para que as pessoas pudessem sanar as suas dúvidas, especialmente porque estudei numa instituição que tinha um ambiente virtual de aprendizagem em que nós não tínhamos a opção de perguntarmos diretamente ao nosso professor. Lembro até hoje de uma situação desagradável em uma das matérias no projeto da disciplina, onde eu estudei muito mas eu ainda tinha sérias dúvidas de como construir o projeto da disciplina. Com a ajuda de uma professora de uma outra matéria, consegui resolver esse problema. Por conta disso, o ambiente virtual de aprendizagem da Academy SM originalmente foi projetado para obter features que outros ambientes não tem e especialmente **mecanismos de comunicação assíncrona e documentada**. Eu gosto muito de praticar a repetição espaçada em tudo o que estudo e se possível, anoto no caderno e até mesmo guardo os prompts de conversas com o ChatGPT e de artigos que acho relevantes para eventuais discussões. Assim, nasceu a ideia de manter artigos acadêmicos (com a autorização de seus idealizadores) e um fórum de dúvidas. 

Há coisas que eu considero essenciais para uma boa ferramenta

1. Comunicação Síncrona - A comunicação Síncrona para mim é extremamente importante, ela pode ser feita por meio de chamadas de áudio e de vídeo, utilizando as tecnologias do Daily.co;
2. Espaço para Dúvidas - Como eu havia falado, um espaço para dúvidas é algo inegociável, percebo que a maioria dos professores, criadores de conteúdo e até mesmo universidades que decidem desenvolver a própria plataforma o fazem especialmente pela falta de um espaço para as dúvidas. Me lembro que muitas das dúvidas que eu tive durante a minha graduação eram dúvidas que outras pessoas também poderiam ter. Por isso, um espaço de convivência de professor e de alunos onde os alunos podem perguntar e responder uns aos outros é algo tão essencial na educação, além de mecanismos de avaliação dessas dúvidas e respostas, como os upvotes e os downvotes;
3. Compartilhamento de Arquivos - Dentro da Academy SM, os alunos podem compartilhar os artigos e até mesmo criarem seus próprios artigos, além de que postagens semelhantes às de outras redes sociais como o Facebook, o Instagram e o Quora são um recurso muito poderoso nativo da Academy SM;
4. Mecanismos de Avaliação - Os alunos podem ser constantemente avaliados por conta da Aba Tarefas, lá, os professores terão a opção de criarem e avaliarem as tarefas feitas por alunos eu como professor posso por exemplo, pedir que um aluno meu desenvolva o próprio portfólio em HTML, CSS e JavaScript, posso receber o link do repositório no Github e atribuir uma nota de 0 a 10 para ele;
5. Mecanismos de Comunicação Assíncrona - Mais um mecanismo que não existia e que precisava de dependências externas em outras plataformas eram os mecanismos de comunicação assíncrona. Mecanismos de envio de mensagens de texto e de áudio são ideias promissoras e que poderiam facilitar no aprendizado de qualquer aluno.

Todos esses recursos, uns alinhados com os outros podem servir como uma importante ferramenta no aprendizado dos alunos da Academy SM e eles foram pensados buscando atender a demanda dos alunos.

## Por que Criar Dois Bancos de Dados? 🤔

Admito que essa escolha de criar dois bancos de dados, um para cada API possa ter sido uma escolha errada, porém, essa escolha tem um objetivo muito simples: Lembra que eu falei que a ideia era que a Academy SM fosse um projeto que possibilitava as pessoas a terem dúvidas e assim responderem às dúvidas umas das outras? Então! Foi especialmente nesse contexto que eu achei que seria uma melhor alternativa criar dois bancos de dados diferentes para que eu pudesse manter os dados da minha aplicação. Daí, nas dúvidas e artigos públicos eu teria um banco de dados à parte. Além disso, eu estava pesquisando sobre microsserviços na época em que decidi começar a Academy SM e achei que seria interessante aprender essa tecnologia.

## Modelagem de Dados

O banco de dados principal foi pensado baseando-se nas ideias descritas acima, ele tem 21 tabelas cada qual com a sua função e é o banco de dados SQL principal da Academy SM, tendo as seguintes classes C#:

- Courses - Classe escrita para a tabela das informações principais do grupo;
- Categories - Cada grupo pode ter mais de uma categoria;
- ApplicationUser - Informações do Usuário trazidas para o contexto das telas de Grupos;
- Assignments - Tarefas dos alunos;
- Announcements - O professor pode fazer um anúncio no grupo para a turma inteira;
- Article - Artigo acadêmico ou um livro enviado num grupo;
- Doubts - Tabela cujo objetivo é manter as dúvidas dos usuários;
- Posts - Postagens dos usuários nos grupos da Academy SM;
- Conversation - Talvez aqui poderia ser até mesmo um grupo diferente, mas o objetivo principal é justamente salvar as conversas dos usuários;
- Messages - As mensagens que as pessoas podem mandar pelo Chat.
- Comments - Comentários podem ser feitos diretamente nas postagens.
- PostVote - Os usuários têm o direito de darem upvotes ou downvotes para qualquer postagem que eles verem dentro dos grupos.
- CategoryGroups - A relação entre grupos e categoria é uma relação de muitos para muitos, ou seja, Vários grupos podem ter a mesma categoria e os grupos podem ter muitas categorias.
- GroupsUsers - A relação entre usuários e grupos é uma relação igualmente de muitos para muitos, e além disso, algumas informações relevantes devem ser postas em consideração, tais como a Role do usuário dentro daquele grupo, se ele é um professor ou se ele é um simples aluno;
- AssignmentSents - É basicamente uma tabela de envios de tarefas, além disso, os usuários podem enviar suas tarefas como um arquivo individual;
- Answer - E uma tabela que contém as respostas das perguntas;
- DoubtVote - Assim como os posts, as dúvidas dos usuários também estão abertas aos votos da comunidade;
- PostFile - Um post também pode ter arquivos assim como no Facebook por exemplo onde você posta uma foto, além disso, uma postagem pode ter muitos arquivos, então é uma relação de um para muitos;
- ConversationsUsers - A relação entre conversas e grupos é uma relação de muitos para muitos;
- AssignmentFile - Tarefas também podem ter arquivos;
- DoubtFile - O usuário pode postar diversos arquivos em suas dúvidas;
- AnswerVote - Uma resposta pode ter upvotes ou downvotes;
- AnswerComment - Os usuários também podem responder as respostas com um pequeno comentário;

Temos inclusive, uma foto do nosso diagrama de dados:

![Diagrama de Dados - Academy SM Groups](<../imgs/6.1 - Diagrama de Classes - Academy SM Courses.png>)

## Quais são as Principais Tecnologias do Projeto?

- **.NET e C#** - Já era uma escolha esperada, visto que essa é exatamente a mesma tecnologia que utilizei na API de Cadastro de Usuário.
- **Entity Framework Core** - Novamente, escolhi pelo meu ORM preferido do momento;
- **SQL Server** - Está aqui a primeira escolha que possivelmente eu posso ter errado, optei por esse banco de dados especialmente porque era um banco que eu sabia e conhecia além de que bancos SQL são muito mais famosos do que bancos de dados de grafos por exemplo. Mediante a isso, acreditei que fosse uma escolha sólida.
- **MongoDB** - Novamente, o MongoDB está dedicado a dados secundários, futuramente, os dados de pagamento serão adicionados ao MongoDB.

## Instalação e Configuração

O processo de instalação desse projeto é muito parecido ao processo de instalação da API de Cadastro de Usuário. Por isso, novamente, afirmo que é ideal que você instale a IDE da Visual Studio que novamente, pode ser acessada por esse Link [Aqui](https://visualstudio.microsoft.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false) e o .NET SDK que pode ser baixado por [AQUI](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-9.0.100-windows-x64-installer).

O processo de instalação da Visual Studio Community é mostrado [AQUI](<5 - CadastroUsuario.md>) na documentação responsável pela API de Cadastro de Usuário.

Já o processo de Inicialização da Aplicação é extremamente parecido com o de Cadastro de Usuário e eu simplesmente copiarei e colarei as instruções de 1 a 6:

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

#### 7. Selecione Groups

![Selecione Groups](<../imgs/6.2 - Selecione Groups.png>)

#### 8. Digite o Comando `Update-Database`

![Update-Database](<../imgs/6.3 - Update-Database.png>)

#### 9. Inicie as Aplicações com o Botão Iniciar

![Clique em Iniciar](<../imgs/4.9 - Clique em Iniciar.png>)

#### Pronto!

## Estrutura do Projeto

Após Clicar em **RedeSocialAcademica** >> **Server** >> **Groups**, você verá a seguinte imagem:

![Groups Estrutura do Projeto](<../imgs/6.4 - Groups - Estrutura do Projeto.png>)

Novamente, a estrutura de pastas foi pensada nos princípios do Domain Driven Design, por isso, vamos falar sobre cada uma das pastas por aqui.

### Domain

Domain, ou camada de domínio é o "coração" da nossa aplicação, o objetivo aqui é manter as entidades e objetos de valor que servirão como base para a criação da base de dados. Lembra de lá de cima onde nós falamos um pouco sobre os meus objetivos com essa API especificamente? Então! Esses objetivos estão diretamente entrelaçados com essa camada aqui. Como se o objetivo dessa camada e das classes escritas em seus namespaces fossem as representações dos meus desejos e ideias.

#### DomainServices

Domain Services é a pasta responsável por armazenar os arquivos de validação de dados dentro da nossa aplicação, na API de Grupos isso não é diferente. É mais do que claro que quando um usuário responder alguma dúvida, ele obrigatóriamente deve dizer alguma coisa no Input, quando um usuário precisa criar um grupo, claramente o nome não deve ser nulo. Acho que você já entendeu onde eu quero chegar né? Admito que agora eu não vou explicar um a um o porquê os campos são obrigatórios, até porque o último episódio teve 26Kb de tamanho, mas talvez para um futuro eu possa explicar com mais clareza sobre o código.

``` csharp
public bool ValidateName(string name)
{
    if (string.IsNullOrWhiteSpace(name))
        throw new ArgumentException("Nome do Grupo Inválido!");

    return true;
}
```

#### Interfaces

Assim como a API de Cadastro de Usuário, a API de Grupos também segue o conceito de injeção de dependências e inversão de controle na maioria de suas classes, meu objetivo é que para cada método criado, eu deveria criar no mínimo padronizar uma assinatura, um tipo e os parâmetros diretamente numa Interface e permitir que as dependências externas sejam colocadas diretamente na classe. Essa é uma forma excelente de cumprir o Domain Driven Design e de centralizar no domínio a lógica de negócios ao máximo possível.

Exemplo: IGroupController

``` csharp
Task<ActionResult<CreateGroupViewModel>> Create(Courses courses);
```

Exemplo de implementação: GroupController:

``` csharp
[HttpPost]
[Authorize(AuthenticationSchemes = "CookieAuth")]
public async Task<ActionResult<CreateGroupViewModel>> Create([FromBody] Courses courses)
{
    await _applicationServices.Create(courses);
    int groupId = await _applicationServices.GetIdByName(courses.Name!);

    return Ok(new CreateGroupViewModel { Message = "Grupo Criado com Sucesso!", GroupId = groupId });
}
```

As dependências do Asp.Net Core como o Authorize, o HttpPost e o FromBody só são utilizadas diretamente dentro da classe GroupController, enquanto a assinatura da classe continua a mesma.

#### Models

Na minha opinião, essa pasta é o coração da aplicação. Ela é quem recebe a maior parte das importações e contém o retrato das ideias que eu tive em relação à essa API. Claramente, a parte de tarefas deve ser representada por uma classe chamada `Assignments`, assim como as dúvidas que eu quero introduzir na minha aplicação são inseridas primariamente por uma classe chamada `Doubt`.

``` csharp
public class Doubt
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Status { get; set; }
    public DateTime DateCreation { get; set; }

    public Courses? Group { get; set; }
    public int GroupId { get; set; }

    public ApplicationUser? User { get; set; }
    public Guid UserId { get; set; }

    public ICollection<DoubtVote>? Votes { get; set; }
    public ICollection<Answer>? Answers { get; set; }
    public ICollection<DoubtFile>? Files { get; set; }
}
```

Essa pasta contém diversas subpastas, dentre elas:

1. **API** - As classes dessa pasta têm por objetivo receber os dados das APIs referenciadas por essa API.
2. **MongoDBModels** - Classes de Collections e configurações do MongoDB.
3. **SQLServerModels** - As classes do SQL Server nessa API ganharam uma pasta dedicada, mais especificamente a classe SQL Server Models, além disso, a pasta **Agregations** é responsável pelas tabelas que tem alguma relação de muitos para muitos, um exemplo bem típico é a tabela **CategoryGroups** que é uma tabela que é responsável pela relação entre Courses e Categories¹.
4. **ViewModels** - Muitas vezes, no SQL Server armazenamos informações que não queremos retornar em um determinado contexto para o usuário, é praticamente inviável utilizar um `Select * From <NOME-DA-TABELA>` todas as vezes que formos utilizar um banco de dados. Além disso, por vezes buscamos dados de outras tabelas e justamente para não trazer mais funcionalidades ao banco de dados que nasceu a pasta **ViewModels**², o objetivo é claro: solicitar apenas alguns parâmetros dessas consultas ou criar scripts SQL próprios para isso.³ 

##### Nota 1 - Agregations

Um exemplo muito claro de agregação que já foi citado foi a classe **CategoryGroups**: 

``` csharp
public class CategoryGroups
{
    public Category? Category { get; set;  }
    public int CategoryId { get; set; }

    public Courses? Group { get; set; }
    public int GroupId { get; set; }
}
```

Perceba como essa classe sequer tem Ids, essa é a maior prova de que ela é uma agregação.

Estudem Domain Driven Design galera!

##### Nota 2 - View Models

Observe o seguinte script SQL:

``` sql
Select * From Posts
Where GroupId = @Id

Select Id
    [Name]
    [Level]
    [Description]
From Groups
Where Id = @Id
```

Para começo de conversa, o primeiro script a depender do grupo e do número de usuários pode retornar milhares de resultados, porém, o segundo script só deve retornar um resultado. Isso é um enorme caso de uso de uma ViewModel, por vezes, queremos retornar muitos resultados que estão fora de uma tabela específica, esse é o caso de uso perfeito para view models. Se eu criasse uma View do SQL, possivelmente eu teria que escrever um `Inner Join` e retornaria vários resultados da tabela grupos que eu não desejo retornar. E principalmente: Como eu faria esses dois selects separados numa View? Posso estar muito equivocado, mas na minha opinião, esse é o caso de uso perfeito para ViewModels. 

``` csharp
public class GroupsHomeViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Level { get; set; }
    public string? Description { get; set; }
    public ICollection<Post>? Posts { get; set; }
}
```

Pesquisem sobre ViewModels!

##### Nota 3 - Grupos e Courses

Perceba que muitas classes que gerenciam a tabela Courses têm o nome "Groups" e não "Courses". Nesse contexto, *Groups* e *Courses* são exatamente a mesma coisa. Eu não consegui criar uma classe chamada Groups especialmente porque Groups era o nome do projeto, essa é a prova cabal de que ambas são a mesma coisa.

### Infra

Assim como na API de Cadastro de Usuário, as classes na pasta "Infra", têm por objetivo realizar a comunicação com dependências externas e apesar de mais classes, a API de Grupos tem menos dependências externas. Resumidamente, eu separei as pastas de acordo com a sua funcionalidade.

#### Authentication (Descontinuada)

A pasta Authentication foi escrita especialmente **quando eu não sabia como a autenticação do ASP.Net Core funcionava.**