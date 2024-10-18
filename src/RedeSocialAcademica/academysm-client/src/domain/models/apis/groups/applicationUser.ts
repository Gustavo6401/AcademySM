export default class GroupsApplicationUser {
    private id: string
    private name: string
    private educationalBackground: string
    private institution: string
    private courseName: string
    private profilePicFilePath: string

    constructor(id: string, name: string, educationalBackground: string, institution: string, courseName: string,
        profilePicFilePath: string
    ) {
        this.id = id
        this.name = name
        this.educationalBackground = educationalBackground
        this.institution = institution
        this.courseName = courseName
        this.profilePicFilePath = profilePicFilePath
    }

    // Getters
    public getId(): string {
        return this.id;
    }

    public getName(): string {
        return this.name;
    }

    public getEducationalBackground(): string {
        return this.educationalBackground;
    }

    public getInstitution(): string {
        return this.institution;
    }

    public getCourseName(): string {
        return this.courseName;
    }

    public getProfilePicFilePath(): string {
        return this.profilePicFilePath;
    }

    // Setters
    public setId(id: string): void {
        this.id = id;
    }

    public setName(name: string): void {
        this.name = name;
    }

    public setEducationalBackground(educationalBackground: string): void {
        this.educationalBackground = educationalBackground;
    }

    public setInstitution(institution: string): void {
        this.institution = institution;
    }

    public setCourseName(courseName: string): void {
        this.courseName = courseName;
    }

    public setFunds(profilePicFilePath: string): void {
        this.profilePicFilePath = profilePicFilePath;
    }


}