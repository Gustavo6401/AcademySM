export default class ConversationUsers {
    private id: number
    private conversationRole: string
    private userId: string
    private conversationId: number

    constructor(id: number, conversationRole: string, userId: string, conversationId: number) {
        this.id = id
        this.conversationRole = conversationRole
        this.userId = userId
        this.conversationId = conversationId
    }

    // Getters
    public getId(): number {
        return this.id;
    }

    public getConversationRole(): string {
        return this.conversationRole;
    }

    public getUserId(): string {
        return this.userId;
    }

    public getConversationId(): number {
        return this.conversationId;
    }

    // Setters
    public setId(id: number): void {
        this.id = id;
    }

    public setConversationRole(conversationRole: string): void {
        this.conversationRole = conversationRole;
    }

    public setUserId(userId: string): void {
        this.userId = userId;
    }

    public setConversationId(conversationId: number): void {
        this.conversationId = conversationId;
    }
}