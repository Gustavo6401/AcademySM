import IIconValidationStrategy from "../iIconValidationStrategy";

export default class IsBingOriginStrategy implements IIconValidationStrategy {
    Validate(origin: string): boolean {
        if (origin === 'Bing') {
            return true
        }

        return false
    }

}