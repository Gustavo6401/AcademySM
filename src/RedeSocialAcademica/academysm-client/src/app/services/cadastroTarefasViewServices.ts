import Assignment from "../../domain/models/apis/groups/assignment";
import AssignmentAPI from "../../infra/api/groups/assignmentAPI";

export default class CadastroTarefasViewServices {
    private api: AssignmentAPI = new AssignmentAPI()

    async create(title: string, dueDate: Date, noteValue: number, groupId: string) : Promise<string> {
        var id: number = Number.parseInt(groupId)

        var assignment: Assignment = new Assignment(0, title, new Date(Date.now()), dueDate, noteValue, id)
        var response: string = await this.api.create(assignment)

        return response
    }
}