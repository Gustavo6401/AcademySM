export default class UserCreateResponse {
    private message: string
    private userId: string

    constructor(message: string, userId: string) {
        this.message = message
        this.userId = userId
    }

    // Getters
    public getMessage(): string {
        return this.message;
    }

    public getUserId(): string {
        return this.userId;
    }

    // Setters
    public setMessage(response: string): void {
        this.message = response;
    }

    public setUserId(userId: string): void {
        this.userId = userId;
    }
}