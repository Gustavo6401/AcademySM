import IIconValidationStrategy from "../iIconValidationStrategy";

export default class IsGoogleOriginStrategy implements IIconValidationStrategy {
    Validate(origin: string): boolean {
        if (origin === 'Google') {
            return true
        }

        return false
    }
}