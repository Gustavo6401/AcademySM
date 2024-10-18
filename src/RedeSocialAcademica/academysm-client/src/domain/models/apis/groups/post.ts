export default class Post {
    private id: number
    private title: string
    private dateCreation: Date
    private content: string
    private groupId: number
    private userId: string

    constructor(id: number, title: string, dateCreation: Date, content: string, groupId: number, userId: string) {
        this.id = id
        this.title = title
        this.dateCreation = dateCreation
        this.content = content
        this.groupId = groupId
        this.userId = userId
    }

    // Getters
    public getId(): number {
        return this.id;
    }

    public getTitle(): string {
        return this.title;
    }

    public getDateCreation(): Date {
        return this.dateCreation;
    }

    public getContent(): string {
        return this.content;
    }

    // Setters
    public setId(id: number): void {
        this.id = id;
    }

    public setTitle(title: string): void {
        this.title = title;
    }

    public setDateCreation(dateCreation: Date): void {
        this.dateCreation = dateCreation;
    }

    public setContent(content: string): void {
        this.content = content;
    }

    // Getters
    public getGroupId(): number {
        return this.groupId;
    }

    public getUserId(): string {
        return this.userId;
    }

    // Setters
    public setGroupId(groupId: number): void {
        this.groupId = groupId;
    }

    public setUserId(userId: string): void {
        this.userId = userId;
    }
}