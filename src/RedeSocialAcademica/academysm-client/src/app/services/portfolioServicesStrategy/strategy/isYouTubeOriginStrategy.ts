import IIconValidationStrategy from "../iIconValidationStrategy";

export default class IsYouTubeOriginStrategy implements IIconValidationStrategy {
    Validate(origin: string): boolean {
        if (origin === 'YouTube') {
            return true
        }

        return false
    }
}