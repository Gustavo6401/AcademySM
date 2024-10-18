import IValidationStrategy from "./IValidationStrategy";

export default class HasNumberStrategy implements IValidationStrategy {
    Validate(senha: string): boolean {
        // Verifies whether the password has numbers.
        // This programming language is a 💩💩💩
        if (Array.from(senha).some(char => char >= '0' && char <= '9')) {
            return true
        }

        return false
    }

}