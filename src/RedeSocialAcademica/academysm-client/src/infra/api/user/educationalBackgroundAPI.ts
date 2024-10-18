import axios, { AxiosInstance, AxiosResponse } from 'axios'
import EducationalBackground from '../../../domain/models/apis/user/educationalBackground';

export default class EducationalBackgroundAPI {
    async createAsync(background: EducationalBackground) {
        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_USER_API,
            withCredentials: true
        })

        const bodyRequest = {
            course: background.getCourse(),
            educationalDegree: background.getEducationalDegree(),
            status: background.getStatus(),
            institution: background.getInstitution(),
            courseBegin: background.getCourseBegin(),
            courseEnd: background.getCourseEnd(),
            userId: background.getUserId()
        }

        try {
            const resultado = await api.post("/api/EducationalBackground", bodyRequest)

            return resultado.data
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

    async getByUserIdAsync(id: string) {
        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_USER_API
        })

        try {
            const resultado = await api.get(`/api/EducationalBackground/ListUsersEducationalBackgrounds?userId=${id}`)


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