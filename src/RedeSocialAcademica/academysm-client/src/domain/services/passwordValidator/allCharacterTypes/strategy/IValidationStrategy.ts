export default interface IValidationStrategy {
    Validate(senha: string): boolean
}