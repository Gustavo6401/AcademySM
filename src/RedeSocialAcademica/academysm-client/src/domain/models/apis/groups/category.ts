export default class Category {
    private id: number
    private name: string
    private mainCategory: string
    private icon: string

    constructor(id: number, name: string, mainCategory: string, icon: string) {
        this.id = id
        this.name = name
        this.mainCategory = mainCategory
        this.icon = icon
    }

    // Getters
    public getId(): number {
        return this.id;
    }

    public getName(): string {
        return this.name;
    }

    public getMainCategory(): string {
        return this.mainCategory;
    }

    public getIcon(): string {
        return this.icon
    }

    // Setters
    public setId(id: number): void {
        this.id = id;
    }

    public setName(name: string): void {
        this.name = name;
    }

    public setMainCategory(mainCategory: string): void {
        this.mainCategory = mainCategory;
    }

    public setIcon(icon: string): void {
        this.icon = icon
    }
}