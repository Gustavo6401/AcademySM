import axios, { AxiosInstance, AxiosResponse } from "axios"

export default class DailyRooms {
    async createRoom(): Promise<any> {
        const exp: number = Math.round(Date.now() / 1000) + 60 * 10

        const options = {
            properties: {
                exp
            }
        }

        const isLocal = import.meta.env.VITE_ROOM_ENDPOINT && import.meta.env.VITE_ROOM_ENDPOINT === 'local';

        console.log(import.meta.env.VITE_ROOM_ENDPOINT)

        const endpoint = isLocal
            ? 'https://api.daily.co/v1/rooms'
            : `${window.location.origin}/Videoconference`;

        //const endpoint = 'https://api.daily.co/v1/rooms'

        const instance = axios.create({
            baseURL: endpoint
        })

        const response = await instance.post('/', options, {
            headers: {
                'Content-Type': 'application/json',
                Authorization: `Bearer ${import.meta.env.VITE_DAILY_API_KEY}`,
            }
        })

        const roomName = response.data.url

        return roomName
    }

    async getRoomUrl(roomName: string) {
        const endpoint: string = 'https://api.daily.co/v1/rooms'

        const api: AxiosInstance = axios.create({
            baseURL: endpoint
        })

        try {
            const response: AxiosResponse = await api.get(`/${roomName}`, {
                headers: {
                    'Content-Type': 'application/json',
                    Authorization: `Bearer ${import.meta.env.VITE_DAILY_API_KEY}`
                }
            })

            const roomUrl: string = response.data.url

            return roomUrl
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