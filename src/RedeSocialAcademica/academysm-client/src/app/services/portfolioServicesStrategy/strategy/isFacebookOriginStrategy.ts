import IIconValidationStrategy from "../iIconValidationStrategy";

export default class IsFacebookOriginStrategy implements IIconValidationStrategy {
    Validate(origin: string): boolean {
        if (origin === 'Facebook') {
            return true
        }

        return false
    }

}