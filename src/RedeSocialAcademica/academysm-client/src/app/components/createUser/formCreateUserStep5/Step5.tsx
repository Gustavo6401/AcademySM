import { useEffect } from "react"
import { useForm } from "../../../context/createUserFormContext"
import { FormActions } from "../../../context/infos/createUserFormContextInfos"
import { ConvertBoolean, HandleProfilePicChange, VerifyWhetherStringIsEmpty } from "../utils/formHandlers"
import EducationalBackground from "../../../../domain/models/apis/user/educationalBackground"
import Links from "../../../../domain/models/apis/user/links"
import ApplicationUser from "../../../../domain/models/apis/user/applicationUser"
import GroupsApplicationUser from "../../../../domain/models/apis/groups/applicationUser"
import ProfilePic from "../../../../domain/models/apis/user/profilePic"
import CadastroUsuarioViewServices from "../../../services/cadastroUsuarioViewServices"

export default function FormStep5() {
    const { state, dispatch } = useForm()
    const services: CadastroUsuarioViewServices = new CadastroUsuarioViewServices()

    useEffect(() => {
        dispatch({
            type: FormActions.setCurrentStep,
            payload: 5
        })
    }, [dispatch])

    async function CadastrarUsuario() {
        let applicationUser: ApplicationUser = new ApplicationUser('', state.fullName, state.email, state.password,
            state.birthDate, state.phone, state.educationalDegree, state.actualCourse, state.curriculum,
            state.institution, state.passwordErrors, state.consentCookie, state.consentPrivacyPolicy)

        let groupsApplicationUser: GroupsApplicationUser = new GroupsApplicationUser('', state.fullName,
            state.educationalDegree, state.institution, state.actualCourse, state.profilePicFileName)

        let profilePicData: ProfilePic = new ProfilePic('', state.profilePicFileName, new Date(Date.now()), true, '')

        const response: string = await services.create(applicationUser, groupsApplicationUser, state.educationalBackgrounds,
            profilePicData, state.file, state.links)

        alert(response)
    }

    return (
        <div>
            <div className='cadastroUsuarioViewInfos'>
                <h3>Principais Informações</h3>
                <label>Nome Completo: {state.fullName}</label>
                <label>E-Mail: {state.email}</label>
                <label>Data de Nascimento: {new Date(state.birthDate).getDate() + 1}/{new Date(state.birthDate).getMonth() + 1}/{new Date(state.birthDate).getFullYear()}</label>
                <label>Aceita os Cookies: {ConvertBoolean(state.consentCookie)}</label>
                <label>Aceita a Política de Privacidade: {ConvertBoolean(state.consentPrivacyPolicy)}</label>
            </div>
            <div className='cadastroUsuarioViewInfos'>
                <h3>Informações Secundárias</h3>
                <label>Telefone: {VerifyWhetherStringIsEmpty(state.phone)}</label>
                <label>Curso Atual: {VerifyWhetherStringIsEmpty(state.actualCourse)}</label>
                <label>Status do Curso: {VerifyWhetherStringIsEmpty(state.educationalDegree)}</label>
                <label>Instituição: {VerifyWhetherStringIsEmpty(state.institution)}</label>
                <label>Currículo: {VerifyWhetherStringIsEmpty(state.curriculum)}</label>
            </div>
            {state.educationalBackgrounds ? state.educationalBackgrounds.map(
                (educationalBackground: EducationalBackground, index: number) =>
                    <div className='cadastroUsuarioViewInfos'>
                        <h3>Formação Nº {index}</h3>
                        <label>Curso: {educationalBackground.getCourse()}</label>
                        <label>Instituição: {educationalBackground.getInstitution()}</label>
                        <label>Grau de Escolaridade: {educationalBackground.getEducationalDegree()}</label>
                        <label>Status do Curso: {educationalBackground.getStatus()}</label>
                        <label>Início: {new Date(educationalBackground.getCourseBegin()).getDate() + 1}/{new Date(educationalBackground.getCourseBegin()).getMonth() + 1}/{new Date(educationalBackground.getCourseBegin()).getFullYear()}</label>
                        <label>Fim: {new Date(educationalBackground.getCourseEnd()).getDate() + 1}/{new Date(educationalBackground.getCourseEnd()).getMonth() + 1}/{new Date(educationalBackground.getCourseEnd()).getFullYear()}</label>
                    </div>
            ) : 'Carregando'}
            {state.links ? state.links.map(
                (link: Links, index: number) =>
                    <div className='cadastroUsuarioViewInfos'>
                        <h3>Link Nº {index}</h3>
                        <label>Nome do Perfil: {link.getProfileName()}</label>
                        <label>Origem: {link.getOrigin()}</label>
                        <label>Link: <a href={link.getLink()}>{link.getLink()}</a></label>
                    </div>
            ) : 'Carregando'}
            <div className='cadastroUsuarioViewInfos'>
                <h3>Adicionar Foto de Perfil.</h3>
                <input 
                    type='file'
                    placeholder='Adicionar Foto de Perfil.'
                    onChange={e => HandleProfilePicChange(e, FormActions.setProfilePicFileName, dispatch)}
                />
            </div>
            <div className='cadastroUsuarioViewInfos2'>
                <button
                    className='large azul-escuro'
                    onClick={CadastrarUsuario}>
                    Cadastrar Usuário
                </button>
            </div>
        </div>
    )
}