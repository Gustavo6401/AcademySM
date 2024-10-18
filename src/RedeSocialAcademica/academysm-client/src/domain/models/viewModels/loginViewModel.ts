export default class LoginViewModel {
    private id: string
    private userFullName: string
    private userProfilePicPath: string
    private returnMessage: string

    constructor(id: string, userFullName: string, userProfilePicPath: string, returnMessage: string) {
        this.id = id
        this.userFullName = userFullName
        this.userProfilePicPath = userProfilePicPath
        this.returnMessage = returnMessage
    }

    // Getters
    public getId(): string {
        return this.id;
    }

    public getUserFullName(): string {
        return this.userFullName;
    }

    public getUserProfilePicPath(): string {
        return this.userProfilePicPath;
    }

    public getReturnMessage(): string {
        return this.returnMessage;
    }

    // Setters
    public setId(id: string): void {
        this.id = id;
    }

    public setUserFullName(userFullName: string): void {
        this.userFullName = userFullName;
    }

    public setUserProfilePicPath(userProfilePicPath: string): void {
        this.userProfilePicPath = userProfilePicPath;
    }

    public setReturnMessage(returnMessage: string): void {
        this.returnMessage = returnMessage;
    }
}