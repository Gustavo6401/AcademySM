export default class CreateGroupViewModel {
    private groupId: number
    private message: string

    constructor(groupId: number, message: string) {
        this.groupId = groupId
        this.message = message
    }

    // Getters
    public getGroupId(): number {
        return this.groupId;
    }

    public getMessage(): string {
        return this.message;
    }

    // Setters
    public setGroupId(groupId: number): void {
        this.groupId = groupId;
    }

    public setMessage(message: string): void {
        this.message = message;
    }
}