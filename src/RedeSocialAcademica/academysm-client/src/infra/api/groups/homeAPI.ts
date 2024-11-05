import axios, { AxiosResponse } from "axios";

export default class HomeAPI {
    async dailyAccessToken() : Promise<string> {
        const api = axios.create({
            baseURL: import.meta.env.VITE_GROUPS_API,
            withCredentials: true
        })

        try {
            const response: AxiosResponse = await api.get('/DailyAccessToken')

            const result: string = response.data

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
                console.error('Erro na Configura��o da Requisição')
            }

            throw error
        }
    }
}