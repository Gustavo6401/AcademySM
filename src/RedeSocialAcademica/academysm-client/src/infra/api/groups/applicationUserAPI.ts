import axios, { AxiosInstance, AxiosResponse } from "axios";
import GroupsApplicationUser from "../../../domain/models/apis/groups/applicationUser";

export default class GroupsApplicationUserAPI {
    private api: AxiosInstance = axios.create({
        baseURL: import.meta.env.VITE_GROUPS_API,
        withCredentials: true
    })

    async createAsync(user: GroupsApplicationUser) {
        const bodyRequest = {
            id: user.getId(),
            name: user.getName(),
            educationalBackground: user.getEducationalBackground(),
            institution: user.getInstitution(),
            courseName: user.getCourseName(),
            profilePicPathName: user.getProfilePicFilePath()
        }

        try {
            const resultado: AxiosResponse = await this.api.post("/api/ApplicationUser", bodyRequest)

            return resultado.data
        } catch (error) {
            console.log(error)
            throw error
        }
    }

    async deleteAsync(id: string) {
        try {
            await this.api.delete(`/api/ApplicationUser?id=${id}`)
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