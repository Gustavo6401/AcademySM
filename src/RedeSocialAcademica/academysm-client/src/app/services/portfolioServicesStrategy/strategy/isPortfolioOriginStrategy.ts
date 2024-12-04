import IIconValidationStrategy from "../iIconValidationStrategy";

export default class IsPortfolioOriginStrategy implements IIconValidationStrategy {
    Validate(origin: string): boolean {
        if (origin === 'Portf�lio') {
            return true
        }

        return false
    }

}