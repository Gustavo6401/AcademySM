import ApplicationUser from "../../../domain/models/apis/user/applicationUser";
import axios, { AxiosInstance, AxiosResponse } from "axios";
import UserDetailsViewModel from "../../../domain/models/viewModels/userDetailsViewModel";
import FormationsName from "../../../domain/models/viewModels/formationsName";
import LoginViewModel from "../../../domain/models/viewModels/loginViewModel";
import UserCreateResponse from "../../../domain/models/apis/user/userCreateResponse";
import PortfolioCourses from "../../../domain/models/viewModels/portfolio/portfolioCourses";
import PortfolioLink from "../../../domain/models/viewModels/portfolio/portfolioLink";
import ParticipantGroup from "../../../domain/models/viewModels/portfolio/participantGroup";
import UserPortfolio from "../../../domain/models/viewModels/portfolio/userPortfolio";

export default class ApplicationUserAPI {
    async createAsync(user: ApplicationUser): Promise<UserCreateResponse> {
        const bodyRequest = {
            fullName: user.getFullName(),
            email: user.getEmail(),
            password: user.getPassword(),
            birthDate: user.getBirthDate(),
            phone: user.getPhone(),
            educationalDegree: user.getEducationalDegree(),
            actualCourse: user.getActualCourse(),
            curriculum: user.getCurriculum(),
            institution: user.getInstitution(),
            passwordErrors: user.getPasswordErrors(),
            consentPrivacyPolicy: user.getConsentPrivacyPolicy(),
            consentCookies: user.getConsentCookies()
        }

        let api = axios.create({
            baseURL: import.meta.env.VITE_USER_API,
            withCredentials: true
        })

        try {
            const response: AxiosResponse = await api.post('/api/User', bodyRequest)

            return new UserCreateResponse(response.data.message, response.data.userId)

        } catch (error) {
            console.error('Erro ao Fazer a Requisição: ', error)

            throw error
        }
    }

    async deleteAsync(id: string) {
        let api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_USER_API,
            withCredentials: true
        })

        try {
            await api.delete(`/api/User?id=${id}`)
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

    async getByEmailAsync(email: string): Promise<ApplicationUser> {
        let api = axios.create({
            baseURL: import.meta.env.VITE_USER_API
        })

        try {
            const resultado: AxiosResponse = await api.get(`/api/User/GetByEmail?email=${email}`)

            const response: any = resultado.data

            const applicationUserResponse: ApplicationUser = new ApplicationUser(response.id, response.fullName,
                response.email, response.password, response.birthDate, response.phone,
                response.educationalDegree, response.actualCourse, response.curriculum, response.institution,
                    response.passwordErrors, response.consentPrivacyPolicy, response.consentCookies)

            return applicationUserResponse
        } catch (error) {
            console.error('Erro ao Fazer a Requisição', error)
            throw error
        }
    }

    async getAsync(id: string) {
        let api = axios.create({
            baseURL: import.meta.env.VITE_USER_API
        })

        try {
            const resultado = await api.get(`/api/User?id=${id}`)

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

    async loginAsync(email: string, password: string) : Promise<LoginViewModel> {
        const bodyRequest = {
            email: email,
            password: password
        }

        let api = axios.create({
            baseURL: import.meta.env.VITE_USER_API,
            withCredentials: true
        })

        try {
            const resultado = await api.post(`/api/User/Login`, bodyRequest)

            const response: any = resultado.data

            const loginReturn: LoginViewModel = new LoginViewModel(response.id, response.userFullName,
                                                response.userProfilePicPath, response.returnMessage)

            return loginReturn
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

    async modifyAuthCookie(userId: string) : Promise<void> {
        let api = axios.create({
            baseURL: import.meta.env.VITE_USER_API,
            withCredentials: true
        })

        try {
            await api.post('/ModifyAuthCookie', '', {
                headers: {
                    'userId': userId
            } })
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

    async ownProile(id: string): Promise<string> {
        let api: AxiosInstance = axios.create({
            baseURL: import.meta.env.VITE_USER_API
        })

        try {
            const resultado: AxiosResponse = await api.get(`/api/User/OwnProfile?id=${id}`)

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

    async portfolio(id: string): Promise<UserPortfolio> {
        let api = axios.create({
            baseURL: import.meta.env.VITE_USER_API
        })

        try {
            const resultado: AxiosResponse = await api.get(`/Portfolio?id=${id}`)

            const response: any = resultado.data
            const educationalBackgrounds: Array<any> = response.courses // User's educational backgrounds
            const links: Array<any> = response.links // User's links.
            const academySMGroups: Array<any> = response.academySMGroups // Groups that a user is in Academy SM.

            const listEducationalBackgrounds: Array<PortfolioCourses> = educationalBackgrounds.map((json: any) =>
                new PortfolioCourses(json.courseId, json.name))

            const listLinks: Array<PortfolioLink> = links.map((json: any) =>
                new PortfolioLink(json.id, json.name, json.origin, json.link))

            const listAcademySMGroups: Array<ParticipantGroup> = academySMGroups.map((json: any) =>
                new ParticipantGroup(json.groupId, json.groupName, json.role, json.categoryIcon))

            return new UserPortfolio(response.userId, response.userName, response.curriculum,
                response.profilePic, listEducationalBackgrounds, listLinks, listAcademySMGroups)
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

    async userDetails(id: string): Promise<UserDetailsViewModel> {
        let api = axios.create({
            baseURL: import.meta.env.VITE_USER_API
        })

        try {
            const resultado = await api.get(`/UserDetails?id=${id}`)

            // Gets the formations results. We can't do this directly in the object.
            const formationsArrayJson: Array<any> = resultado.data.formations

            const formationsArray: Array<FormationsName> = formationsArrayJson.map((formationJson: any) =>
                new FormationsName(formationJson.id, formationJson.name)
            )

            const response: UserDetailsViewModel = new UserDetailsViewModel(resultado.data.id,
                resultado.data.fullName,
                resultado.data.formation,
                resultado.data.profilePicFileName,
                formationsArray)

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
}