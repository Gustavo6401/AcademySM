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

#### 7. Selecione **CadastroUsuario* como o projeto padrão

![Cadastro Usuário](<../imgs/5.6 - CadastroUsuario.png>)