export default class Article {
    private id: number
    private title: string
    private writer: string
    private filePath: string
    private yearWrite: number
    private dateCreation: Date
    private groupId: number
    private userId: string

    constructor(id: number, title: string, writer: string, filePath: string, yearWrite: number,
        dateCreation: Date, groupId: number, userId: string
    ) {
        this.id = id
        this.title = title
        this.writer = writer
        this.filePath = filePath
        this.yearWrite = yearWrite
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

    public getWriter(): string {
        return this.writer;
    }

    public getFilePath(): string {
        return this.filePath;
    }

    public getYearWrite(): number {
        return this.yearWrite;
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

    public setWriter(writer: string): void {
        this.writer = writer;
    }

    public setFilePath(filePath: string): void {
        this.filePath = filePath;
    }

    public setYearWrite(yearWrite: number): void {
        this.yearWrite = yearWrite;
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