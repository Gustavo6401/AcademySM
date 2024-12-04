import IIconValidationStrategy from "../iIconValidationStrategy";

export default class IsInstagramOriginStrategy implements IIconValidationStrategy {
    Validate(origin: string): boolean {
        if (origin === 'Instagram') {
            return true
        }

        return false
    }
}