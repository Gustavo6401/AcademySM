import axios, { AxiosInstance, AxiosResponse } from "axios";
import Assignment from "../../../domain/models/apis/groups/assignment";

export default class AssignmentAPI {
    async create(assignment: Assignment): Promise<string> {
        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_GROUPS_API,
            withCredentials: true
        })

        const bodyRequest = {
            title: assignment.getTitle(),
            dateCreation: assignment.getDateCreation(),
            dueDate: assignment.getDueDate(),
            noteValue: assignment.getNoteValue(),
            groupId: assignment.getGroupId()
        }

        try {
            const resultado = await api.post('/api/Assignment', bodyRequest)

            const response: string = resultado.data

            return response
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

    async getById(assignmentId: number): Promise<Assignment> {
        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_GROUPS_API,
            withCredentials: true
        })

        try {
            const resultado: AxiosResponse = await api.get(`/api/Assignment/GetById?id=${assignmentId}`)

            const info: any = resultado.data

            const assignment: Assignment = new Assignment(info.id, info.title, info.dateCreation, info.dueDate,
                info.noteValue, info.groupId)

            return assignment
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

    async index(groupId: number): Promise<Array<Assignment>>  {
        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_GROUPS_API,
            withCredentials: true
        })

        try {
            const resultado = await api.get(`/api/Assignment/Index?groupId=${groupId}`)

            const dataArrayJson: Array<any> = resultado.data

            const list: Array<Assignment> = dataArrayJson.map((json: any) => 
                new Assignment(json.id, json.title, json.dateCreation, json.dueDate, json.noteValue,
                    json.groupId))

            return list
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