import { ReactNode, createContext, useContext, useReducer } from "react";
import * as Strategies from './formReducerStrategy/createUser/strategy/index'
import ICreateUserStrategy from "./formReducerStrategy/createUser/ICreateUserStrategy";
import { FormActions, initialData, Action, ContextType, State } from './infos/createUserFormContextInfos'

const FormContext = createContext<ContextType | undefined>(undefined)

function FormReducer(state: State, action: Action) {
    const mapReducers = new Map<FormActions, ICreateUserStrategy>()
    mapReducers.set(FormActions.setActualCourse, new Strategies.SetActualCourseStrategy())
    mapReducers.set(FormActions.setBirthDate, new Strategies.SetBirthDateStrategy())
    mapReducers.set(FormActions.setConsentCookie, new Strategies.SetConsentCookieStrategy())
    mapReducers.set(FormActions.setCurrentStep, new Strategies.SetCurrentStepStrategy())
    mapReducers.set(FormActions.setCurriculum, new Strategies.SetCurriculumStrategy())
    mapReducers.set(FormActions.setDateCreation, new Strategies.SetDateCreationStrategy())
    mapReducers.set(FormActions.setEducationalBackgrounds, new Strategies.SetEducationalBackgroundStrategy())
    mapReducers.set(FormActions.setEducationalDegree, new Strategies.SetEducationalDegree())
    mapReducers.set(FormActions.setEmail, new Strategies.SetEmailStrategy())
    mapReducers.set(FormActions.setFile, new Strategies.SetFileStrategy())
    mapReducers.set(FormActions.setFullName, new Strategies.SetFullNameStrategy())
    mapReducers.set(FormActions.setId, new Strategies.SetIdStrategy())
    mapReducers.set(FormActions.setInstitution, new Strategies.SetInstitutionStrategy())
    mapReducers.set(FormActions.setIsActive, new Strategies.SetIsActiveStrategy())
    mapReducers.set(FormActions.setLinks, new Strategies.SetLinksStrategy())
    mapReducers.set(FormActions.setPassword, new Strategies.SetPasswordStrategy())
    mapReducers.set(FormActions.setPasswordErrors, new Strategies.SetPasswordErrorsStrategy())
    mapReducers.set(FormActions.setPhone, new Strategies.SetPhoneStrategy())
    mapReducers.set(FormActions.setPrivacyPolicy, new Strategies.SetPrivacyPolicyStrategy())
    mapReducers.set(FormActions.setProfilePicFileName, new Strategies.SetProfilePicStrategy())

    /**
     * en
     * Map is a JavaScript data structure, similar to dictionaries. My main goal is to verify each one
     * of the keys in my dictionary, more specifity, the FormAction enum keys. 
     * 
     * (if action.type === key) 
     *      then return resp and edit user's data.
     * 
     * pt-br
     * Map é uma estrutura de dados do JavaScript muito parecida com os dicionários. Meu objetivo é
     * verificar cada item do enum. Se algum item for igual à variável action.type que nada mais são do
     * que os tipos da ação, eu edito os dados inseridos no useReducer.
     */
    for (const [key, value] of mapReducers) {
        if (key === action.type) {
            var resp = value.validate(state, key, action.payload)

            /**
             * en
             * Returns data, already modified.
             * 
             * pt-br
             * Retorna os dados já alterados.
             */
            return resp
        }
    }

    /**
     * en
     * Returns actual state if it hasn't any modifications.
     * 
     * pt-br
     * Retorna o estado atual se não tiver nenhuma modificação.
     */
    return state
}

export default function FormProvider({ children }: { children: ReactNode }) {
    const [state, dispatch] = useReducer(FormReducer, initialData)
    const value = { state, dispatch }

    return (
        <FormContext.Provider value={value}>
            {children}
        </FormContext.Provider>
    )
}

export const useForm = () => {
    const context = useContext(FormContext)
    if (context === undefined) {
        throw new Error('useForm Precisa ser usado dentro do FormProvider')
    }

    return context
}