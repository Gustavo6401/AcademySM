import IMaximumCharacterStrategy from "./maximumCharacterStrategy";

export default class LowerStrategy implements IMaximumCharacterStrategy {
    private lowerChars: string = 'abcdefghijklmnopqrstuvwxyz'

    characterValid(character: string): boolean {
        return this.lowerChars.includes(character)
    }

}