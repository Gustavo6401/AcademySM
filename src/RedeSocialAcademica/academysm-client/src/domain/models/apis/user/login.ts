export default class Login {
    private email: string
    private password: string

    constructor(email: string, password: string) {
        this.email = email
        this.password = password
    }

    // Getters
    public getEmail(): string {
        return this.email;
    }

    public getPassword(): string {
        return this.password;
    }

    // Setters
    public setEmail(email: string): void {
        this.email = email;
    }

    public setPassword(password: string): void {
        this.password = password;
    }
}