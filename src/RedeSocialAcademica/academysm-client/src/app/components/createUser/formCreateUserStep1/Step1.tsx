import { useEffect } from "react";
import { useForm } from "../../../context/createUserFormContext";
import { FormActions } from '../../../context/infos/createUserFormContextInfos'
import navigateTo from "../../../../infra/navigation/navigation";
import './Step1.css'
import HandleStringChanged, { HandleBooleanChanged, HandleDateChanged, FormatDate } from "../utils/formHandlers";

export default function FormStep1({ nextStep }) {
    const { state, dispatch } = useForm()

    useEffect(() => {
        dispatch({
            type: FormActions.setCurrentStep,
            payload: 1
        })
    }, [dispatch])

    return (
        <div className="cadastroUsuarioForm-1">
            <div className='form-group-createUser'>
                <label>Nome</label>
                <input
                    className='medium'
                    type='text'
                    placeholder="Nome"
                    value={state.fullName}
                    required
                    onChange={e => HandleStringChanged(e, FormActions.setFullName, dispatch)}
                />
            </div>
            <div className='form-group-createUser'>
                <label>E-Mail</label>
                <input
                    className='medium'
                    type='email'
                    placeholder="E-Mail"
                    value={state.email}
                    required
                    onChange={e => HandleStringChanged(e, FormActions.setEmail, dispatch)}
                />
            </div>
            <div className='form-group-createUser'>
                <label>Senha</label>
                <input
                    className='medium'
                    type='password'
                    placeholder="Senha"
                    value={state.password}
                    required
                    onChange={e => HandleStringChanged(e, FormActions.setPassword, dispatch)}
                />
            </div>
            <div className='form-group-createUser'>
                <label>Data de Nascimento</label>
                <input
                    className='medium'
                    type='date'
                    placeholder="Data de Nascimento"
                    required
                    value={state.birthDate ? FormatDate(state.birthDate) : ''}
                    onChange={e => HandleDateChanged(e, FormActions.setBirthDate, dispatch)}
                />
            </div>
            <div>
                <input
                    type='checkbox'
                    checked={state.consentCookie}
                    required
                    onChange={e => HandleBooleanChanged(e, FormActions.setConsentCookie, dispatch)}
                />
                Concordo com o Uso de Cookies Técnicos necessários para a criação e manutenção de minha conta conforme descritos na <a onClick={() => navigateTo('/Privacidade')}>Política de Privacidade</a>
            </div>
            <div>
                <input
                    type='checkbox'
                    checked={state.consentPrivacyPolicy}
                    required
                    onChange={e => HandleBooleanChanged(e, FormActions.setPrivacyPolicy, dispatch)}
                />
                Concordo com os termos descritos na <a onClick={() => navigateTo('/Privacidade')}>Política de Privacidade</a>
            </div>
            <div>
                {nextStep}
            </div>
        </div>
    )
}