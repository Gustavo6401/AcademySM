import axios, { AxiosInstance } from "axios";
import GroupsUsers from "../../../domain/models/apis/groups/groupsUsers";

export default class GroupsUserAPI {
    private api: AxiosInstance = axios.create({
        baseURL: import.meta.env.VITE_GROUPS_API,
        withCredentials: true
    })

    async create(usuarioGrupo: GroupsUsers) : Promise<string> {
        const bodyRequest = {
            role: usuarioGrupo.getRole(),
            userId: usuarioGrupo.getUserId(),
            publicGroupId: usuarioGrupo.getPublicGroupId()
        }

        try {
            const resultado = await this.api.post('/api/UserGroup', bodyRequest)

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
                console.error('Erro na Configuração da Requisição')
            }

            throw error
        }
    }
}