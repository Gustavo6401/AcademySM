export default class GroupViewModel {
    private groupId: number
    private groupTitle: string
    private groupLevel: string
    private groupCategoryIcon: string

    constructor(groupId: number, groupTitle: string, groupLevel: string, groupCategoryIcon: string) {
        this.groupId = groupId
        this.groupTitle = groupTitle
        this.groupLevel = groupLevel
        this.groupCategoryIcon = groupCategoryIcon
    }

    // Getters
    public getGroupId(): number {
        return this.groupId;
    }

    public getGroupTitle(): string {
        return this.groupTitle;
    }

    public getGroupLevel(): string {
        return this.groupLevel;
    }

    public getGroupCategoryIcon(): string {
        return this.groupCategoryIcon;
    }

    // Setters
    public setGroupId(groupId: number): void {
        this.groupId = groupId;
    }

    public setGroupTitle(groupTitle: string): void {
        this.groupTitle = groupTitle;
    }

    public setGroupLevel(groupLevel: string): void {
        this.groupLevel = groupLevel;
    }

    public setGroupCategoryIcon(groupCategoryIcon: string): void {
        this.groupCategoryIcon = groupCategoryIcon;
    }
}