import GroupViewModel from "../../domain/models/viewModels/groupViewModel";
import GroupsAPI from "../../infra/api/groups/groupsAPI";

export default class GroupViewServices {
    private groupsAPI: GroupsAPI = new GroupsAPI();

    async groups(): Promise<Array<GroupViewModel>> {
        const response = await this.groupsAPI.groups()

        return response
    }
}