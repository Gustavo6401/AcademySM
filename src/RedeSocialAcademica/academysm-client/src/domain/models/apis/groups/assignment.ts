export default class Assignment {
    private id: number
    private title: string
    private dateCreation: Date
    private dueDate: Date
    private noteValue: number
    private groupId: number    

    constructor(id: number, title: string, dateCreation: Date, dueDate: Date, noteValue: number, groupId: number) {
        this.id = id
        this.title = title
        this.dateCreation = dateCreation
        this.dueDate = dueDate
        this.noteValue = noteValue
        this.groupId = groupId
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

    public getDueDate(): Date {
        return this.dueDate;
    }

    public getNoteValue(): number {
        return this.noteValue;
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

    public setDueDate(dueDate: Date): void {
        this.dueDate = dueDate;
    }

    public setNoteValue(noteValue: number): void {
        this.noteValue = noteValue;
    }

    // Getters
    public getGroupId(): number {
        return this.groupId;
    }

    // Setters
    public setGroupId(groupId: number): void {
        this.groupId = groupId;
    }
}