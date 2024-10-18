export default class Comment {
    private id: number
    private content: string
    private dateCreation: Date
    private userId: string
    private postId: number

    constructor(id: number, content: string, dateCreation: Date, userId: string, postId: number) {
        this.id = id
        this.content = content
        this.dateCreation = dateCreation
        this.userId = userId
        this.postId = postId
    }

    // Getters
    public getId(): number {
        return this.id;
    }

    public getContent(): string {
        return this.content;
    }

    public getDateCreation(): Date {
        return this.dateCreation;
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

    public setContent(content: string): void {
        this.content = content;
    }

    public setDateCreation(dateCreation: Date): void {
        this.dateCreation = dateCreation;
    }

    public setUserId(userId: string): void {
        this.userId = userId;
    }

    public setPostId(postId: number): void {
        this.postId = postId;
    }


}