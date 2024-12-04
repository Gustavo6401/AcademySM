import { CreateUserViewModel } from "../../../../../domain/models/viewModels/createUserViewModel";
import { FormActions } from "../../../infos/createUserFormContextInfos";
import ICreateUserStrategy from "../ICreateUserStrategy";

export default class SetPasswordErrorsStrategy implements ICreateUserStrategy {
    validate(state: CreateUserViewModel, formActions: FormActions, payload: any) {
        if (formActions === FormActions.setPasswordErrors) {
            return { ...state, passwordErrors: payload }
        }

        return state
    }
}