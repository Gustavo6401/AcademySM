export default class PostVote {
    private id: number
    private vote: string
    private voteDate: Date
    private userId: string
    private postId: number

    constructor(id: number, vote: string, voteDate: Date, userId: string, postId: number) {
        this.id = id
        this.vote = vote
        this.voteDate = voteDate
        this.userId = userId
        this.postId = postId
    }

    // Getters
    public getId(): number {
        return this.id;
    }

    public getVote(): string {
        return this.vote;
    }

    public getVoteDate(): Date {
        return this.voteDate;
    }

    public getUserId(): string {
        return this.userId;
    }

    public getPostId(): number {
        return this.postId;
    }

    // Setters
    public setId(id: number): void {
        this.id = id;
    }

    public setVote(vote: string): void {
        this.vote = vote;
    }

    public setVoteDate(voteDate: Date): void {
        this.voteDate = voteDate;
    }

    public setUserId(userId: string): void {
        this.userId = userId;
    }

    public setPostId(postId: number): void {
        this.postId = postId;
    }
}