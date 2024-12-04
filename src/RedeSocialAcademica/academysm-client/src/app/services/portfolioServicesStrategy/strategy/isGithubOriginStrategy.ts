import IIconValidationStrategy from "../iIconValidationStrategy";

export default class IsGithubOriginStrategy implements IIconValidationStrategy {
    Validate(origin: string): boolean {
        if (origin === 'Github') {
            return true
        }

        return false
    }
}