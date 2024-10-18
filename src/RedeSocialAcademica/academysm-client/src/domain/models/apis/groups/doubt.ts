export default class Doubt {
    private id: number
    private title: string
    private content: string
    private status: string
    private dateCreation: Date
    private groupId: number
    private userId: string

    constructor(id: number, title: string, content: string, status: string, dateCreation: Date, groupId: number,
        userId: string
    ) {
        this.id = id
        this.title = title
        this.content = content
        this.status = status
        this.dateCreation = dateCreation
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

    public getContent(): string {
        return this.content;
    }

    public getStatus(): string {
        return this.status;
    }

    public getDateCreation(): Date {
        return this.dateCreation;
    }

    // Setters
    public setId(id: number): void {
        this.id = id;
    }

    public setTitle(title: string): void {
        this.title = title;
    }

    public setContent(content: string): void {
        this.content = content;
    }

    public setStatus(status: string): void {
        this.status = status;
    }

    public setDateCreation(dateCreation: Date): void {
        this.dateCreation = dateCreation;
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