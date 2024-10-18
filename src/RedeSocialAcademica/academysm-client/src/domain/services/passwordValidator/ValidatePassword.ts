import Validate from "./allCharacterTypes/Validate"
import LowerStrategy from "./hasMaxFiveCharsOfSameTypeInASequence/lowerStrategy"
import IMaximumCharacterStrategy from "./hasMaxFiveCharsOfSameTypeInASequence/maximumCharacterStrategy"
import NumberStrategy from "./hasMaxFiveCharsOfSameTypeInASequence/numberStrategy"
import SymbolsStrategy from "./hasMaxFiveCharsOfSameTypeInASequence/symbolsStrategy"
import UpperStrategy from "./hasMaxFiveCharsOfSameTypeInASequence/upperStrategy"

export default function passwordValidator(password: string): boolean {
    var sixteenCharacters: boolean = hasSixteenCharacters(password)

    if (sixteenCharacters !== true) {
        return false
    }

    var allCharTypes: boolean = containsAllCharacterTypes(password)

    if (allCharTypes !== true) {
        return false
    }

    var fiveCharsInARow: boolean = containsFiveCharsOfSameType(password)

    if(fiveCharsInARow !== true) {
        return false
    }

    return true
}

function hasSixteenCharacters(password: string): boolean {
    if (password.length <= 16) {
        return false
    }

    return true
}

function containsAllCharacterTypes(password: string): boolean {
    var validate: Validate = new Validate()
    var isValid: boolean = validate.IsValid(password)

    return isValid
}

function containsFiveCharsOfSameType(password: string): boolean {
    const mapValidValues: Map<string, IMaximumCharacterStrategy> = new Map<string, IMaximumCharacterStrategy>([
        ['Lower', new LowerStrategy()],
        ['Upper', new UpperStrategy()],
        ['Number', new NumberStrategy()],
        ['Symbol', new SymbolsStrategy()]
    ])

    var type: string = ''
    var qtd: number = 0

    var passwordArray: Array<string> = password.split('')

    passwordArray.forEach((char: string) => {
        for (const [key, value] of mapValidValues.entries()) {
            if (value.characterValid(char)) {
                if (type === key) {
                    qtd = qtd + 1

                    if (qtd == 4) {
                        return false
                    }
                } else {
                    type = key
                    qtd = 1
                }
                break
            }
        }
    })

    return true
}