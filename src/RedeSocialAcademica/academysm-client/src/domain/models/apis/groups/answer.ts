export default class Answer {
    private id: number
    private title: string
    private content: string
    private dateCreation: Date

    constructor(id: number, title: string, content: string, dateCreation: Date) {
        this.id = id
        this.title = title
        this.content = content
        this.dateCreation = dateCreation
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

    public setDateCreation(dateCreation: Date): void {
        this.dateCreation = dateCreation;
    }

}