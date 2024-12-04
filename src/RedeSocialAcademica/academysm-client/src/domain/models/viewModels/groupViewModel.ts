export default class GroupViewModel {
    private groupId: string
    private groupTitle: string
    private groupLevel: string
    private groupCategoryIcon: string

    constructor(groupId: string, groupTitle: string, groupLevel: string, groupCategoryIcon: string) {
        this.groupId = groupId
        this.groupTitle = groupTitle
        this.groupLevel = groupLevel
        this.groupCategoryIcon = groupCategoryIcon
    }

    // Getters
    public getGroupId(): string {
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
    public setGroupId(groupId: string): void {
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