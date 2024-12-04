import { ChangeEvent } from "react";
import { Action, FormActions } from "../../../context/infos/createUserFormContextInfos";

export default function HandleStringChanged(e: ChangeEvent<HTMLInputElement>, typeAction: FormActions, dispatch: React.Dispatch<Action>) {
    dispatch({
        type: typeAction,
        payload: e.target.value
    })
}

export function HandleStringSelectChanged(e: ChangeEvent<HTMLSelectElement>, typeAction: FormActions, dispatch: React.Dispatch<Action>) {
    dispatch({
        type: typeAction,
        payload: e.target.value
    })
}

export function HandleStringTextAreaChanged(e: ChangeEvent<HTMLTextAreaElement>, typeAction: FormActions, dispatch: React.Dispatch<Action>) {
    dispatch({
        type: typeAction,
        payload: e.target.value
    })
}

export function HandleNumberChanged(e: ChangeEvent<HTMLInputElement>, typeAction: FormActions, dispatch: React.Dispatch<Action>) {
    dispatch({
        type: typeAction,
        payload: e.target.valueAsNumber
    })
}

export function HandleBooleanChanged(e: ChangeEvent<HTMLInputElement>, typeAction: FormActions, dispatch: React.Dispatch<Action>) {
    dispatch({
        type: typeAction,
        payload: e.target.checked
    })
}

export function HandleDateChanged(e: ChangeEvent<HTMLInputElement>, typeAction: FormActions, dispatch: React.Dispatch<Action>) {
    dispatch({
        type: typeAction,
        payload: e.target.valueAsDate
    })
}

// Code Generated with ChatGPT.
export function FormatDate(date: Date): string {
    return date.toISOString().split('T')[0]; // Retorna apenas YYYY-MM-DD
}

export function ConvertBoolean(response: boolean): string {
    if (response !== true) {
        return 'Não.'
    }

    return 'Sim.'
}

export function VerifyWhetherStringIsEmpty(word: string): string {
    if (word === '') {
        return 'N/A'
    }

    return word
}

export function HandleProfilePicChange(e: ChangeEvent<HTMLInputElement>, typeActions: FormActions, dispatch: React.Dispatch<Action>) {
    let file: File = e.target.files?.[0]

    dispatch({
        type: typeActions,
        payload: file.name
    })

    dispatch({
        type: FormActions.setFile,
        payload: file
    })
}