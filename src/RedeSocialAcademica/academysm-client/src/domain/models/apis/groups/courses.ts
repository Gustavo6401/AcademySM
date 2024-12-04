export default class Courses {
    private id: number
    private name: string
    private level: string
    private tutor: string
    private description: string
    private isPublic: boolean
    private publicId: string

    constructor(id: number, name: string, level: string, tutor: string, description: string, isPublic: boolean,
        publicId: string)
    {
        this.id = id
        this.name = name
        this.level = level
        this.tutor = tutor
        this.description = description
        this.isPublic = isPublic
        this.publicId = publicId
    }
    // Getters
    public getId(): number {
        return this.id;
    }

    public getName(): string {
        return this.name;
    }

    public getLevel(): string {
        return this.level;
    }

    public getTutor(): string {
        return this.tutor;
    }

    public getDescription(): string {
        return this.description;
    }

    public getIsPublic(): boolean {
        return this.isPublic
    }

    public getPublicId(): string {
        return this.publicId
    }

    // Setters
    public setId(id: number): void {
        this.id = id;
    }

    public setName(name: string): void {
        this.name = name;
    }

    public setLevel(level: string): void {
        this.level = level;
    }

    public setTutor(tutor: string): void {
        this.tutor = tutor;
    }

    public setDescription(description: string): void {
        this.description = description;
    }

    public setIsPublic(isPublic: boolean): void {
        this.isPublic = isPublic
    }

    public setPublicId(publicId: string): void {
        this.publicId = publicId
    }
}