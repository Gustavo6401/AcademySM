import FormationsName from "./formationsName"

export default class UserDetailsViewModel {
    private id: string
    private fullName: string
    private formation: string
    private profilePicFileName: string
    private formations: Array<FormationsName>

    constructor(id: string, fullName: string, formation: string, profilePicFileName: string, 
        formations: Array<FormationsName>) {
        this.id = id
        this.fullName = fullName
        this.formation = formation
        this.profilePicFileName = profilePicFileName
        this.formations = formations
    }

    // Getters
    public getId(): string {
        return this.id;
    }

    public getFullName(): string {
        return this.fullName;
    }

    public getFormation(): string {
        return this.formation;
    }

    public getProfilePicFileName(): string {
        return this.profilePicFileName;
    }

    public getFormations(): Array<FormationsName> {
        return this.formations;
    }

    // Setters
    public setId(id: string): void {
        this.id = id;
    }

    public setFullName(fullName: string): void {
        this.fullName = fullName;
    }

    public setFormation(formation: string): void {
        this.formation = formation;
    }

    public setProfilePicFileName(profilePicFileName: string): void {
        this.profilePicFileName = profilePicFileName;
    }

    public setFormations(formations: Array<FormationsName>): void {
        this.formations = formations;
    }
}