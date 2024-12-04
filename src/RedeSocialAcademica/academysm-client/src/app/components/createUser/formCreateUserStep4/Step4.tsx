import { useEffect, useState } from "react"
import { useForm } from "../../../context/createUserFormContext"
import { FormActions } from "../../../context/infos/createUserFormContextInfos"
import Links from "../../../../domain/models/apis/user/links"

export default function FormStep4({ nextStep, skipStep }) {
    const { state, dispatch } = useForm()

    const [profileName, setProfileName] = useState<string>('')
    const [origin, setOrigin] = useState<string>('Portfólio')
    const [link, setLink] = useState<string>('')
    const [links, setLinks] = useState<Array<Links>>(new Array<Links>())

    useEffect(() => {
        dispatch({
            type: FormActions.setCurrentStep,
            payload: 4
        })
    }, [dispatch])

    const handleLinksChanged: () => void = () => {
        let linkInformation: Links = new Links(0, profileName, origin, link, '')

        state.links.push(linkInformation)
        setLinks([...links, linkInformation])

        alert('Link Adicionado! 😁')
    }

    /**
     * en
     * Similar to Step3.modifyEducationalBackgrounds(index: number) => void
     * 
     * pt-br
     * Semelhante a Step3.modifyEducationalBackgrounds(index: number) => void
     */
    const modifyLinks = (index: number) => {
        let linkInformation: Links = links[index]

        setProfileName(linkInformation.getProfileName())
        setOrigin(linkInformation.getOrigin())
        setLink(linkInformation.getLink())

        let linksArray: Array<Links> = state.links.splice(index, 1)
        setLinks(linksArray)
    }

    const deleteLinks = (index: number) => {
        let linksArray: Array<Links> = state.links.splice(index, 1)
        setLinks(linksArray)
    }

    return (
        <div>
            <div className='cadastroUsuarioForm-1'>
                <div className='form-group-createUser'>
                    <label>Nome do Perfil</label>
                    <input
                        className='medium'
                        type='text'
                        value={profileName}
                        placeholder='Nome do Perfil'
                        onChange={e => setProfileName(e.target.value)}
                    />
                </div>
                <div className='form-group-createUser'>
                    <label>Origem</label>
                    <select
                        className='medium'
                        value={origin}
                        onChange={e => setOrigin(e.target.value)}>
                        <option>Github</option>
                        <option>YouTube</option>
                        <option>Linkedin</option>
                        <option selected>Portfólio</option>
                        <option>Facebook</option>
                        <option>Amazon</option>
                        <option>Gitlab</option>
                        <option>Bing</option>
                        <option>Google</option>
                        <option>Instagram</option>
                        <option>Outro</option>
                    </select>
                </div>
                <div className='form-group-createUser'>
                    <label>Link</label>
                    <input
                        className='medium'
                        type='text'
                        value={link}
                        placeholder='Link'
                        onChange={e => setLink(e.target.value)}
                    />
                </div>
                <div>
                    <button
                        className='large preto'
                        onClick={handleLinksChanged}>
                        Adicionar Link
                    </button>
                </div>
                <div className='createUserButtons'>
                    {skipStep}
                    {nextStep}
                </div>
            </div>
            {links ? links.map((linkInformation: Links, index: number) =>
                <div className='cadastroUsuarioViewInfos'>
                    <label>Nome do Perfil: {linkInformation.getProfileName()}</label>
                    <label>Origem: {linkInformation.getOrigin()}</label>
                    <label>link: <a href={linkInformation.getLink()}>{linkInformation.getOrigin()}</a></label>
                    <div>
                        <button
                            className='medium amarelo'
                            onClick={() => modifyLinks(index)}>
                            <i className='bi bi-pencil-fill'></i>
                        </button>
                        <button
                            className='medium bordo'
                            onClick={() => deleteLinks(index)}>
                            <i className='bi bi-trash-fill'></i>
                        </button>
                    </div>
                </div>
            ) : 'Carregando...'}
        </div>
    )
}