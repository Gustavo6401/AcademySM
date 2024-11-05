import axios, { AxiosInstance, AxiosResponse } from "axios";

export default class UploadAPI {
    async upload(input: File): Promise<string>;
    async upload(input: FormData): Promise<string>;

    async upload(input: File | FormData): Promise<string> {
        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_FILE_SERVER_API
        })

        var formData = new FormData()

        if (input instanceof File) {
            formData.append('file', input, input.name)
        } else {
            formData = input
        }

        try {
            const resultado: AxiosResponse = await api.post('/api/Upload', formData)

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