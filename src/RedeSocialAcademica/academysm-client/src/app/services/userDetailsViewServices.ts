import UserDetailsViewModel from "../../domain/models/viewModels/userDetailsViewModel";
import ApplicationUserAPI from "../../infra/api/user/applicationUserAPI";

export default class UserDetailsViewServices {
    private userDetailsAPI: ApplicationUserAPI = new ApplicationUserAPI()

    async details(id: string): Promise<UserDetailsViewModel> {
        const model: UserDetailsViewModel = await this.userDetailsAPI.userDetails(id)

        return model
    } 
}