import { CreateUserViewModel } from "../../../../../domain/models/viewModels/createUserViewModel";
import { FormActions } from "../../../infos/createUserFormContextInfos";
import ICreateUserStrategy from "../ICreateUserStrategy";

export default class SetFileStrategy implements ICreateUserStrategy {
    validate(state: CreateUserViewModel, formActions: FormActions, payload: any) {
        if (formActions === FormActions.setFile) {
            return { ...state, file: payload }
        }

        return state
    }
}