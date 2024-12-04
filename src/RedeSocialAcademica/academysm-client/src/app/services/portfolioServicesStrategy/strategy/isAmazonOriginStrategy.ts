import IIconValidationStrategy from "../iIconValidationStrategy";

export default class IsAmazonOriginStrategy implements IIconValidationStrategy {
    Validate(origin: string): boolean {
        if (origin === 'Amazon') {
            return true
        }

        return false
    }

}