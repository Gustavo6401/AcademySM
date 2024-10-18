import IValidationStrategy from "./IValidationStrategy";

export default class HasUpperCaseStrategy implements IValidationStrategy {
    Validate(senha: string): boolean {
        if (Array.from(senha).some(
            // Verifies whether the password has some characters.
            char => char.toLowerCase() !== char.toUpperCase()
                // Verifies whether the password is an UpperCase.
                && char === char.toUpperCase()
        )) {
            // If we have a lowerCase, this algorithm will return true.
            return true
        }

        return false
    }
}