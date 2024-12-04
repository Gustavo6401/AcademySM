export default class Room {
    private id: string
    private groupId: string
    private roomId: string
    private dateCreation: Date

    constructor(id: string, groupId: string, roomId: string, dateCreation: Date) {
        this.id = id
        this.groupId = groupId
        this.roomId = roomId
        this.dateCreation = dateCreation
    }

    // Getters
    public getId(): string {
        return this.id;
    }

    public getGroupId(): string {
        return this.groupId;
    }

    public getRoomId(): string {
        return this.roomId;
    }

    public getDateCreation(): Date {
        return this.dateCreation;
    }

    // Setters
    public setId(id: string): void {
        this.id = id;
    }

    public setGroupId(groupId: string): void {
        this.groupId = groupId;
    }

    public setRoomId(roomId: string): void {
        this.roomId = roomId;
    }

    public setDateCreation(dateCreation: Date): void {
        this.dateCreation = dateCreation;
    }
}