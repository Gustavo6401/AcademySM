export default class Links {
    private id: number
    private profileName: string
    private origin: string
    private link: string
    private userId: string
    constructor(id: number, profileName: string, origin: string, link: string, userId: string) {
        this.id = id
        this.profileName = profileName
        this.origin = origin
        this.link = link
        this.userId = userId
    }
    // Getters
    public getId(): number {
        return this.id;
    }

    public getProfileName(): string {
        return this.profileName
    }

    public getOrigin(): string {
        return this.origin;
    }

    public getLink(): string {
        return this.link;
    }

    public getUserId(): string {
        return this.userId;
    }

    // Setters
    public setId(id: number): void {
        this.id = id;
    }

    public setProfileName(profileName: string): void {
        this.profileName = profileName
    }

    public setOrigin(origin: string): void {
        this.origin = origin;
    }

    public setLink(link: string): void {
        this.link = link;
    }

    public setUserId(userId: string): void {
        this.userId = userId;
    }

}