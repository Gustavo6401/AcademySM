import { CreateUserViewModel } from "../../../../../domain/models/viewModels/createUserViewModel";
import { FormActions } from "../../../infos/createUserFormContextInfos";
import ICreateUserStrategy from "../ICreateUserStrategy";

export default class SetEducationalDegreeStrategy implements ICreateUserStrategy {
    validate(state: CreateUserViewModel, formActions: FormActions, payload: any) {
        if (formActions === FormActions.setEducationalDegree) {
            return { ...state, educationalDegree: payload }
        }

        return state
    }
}