import Courses from "../../domain/models/apis/groups/courses";
import GroupsAPI from "../../infra/api/groups/groupsAPI";

export default class GroupHomeApplicationServices {
    private groupsAPI: GroupsAPI = new GroupsAPI()

    async get(id: string) : Promise<Courses> {
        const numberId: number = Number.parseInt(id)

        const courses: Courses = await this.groupsAPI.getById(numberId)

        return courses
    }
}