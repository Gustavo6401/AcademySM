export default class PortfolioCourses {
    private courseId: string
    private name: string

    constructor(courseId: string, name: string) {
        this.courseId = courseId
        this.name = name
    }

    // Getters
    public getCourseId(): string {
        return this.courseId;
    }

    public getName(): string {
        return this.name;
    }

    // Setters
    public setCourseId(courseId: string): void {
        this.courseId = courseId;
    }

    public setName(name: string): void {
        this.name = name;
    }
}