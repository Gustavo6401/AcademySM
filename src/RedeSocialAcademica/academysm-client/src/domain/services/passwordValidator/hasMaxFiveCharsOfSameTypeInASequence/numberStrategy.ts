import IMaximumCharacterStrategy from "./maximumCharacterStrategy";

export default class NumberStrategy implements IMaximumCharacterStrategy {
    private numbers: string = '0123456789'

    characterValid(character: string): boolean {
        return this.numbers.includes(character)
    }

}