import EducationalBackground from "../../../domain/models/apis/user/educationalBackground";
import Links from "../../../domain/models/apis/user/links";
import { CreateUserViewModel } from "../../../domain/models/viewModels/createUserViewModel";

export type State = {
    currentStep: number
    id: string
    fullName: string
    email: string
    password: string
    birthDate: Date
    phone: string
    educationalDegree: string
    actualCourse: string
    curriculum: string
    institution: string
    passwordErrors: number
    consentCookie: boolean
    consentPrivacyPolicy: boolean
    educationalBackgrounds: Array<EducationalBackground>
    links: Array<Links>
    profilePicFileName: string
    dateCreation: Date
    isActive: boolean
    file: File | undefined
}

export const initialData: CreateUserViewModel = {
    currentStep: 1,
    id: '',
    fullName: '',
    email: '',
    password: '',
    birthDate: new Date('2024-11-14T11:05:37'),
    phone: '',
    educationalDegree: '',
    actualCourse: '',
    curriculum: '',
    institution: '',
    passwordErrors: 0,
    consentCookie: false,
    consentPrivacyPolicy: false,
    educationalBackgrounds: new Array<EducationalBackground>(),
    links: new Array<Links>(),
    profilePicFileName: '',
    dateCreation: new Date('2024-11-14T11:05:37'),
    isActive: false,
    file: undefined
}

export var currentStep: number = 0

export enum FormActions {
    setCurrentStep,
    setId,
    setFullName,
    setEmail,
    setPassword,
    setBirthDate,
    setPhone,
    setEducationalDegree,
    setActualCourse,
    setCurriculum,
    setInstitution,
    setPasswordErrors,
    setConsentCookie,
    setPrivacyPolicy,
    setEducationalBackgrounds,
    setLinks,
    setProfilePicFileName,
    setDateCreation,
    setIsActive,
    setFile
}

export type Action = {
    type: FormActions,
    payload: any
}

export type ContextType = {
    state: CreateUserViewModel,
    dispatch: (action: Action) => void
}