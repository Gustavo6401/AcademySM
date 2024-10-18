export default class AssignmentFile {
    private id: number
    private path: string
    private assignmentId: number

    constructor(id: number, path: string, assignmentId: number) {
        this.id = id
        this.path = path
        this.assignmentId = assignmentId
    }

    // Getters
    public getId(): number {
        return this.id;
    }

    public getPath(): string {
        return this.path;
    }

    public getAssignmentId(): number {
        return this.assignmentId;
    }

    // Setters
    public setId(id: number): void {
        this.id = id;
    }

    public setPath(path: string): void {
        this.path = path;
    }

    public setAssignmentId(assignmentId: number): void {
        this.assignmentId = assignmentId;
    }
}