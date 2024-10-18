export default class Announcement {
    private id: number
    private announcementText: string
    private dateAnnouncement: Date
    private groupId: number    

    constructor(id: number, announcementText: string, dateAnnouncement: Date, groupId: number) {
        this.id = id
        this.announcementText = announcementText
        this.dateAnnouncement = dateAnnouncement
        this.groupId = groupId
    }

    // Getters
    public getId(): number {
        return this.id;
    }

    public getAnnouncementText(): string {
        return this.announcementText;
    }

    public getDateAnnouncement(): Date {
        return this.dateAnnouncement;
    }

    // Setters
    public setId(id: number): void {
        this.id = id;
    }

    public setAnnouncementText(announcementText: string): void {
        this.announcementText = announcementText;
    }

    public setDateAnnouncement(dateAnnouncement: Date): void {
        this.dateAnnouncement = dateAnnouncement;
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