export default class AnswerVote {
    private id: number
    private vote: string
    private dateVote: Date
    private answerId: number
    private userId: string

    constructor(id: number, vote: string, dateVote: Date, answerId: number, userId: string) {
        this.id = id
        this.vote = vote
        this.dateVote = dateVote
        this.answerId = answerId
        this.userId = userId
    }

    // Getters
    public getId(): number {
        return this.id;
    }

    public getVote(): string {
        return this.vote;
    }

    public getDateVote(): Date {
        return this.dateVote;
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

    public setVote(vote: string): void {
        this.vote = vote;
    }

    public setDateVote(dateVote: Date): void {
        this.dateVote = dateVote;
    }

    public setAnswerId(answerId: number): void {
        this.answerId = answerId;
    }

    public setUserId(userId: string): void {
        this.userId = userId;
    }
}