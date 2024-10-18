import axios, { AxiosInstance, AxiosResponse } from "axios";

export default class UploadAPI {
    async upload(file: File): Promise<string> {
        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_FILE_SERVER_API
        })

        const formData = new FormData()
        console.log(formData)

        formData.append('file' ,file)

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
                console.error('Erro na Configura��o da Requisi��o')
            }

            throw error
        }
    }
}