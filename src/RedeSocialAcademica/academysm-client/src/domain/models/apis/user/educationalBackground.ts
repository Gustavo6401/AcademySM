export default class EducationalBackground {
    private id: string
    private course: string
    private educationalDegree: string
    private status: string
    private institution: string
    private courseBegin: Date
    private courseEnd: Date
    private userId: string

    constructor(id: string, course: string, educationalDegree: string, status: string, institution: string,
        courseBegin: Date, courseEnd: Date, userId: string
    ) {
        this.id = id
        this.course = course
        this.educationalDegree = educationalDegree
        this.status = status
        this.institution = institution
        this.courseBegin = courseBegin
        this.courseEnd = courseEnd
        this.userId = userId
    }

    // Getters
    public getId(): string {
        return this.id;
    }

    public getCourse(): string {
        return this.course;
    }

    public getEducationalDegree(): string {
        return this.educationalDegree;
    }

    public getStatus(): string {
        return this.status;
    }

    public getInstitution(): string {
        return this.institution;
    }

    public getCourseBegin(): Date {
        return this.courseBegin;
    }

    public getCourseEnd(): Date {
        return this.courseEnd;
    }

    public getUserId(): string {
        return this.userId
    }

    // Setters
    public setId(id: string): void {
        this.id = id;
    }

    public setCourse(course: string): void {
        this.course = course;
    }

    public setEducationalDegree(educationalDegree: string): void {
        this.educationalDegree = educationalDegree;
    }

    public setStatus(status: string): void {
        this.status = status;
    }

    public setInstitution(institution: string): void {
        this.institution = institution;
    }

    public setCourseBegin(courseBegin: Date): void {
        this.courseBegin = courseBegin;
    }

    public setCourseEnd(courseEnd: Date): void {
        this.courseEnd = courseEnd;
    }

    public setUserId(userId: string): void {
        this.userId = userId
    }
}