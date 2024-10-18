import LoginViewModel from "../../domain/models/viewModels/loginViewModel";
import ApplicationUserAPI from "../../infra/api/user/applicationUserAPI";

export default class LoginViewServices {
    private userAPI: ApplicationUserAPI

    constructor() {
        this.userAPI = new ApplicationUserAPI()
    }

    async login(email: string, password: string): Promise<string> {
        const resultado: LoginViewModel = await this.userAPI.loginAsync(email, password)
        localStorage.setItem('userId', resultado.getId())
        localStorage.setItem('fullName', resultado.getUserFullName())
        localStorage.setItem('profilePicPath', resultado.getUserProfilePicPath())

        return resultado.getReturnMessage()
    }
}