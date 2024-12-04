import GroupsApplicationUserAPI from "../../infra/api/groups/applicationUserAPI";
import ApplicationUserAPI from "../../infra/api/user/applicationUserAPI";

export default class DeleteUserViewServices {
    private userAPI: ApplicationUserAPI = new ApplicationUserAPI()
    private groupsUserAPI: GroupsApplicationUserAPI = new GroupsApplicationUserAPI()

    async deleteUser(id: string) {
        await this.userAPI.deleteAsync(id)
        await this.groupsUserAPI.deleteAsync(id)
    }
}