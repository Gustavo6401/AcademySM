import AssignmentSent from "../../domain/models/apis/groups/assignmentSent";
import AssignmentSentAPI from "../../infra/api/groups/assignmentSentAPI";
import UploadAPI from "../../infra/api/utils/uploadAPI";

export default class EnviarTarefaViewServices {
    private api: AssignmentSentAPI = new AssignmentSentAPI()
    private uploadAPI: UploadAPI = new UploadAPI()

    async create(file: File, tarefaId: string): Promise<string> {
        var idTarefa: number = Number.parseInt(tarefaId)

        const fileName: string = await this.uploadAPI.upload(file)
        var userId: string = localStorage.getItem('userId') ?? ''

        if (userId === '') {
            return 'Para que a Tarefa seja enviada, é necessário que o usuário esteja logado.'
        }

        const assignmentSent: AssignmentSent = new AssignmentSent(0, new Date(Date.now()), fileName, 0, idTarefa, userId)

        const response: string = await this.api.create(assignmentSent)

        return response
    }
}