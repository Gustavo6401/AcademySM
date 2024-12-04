import IIconValidationStrategy from "../iIconValidationStrategy";

export default class IsLinkedinOriginStrategy implements IIconValidationStrategy {
    Validate(origin: string): boolean {
        if (origin === 'Linkedin') {
            return true
        }

        return false
    }
}