export default class GroupsUsers {
    private id: number
    private role: string
    private userId: string
    private groupId: number

    constructor(id: number, role: string, userId: string, groupId: number) {
        this.id = id
        this.role = role
        this.userId = userId
        this.groupId = groupId
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

    public getGroupId(): number {
        return this.groupId;
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

    public setGroupId(groupId: number): void {
        this.groupId = groupId;
    }
}