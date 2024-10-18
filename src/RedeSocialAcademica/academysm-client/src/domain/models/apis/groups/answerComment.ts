export default class AnswerComment {
    private id: number
    private content: string
    private dateCreated: Date
    private answerId: number
    private userId: string

    constructor(id: number, content: string, dateCreated: Date, answerId: number, userId: string) {
        this.id = id
        this.content = content
        this.dateCreated = dateCreated
        this.answerId = answerId
        this.userId = userId
    }

    // Getters
    public getId(): number {
        return this.id;
    }

    public getContent(): string {
        return this.content;
    }

    public getDateCreated(): Date {
        return this.dateCreated;
    }

    public getAnswerId(): number {
        return this.answerId;
    }

    public getUserId(): string {
        return this.userId;
    }

    // Setters
    public setId(id: number): void {
        this.id = id;
    }

    public setContent(content: string): void {
        this.content = content;
    }

    public setDateCreated(dateCreated: Date): void {
        this.dateCreated = dateCreated;
    }

    public setAnswerId(answerId: number): void {
        this.answerId = answerId;
    }

    public setUserId(userId: string): void {
        this.userId = userId;
    }
}