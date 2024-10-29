# Nosso Front-End e projeto principal

Creio que a maior parte do código utilizada em produção está nesse projeto. Aqui contém todo o Front-End, desde a página inicial até a página de tarefas. Esse Front-End foi criado baseando-se especialmente no projeto feito no Figma que pode ser acessado (apenas por algumas pessoas) [AQUI](https://www.figma.com/design/pmKg40i1wD9hc8vDGLWJbP/Academy-SM?node-id=0-1&node-type=canvas&t=h5HwM3hpo26nRAnm-0)

## Como esse projeto foi pensado?

Pensei em ser ao máximo inovador, mas ao mesmo tempo, escrever algo agradável aos nossos olhos, por isso, decidi-me por uma paleta de cores revolucionária e manter todos os componentes e modais com o fundo branco. Verás que a tela principal da Academy SM, começa num vermelho parecido com o utilizado em sites como o Quora e o Reddit, sendo esse aqui: <span style="color: #c32323">■</span>. Se você for ler o Whitepaper da Academy SM, verás que comecei com a ideia de um blog de perguntas e respostas que depois foi adaptado para um Ambiente Virtual de Aprendizagem que poderia ser utilizado por qualquer profissional da Educação. O fundo é um gradiente vermelho que começa no canto superior esquerdo para um preto apagado no final da página. Além de possuir duas barras de navegação, uma branca e uma vermelha.

## Quais as Tecnologias Utilizadas no Projeto? 🤔🧐

Utilizamos as seguintes tecnologias:

- **React JS**: O projeto foi idealizado em 2022, até então, eu não sabia da existência do Blazor Server (tecnologia essa em que só escrevi meu primeiro projeto em 2024). Por isso, eu decidi pelo React JS.
- **VITE**: O VITE foi uma tecnologia que até então eu nunca tinha ouvido falar, mas que eu utilizei especialmente ao criar o projeto na Visual Studio, como mencionado em outros capítulos dessa documentação, o objetivo é criar e desenvolver todo esse código na Visual Studio Community 2022, por isso, decidi pelo VITE.
- **NPM**: Eu cheguei a desenvolver uma versão com yarn, inclusive, uma versão antiga utilizava o yarn. Porém, desisti e vi o quanto a minha decisão foi correta após fazer a minificação do meu projeto. Admito que em um determinado momento, acreditei que meu projeto inteiro seria carregado quando o usuário acessasse o navegador, por isso, eu utilizei o yarn. 🤦🏼‍♂️, mas isso acontece quando utilizamos o ChatGPT de uma forma errada.
- **TypeScript**: A maior parte do projeto foi escrita utilizando TypeScript, o que na minha opinião, valeu muito a pena e o investimento de tempo. Ao utilizar Hooks do React como `useState()` e `useEffect()`, eu pude perceber o quanto a tipagem do TypeScript poderia me ajudar.
- **JavaScript**: Eu reservei o JavaScript para componentes e interfaces com a tipagem mais simples e de preferência, em que eu não consiga utilizar os Hooks `useState()` e `useEffect()`.
- **Node JS**: Node até então era o único interpretador de JavaScript que eu conhecia.
- **Axios**: Eu já fiz requisições utilizando o fetch e o jQuery, porém, nenhum desses me chamou tanta atenção pela facilidade como o Axios, o que justificou o meu uso.
- **Bootstrap Icons**: Bootstrap Icons para mim foi uma escolha sólida, visto que se eu escolhesse outro framework como o Font-Awesome eu teria que pagar a partir de um determinado número de chamadas à API.
- **CSS**: Não vi a necessidade de utilizar nenhum tipo de framework como Tailwind, Bootstrap ou SCSS aqui. Achei o CSS puro como uma alternativa bem melhor.

## Instalação e Configuração

1. Entre no diretório chamado academysm-client após fazer o download do repositório.

![Acessando o Diretório](<../imgs/4 - Acessando o Diretório academysm-client.png>)

2. Rode o comando: `npm i` para instalar as dependências.

![Utilizando npm i](<../imgs/4 - Utilizando o Comando npm i.png>)

3. Abra o arquivo `RedeSocialAcademica.sln` diretamente na sua Visual Studio.

![Abrindo o Arquivo na Visual Studio Pt. 1](<../imgs/4-3 - Abrindo o Arquivo na Visual Studio.png>)

![Abrindo o Arquivo na Visual Studio Pt. 2](<../imgs/4-4 - Abrindo a Visual Studio Pt. 2.png>)

4. Clique com o botão direito em cima da solução `RedeSocialAcademica`

![Clicando com o Botão Esquerdo](<../imgs/4.5 - Clicando com o Botão Esquerdo Por Cima da Solução.png>)

5. Clique em **Configurar Projetos de Inicialização**

![Configurar Projetos de Inicialização](<../imgs/4.6 - Configurar Projetos de Inicialização.png>)

6. Clique em **Vários Projetos de Inicialização** e selecione *Iniciar* para **academysm-client**, **CadastroUsuario**, **Groups** e **FileServer**

![Selecionar Projetos para Iniciar](<../imgs/4.7 - Selecionar Projetos para Inicializar.png>)

7. Clique em **OK**

![Clique em OK](<../imgs/4.8 - Clique em OK.png>)

8. Clique em **Iniciar**

![Clique em Iniciar](<../imgs/4.9 - Clique em Iniciar.png>)

9.  Após abrir o navegador, digite o endereço [https://localhost:5173](https://localhost:5173)

![Acessando o Endereço Correto](<../imgs/4.10 - Abrindo a Aplicação.png>)

10. Após digitado o endereço correto, aceite os certificados SSL, clique em **Avançado** e depois em **Continuar até localhost.**:

![Acessando a Aplicação](<../imgs/4.11 - Continue em Avançado.png>)

![Continue até localhost](<../imgs/4.12 - Continue até localhost.png>)

11. Pronto!

![Pronto!](<../imgs/4.13 - Pronto.png>)

Após esse passo a passo, você será capaz de acessar a aplicação diretamente em seu ambiente de desenvolvimento. Vale lembrar que não fomos capazes de fornecer certificados SSL confiáveis, porém, precisamos muito dos certificados, visto que utilizamos Cookies HTTPOnly na aplicação, o que dificulta bastante o nosso trabalho.

## Estrutura do Projeto

Após Buscar em **RedeSocialAcademica** >> **Client** >> **academysm-client** você verá a seguinte imagem:

![Estrutura do Projeto](<../imgs/4.14 - Estrutura do Projeto.png>)

- .vscode - Quando abro a VsCode geralmente essa pasta é criada automaticamente, mas não faço ideia do que ela faça.
- public - Na pasta **public**, tem o arquivo vite.svg com a logo da Vite.
- src - A pasta **src** contém todos os arquivos da aplicação.
- .env - Arquivo com as variáveis de ambiente.
- cert.pem e key.pem - Arquivos de certificados digitais com o objetivo de oferecer a minha aplicação em HTTPS.
- tsconfig.json e vite.config.ts - Arquivos padrões para projetos com Vite, Typescript e Node. Fiz modificações neles para que os arquivos TypeScript possam interoperar com arquivos JavaScript.
- Demais arquivos - Exceto o nuget.cofig, todos os arquivos aqui são padrões de projetos node.

### Mas e quanto à pasta src?

A pasta **src** para mim, é a pasta principal do meu projeto, ali tem três pastas principais e dois arquivos principais. O meu objetivo foi utilizar os princípios do Domain Driven Design nesse projeto, organizando assim a minha aplicação Front-End de forma limpa e organizada

- **domain** - A pasta domain têm por objetivo fornecer as regras de negócio da aplicação. O gerador de senhas da Academy SM por exemplo têm suas validações na sub-pasta **services** >> **passwordValidator**. As regras de negócio que não dependem de serviços externos, ou seja, que são de serviços do próprio Front-End (como a geração de senha) devem ser escritas na pasta **services**. Já a pasta **models** contém as entidades de dados e todas as classes que podem estão sendo utilizadas no Front-End, **viewModels** por exemplo estão mais adaptadas para o Front-End. **apis** são os modelos de dados retornados pelas APIs.
- **infra** - Camada de comunicação com serviços externos, dentro dela, temos a subpasta **api** contendo as comunicações com os Endpoints da API, **crypto** são os serviços de Criptografia e por fim, **navigation** é uma pasta cuja função é criar features para navegação, um exemplo disso é a função `navigateTo()`, função essa, cujo objetivo é navegar em cada pedaço do site.
- **app** - A camada de aplicação contém a interação com o usuário e a orquestração entre domain e infra. O objetivo é que *nenhum código presente na camada de domínio sofra influência externa.* Por isso, criei a subcamada **applicationServices**, camada essa também presente nas aplicações .NET. Além disso, os componentes visuais das pastas **components**, **pages**, **modal** e **assets** estão dispostos nessa pasta. Para que você possa contribuir com o desenvolvimento de novos componentes, exigimos que um padrão a seguir é que se o componente é um componente, você deve criar uma pasta com o nome do seu componente, com um arquivo .css com o nome do componente e um arquivo .tsx (ou .jsx) na pasta do componente, para páginas e modais, o processo é o mesmo, porém, você deve criar modais na pasta **modal** e páginas na pasta **web**.
- **App.tsx** - O arquivo **App.tsx** serve como esquema de roteamento da aplicação. O roteamento é um ponto de melhoria da Academy SM, pois pretendo implementar um design pattern strategy ou até mesmo um React Router DOM.
- **main.tsx** - O arquivo que contém o ponto de partida de fato da aplicação, módulo chamado diretamente no arquivo `index.html`.

![Estrutura do Projeto - Front-End](<../imgs/4.15 - Estrutura do Projeto - Front-End.png>)

## Principais Funcionalidades

As principais funcionalidades desse projeto são: 

- **Servir como Front-End**
- **Geração de Senhas** - Temos uma Página de Geração de Senhas
- **Identidade Visual da Academy SM** - Temos a identidade visual e nossa paleta de cores.

## Explicação do Código

Essa aplicação ainda assim têm trechos críticos de código, dentre eles:

``` typescript
const navigation = (path: string) => {      
        let Component

        // Verifies Whether we have more digits in the URL after /DetalhesUsuario, using the flag d+$
        const userDetailsRegex: RegExp = /^\/DetalhesUsuario\/[a-fA-F0-9-]+$/
        const groupHomeRegex: RegExp = /^\/Grupos\/Home\/\d+$/;
        const tarefasRegex: RegExp = /^\/Tarefas\/\d+$/
        const videoConferenciaRegex: RegExp = /^\/Videoconferencia\/\d+$/
        const tarefaRegex: RegExp = /^\/Tarefa\/\d+$/

        if (userDetailsRegex.test(path)) {
            Component = DetalhesUsuario
        } else if (groupHomeRegex.test(path)) {
            Component = GruposHomePage
        } else if (tarefasRegex.test(path)) {
            Component = Tarefas
        } else if (videoConferenciaRegex.test(path)) {
            Component = Videoconference
        } else if (tarefaRegex.test(path)) {
            Component = Tarefa
        }
        else {
            // Essa parte ficou uma merda.

            switch (path) {
                case '/CadastroDeUsuario':
                    Component = CadastroUsuario
                    break
                case '/GeradorDeSenhas':
                    Component = PasswordGenerator
                    break
                case '/Grupos':
                    Component = Grupos
                    break
                case '/Privacidade':
                    Component = Privacidade
                    break
                case '/':
                default:
                    Component = Login
                    break

            }
        }      

        setComponent(() => Component)
    }
```

Essa função é um grande exemplo, pois essa é a forma na qual fazemos o roteamento atualmente, com certeza ela é um grande ponto de melhoria (senão o maior ponto de melhoria da Academy SM atualmente).

``` javascript
export default function Navbar() {
    return (
        <nav className='navbar-mine'>
            <div>
                <a className='nav-mine-link inika' href='#'>Academy SM</a>
                <div className='navbar-toggle' id='menuToggle'>
                    <div className='nav-toggle-item'></div>
                    <div className='nav-toggle-item'></div>
                    <div className='nav-toggle-item'></div>
                </div>
            </div>
            <ul className='barra-navegacao closed' id='menu'>
                <li className='navbar-li'>
                    <a className='nav-mine-link' href='#'>Home</a>
                </li>
                <li className='navbar-li'>
                    <a className='nav-mine-link' href='#'>Artigos</a>
                </li>
                <li className='navbar-li'>
                    <a className='nav-mine-link' href='/Grupos'>Grupos</a>
                </li>
                <li className='navbar-li'>
                    <a className='nav-mine-link' href='#'>Dúvidas</a>
                </li>
            </ul>
        </nav>
    );
}
```

Já esse é um padrão de componente que criamos aqui na Academy SM, a ideia é que todos os nossos componentes sejam funcionais que sejam criados portanto em variáveis constantes ou diretamente em funções. 

``` typescript
async getById(id: number): Promise<Courses> {
        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_GROUPS_API
        })

        try {
            const resultado: AxiosResponse = await api.get(`/api/Group/GetById?id=${id}`)

            const resultAny: any = resultado.data

            const coursesData: Courses = new Courses(resultAny.id, resultAny.name, resultAny.level,
                resultAny.tutor, resultAny.description, resultAny.isPublic)

            return coursesData
        } catch (error: any) {
            if (error.response) {
                console.error('Erro: ', error.response.data)
                console.log('Mensagem: ', error.response.message)
                console.log('Status: ', error.response.status)
                console.log('Headers: ', error.response.headers)
            } else if (error.request) {
                console.error('Nenhuma Resposta Recebida: ', error.request)
            } else {
                console.error('Erro na Configuração da Requisição')
            }

            throw error
        }
    }
```

Esse é o exemplo de uma chamada à API. Os arquivos obrigatoriamente são criados com a extensão .ts e dentro do método criamos um Axios Instance. Ao fazermos a chamada à API fazemos o tratamento de erro e temos por obrigação coletar o erro e o status do erro. 

``` typescript
export default function navigateTo(path: string) {
    window.history.pushState({}, '', path)
    window.dispatchEvent(new Event('popstate'))
}
```

Essa é a função que tem por objetivo fazer a navegação e direcionamento dentro da Academy SM.

## Contribuição

Você pode contribuir com a Academy SM seguindo os padrões citados acima, respeitando a estrutura de pastas e se você for um desenvolvedor React ou TypeScript sua ajuda é muito bem-vinda. Solicitamos uma Issue com uma feature Request diretamente na aba "Issues" e a partir daí, liberamos para que você faça seus pull requests.

## Licença 

Esse projeto está protegido pela licença Apache, o que significa que o código escrito nele pode ser reutilizado desde que você mantenha os créditos do autor original.

## Agradecimentos.

Muito obrigado pela atenção! Solicitamos que você leia também a próxima parte da documentação, a parte do projeto de [Cadastro de usuário](5%20-%20CadastroUsuario.md). 

O ser humano é naturalmente polímata! 