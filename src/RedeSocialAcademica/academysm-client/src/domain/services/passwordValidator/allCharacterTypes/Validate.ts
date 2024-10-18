import HasLowerCaseStrategy from "./strategy/HasLowerCaseStrategy";
import HasNumberStrategy from "./strategy/HasNumberStrategy";
import HasSymbolStrategy from "./strategy/HasSymbolStrategy";
import HasUpperCaseStrategy from "./strategy/HasUpperCaseStrategy";
import IValidationStrategy from "./strategy/IValidationStrategy";

export default class Validate {
    IsValid(senha: string): boolean {
        var strategies: IValidationStrategy[] = new Array()
        strategies.push(new HasLowerCaseStrategy())
        strategies.push(new HasUpperCaseStrategy())
        strategies.push(new HasNumberStrategy())
        strategies.push(new HasSymbolStrategy())

        strategies.forEach((strategy) => {
            var result: boolean = strategy.Validate(senha)

            if (result === false) {
                return false
            }
        })

        return true
    }
}