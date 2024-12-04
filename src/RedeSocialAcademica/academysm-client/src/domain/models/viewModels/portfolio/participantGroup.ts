export default class ParticipantGroup {
    private groupId: number
    private groupName: string
    private role: string
    private categoryIcon: string

    constructor(groupId: number, groupName: string, role: string, categoryIcon: string) {
        this.groupId = groupId
        this.groupName = groupName
        this.role = role
        this.categoryIcon = categoryIcon
    }

    // Getters
    public getGroupId(): number {
        return this.groupId;
    }

    public getGroupName(): string {
        return this.groupName;
    }

    public getRole(): string {
        return this.role;
    }

    public getCategoryIcon(): string {
        return this.categoryIcon;
    }

    // Setters
    public setGroupId(groupId: number): void {
        this.groupId = groupId;
    }

    public setGroupName(groupName: string): void {
        this.groupName = groupName;
    }

    public setRole(role: string): void {
        this.role = role;
    }

    public setCategoryIcon(categoryIcon: string): void {
        this.categoryIcon = categoryIcon;
    }
}