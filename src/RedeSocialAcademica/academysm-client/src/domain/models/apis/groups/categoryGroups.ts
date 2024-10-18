export default class CategoryGroups {
    private categoryId: number
    private groupId: number

    constructor(categoryId: number, groupId: number) {
        this.categoryId = categoryId
        this.groupId = groupId
    }

    // Getters
    public getCategoryId(): number {
        return this.categoryId;
    }

    public getGroupId(): number {
        return this.groupId;
    }

    // Setters
    public setCategoryId(categoryId: number): void {
        this.categoryId = categoryId;
    }

    public setGroupId(groupId: number): void {
        this.groupId = groupId;
    }


}