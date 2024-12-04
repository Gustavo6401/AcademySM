import ParticipantGroup from "./participantGroup"
import PortfolioCourses from "./portfolioCourses"
import PortfolioLink from "./portfolioLink"

export default class UserPortfolio {
    private userId: string
    private userName: string
    private curriculum: string
    private profilePic: string
    private courses: Array<PortfolioCourses>
    private links: Array<PortfolioLink>
    private academySMGroups: Array<ParticipantGroup>

    constructor(userId: string, userName: string, curriculum: string, profilePic: string,
        courses: Array<PortfolioCourses>, links: Array<PortfolioLink>, academySMGroups: Array<ParticipantGroup>) {
        this.userId = userId
        this.userName = userName
        this.curriculum = curriculum
        this.profilePic = profilePic
        this.courses = courses
        this.links = links
        this.academySMGroups = academySMGroups
    }

    // Getters
    public getUserId(): string {
        return this.userId;
    }

    public getUserName(): string {
        return this.userName;
    }

    public getCurriculum(): string {
        return this.curriculum;
    }

    public getProfilePic(): string {
        return this.profilePic
    }

    public getCourses(): Array<PortfolioCourses> {
        return this.courses;
    }

    public getLinks(): Array<PortfolioLink> {
        return this.links;
    }

    public getAcademySmGroups(): Array<ParticipantGroup> {
        return this.academySMGroups;
    }

    // Setters
    public setUserId(userId: string): void {
        this.userId = userId;
    }

    public setUserName(userName: string): void {
        this.userName = userName;
    }

    public setCurriculum(curriculum: string): void {
        this.curriculum = curriculum;
    }

    public setProfilePic(profilePic: string): void {
        this.profilePic = profilePic
    }

    public setCourses(courses: Array<PortfolioCourses>): void {
        this.courses = courses;
    }

    public setLinks(links: Array<PortfolioLink>): void {
        this.links = links;
    }

    public setAcademySmGroups(academySmGroups: Array<ParticipantGroup>): void {
        this.academySMGroups = academySmGroups;
    }
}