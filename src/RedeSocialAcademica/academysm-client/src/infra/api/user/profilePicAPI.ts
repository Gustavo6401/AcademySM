import axios, { AxiosInstance, AxiosResponse } from "axios";
import ProfilePic from "../../../domain/models/apis/user/profilePic";

export default class ProfilePicAPI {
    private api: AxiosInstance = axios.create({
        baseURL: import.meta.env.VITE_USER_API,
        withCredentials: true
    })

    async createAsync(profilePic: ProfilePic) {
        const bodyRequest = {
            fileNameAndPath: profilePic.getFileNameAndPath(),
            dateCreation: profilePic.getDateCreation(),
            isActive: true,
            userId: profilePic.getUserId()
        }

        try {
            const resultado: AxiosResponse = await this.api.post("/api/ProfilePic", bodyRequest)

            return resultado.data
        } catch (error) {
            console.log('Erro ao Fazer a Requisição', error)
            throw error
        }
    }
}