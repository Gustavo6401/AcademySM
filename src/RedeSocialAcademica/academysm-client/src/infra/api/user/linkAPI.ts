import axios, { AxiosInstance } from "axios";
import Links from "../../../domain/models/apis/user/links";

export default class LinkAPI {
    private api: AxiosInstance = axios.create({
        baseURL: import.meta.env.VITE_USER_API,
        withCredentials: true
    })

    async createAsync(link: Links): Promise<string> {
        const bodyRequest = {
            profileName: link.getProfileName(),
            origin: link.getOrigin(),
            link: link.getLink(),
            userId: link.getUserId()
        }

        try {
            const resultado = await this.api.post('/api/Links', bodyRequest)

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
}