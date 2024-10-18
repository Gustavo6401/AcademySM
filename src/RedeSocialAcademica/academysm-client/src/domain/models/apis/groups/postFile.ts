export default class PostFile {
    private id: number
    private relativePath: string
    private postId: number

    constructor(id: number, relativePath: string, postId: number) {
        this.id = id
        this.relativePath = relativePath
        this.postId = postId
    }

    // Getters
    public getId(): number {
        return this.id;
    }

    public getRelativePath(): string {
        return this.relativePath;
    }

    public getPostId(): number {
        return this.postId;
    }

    // Setters
    public setId(id: number): void {
        this.id = id;
    }

    public setRelativePath(relativePath: string): void {
        this.relativePath = relativePath;
    }

    public setPostId(postId: number): void {
        this.postId = postId;
    }
}