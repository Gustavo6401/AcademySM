import { useEffect, useState } from "react";
import { useForm } from "../../../context/createUserFormContext";
import { FormActions } from "../../../context/infos/createUserFormContextInfos";
import EducationalBackground from "../../../../domain/models/apis/user/educationalBackground";
import { FormatDate } from "../utils/formHandlers";

export default function Step3({ nextStep, skipStep }) {
    const [course, setCourse] = useState<string>('')
    const [educationalDegree, setEducationalDegree] = useState<string>('Ensino Superior')
    const [status, setStatus] = useState<string>('Concluído')
    const [institution, setInstitution] = useState<string>('')
    const [courseBegin, setCourseBegin] = useState<Date>(new Date())
    const [courseEnd, setCourseEnd] = useState<Date>(new Date())
    const [educationalBackgrounds, setEducationalBackgrounds] = useState<Array<EducationalBackground>>(new Array<EducationalBackground>())

    const { state, dispatch } = useForm()

    useEffect(() => {
        dispatch({
            type: FormActions.setCurrentStep,
            payload: 3
        })
    }, [dispatch])

    const handleEducationalBackgroundsChanged: () => void = () => {
        let educationalBackground: EducationalBackground = new EducationalBackground('', course,
            educationalDegree, status, institution, courseBegin, courseEnd, '')

        state.educationalBackgrounds.push(educationalBackground)
        setEducationalBackgrounds([...educationalBackgrounds, educationalBackground])

        alert('Formação Adicionada! 😁')
    }

    const modifyEducationalBackgrounds = (index: number) => {
        /**
         * en
         * Search an Element based in its index.
         * 
         * pt-br
         * Busca um elemento baseado no seu índice.
         */
        let educationalBackground: EducationalBackground = educationalBackgrounds[index]

        /**
         * en
         * Updates the state
         * 
         * pt-Br
         * Atualiza o Estado.
         */
        setCourse(educationalBackground.getCourse())
        setInstitution(educationalBackground.getInstitution())
        setEducationalDegree(educationalBackground.getEducationalDegree())
        setStatus(educationalBackground.getStatus())
        setCourseBegin(educationalBackground.getCourseBegin())
        setCourseEnd(educationalBackground.getCourseEnd())

        /**
         * en
         * Deletes the Educational Background from educationalBackground array.
         * 
         * pt-Br
         * Remove o grau educacional do vetor de grais educacionais.
         */
        let educationalBackgroundsArray: Array<EducationalBackground> = state.educationalBackgrounds.splice(index, 1)
        setEducationalBackgrounds(educationalBackgroundsArray)
    }

    const deleteEducationalBackgrounds = (index: number) => {
        let educationalBackgroundsArray: Array<EducationalBackground> = state.educationalBackgrounds.splice(index, 1)
        setEducationalBackgrounds(educationalBackgroundsArray)
    }

    return (
        <div>
            <div className='cadastroUsuarioForm-1'>
                <div className='form-group-createUser'>
                    <label>Curso</label>
                    <input
                        className='medium'
                        type='text'
                        value={course}
                        placeholder='Curso'
                        onChange={e => setCourse(e.target.value)}
                    />
                </div>
                <div className='form-group-createUser'>
                    <label>Instituição</label>
                    <input
                        className='medium'
                        value={institution}
                        type='text'
                        placeholder='Instituição'
                        onChange={e => setInstitution(e.target.value)}
                    />
                </div>
                <div className='form-group-createUser'>
                    <label>Grau de Escolaridade</label>
                    <select
                        className='medium'
                        value={educationalDegree}
                        defaultValue='Ensino Superior'
                        onChange={e => setEducationalDegree(e.target.value)}
                    >
                        <option value={'Ensino Fundamental 1'}>Ensino Fundamental 1</option>
                        <option value={'Ensino Fundamental 2'}>Ensino Fundamental 2</option>
                        <option value={'Ensino Médio'}>Ensino Médio</option>
                        <option value={'Ensino Médio Técnico'}>Ensino Médio Técnico</option>
                        <option value={'Ensino Superior'}>Ensino Superior</option>
                        <option value={'Pós-Graduação'}>Pós-Graduação</option>
                        <option value={'Mestrado'}>Mestrado</option>
                        <option value='Doutorado'>Doutorado</option>
                    </select>
                </div>
                <div className='form-group-createUser'>
                    <label>Status</label>
                    <select
                        className='medium'
                        value={status}
                        onChange={e => setStatus(e.target.value)}
                        defaultValue='Concluído'
                    >
                        <option value={'Concluído'}>Concluído</option>
                        <option value={'Trancado'}>Trancado</option>
                        <option value={'Cursando'}>Cursando</option>
                    </select>
                </div>
                <div className='form-group-createUser'>
                    <label>Início</label>
                    <input
                        className='medium'
                        type='date'
                        value={courseBegin ? FormatDate(courseBegin) : ''}
                        onChange={e => setCourseBegin(e.target.valueAsDate || new Date())}
                    />
                </div>
                <div className='form-group-createUser'>
                    <label>Fim</label>
                    <input
                        className='medium'
                        value={courseEnd ? FormatDate(courseEnd): ''}
                        type='date'
                        onChange={e => setCourseEnd(e.target.valueAsDate || new Date())}
                    />
                </div>
                <div>
                    <button
                        className='large preto'
                        onClick={handleEducationalBackgroundsChanged}>
                        Adicionar Formação
                    </button>
                </div>
                <div className='createUserButtons'>
                    {skipStep}
                    {nextStep}
                </div>
            </div>
            {educationalBackgrounds ? educationalBackgrounds.map((item: EducationalBackground, index: number) =>
                <div className='cadastroUsuarioViewInfos'>
                    <label>Curso: {item.getCourse()}</label>
                    <label>Instituição: {item.getInstitution()}</label>
                    <label>Grau de Escolaridade: {item.getEducationalDegree()}</label>
                    <label>Status: {item.getStatus()}</label>
                    <label>Início: {new Date(item.getCourseBegin()).getDate() + 1}/{new Date(item.getCourseBegin()).getMonth() + 1}/{new Date(item.getCourseBegin()).getFullYear()}</label>
                    <label>Fim: {new Date(item.getCourseEnd()).getDate() + 1}/{new Date(item.getCourseEnd()).getMonth() + 1}/{new Date(item.getCourseEnd()).getFullYear()}</label>
                    <div>
                        <button
                            className='medium amarelo'
                            onClick={() => modifyEducationalBackgrounds(index)}>
                            <i className='bi bi-pencil-fill'></i>
                        </button>
                        <button
                            className='medium bordo'
                            onClick={() => deleteEducationalBackgrounds(index)}>
                            <i className='bi bi-trash-fill'></i>
                        </button>
                    </div>
                </div>
            )
                : 'Nenhuma Formação Disponível'}
        </div>
    )
}