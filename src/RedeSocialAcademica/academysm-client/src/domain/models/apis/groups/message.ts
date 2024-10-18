export default class Message {
    private id: number
    private content: string
    private dateSent: Date
    private userId: string
    private conversationId: number

    constructor(id: number, content: string, dateSent: Date, userId: string, conversationId: number) {
        this.id = id
        this.content = content
        this.dateSent = dateSent
        this.userId = userId
        this.conversationId = conversationId
    }

    // Getters
    public getId(): number {
        return this.id;
    }

    public getContent(): string {
        return this.content;
    }

    public getDateSent(): Date {
        return this.dateSent;
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

    public setContent(content: string): void {
        this.content = content;
    }

    public setDateSent(dateSent: Date): void {
        this.dateSent = dateSent;
    }

    public setUserId(userId: string): void {
        this.userId = userId;
    }

    public setConversationId(conversationId: number): void {
        this.conversationId = conversationId;
    }
}