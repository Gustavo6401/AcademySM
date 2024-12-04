import axios, { AxiosInstance, AxiosResponse } from "axios";
import Room from "../../../domain/models/apis/groups/mongo/room";

export default class RoomsAPI {
    async createAsync(room: Room) {
        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_GROUPS_API,
            withCredentials: true
        })

        const bodyRequest = {
            groupId: room.getGroupId(),
            roomId: room.getRoomId(),
            dateCreation: room.getDateCreation()
        }

        try {
            const result: AxiosResponse = await api.post('/api/Rooms', bodyRequest) // Cores
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

    /**
     *  
     * @param groupId
     * @returns
     * 
     * Gets the Room Name, and prepares to get roomsUrl.
     */
    async getAsync(groupId: string): Promise<string> {
        const api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_GROUPS_API,
            withCredentials: true
        })

        try {
            const response: AxiosResponse = await api.get(`/api/Rooms?groupId=${groupId}`)

            const roomName: string = response.data

            return roomName
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