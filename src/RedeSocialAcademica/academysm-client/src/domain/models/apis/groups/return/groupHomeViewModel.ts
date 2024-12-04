import Post from "../post"

export default class GroupHomeViewModel {
    private id: string
    private name: string
    private level: string
    private description: string
    private posts: Array<Post>

    constructor(id: string, name: string, level: string, description: string, posts: Array<Post>) {
        this.id = id
        this.name = name
        this.level = level
        this.description = description
        this.posts = posts
    }

    // Getters
    public getId(): string {
        return this.id;
    }

    public getName(): string {
        return this.name;
    }

    public getLevel(): string {
        return this.level;
    }

    public getDescription(): string {
        return this.description;
    }

    public getPosts(): Array<Post> {
        return this.posts;
    }

    // Setters
    public setId(id: string): void {
        this.id = id;
    }

    public setName(name: string): void {
        this.name = name;
    }

    public setLevel(level: string): void {
        this.level = level;
    }

    public setDescription(description: string): void {
        this.description = description;
    }

    public setPosts(posts: Array<Post>): void {
        this.posts = posts;
    }
}