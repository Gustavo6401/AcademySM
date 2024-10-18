import Assignment from "../../domain/models/apis/groups/assignment";
import AssignmentAPI from "../../infra/api/groups/assignmentAPI";
import GroupsAPI from "../../infra/api/groups/groupsAPI";

export default class TarefasViewServices {
    private api: AssignmentAPI = new AssignmentAPI()
    private groupsApi: GroupsAPI = new GroupsAPI()

    async viewGroupTasks(groupId: string): Promise<Array<Assignment>> {
        const groupNumberId: number = Number.parseInt(groupId)

        return await this.api.index(groupNumberId)
    }

    async isProfessorAccessing(groupId: string): Promise<boolean> {
        const groupNumberId: number = Number.parseInt(groupId)

        return await this.groupsApi.isProfessor(groupNumberId)
    }
}