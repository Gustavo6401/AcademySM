import { useEffect } from "react"
import { useForm } from "../../../context/createUserFormContext"
import { FormActions } from "../../../context/infos/createUserFormContextInfos"
import HandleStringChanged, { HandleStringSelectChanged, HandleStringTextAreaChanged } from "../utils/formHandlers"

export default function FormStep2({ nextStep, skipStep }) {
    const { state, dispatch } = useForm()

    useEffect(() => {
        dispatch({
            type: FormActions.setCurrentStep,
            payload: 2
        })
    }, [dispatch])

    return (
        <div className='cadastroUsuarioForm-1'>
            <div className='form-group-createUser'>
                <label>Telefone</label>
                <input
                    className='medium'
                    type='tel'
                    placeholder='Telefone'
                    value={state.phone}
                    onChange={e => HandleStringChanged(e, FormActions.setPhone, dispatch)}
                />
            </div>
            <div className='form-group-createUser'>
                <label>Curso Atual</label>
                <input
                    className='medium'
                    type='text'
                    placeholder='Curso Atual'
                    value={state.actualCourse}
                    onChange={e => HandleStringChanged(e, FormActions.setActualCourse, dispatch)}
                />
            </div>
            <div className='form-group-createUser'>
                <label>Grau Educacional</label>
                <select
                    className='medium'
                    value={state.educationalDegree}
                    onChange={e => HandleStringSelectChanged(e, FormActions.setEducationalDegree, dispatch)}
                >
                    <option value={'Ensino Fundamental 1'}>Ensino Fundamental 1</option>
                    <option value={'Ensino Fundamental 2'}>Ensino Fundamental 2</option>
                    <option value={'Ensino Médio'}>Ensino Médio</option>
                    <option value={'Ensino Médio Técnico'}>Ensino Médio Técnico</option>
                    <option value={'Ensino Superior'} selected>Ensino Superior</option>
                    <option value={'Pós-Graduação'}>Pós-Graduação</option>
                    <option value={'Mestrado'}>Mestrado</option>
                    <option value='Doutorado'>Doutorado</option>
                </select>
            </div>
            <div className='form-group-createUser'>
                <label>Instituição</label>
                <input
                    className='medium'
                    type='text'
                    placeholder='Instituição'
                    value={state.institution}
                    onChange={e => HandleStringChanged(e, FormActions.setInstitution, dispatch)}
                />
            </div>
            <div className='form-group-createUser'>
                <label>Currículo</label>
                <textarea
                    className='medium'
                    placeholder='Currículo'
                    value={state.curriculum}
                    onChange={e => HandleStringTextAreaChanged(e, FormActions.setCurriculum, dispatch)}
                >
                </textarea>
            </div>
            <div className='createUserButtons'>
                {skipStep}
                {nextStep}
            </div>
        </div>
    )
}