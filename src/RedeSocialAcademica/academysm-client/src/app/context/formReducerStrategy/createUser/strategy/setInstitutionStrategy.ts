import { CreateUserViewModel } from "../../../../../domain/models/viewModels/createUserViewModel";
import { FormActions } from "../../../infos/createUserFormContextInfos";
import ICreateUserStrategy from "../ICreateUserStrategy";

export default class SetInstitutionStrategy implements ICreateUserStrategy {
    validate(state: CreateUserViewModel, formActions: FormActions, payload: any) {
        if (formActions === FormActions.setInstitution) {
            return { ...state, institution: payload }
        }

        return state
    }
}