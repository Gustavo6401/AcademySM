import axios, { AxiosInstance, AxiosResponse } from 'axios'
import GroupViewModel from '../../../domain/models/viewModels/groupViewModel';
import Courses from '../../../domain/models/apis/groups/courses'
import CreateGroupViewModel from '../../../domain/models/apis/groups/return/createGroupViewModel';

export default class GroupsAPI {
    async create(courses: Courses): Promise<CreateGroupViewModel> {
        const bodyRequest = {
            name: courses.getName(),
            level: courses.getLevel(),
            tutor: courses.getTutor(),
            description: courses.getDescription(),
            isPublic: true
        }

        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_GROUPS_API,
            withCredentials: true
        })

        try {
            const resultado: AxiosResponse = await api.post('/api/Group', bodyRequest)

            const result: CreateGroupViewModel = new CreateGroupViewModel(resultado.data.groupId, resultado.data.message)

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

    async getById(id: number): Promise<Courses> {
        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_GROUPS_API
        })

        try {
            const resultado: AxiosResponse = await api.get(`/api/Group/GetById?id=${id}`)

            const resultAny: any = resultado.data

            const coursesData: Courses = new Courses(resultAny.id, resultAny.name, resultAny.level,
                resultAny.tutor, resultAny.description, resultAny.isPublic)

            return coursesData
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

    async groups(): Promise<Array<GroupViewModel>> {
        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_GROUPS_API
        })

        try {
            const resultado: AxiosResponse = await api.get('/Groups')

            const dataArrayJson: Array<any> = resultado.data

            const list: Array<GroupViewModel> = dataArrayJson.map((json: any) =>
                new GroupViewModel(json.groupId, json.groupTitle, json.groupLevel, json.groupCategoryIcon))

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
                console.error('Erro na Configuração da Requisição')
            }

            throw error
        }
    }

    async isProfessor(groupId: number): Promise<boolean> {
        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_GROUPS_API,
            withCredentials: true
        })

        try {
            const resultado = await api.get(`/api/Group/IsProfessor?groupId=${groupId}`)

            const result: boolean = resultado.data

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