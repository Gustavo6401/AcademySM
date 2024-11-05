export default class ApplicationUser {
    private id: string = ""
    private fullName: string
    private email: string
    private password: string
    private birthDate: Date
    private phone: string
    private educationalDegree: string
    private actualCourse: string
    private curriculum: string
    private institution: string
    private passwordErrors: number = 0
    private consentCookie: boolean = false
    private consentPrivacyPolicy: boolean = false

    constructor(id: string, fullName: string, email: string, password: string, birthDate: Date, phone: string,
        educationalDegree: string, actualCourse: string, curriculum: string, institution: string,
        passwordErrors: number, consentCookie: boolean, consentPrivacyPolicy: boolean) {
        this.id = id
        this.fullName = fullName
        this.email = email
        this.password = password
        this.birthDate = birthDate
        this.phone = phone
        this.educationalDegree = educationalDegree
        this.actualCourse = actualCourse
        this.curriculum = curriculum
        this.institution = institution
        this.passwordErrors = passwordErrors
        this.consentCookie = consentCookie
        this.consentPrivacyPolicy = consentPrivacyPolicy
    }

    getId(): string {
        return this.id
    }

    getFullName(): string {
        return this.fullName
    }

    getEmail(): string {
        return this.email
    }

    getPassword(): string {
        return this.password
    }

    getBirthDate(): Date {
        return this.birthDate
    }

    getPhone(): string {
        return this.phone
    }

    getEducationalDegree(): string {
        return this.educationalDegree
    }

    getActualCourse(): string {
        return this.actualCourse
    }

    getCurriculum(): string {
        return this.curriculum
    }

    getInstitution(): string {
        return this.institution
    }

    getPasswordErrors(): number {
        return this.passwordErrors
    }

    getConsentCookies(): boolean {
        return this.consentCookie
    }

    getConsentPrivacyPolicy(): boolean {
        return this.consentPrivacyPolicy
    }
}