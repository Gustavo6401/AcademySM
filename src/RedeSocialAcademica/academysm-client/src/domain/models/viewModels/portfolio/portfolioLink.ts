export default class PortfolioLink {
    private id: string
    private name: string // Name of profile.
    private origin: string
    private link: string

    constructor(id: string, name: string, origin: string, link: string) {
        this.id = id
        this.name = name
        this.origin = origin
        this.link = link
    }

    // Getters
    public getId(): string {
        return this.id;
    }

    public getName(): string {
        return this.name
    }

    public getOrigin(): string {
        return this.origin;
    }

    public getLink(): string {
        return this.link;
    }

    // Setters
    public setId(id: string): void {
        this.id = id;
    }

    public setName(name: string): void {
        this.name = name
    }

    public setOrigin(origin: string): void {
        this.origin = origin;
    }

    public setLink(link: string): void {
        this.link = link;
    }
}