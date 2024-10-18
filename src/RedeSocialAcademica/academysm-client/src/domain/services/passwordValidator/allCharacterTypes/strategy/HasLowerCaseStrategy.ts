import IValidationStrategy from "./IValidationStrategy";

export default class HasLowerCaseStrategy implements IValidationStrategy {
    Validate(senha: string): boolean {
        if (Array.from(senha).some(
            // Verifies whether the password has some characters.
            char => char.toLowerCase() !== char.toUpperCase()
                // Verifies whether the password is a LowerCase.
                && char === char.toLowerCase()
        )) {
            // If we have a lowerCase, this algorithm will return true.
            return true
        }

        return false
    }
}