export default class Conversation {
    private id: number
    private title: string

    constructor(id: number, title: string) {
        this.id = id
        this.title = title
    }

    // Getters
    public getId(): number {
        return this.id;
    }

    public getTitle(): string {
        return this.title;
    }

    // Setters
    public setId(id: number): void {
        this.id = id;
    }

    public setTitle(title: string): void {
        this.title = title;
    }
}