export default class CreateGroupViewModel {
    private groupId: string
    private message: string

    constructor(groupId: string, message: string) {
        this.groupId = groupId
        this.message = message
    }

    // Getters
    public getGroupId(): string {
        return this.groupId;
    }

    public getMessage(): string {
        return this.message;
    }

    // Setters
    public setGroupId(groupId: string): void {
        this.groupId = groupId;
    }

    public setMessage(message: string): void {
        this.message = message;
    }
}