import IIconValidationStrategy from "../iIconValidationStrategy";

export default class IsGitlabOriginStrategy implements IIconValidationStrategy {
    Validate(origin: string): boolean {
        if (origin === 'Gitlab') {
            return true
        }

        return false
    }

}