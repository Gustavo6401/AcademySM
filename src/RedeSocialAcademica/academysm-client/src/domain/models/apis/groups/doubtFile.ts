export default class DoubtFile {
    private id: number
    private filePath: string
    private doubtId: number

    constructor(id: number, filePath: string, doubtId: number) {
        this.id = id
        this.filePath = filePath
        this.doubtId = doubtId
    }

    // Getters
    public getId(): number {
        return this.id;
    }

    public getFilePath(): string {
        return this.filePath;
    }

    public getDoubtId(): number {
        return this.doubtId;
    }

    // Setters
    public setId(id: number): void {
        this.id = id;
    }

    public setFilePath(filePath: string): void {
        this.filePath = filePath;
    }

    public setDoubtId(doubtId: number): void {
        this.doubtId = doubtId;
    }
}