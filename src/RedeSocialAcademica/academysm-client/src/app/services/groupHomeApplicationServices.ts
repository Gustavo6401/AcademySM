import GroupHomeViewModel from "../../domain/models/apis/groups/return/groupHomeViewModel";
import GroupsAPI from "../../infra/api/groups/groupsAPI";

export default class GroupHomeApplicationServices {
    private groupsAPI: GroupsAPI = new GroupsAPI()

    async get(id: string): Promise<GroupHomeViewModel> {
        const courses: GroupHomeViewModel = await this.groupsAPI.accessGroup(id)

        return courses
    }
}