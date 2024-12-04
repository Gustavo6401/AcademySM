export default class GroupsUsers {
    private id: number
    private role: string
    private userId: string
    private publicGroupId: string

    constructor(id: number, role: string, userId: string, publicGroupId: string) {
        this.id = id
        this.role = role
        this.userId = userId
        this.publicGroupId = publicGroupId
    }

    // Getters
    public getId(): number {
        return this.id;
    }

    public getRole(): string {
        return this.role;
    }

    public getUserId(): string {
        return this.userId;
    }

    public getPublicGroupId(): string {
        return this.publicGroupId;
    }

    // Setters
    public setId(id: number): void {
        this.id = id;
    }

    public setRole(role: string): void {
        this.role = role;
    }

    public setUserId(userId: string): void {
        this.userId = userId;
    }

    public setGroupId(publicGroupId: string): void {
        this.publicGroupId = publicGroupId;
    }
}