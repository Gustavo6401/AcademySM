import UserPortfolio from "../../domain/models/viewModels/portfolio/userPortfolio";
import ApplicationUserAPI from "../../infra/api/user/applicationUserAPI";
import IIconValidationStrategy from "./portfolioServicesStrategy/iIconValidationStrategy";
import IsAmazonOriginStrategy from "./portfolioServicesStrategy/strategy/isAmazonOriginStrategy";
import IsBingOriginStrategy from "./portfolioServicesStrategy/strategy/isBingOriginStrategy";
import IsFacebookOriginStrategy from "./portfolioServicesStrategy/strategy/isFacebookOriginStrategy";
import IsGithubOriginStrategy from "./portfolioServicesStrategy/strategy/isGithubOriginStrategy";
import IsGitlabOriginStrategy from "./portfolioServicesStrategy/strategy/isGitlabOriginStrategy";
import IsGoogleOriginStrategy from "./portfolioServicesStrategy/strategy/isGoogleOriginStrategy";
import IsInstagramOriginStrategy from "./portfolioServicesStrategy/strategy/isInstagramOriginStrategy";
import IsLinkedinOriginStrategy from "./portfolioServicesStrategy/strategy/isLinkedinOriginStrategy";
import IsPortfolioOriginStrategy from "./portfolioServicesStrategy/strategy/isPortfolioOriginStrategy";
import IsYouTubeOriginStrategy from "./portfolioServicesStrategy/strategy/isYouTubeOriginStrategy";

export default class PortfolioViewServices {
    private applicationUserAPI: ApplicationUserAPI = new ApplicationUserAPI()

    async portfolio(id: string): Promise<UserPortfolio> {
        let portfolio = await this.applicationUserAPI.portfolio(id)

        return portfolio
    }

    /**
     * This method is responsible for checking the correct Icon Link for user.
     * 
     * Example:
     * @param origin = YouTube - Icon = bi bi-youtube
     */
    correctIcon(origin: string) {
        /**
         * en
         * We store the Origin of the link in the Map.
         * 
         * pt-br
         * Nós armazenamos a origem do link no Map.
         * 
         * en
         * For a future optimization, we can devide the maps, in order to do something like the databases. We can
         * put icons from A to L in a map and M to Z in another map. This will optimize the running of the code.
         * 
         * pt-br
         * Em otimizações futuras, nós podemos dividir o map, com o objetivo de fazer algo semelhante aos bancos
         * de dados SQL. Nós podemos colocar os ícones de A a L em um map e de M a Z em outro mapa. E verificar
         * se o nome do ícone começa com uma letra entre A e L. Isso otimizaria muito o funcionamento do código.
         * 
         * if(icon.StartsWith('a')) {
         *      Primeiro map - First map.
         * }
         * else {
         *      Primeiro map - Last map.
         * }
         */
        const mapOrigins = new Map<string, IIconValidationStrategy>()
        mapOrigins.set('bi bi-github', new IsGithubOriginStrategy())
        mapOrigins.set('bi bi-youtube', new IsYouTubeOriginStrategy())
        mapOrigins.set('bi bi-linkedin', new IsLinkedinOriginStrategy())
        mapOrigins.set('bi bi-person-vcard-fill', new IsPortfolioOriginStrategy())
        mapOrigins.set('bi bi-facebook', new IsFacebookOriginStrategy())
        mapOrigins.set('bi bi-amazon', new IsAmazonOriginStrategy())
        mapOrigins.set('bi bi-gitlab', new IsGitlabOriginStrategy())
        mapOrigins.set('bi bi-bing', new IsBingOriginStrategy())
        mapOrigins.set('bi bi-google', new IsGoogleOriginStrategy())
        mapOrigins.set('bi bi-instagram', new IsInstagramOriginStrategy())

        // We search for all elements of map, searching for the origin.
        // Buscamos cada item do Map, buscando a origem.
        for (const [key, value] of mapOrigins) {
            var resp = value.Validate(origin)

            // If the origin will be found, this will return the key. Example:
            // If origin === YouTube
            // YouTubeIconStrategy will return true.
            // The selected icon will be bi bi-youtube

            // pt-br
            // Se a origem do link for encontrada, esse if retornará a key. Exemplo:
            // if origin === YouTube
            // YouTubeIconStrategy.Validate() retornará true.
            // O ícone selecionado será bi bi-youtube.
            if (resp === true) {
                // The name of the icon is the key of the map.

                // pt-br
                // O nome do ícone é a key do map.
                return key
            }
        }

        return 'bi bi-link'
    }
}