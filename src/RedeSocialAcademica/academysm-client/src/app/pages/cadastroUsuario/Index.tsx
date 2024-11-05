import Navbar from '../../components/navbar/index.jsx'
import CourseStatus from '../../components/courseStatus/Index.tsx'
import '../cadastroUsuario/Index.css'
import GrauFormacao from '../../components/formacaoAtual/Index.jsx'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap-icons/font/bootstrap-icons.css'
import 'bootstrap'
import { useState, ChangeEvent, useRef } from 'react'
import EducationalBackground from '../../../domain/models/apis/user/educationalBackground.js'
import ApplicationUser from '../../../domain/models/apis/user/applicationUser.js'
import GroupsApplicationUser from '../../../domain/models/apis/groups/applicationUser.js'
import ProfilePic from '../../../domain/models/apis/user/profilePic.js'
import CadastroUsuarioViewServices from '../../services/cadastroUsuarioViewServices.js'
import navigateTo from '../../../infra/navigation/navigation.js'
import EduBackground from '../../components/educationalBackgrounds/educBackground.js'

export default function CadastroUsuario() {
    const services = new CadastroUsuarioViewServices()

    const [fullName, setFullName] = useState<string>('')
    const[email, setEmail] = useState('')
    const[password, setPassword] = useState('')
    const[birthDate, setBirthDate] = useState<Date | null>(null)
    const[phone, setPhone] = useState('')
    const[educationalDegree, setEducationalDegree] = useState('')
    const[actualCourse, setActualCourse] = useState('')
    const[curriculum, setCurriculum] = useState('')
    const[institution, setInstitution] = useState('')
    const [consentCookies, setConsentCookies] = useState<boolean>(false)
    const[consentPrivacyPolicy, setConsentPrivacyPolicy] = useState<boolean>(false)

    const[course, setCourse] = useState('')
    const[formationEucationalDegree, setFormationEducationalDegree] = useState('')
    const[status, setStatus] = useState('')
    const[FormationInstitution, setFormationInstitution] = useState('')
    const[courseBegin, setCourseBegin] = useState<Date | null>(null)
    const [courseEnd, setCourseEnd] = useState<Date | null>(null)

    const [file, setFile] = useState<File | null>(null)

    const[imageSrc, setImageSrc] = useState<string>('') 

    const fileInputRef = useRef<HTMLInputElement>(null)

    const [educationalBackgroundList, setEducationalBackgroundList] = useState<EducationalBackground[]>([])

    const passwordGenerator = () => {
        navigateTo("/GeradorDeSenhas")
    }

    function handleGrauChange(e: React.ChangeEvent<HTMLSelectElement>) {
        setEducationalDegree(e.target.value)
    }

    function navigate(path: string) {
        navigateTo(path)
    }

    function handleDataChanged(e: ChangeEvent<HTMLInputElement>, functionParameter: Function) {
        const dateValue: string = e.target.value
        const parsedDate: Date = new Date(dateValue)
        functionParameter(parsedDate)
    }

    function handleBooleanChanged(e: ChangeEvent<HTMLInputElement>, functionParameter: Function) {
        const booleanValue: string = e.target.value
        const parsedBoolean: boolean = booleanValue === 'true'
        functionParameter(parsedBoolean)
    }

    function handleDivClick() {
        if(fileInputRef.current) {
            fileInputRef.current.click()
        }
    }

    function handleFileChange(event: React.ChangeEvent<HTMLInputElement>) {
        setFile(event.target.files?.[0])

        if(file) {
            console.log("Arquivo Selecionado.", file.name)
        }
    }

    function addFormationToAList() {
        const formation = new EducationalBackground('', 
            course, 
            formationEucationalDegree, 
            status, 
            FormationInstitution, 
            courseBegin ? new Date(courseBegin) : new Date(), 
            courseEnd ? new Date(courseEnd) : new Date(),
            '')

        setEducationalBackgroundList([...educationalBackgroundList, formation])        
    }

    async function cadastrarUsuario() {
        const applicationUser = new ApplicationUser(
            '',
            fullName,
            email,
            password,
            birthDate ? new Date(birthDate) : new Date(),
            phone,
            educationalDegree,
            actualCourse,
            curriculum,
            institution,
            0,
            consentCookies,
            consentPrivacyPolicy
        )

        const groupsApplicationUser = new GroupsApplicationUser(
            '',
            fullName,
            educationalDegree,
            institution,
            actualCourse,
            imageSrc.toString()
        )

        const profilePicData = new ProfilePic(
            '',
            imageSrc.toString(),
            new Date(Date.now()),
            true,
            ''
        )

        const response: string = await services.create(applicationUser, groupsApplicationUser, educationalBackgroundList, profilePicData, file)

        alert(response)
    }

    return (
        <div>
            <Navbar />
            <div className='centralizador-2 centralizador-3'>
                <div className='cadastroUsuario'>
                    {/* For further information about input's classes, see the documentation.*/}
                    {/* Component Isolation is used for making small margins in the component. */}
                    <h1>Dados Pessoais</h1>
                    <hr />
                    <div className='componentIsolator-1'>
                        <input className='formInputType-1' type='text' placeholder='Nome Completo' onChange={e => setFullName(e.target.value)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <input className='formInputType-1' type='email' placeholder='E-Mail' onChange={e => setEmail(e.target.value)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <input className='formInputType-1' type='password' placeholder='Senha' onChange={e => setPassword(e.target.value)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <input className='formInputType-1' type='date' placeholder='Data de Nascimento' onChange={e => handleDataChanged(e, setBirthDate)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <input className='formInputType-1' type='text' placeholder='Telefone (Com DDD)' onChange={e => setPhone(e.target.value)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <GrauFormacao cssClass='formInputType-1' onChange={e => setEducationalDegree(e.target.value)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <input className='formInputType-1' type='text' placeholder='Curso Atual' onChange={e => setActualCourse(e.target.value)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <textarea className='textArea-1' placeholder='Currículo' onChange={e => setCurriculum(e.target.value)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <input className='formInputType-1' type='text' placeholder='Instituição' onChange={e => setInstitution(e.target.value)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <input type='checkbox' onChange={e => handleBooleanChanged(e, setConsentCookies)} />
                        Concordo com o Uso de Cookies Técnicos necessários para a criação e manutenção de minha conta conforme descritos na <a onClick={() => navigate('/Privacidade')}>Política de Privacidade</a>
                    </div>
                    <div className='componentIsolator-1'>
                        <input type='checkbox' onChange={e => handleBooleanChanged(e, setConsentPrivacyPolicy)} />
                        Concordo com os termos descritos na <a onClick={() => navigate('/Privacidade')}>Política de Privacidade</a>
                    </div>
                    <div className='componentIsolator-1'>
                        <button className='button-large azul-escuro' onClick={cadastrarUsuario}>Cadastrar</button>
                    </div>
                    <div className='componentIsolator-1'>
                        <button className='button-large vermelho' onClick={passwordGenerator}>Gere Aqui a Sua Senha.</button>
                    </div>
                </div>
                <div className='cadastroUsuarioSecond'>
                    <div className='formacoes'>
                        <h1>Formação</h1>
                        <hr />
                        <div className='componentIsolator-1'>
                            <input className='formInputType-1' type='text' name='course' placeholder='Curso' onChange={e => setCourse(e.target.value)} />
                        </div>
                        <div className='componentIsolator-1'>
                            <GrauFormacao cssClass='formInputType-1' onChange={e => setFormationEducationalDegree(e.target.value)} />
                        </div>
                        <div className='componentIsolator-1'>
                            <CourseStatus onChange={e => setStatus(e.target.value)} />
                        </div>
                        <div className='componentIsolator-1'>
                            <input className='formInputType-1' placeholder='Instituição' onChange={e => setFormationInstitution(e.target.value)} />
                        </div>
                        <div className='componentIsolator-1'>
                            <div className='groupInputSameLine-1'>
                                <div className='componentIsolator-1'>
                                    <label>Início: </label><input className='formInputType-3' type='date' name='Inicio' placeholder='Início' onChange={e => handleDataChanged(e, setCourseBegin)} />
                                </div>
                                <div className='componentIsolator-1'>
                                    <label>Fim: </label><input className='formInputType-3' type='date' name='Fim' placeholder='Fim' onChange={e => handleDataChanged(e, setCourseEnd)} />
                                </div>
                                <div className='componentIsolator-1'>
                                    <button className='button-medium vermelho' onClick={addFormationToAList}>Adicionar Formação</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className='profilePic' onClick={handleDivClick}>
                        <input className='profilePicInput' type='file' ref={fileInputRef} onChange={handleFileChange} />
                        <div className='profilePicButton'>
                            <i className="bi bi-plus"></i>
                        </div>
                        <label className='profilePicLabel'>Adicionar Foto de Perfil</label>
                    </div>
                    {educationalBackgroundList ? educationalBackgroundList.map(item => 
                        <EduBackground course={item.getCourse()}
                                       educationalDegree={item.getEducationalDegree()} 
                                       status={item.getStatus()}
                                       institution={item.getInstitution()}
                                       courseBegin={item.getCourseBegin()}
                                       courseEnd={item.getCourseEnd()} 
                        />
                    ) : 
                    <></>}
                </div>
            </div>
        </div>
    )
}