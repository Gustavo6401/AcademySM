export default class DoubtVote {
    private id: number
    private vote: string
    private dateVote: Date
    private userId: string
    private doubtId: number

    constructor(id: number, vote: string, dateVote: Date, userId: string, doubtId: number) {
        this.id = id
        this.vote = vote
        this.dateVote = dateVote
        this.userId = userId
        this.doubtId = doubtId
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

    public getUserId(): string {
        return this.userId;
    }

    public getDoubtId(): number {
        return this.doubtId;
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

    public setUserId(userId: string): void {
        this.userId = userId;
    }

    public setDoubtId(doubtId: number): void {
        this.doubtId = doubtId;
    }
}