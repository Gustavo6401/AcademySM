import EducationalBackground from "../apis/user/educationalBackground"
import Links from "../apis/user/links"

export type CreateUserViewModel = {
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