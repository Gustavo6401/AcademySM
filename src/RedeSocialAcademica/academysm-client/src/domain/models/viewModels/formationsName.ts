export default class FormationsName {
    private id: string
    private nome: string

    constructor(id: string, nome: string) {
        this.id = id
        this.nome = nome
    }

    // Getters
    public getId(): string {
        return this.id;
    }

    public getNome(): string {
        return this.nome;
    }

    // Setters
    public setId(id: string): void {
        this.id = id;
    }

    public setNome(nome: string): void {
        this.nome = nome;
    }
}