import { CreateUserViewModel } from "../../../../domain/models/viewModels/createUserViewModel";
import { FormActions } from "../../infos/createUserFormContextInfos";

export default interface ICreateUserStrategy {
    validate(state: CreateUserViewModel, formActions: FormActions, payload: any)
}