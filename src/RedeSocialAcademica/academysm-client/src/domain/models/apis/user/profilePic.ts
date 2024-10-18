export default class ProfilePic {
    private id: string
    private fileNameAndPath: string
    private dateCreation: Date
    private isActive: boolean
    private userId: string

    constructor(id: string, fileNameAndPath: string, dateCreation: Date, isActive: boolean, userId: string) {
        this.id = id
        this.fileNameAndPath = fileNameAndPath
        this.dateCreation = dateCreation
        this.isActive = isActive
        this.userId = userId
    }

    // Getters
    public getId(): string {
        return this.id;
    }

    public getFileNameAndPath(): string {
        return this.fileNameAndPath;
    }

    public getDateCreation(): Date {
        return this.dateCreation;
    }

    public getIsActive(): boolean {
        return this.isActive;
    }

    public getUserId(): string {
        return this.userId
    }

    // Setters
    public setId(id: string): void {
        this.id = id;
    }

    public setFileNameAndPath(fileNameAndPath: string): void {
        this.fileNameAndPath = fileNameAndPath;
    }

    public setDateCreation(dateCreation: Date): void {
        this.dateCreation = dateCreation;
    }

    public setIsActive(isActive: boolean): void {
        this.isActive = isActive;
    }

    public setUserId(userId: string): void {
        this.userId = userId
    }
}