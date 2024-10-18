import AssignmentAPI from "../../infra/api/groups/assignmentAPI"

export default class TarefaViewServices {
    private api: AssignmentAPI = new AssignmentAPI()

    async get(tarefaId: string) {
        const idTarefa: number = Number.parseInt(tarefaId)

        return await this.api.getById(idTarefa)
    }
}