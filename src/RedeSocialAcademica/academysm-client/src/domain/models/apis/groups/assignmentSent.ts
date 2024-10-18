export default class AssignmentSent {
    private id: number
    private dateSent: Date
    private filePath: string
    private rate: number
    private assignmentId: number
    private userId: string

    constructor(id: number, dateSent: Date, filePath: string, rate: number, assignmentId: number, userId: string) {
        this.id = id
        this.dateSent = dateSent
        this.filePath = filePath
        this.rate = rate
        this.assignmentId = assignmentId
        this.userId = userId
    }

    // Getters
    public getId(): number {
        return this.id;
    }

    public getDateSent(): Date {
        return this.dateSent;
    }

    public getFilePath(): string {
        return this.filePath;
    }

    public getRate(): number {
        return this.rate;
    }

    public getAssignmentId(): number {
        return this.assignmentId
    }

    public getUserId(): string {
        return this.userId
    }

    // Setters
    public setId(id: number): void {
        this.id = id;
    }

    public setDateSent(dateSent: Date): void {
        this.dateSent = dateSent;
    }

    public setFilePath(filePath: string): void {
        this.filePath = filePath;
    }

    public setRate(rate: number): void {
        this.rate = rate;
    }

    public setAssignmentId(assignmentId: number): void {
        this.assignmentId = assignmentId
    }

    public setUserId(userId: string): void {
        this.userId = userId
    }
}