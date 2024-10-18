import axios, { AxiosInstance, AxiosResponse } from "axios";
import AssignmentSent from "../../../domain/models/apis/groups/assignmentSent";

export default class AssignmentSentAPI {
    async create(assignmentSent: AssignmentSent) : Promise<string> {
        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_GROUPS_API,
            withCredentials: true
        })

        const bodyRequest = {
            dateSent: assignmentSent.getDateSent(),
            filePath: assignmentSent.getFilePath(),
            rate: 0,
            assignmentId: assignmentSent.getAssignmentId(),
            userId: assignmentSent.getUserId()
        }

        try {
            const resultado: AxiosResponse = await api.post('/api/AssignmentSent', bodyRequest)

            const result: string = resultado.data

            return result
        } catch (error: any) {
            if (error.response) {
                console.error('Erro: ', error.response.data)
                console.log('Mensagem: ', error.response.message)
                console.log('Status: ', error.response.status)
                console.log('Headers: ', error.response.headers)
            } else if (error.request) {
                console.error('Nenhuma Resposta Recebida: ', error.request)
            } else {
                console.error('Erro na Configura��o da Requisi��o')
            }

            throw error
        }
    }
}