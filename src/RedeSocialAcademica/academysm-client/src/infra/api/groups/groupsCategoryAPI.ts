import axios, { AxiosInstance, AxiosResponse } from "axios";
import CategoryGroups from "../../../domain/models/apis/groups/categoryGroups";
import { CategoryGroupsViewModel } from "../../../domain/models/viewModels/categoryGroupsViewModel";

export default class GroupsCategoryAPI {
    async create(groupsCategory: CategoryGroupsViewModel): Promise<string> {
        const bodyRequest = {
            categoryId: groupsCategory.categoryId,
            publicGroupId: groupsCategory.publicGroupId
        }

        console.log(bodyRequest)

        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_GROUPS_API,
            withCredentials: true
        })

        try {
            const resultado: AxiosResponse = await api.post("/api/GroupsCategory", bodyRequest)

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