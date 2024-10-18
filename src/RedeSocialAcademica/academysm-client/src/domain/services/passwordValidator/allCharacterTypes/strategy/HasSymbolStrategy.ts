import IValidationStrategy from "./IValidationStrategy";

export default class HasSymbolStrategy implements IValidationStrategy {
    Validate(senha: string): boolean {
        var symbols: string = '!@#$%¨&*()£¢¬/?°\\|\":;.,><^~`´}]º{{ª=+§-_\''

        if (Array.from(senha)
            .some(char => symbols
                .includes(char))) {
                    return true
        }

        return false
    }

}