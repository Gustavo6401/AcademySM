import { CreateUserViewModel } from "../../../../../domain/models/viewModels/createUserViewModel";
import { FormActions } from "../../../infos/createUserFormContextInfos";
import ICreateUserStrategy from "../ICreateUserStrategy";

export default class SetIsActiveStrategy implements ICreateUserStrategy {
    validate(state: CreateUserViewModel, formActions: FormActions, payload: any) {
        if (formActions === FormActions.setIsActive) {
            return { ...state, isActive: payload }
        }

        return state
    }
}